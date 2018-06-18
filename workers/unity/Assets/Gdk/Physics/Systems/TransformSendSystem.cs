using Generated.Improbable.Transform;
using Improbable.Gdk.Core;
using Unity.Entities;
using UnityEngine;

namespace Improbable.Gdk.TransformSynchronization
{
    public class TransformSendSystem : CustomSpatialOSSendSystem<SpatialOSTransform>
    {
        public struct TransformData
        {
            public int Length;
            public ComponentDataArray<SpatialOSTransform> Transforms;
            public ComponentDataArray<Authoritative<SpatialOSTransform>> TransformAuthority;
            public ComponentDataArray<SpatialEntityId> SpatialEntityIds;
        }

        [Inject] private TransformData transformData;

        // Number of transform sends per second.
        private const float SendRate = 30.0f;

        private float timeSinceLastSend = 0.0f;

        protected override void OnUpdate()
        {
            // Send update at SendRate.
            timeSinceLastSend += Time.deltaTime;
            if (timeSinceLastSend < (1.0f / SendRate))
            {
                return;
            }

            timeSinceLastSend = 0.0f;

            for (var i = 0; i < transformData.Length; i++)
            {
                var component = transformData.Transforms[i];

                if (component.DirtyBit != true)
                {
                    continue;
                }

                var entityId = transformData.SpatialEntityIds[i].EntityId;
                var update = new global::Improbable.Transform.Transform.Update();
                update.SetLocation(global::Generated.Improbable.Transform.Location.ToSpatial(component.Location));
                update.SetRotation(global::Generated.Improbable.Transform.Quaternion.ToSpatial(component.Rotation));
                update.SetTick(component.Tick);
                Generated.Improbable.Transform.Transform.Translation.SendComponentUpdate(worker.Connection, entityId,
                    update);

                component.DirtyBit = false;
                transformData.Transforms[i] = component;
            }
        }
    }
}
