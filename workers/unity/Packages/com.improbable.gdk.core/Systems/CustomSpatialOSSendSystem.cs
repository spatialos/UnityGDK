using Unity.Entities;
using UnityEngine;

namespace Improbable.Gdk.Core
{
    [UpdateInGroup(typeof(SpatialOSSendGroup.CustomSpatialOSSendGroup))]
    public abstract class CustomSpatialOSSendSystem<T> : ComponentSystem where T : ISpatialComponentData
    {
        private const string LoggerName = "CustomSpatialOSSendSystem";

        private const string CustomReplicationSystemAlreadyExists =
            "Custom Replication System for this component already exists.";

        private SpatialOSSendSystem spatialOSSendSystem;

        protected WorkerBase Worker;

        protected override void OnCreateManager(int capacity)
        {
            base.OnCreateManager(capacity);

            Worker = WorkerRegistry.GetWorkerForWorld(World);

            spatialOSSendSystem = World.GetOrCreateManager<SpatialOSSendSystem>();
            if (!spatialOSSendSystem.TryRegisterCustomReplicationSystem(typeof(T)))
            {
                Worker.View.LogDispatcher.HandleLog(LogType.Error, new LogEvent(CustomReplicationSystemAlreadyExists)
                    .WithField(LoggingUtils.LoggerName, LoggerName)
                    .WithField("ComponentType", typeof(T)));
            }
        }
    }
}
