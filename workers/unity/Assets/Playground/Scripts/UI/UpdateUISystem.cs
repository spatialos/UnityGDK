using Improbable.Gdk.Core;
using Playground.Scripts.UI;
using Unity.Entities;

namespace Playground
{
    [UpdateInGroup(typeof(SpatialOSUpdateGroup))]
    public class UpdateUISystem : ComponentSystem
    {
        private ComponentUpdateSystem componentUpdateSystem;

        private ComponentGroup launcherGroup;
        private ComponentGroup scoreGroup;

        protected override void OnCreateManager()
        {
            base.OnCreateManager();

            componentUpdateSystem = World.GetExistingManager<ComponentUpdateSystem>();
            launcherGroup = GetComponentGroup(
                ComponentType.ReadOnly<Launcher.Component>(),
                ComponentType.ReadOnly<SpatialEntityId>(),
                ComponentType.ReadOnly<Launcher.ComponentAuthority>()
            );
            launcherGroup.SetFilter(Launcher.ComponentAuthority.Authoritative);

            scoreGroup = GetComponentGroup(
                ComponentType.ReadOnly<Score.Component>(),
                ComponentType.ReadOnly<SpatialEntityId>(),
                ComponentType.ReadOnly<Score.ComponentAuthority>()
            );
            scoreGroup.SetFilter(Score.ComponentAuthority.Authoritative);
        }

        protected override void OnUpdate()
        {
            Entities.With(launcherGroup).ForEach(
                (ref SpatialEntityId spatialEntityId, ref Launcher.Component launcher) =>
                {
                    var spatialId = spatialEntityId.EntityId;
                    var launcherUpdates =
                        componentUpdateSystem.GetEntityComponentUpdatesReceived<Launcher.Update>(spatialId);
                    if (launcherUpdates.Count > 0)
                    {
                        UIComponent.Main.TestText.text = launcher.RechargeTimeLeft > 0.0f
                            ? "Recharging"
                            : $"Energy: {launcher.EnergyLeft}";
                    }
                });

            Entities.With(scoreGroup).ForEach((ref SpatialEntityId spatialEntityId, ref Score.Component score) =>
            {
                var spatialId = spatialEntityId.EntityId;
                var launcherUpdates =
                    componentUpdateSystem.GetEntityComponentUpdatesReceived<Score.Update>(spatialId);
                if (launcherUpdates.Count > 0)
                {
                    UIComponent.Main.ScoreText.text = $"Score: {score.Score}";
                }
            });
        }
    }
}
