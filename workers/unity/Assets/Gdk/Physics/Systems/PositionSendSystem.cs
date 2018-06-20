using Generated.Improbable;
using Improbable.Gdk.Core;
using Unity.Entities;
using UnityEngine;

namespace Improbable.Gdk.TransformSynchronization
{
    public class PositionSendSystem : CustomSpatialOSSendSystem<SpatialOSPosition>
    {
        public struct PositionData
        {
            public int Length;
            public ComponentDataArray<SpatialOSPosition> Position;
            public ComponentDataArray<Authoritative<SpatialOSPosition>> PositionAuthority;
            public ComponentDataArray<SpatialEntityId> SpatialEntityIds;
        }

        [Inject] private PositionData positionData;

        // Number of position sends per second.
        private const float SendRate = 1.0f;

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

            for (var i = 0; i < positionData.Length; i++)
            {
                var component = positionData.Position[i];

                if (component.DirtyBit != true)
                {
                    continue;
                }

                var entityId = positionData.SpatialEntityIds[i].EntityId;
                var update = new global::Improbable.Position.Update();
                update.SetCoords(global::Generated.Improbable.Coordinates.ToSpatial(component.Coords));
                Generated.Improbable.Position.Translation.SendComponentUpdate(worker.Connection, entityId, update);

                component.DirtyBit = false;
                positionData.Position[i] = component;
            }
        }
    }
}
