using Improbable.Gdk.Core.GameObjectRepresentation;
using Improbable.Gdk.PlayerLifecycle;
using Improbable.Gdk.TransformSynchronization;
using Unity.Entities;
using UnityEngine;

namespace Playground
{
    public static class WorkerUtils
    {
        public const string UnityClient = "UnityClient";
        public const string UnityGameLogic = "UnityGameLogic";

        public static void AddClientSystems(World world)
        {
            Debug.Log(world.Name);
            AddLifecycleSystems(world);
            TransformSynchronizationSystemHelper.AddSystems(world);
            PlayerLifecycleConfig.AddClientSystems(world);
            GameObjectRepresentationSystemHelper.AddSystems(world);
            GameObjectCreationSystemHelper.AddStandardGameObjectCreation(world);
            world.GetOrCreateManager<ProcessColorChangeSystem>();
            world.GetOrCreateManager<LocalPlayerInputSync>();
            world.GetOrCreateManager<InitCameraSystem>();
            world.GetOrCreateManager<FollowCameraSystem>();
            world.GetOrCreateManager<InitUISystem>();
            world.GetOrCreateManager<UpdateUISystem>();
            world.GetOrCreateManager<PlayerCommandsSystem>();
            world.GetOrCreateManager<MetricSendSystem>();
        }

        public static void AddGameLogicSystems(World world)
        {
            Debug.Log(world.Name);
            AddLifecycleSystems(world);
            TransformSynchronizationSystemHelper.AddSystems(world);
            PlayerLifecycleConfig.AddServerSystems(world);
            GameObjectRepresentationSystemHelper.AddSystems(world);
            GameObjectCreationSystemHelper.AddStandardGameObjectCreation(world);
            world.GetOrCreateManager<CubeMovementSystem>();
            world.GetOrCreateManager<MoveLocalPlayerSystem>();
            world.GetOrCreateManager<TriggerColorChangeSystem>();
            world.GetOrCreateManager<ProcessLaunchCommandSystem>();
            world.GetOrCreateManager<ProcessRechargeSystem>();
            world.GetOrCreateManager<MetricSendSystem>();
            world.GetOrCreateManager<ProcessScoresSystem>();
            world.GetOrCreateManager<CollisionProcessSystem>();
        }

        private static void AddLifecycleSystems(World world)
        {
            world.GetOrCreateManager<ArchetypeInitializationSystem>();
            world.GetOrCreateManager<DisconnectSystem>();
        }
    }
}
