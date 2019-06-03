using Improbable.Gdk.Core;
using Improbable.Gdk.PlayerLifecycle;
using Unity.Entities;
using UnityEngine;

namespace Improbable.Gdk.PlayerLifecycle
{
    [DisableAutoCreation]
    [UpdateBefore(typeof(SpatialOSUpdateGroup))]
    public class SendPlayerHeartbeatRequestSystem : ComponentSystem
    {
        private float timeOfNextHeartbeat = Time.time + PlayerLifecycleConfig.PlayerHeartbeatIntervalSeconds;
        private ComponentGroup group;
        private CommandSystem commandSystem;

        protected override void OnCreateManager()
        {
            base.OnCreateManager();

            group = GetComponentGroup(
                ComponentType.ReadOnly<PlayerHeartbeatServer.ComponentAuthority>(),
                ComponentType.ReadWrite<HeartbeatData>(),
                ComponentType.ReadOnly<SpatialEntityId>()
            );
            group.SetFilter(PlayerHeartbeatServer.ComponentAuthority.Authoritative);

            commandSystem = World.GetExistingManager<CommandSystem>();
        }

        protected override void OnUpdate()
        {
            if (Time.time < timeOfNextHeartbeat)
            {
                return;
            }

            timeOfNextHeartbeat = Time.time + PlayerLifecycleConfig.PlayerHeartbeatIntervalSeconds;

            Entities.With(group).ForEach((ref SpatialEntityId spatialEntityId) =>
            {
                commandSystem.SendCommand(
                    new PlayerHeartbeatClient.PlayerHeartbeat.Request(spatialEntityId.EntityId, new Empty()));
            });
        }
    }
}
