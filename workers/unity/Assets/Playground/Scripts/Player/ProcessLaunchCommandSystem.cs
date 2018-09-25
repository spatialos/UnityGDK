using Generated.Playground;
using Improbable.Gdk.Core;
using Improbable.Gdk.Core.Commands;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

#region Diagnostic control

#pragma warning disable 649
// ReSharper disable UnassignedReadonlyField
// ReSharper disable UnusedMember.Global

#endregion

namespace Playground
{
    [UpdateInGroup(typeof(SpatialOSUpdateGroup))]
    public class ProcessLaunchCommandSystem : ComponentSystem
    {
        private const float RechargeTime = 2.0f;

        private struct LaunchCommandData
        {
            public readonly int Length;
            [ReadOnly] public EntityArray Entity;
            public ComponentDataArray<SpatialOSLauncher> Launcher;
            [ReadOnly] public ComponentDataArray<Launcher.CommandRequests.LaunchEntity> Requests;
            [ReadOnly] public ComponentDataArray<Launchable.CommandSenders.LaunchMe> Senders;
        }

        private struct LaunchableData
        {
            public readonly int Length;
            public ComponentDataArray<SpatialOSLaunchable> Launchable;
            [ReadOnly] public ComponentDataArray<Launchable.CommandRequests.LaunchMe> Requests;
            [ReadOnly] public ComponentArray<Rigidbody> Rigidbody;
            [ReadOnly] public ComponentDataArray<Launcher.CommandSenders.IncreaseScore> Sender;
        }

        [Inject] private LaunchCommandData launchCommandData;
        [Inject] private LaunchableData launchableData;

        protected override void OnUpdate()
        {
            // Handle Launch Commands from players. Only allow if they have energy etc.
            for (var i = 0; i < launchCommandData.Length; i++)
            {
                var sender = launchCommandData.Senders[i];
                var launcher = launchCommandData.Launcher[i];

                if (launcher.RechargeTimeLeft > 0)
                {
                    return;
                }

                var requests = launchCommandData.Requests[i].Requests;
                var energyLeft = launcher.EnergyLeft;
                var j = 0;
                while (energyLeft > 0f && j < requests.Count)
                {
                    var info = requests[j].RawRequest;
                    var energy = math.min(info.LaunchEnergy, energyLeft);
                    sender.RequestsToSend.Add(new Launchable.LaunchMe.Request(info.EntityToLaunch, new Generated.Playground.LaunchMeCommandRequest
                    {
                        ImpactPoint = info.ImpactPoint,
                        LaunchDirection = info.LaunchDirection,
                        LaunchEnergy = energy,
                        Player = info.Player
                    }));
                    energyLeft -= energy;
                    j++;
                }

                if (energyLeft <= 0.01f)
                {
                    launcher.EnergyLeft = 0.0f;
                    launcher.RechargeTimeLeft = RechargeTime;
                    PostUpdateCommands.AddComponent(launchCommandData.Entity[i], new Recharging());
                }
                else
                {
                    launcher.EnergyLeft = energyLeft;
                }

                launchCommandData.Launcher[i] = launcher;
            }

            // Handle Launch Me Commands by applying force to rigidbodies proportional to launch energy.
            // Also add launch energy to launcher component.
            for (var i = 0; i < launchableData.Length; i++)
            {
                var rigidbody = launchableData.Rigidbody[i];
                var launchable = launchableData.Launchable[i];
                var sender = launchableData.Sender[i];
                foreach (var request in launchableData.Requests[i].Requests)
                {
                    var info = request.RawRequest;
                    rigidbody.AddForceAtPosition(
                        new Vector3(info.LaunchDirection.X, info.LaunchDirection.Y, info.LaunchDirection.Z) *
                        info.LaunchEnergy * 100.0f,
                        new Vector3(info.ImpactPoint.X, info.ImpactPoint.Y, info.ImpactPoint.Z)
                    );
                    launchable.MostRecentLauncher = info.Player;
                }

                sender.RequestsToSend.Add(new Launcher.IncreaseScore.Request(
                    launchable.MostRecentLauncher,
                    new ScoreIncreaseRequest { Amount = 1.0f }));

                launchableData.Launchable[i] = launchable;
            }
        }
    }
}
