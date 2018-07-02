using Generated.Playground;
using Improbable.Gdk.Core;
using Playground.Scripts.UI;
using Unity.Collections;
using Unity.Entities;

namespace Playground
{
    [UpdateInGroup(typeof(SpatialOSUpdateGroup))]
    public class UpdateUISystem : ComponentSystem
    {
        public struct PlayerData
        {
            public int Length;
            [ReadOnly] public ComponentDataArray<SpatialOSLauncher> Launcher;
            [ReadOnly] public ComponentArray<ComponentsUpdated<SpatialOSLauncherUpdate>> Updates;
            [ReadOnly] public ComponentDataArray<Authoritative<SpatialOSPlayerInput>> PlayerAuth;
        }

        [Inject] private PlayerData playerData;

        protected override void OnUpdate()
        {
            var launcher = playerData.Launcher[0];

            if (launcher.RechargeTimeLeft > 0.0f)
            {
                UIComponent.Main.TestText.text = "Recharging";
            }
            else
            {
                UIComponent.Main.TestText.text = $"Energy: {launcher.EnergyLeft}";
            }
        }
    }
}
