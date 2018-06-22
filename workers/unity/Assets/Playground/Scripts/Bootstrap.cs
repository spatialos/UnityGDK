using System;
using System.Collections.Generic;
using System.Linq;
using Improbable.Gdk.Core;
using Unity.Entities;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Compilation;

#endif

namespace Playground
{
    public class Bootstrap : MonoBehaviour
    {
        public GameObject Level;

        private const int TargetFrameRate = -1; // Turns off VSync

        private static readonly List<WorkerBase> Workers = new List<WorkerBase>();

        private static ConnectionConfig connectionConfig;

        public void Awake()
        {
            InitializeWorkerTypes();
            // Taken from DefaultWorldInitalization.cs
            SetupInjectionHooks(); // Register hybrid injection hooks
            PlayerLoopManager.RegisterDomainUnload(DomainUnloadShutdown, 10000); // Clean up worlds and player loop

            Application.targetFrameRate = TargetFrameRate;
            if (Application.isEditor)
            {
#if UNITY_EDITOR
                CompilationPipeline.assemblyCompilationStarted += CompilationStarted;

                var workerConfigurations =
                    AssetDatabase.LoadAssetAtPath<ScriptableWorkerConfiguration>(ScriptableWorkerConfiguration
                        .AssetPath);
                foreach (var workerConfig in workerConfigurations.WorkerConfigurations)
                {
                    if (!workerConfig.IsEnabled)
                    {
                        continue;
                    }

                    var worker = WorkerRegistry.CreateWorker(workerConfig.Type, $"{workerConfig.Type}-{Guid.NewGuid()}",
                        workerConfig.Origin);
                    Workers.Add(worker);
                }

                connectionConfig = new ReceptionistConfig();
                connectionConfig.UseExternalIp = workerConfigurations.UseExternalIp;
#endif
            }
            else
            {
                var commandLineArguments = System.Environment.GetCommandLineArgs();
                Debug.LogFormat("Command line {0}", string.Join(" ", commandLineArguments.ToArray()));
                var commandLineArgs = CommandLineUtility.ParseCommandLineArgs(commandLineArguments);
                var workerType =
                    CommandLineUtility.GetCommandLineValue(commandLineArgs, RuntimeConfigNames.WorkerType,
                        string.Empty);
                var workerId =
                    CommandLineUtility.GetCommandLineValue(commandLineArgs, RuntimeConfigNames.WorkerId,
                        string.Empty);

                // because the launcher does not pass in the worker type as an argument
                var worker = workerType.Equals(string.Empty)
                    ? WorkerRegistry.CreateWorker<UnityClient>($"{workerType}-{Guid.NewGuid()}", new Vector3(0, 0, 0))
                    : WorkerRegistry.CreateWorker(workerType, workerId, new Vector3(0, 0, 0));

                if (worker == null)
                {
                    return;
                }

                Workers.Add(worker);

                connectionConfig = ConnectionUtility.CreateConnectionConfigFromCommandLine(commandLineArgs);
            }

            if (World.AllWorlds.Count <= 0)
            {
                Debug.LogError(
                    "No worlds have been created, due to invalid worker types being specified.");
            }

            var worlds = World.AllWorlds.ToArray();
            ScriptBehaviourUpdateOrder.UpdatePlayerLoop(worlds);
            // Systems don't tick if World.Active isn't set
            World.Active = worlds[0];
        }

        private static void CompilationStarted(string destination)
        {
            foreach (var worker in Workers)
            {
                worker.Disconnect();
            }
        }

        public void Start()
        {
            foreach (var worker in Workers)
            {
                LoadLevel(worker);
                worker.Connect(connectionConfig);
            }
        }

        public static void InitializeWorkerTypes()
        {
            WorkerRegistry.RegisterWorkerType<UnityClient>();
            WorkerRegistry.RegisterWorkerType<UnityGameLogic>();
        }

        public static void SetupInjectionHooks() 
        {
            // Reflection to get internal hook classes. Doesn't seem to be a proper way to do this.
            var gameObjectArrayInjectionHookType =
                typeof(Unity.Entities.GameObjectEntity).Assembly.GetType("Unity.Entities.GameObjectArrayInjectionHook");
            var transformAccessArrayInjectionHookType =
                typeof(Unity.Entities.GameObjectEntity).Assembly.GetType(
                    "Unity.Entities.TransformAccessArrayInjectionHook");
            var componentArrayInjectionHookType =
                typeof(Unity.Entities.GameObjectEntity).Assembly.GetType("Unity.Entities.ComponentArrayInjectionHook");

            InjectionHookSupport.RegisterHook(
                (InjectionHook) Activator.CreateInstance(gameObjectArrayInjectionHookType));
            InjectionHookSupport.RegisterHook(
                (InjectionHook) Activator.CreateInstance(transformAccessArrayInjectionHookType));
            InjectionHookSupport.RegisterHook(
                (InjectionHook) Activator.CreateInstance(componentArrayInjectionHookType));
        }

        public static void DomainUnloadShutdown()
        {
#if UNITY_EDITOR
            CompilationPipeline.assemblyCompilationStarted -= CompilationStarted;
#endif

            World.DisposeAllWorlds();
            ScriptBehaviourUpdateOrder.UpdatePlayerLoop();
        }

        private void LoadLevel(WorkerBase worker)
        {
            Instantiate(Level, worker.Origin, Quaternion.identity);
        }
    }
}
