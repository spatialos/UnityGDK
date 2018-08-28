using System;
using System.Collections.Generic;
using System.Linq;
using Improbable.Gdk.Core;
using Improbable.Gdk.PlayerLifecycle;
using Unity.Entities;
using UnityEngine;

namespace Playground
{
    public class Bootstrap : MonoBehaviour
    {
        public GameObject Level;

        [SerializeField] private int targetFrameRate = 60;

        private static readonly List<Worker> Workers = new List<Worker>();

        public void Awake()
        {
            // Taken from DefaultWorldInitalization.cs
            SetupInjectionHooks(); // Register hybrid injection hooks
            PlayerLoopManager.RegisterDomainUnload(DomainUnloadShutdown, 10000); // Clean up worlds and player loop

            Application.targetFrameRate = targetFrameRate;
            Worker.OnConnect += w => Debug.Log($"{w.WorkerId} is connecting");
            Worker.OnDisconnect += w => Debug.Log($"{w.WorkerId} is disconnecting");

            // Setup template to use for player on connecting client
            PlayerLifecycleConfig.CreatePlayerEntityTemplate = PlayerTemplate.CreatePlayerEntityTemplate;

            if (Application.isEditor)
            {
                var config = new ReceptionistConfig
                {
                    WorkerType = SystemConfig.UnityGameLogic,
                };
                CreateWorker(config, new Vector3(500, 0, 0));
                config = new ReceptionistConfig
                {
                    WorkerType = SystemConfig.UnityClient,
                };
                CreateWorker(config, Vector3.zero);
            }
            else
            {
                var commandLineArguments = Environment.GetCommandLineArgs();
                Debug.LogFormat("Command line {0}", string.Join(" ", commandLineArguments.ToArray()));
                var commandLineArgs = CommandLineUtility.ParseCommandLineArgs(commandLineArguments);
                var config = ConnectionUtility.CreateConnectionConfigFromCommandLine(commandLineArgs);
                if (string.Empty.Equals(config.WorkerType))
                {
                    config.WorkerType = SystemConfig.UnityClient;
                }
                CreateWorker(config, Vector3.zero);
            }

            if (World.AllWorlds.Count <= 0)
            {
                throw new InvalidConfigurationException(
                    "No worlds have been created, due to invalid worker types being specified. Check the config in" +
                    "Improbable -> Configure editor workers.");
            }

            var worlds = World.AllWorlds.ToArray();
            ScriptBehaviourUpdateOrder.UpdatePlayerLoop(worlds);
            // Systems don't tick if World.Active isn't set
            World.Active = worlds[0];
        }

        public static void SetupInjectionHooks()
        {
            var hybridAssembly = typeof(GameObjectEntity).Assembly;

            // Reflection to get internal hook classes. Doesn't seem to be a proper way to do this.
            var gameObjectArrayInjectionHookType =
                hybridAssembly.GetType("Unity.Entities.GameObjectArrayInjectionHook");
            var transformAccessArrayInjectionHookType =
                hybridAssembly.GetType(
                    "Unity.Entities.TransformAccessArrayInjectionHook");
            var componentArrayInjectionHookType =
                hybridAssembly.GetType("Unity.Entities.ComponentArrayInjectionHook");

            InjectionHookSupport.RegisterHook(
                (InjectionHook) Activator.CreateInstance(gameObjectArrayInjectionHookType));
            InjectionHookSupport.RegisterHook(
                (InjectionHook) Activator.CreateInstance(transformAccessArrayInjectionHookType));
            InjectionHookSupport.RegisterHook(
                (InjectionHook) Activator.CreateInstance(componentArrayInjectionHookType));
        }

        public static void DomainUnloadShutdown()
        {
            foreach (var worker in Workers)
            {
                worker.Dispose();
            }

            World.DisposeAllWorlds();
            ScriptBehaviourUpdateOrder.UpdatePlayerLoop();
        }

        private void CreateWorker(ConnectionConfig config, Vector3 origin)
        {
            var worker = Worker.Connect(config, new ForwardingDispatcher(), origin);
            Instantiate(Level, origin, Quaternion.identity);
            SystemConfig.AddSystems(worker.World, config.WorkerType);
            Workers.Add(worker);
        }
    }
}
