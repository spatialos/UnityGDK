using Generated.Improbable.Transform;
using Improbable.Gdk.Core;
using Unity.Collections;
using Unity.Entities;

namespace Improbable.Gdk.TransformSynchronization
{
    [DisableAutoCreation]
    [UpdateInGroup(typeof(SpatialOSUpdateGroup))]
    public class ApplyTransformUpdatesSystem : ComponentSystem
    {
        private struct TransformUpdateData
        {
            public readonly int Length;
            [ReadOnly] public ComponentDataArray<Transform.ReceivedUpdates> TransformUpdate;
            public ComponentArray<BufferedTransform> BufferedTransform;
            [ReadOnly] public ComponentDataArray<NotAuthoritative<Transform.Component>> TransformAuthority;
            [ReadOnly] public ComponentDataArray<Transform.Component> Transform;
        }

        [Inject] private TransformUpdateData transformUpdateData;

        protected override void OnUpdate()
        {
            for (var i = 0; i < transformUpdateData.Length; i++)
            {
                var transformUpdates = transformUpdateData.TransformUpdate[i].Updates;
                var lastTransformSnapshot = new SpatialOSTransform();
                var bufferLength = transformUpdateData.BufferedTransform[i].Length;
                if (bufferLength > 0)
                {
                    lastTransformSnapshot = transformUpdateData.BufferedTransform[i][bufferLength - 1].transformUpdate;
                }
                
                foreach (var update in transformUpdates)
                {
                    if (update.Location.HasValue)
                    {
                        lastTransformSnapshot.Location = update.Location.Value;
                    }

                    if (update.Rotation.HasValue)
                    {
                        lastTransformSnapshot.Rotation = update.Rotation.Value;
                    }

                    if (update.Tick.HasValue)
                    {
                        lastTransformSnapshot.Tick = update.Tick.Value;
                    }

                    var bufferedTransform = new BufferedTransform
                    {
                        transformUpdate = lastTransformSnapshot
                    };
                    
                    transformUpdateData.BufferedTransform[i].Add(bufferedTransform);
                }
            }
        }
    }
}
