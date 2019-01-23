using Improbable.Gdk.Core;
using Improbable.Gdk.ReactiveComponents;
using Improbable.Transform;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;

#region Diagnostic control

#pragma warning disable 649
#pragma warning disable 169
// ReSharper disable UnassignedReadonlyField
// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

#endregion


namespace Improbable.Gdk.TransformSynchronization
{
    [DisableAutoCreation]
    [UpdateInGroup(typeof(SpatialOSUpdateGroup))]
    public class InterpolateTransformSystem : ComponentSystem
    {
        private struct Data
        {
            public readonly int Length;
            public BufferArray<BufferedTransform> TransformBuffer;
            public ComponentDataArray<DeferredUpdateTransform> LastTransformValue;
            [ReadOnly] public SharedComponentDataArray<InterpolationConfig> Config;
            [ReadOnly] public ComponentDataArray<TransformInternal.Component> CurrentTransform;
            [ReadOnly] public ComponentDataArray<NotAuthoritative<TransformInternal.Component>> DenotesNotAuthoritative;
            [ReadOnly] public ComponentDataArray<SpatialEntityId> EntityIds;
        }

        [Inject] private Data data;
        [Inject] private ComponentUpdateSystem updateSystem;

        protected override void OnUpdate()
        {
            for (int i = 0; i < data.Length; ++i)
            {
                var config = data.Config[i];
                var transformBuffer = data.TransformBuffer[i];
                var lastTransformApplied = data.LastTransformValue[i].Transform;

                if (transformBuffer.Length >= config.MaxLoadMatchedBufferSize)
                {
                    transformBuffer.Clear();
                }

                if (transformBuffer.Length == 0)
                {
                    var currentTransformComponent = data.CurrentTransform[i];
                    if (currentTransformComponent.PhysicsTick <= lastTransformApplied.PhysicsTick)
                    {
                        continue;
                    }

                    data.LastTransformValue[i] = new DeferredUpdateTransform
                    {
                        Transform = currentTransformComponent
                    };

                    var transformToInterpolateTo = ToBufferedTransform(currentTransformComponent);

                    uint ticksToFill = math.max((uint) config.TargetBufferSize, 1);

                    if (ticksToFill > 1)
                    {
                        var transformToInterpolateFrom = ToBufferedTransformAtTick(lastTransformApplied,
                            transformToInterpolateTo.PhysicsTick - ticksToFill + 1);

                        transformBuffer.Add(transformToInterpolateFrom);

                        for (uint j = 0; j < ticksToFill - 2; ++j)
                        {
                            transformBuffer.Add(InterpolateValues(transformToInterpolateFrom, transformToInterpolateTo,
                                j + 1));
                        }
                    }

                    transformBuffer.Add(transformToInterpolateTo);
                    continue;
                }

                var updates =
                    updateSystem
                        .GetEntityComponentUpdatesReceived<TransformInternal.Update>(data.EntityIds[i].EntityId);

                for (int j = 0; j < updates.Count; ++j)
                {
                    var update = updates[j].Update;
                    UpdateLastTransfrom(ref lastTransformApplied, update);
                    data.LastTransformValue[i] = new DeferredUpdateTransform
                    {
                        Transform = lastTransformApplied
                    };

                    if (!update.PhysicsTick.HasValue)
                    {
                        continue;
                    }

                    var transformToInterpolateTo = ToBufferedTransform(lastTransformApplied);

                    var transformToInterpolateFrom = transformBuffer[transformBuffer.Length - 1];
                    uint lastTickId = transformToInterpolateFrom.PhysicsTick;

                    // This could go backwards if authority changes quickly between two workers with different loads
                    if (lastTickId >= transformToInterpolateTo.PhysicsTick)
                    {
                        continue;
                    }

                    uint ticksToFill = math.max(transformToInterpolateTo.PhysicsTick - lastTickId, 1);

                    for (uint k = 0; k < ticksToFill - 1; ++k)
                    {
                        transformBuffer.Add(InterpolateValues(transformToInterpolateFrom, transformToInterpolateTo,
                            k + 1));
                    }

                    transformBuffer.Add(transformToInterpolateTo);
                }
            }
        }

        private void UpdateLastTransfrom(ref TransformInternal.Component lastTransform, TransformInternal.Update update)
        {
            if (update.Location.HasValue)
            {
                lastTransform.Location = update.Location.Value;
            }

            if (update.Rotation.HasValue)
            {
                lastTransform.Rotation = update.Rotation.Value;
            }

            if (update.Velocity.HasValue)
            {
                lastTransform.Velocity = update.Velocity.Value;
            }

            if (update.TicksPerSecond.HasValue)
            {
                lastTransform.TicksPerSecond = update.TicksPerSecond.Value;
            }

            if (update.PhysicsTick.HasValue)
            {
                lastTransform.PhysicsTick = update.PhysicsTick.Value;
            }
        }

        private static BufferedTransform ToBufferedTransform(TransformInternal.Component transform)
        {
            return new BufferedTransform
            {
                Position = transform.Location.ToUnityVector3(),
                Velocity = transform.Velocity.ToUnityVector3(),
                Orientation = transform.Rotation.ToUnityQuaternion(),
                PhysicsTick = transform.PhysicsTick
            };
        }

        private static BufferedTransform ToBufferedTransformAtTick(TransformInternal.Component component, uint tick)
        {
            return new BufferedTransform
            {
                Position = component.Location.ToUnityVector3(),
                Velocity = component.Velocity.ToUnityVector3(),
                Orientation = component.Rotation.ToUnityQuaternion(),
                PhysicsTick = tick
            };
        }

        private static BufferedTransform InterpolateValues(BufferedTransform first, BufferedTransform second,
            uint ticksAfterFirst)
        {
            float t = (float) ticksAfterFirst / (float) (second.PhysicsTick - first.PhysicsTick);
            return new BufferedTransform
            {
                Position = Vector3.Lerp(first.Position, second.Position, t),
                Velocity = Vector3.Lerp(first.Velocity, second.Velocity, t),
                Orientation = Quaternion.Slerp(first.Orientation, second.Orientation, t),
                PhysicsTick = first.PhysicsTick + ticksAfterFirst
            };
        }
    }
}
