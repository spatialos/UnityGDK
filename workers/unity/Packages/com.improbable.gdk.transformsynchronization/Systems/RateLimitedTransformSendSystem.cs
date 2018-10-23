using Improbable.Gdk.Core;
using Improbable.Transform;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Improbable.Gdk.TransformSynchronization
{
    [DisableAutoCreation]
    [UpdateAfter(typeof(DefaultUpdateLatestTransformSystem))]
    [UpdateInGroup(typeof(SpatialOSUpdateGroup))]
    public class RateLimitedTransformSendSystem : ComponentSystem
    {
        private struct Data
        {
            public readonly int Length;
            public ComponentDataArray<TransformInternal.Component> TransformComponent;
            public ComponentDataArray<TicksSinceLastTransformUpdate> TicksSinceLastUpdate;
            public ComponentDataArray<LastTransformSentData> LastTransformSent;
            [ReadOnly] public ComponentDataArray<TransformToSend> TransformToSend;
            [ReadOnly] public SharedComponentDataArray<RateLimitedSendConfig> RateLimitedConfig;

            [ReadOnly] public ComponentDataArray<Authoritative<TransformInternal.Component>> DenotesAuthoritative;
        }

        [Inject] private Data data;
        [Inject] private WorkerSystem worker;
        [Inject] private TickRateEstimationSystem tickRate;

        protected override void OnUpdate()
        {
            for (int i = 0; i < data.Length; ++i)
            {
                var lastTransformSent = data.LastTransformSent[i];
                lastTransformSent.TimeSinceLastUpdate += Time.deltaTime;
                data.LastTransformSent[i] = lastTransformSent;

                if (lastTransformSent.TimeSinceLastUpdate <
                    1.0f / data.RateLimitedConfig[i].MaxTransformUpdateRateHz)
                {
                    continue;
                }

                var transform = data.TransformComponent[i];

                var transformToSend = data.TransformToSend[i];

                var currentTransform = new TransformInternal.Component
                {
                    Location = (transformToSend.Position - worker.Origin).ToImprobableLocation(),
                    Rotation = transformToSend.Orientation.ToImprobableQuaternion(),
                    Velocity = transformToSend.Velocity.ToImprobableVelocity(),
                    PhysicsTick = transform.PhysicsTick + data.TicksSinceLastUpdate[i].NumberOfTicks,
                    TicksPerSecond = tickRate.PhysicsTicksPerRealSecond
                };

                var locationHasChanged = TransformUtils.HasChanged(currentTransform.Location, transform.Location);
                var rotationHasChanged = TransformUtils.HasChanged(currentTransform.Rotation, transform.Rotation);
                var velocityHasChanged = TransformUtils.HasChanged(currentTransform.Velocity, transform.Velocity);
                var physicsTickHasChanged = currentTransform.PhysicsTick == transform.PhysicsTick;
                var ticksPerSecondHasChanged =
                    Mathf.Abs(currentTransform.TicksPerSecond - transform.TicksPerSecond) < Mathf.Epsilon;

                currentTransform.DirtyBits |= locationHasChanged ? TransformInternal.Component.DirtyBitsFlag.Location : TransformInternal.Component.DirtyBitsFlag.None;
                currentTransform.DirtyBits |= rotationHasChanged ? TransformInternal.Component.DirtyBitsFlag.Rotation : TransformInternal.Component.DirtyBitsFlag.None;
                currentTransform.DirtyBits |= velocityHasChanged ? TransformInternal.Component.DirtyBitsFlag.Velocity : TransformInternal.Component.DirtyBitsFlag.None;
                currentTransform.DirtyBits |= physicsTickHasChanged ? TransformInternal.Component.DirtyBitsFlag.PhysicsTick : TransformInternal.Component.DirtyBitsFlag.None;
                currentTransform.DirtyBits |= ticksPerSecondHasChanged ? TransformInternal.Component.DirtyBitsFlag.TicksPerSecond : TransformInternal.Component.DirtyBitsFlag.None;

                if (!locationHasChanged && rotationHasChanged)
                {
                    continue;
                }

                lastTransformSent.TimeSinceLastUpdate = 0.0f;
                lastTransformSent.Transform = transform;
                data.LastTransformSent[i] = lastTransformSent;

                data.TransformComponent[i] = currentTransform;

                data.TicksSinceLastUpdate[i] = new TicksSinceLastTransformUpdate
                {
                    NumberOfTicks = 0
                };
            }
        }
    }
}
