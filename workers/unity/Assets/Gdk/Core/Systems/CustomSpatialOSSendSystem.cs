using Unity.Entities;
using UnityEngine;

namespace Improbable.Gdk.Core
{
    [UpdateInGroup(typeof(SpatialOSSendGroup.CustomSpatialOSSendGroup))]
    public abstract class CustomSpatialOSSendSystem<T> : ComponentSystem where T : ISpatialComponentData
    {
        private SpatialOSSendSystem spatialOSSendSystem;

        protected WorkerBase worker;

        protected override void OnCreateManager(int capacity)
        {
            base.OnCreateManager(capacity);

            worker = WorkerRegistry.GetWorkerForWorld(World);

            spatialOSSendSystem = World.GetOrCreateManager<SpatialOSSendSystem>();
            if (!spatialOSSendSystem.TryRegisterCustomReplicationSystem(typeof(T)))
            {
                worker.View.LogDispatcher.HandleLog(LogType.Error, new LogEvent(
                        "Custom Replication System for this component already exists.")
                    .WithField("ComponentType", typeof(T)));
            }
        }
    }
}
