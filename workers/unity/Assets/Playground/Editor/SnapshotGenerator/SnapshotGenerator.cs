using System;
using System.Collections.Generic;
using Generated.Improbable.PlayerLifecycle;
using Generated.Improbable.Transform;
using Generated.Playground;
using Improbable.Gdk.Core;
using UnityEngine;
using Quaternion = Generated.Improbable.Transform.Quaternion;

namespace Playground.Editor.SnapshotGenerator
{
    internal static class SnapshotGenerator
    {
        public struct Arguments
        {
            public int NumberEntities;
            public string OutputPath;
        }

        private static readonly List<string> UnityWorkers =
            new List<string> { UnityGameLogic.WorkerType, UnityClient.WorkerType };

        public static void Generate(Arguments arguments)
        {
            Debug.Log("Generating snapshot.");
            var snapshot = CreateSnapshot(arguments.NumberEntities);

            Debug.Log($"Writing snapshot to: {arguments.OutputPath}");
            snapshot.Serialize(arguments.OutputPath);
        }

        private static SnapshotBuilder CreateSnapshot(int cubeCount)
        {
            var snapshot = new SnapshotBuilder();

            AddPlayerSpawner(snapshot);
            AddCubeGrid(snapshot, cubeCount);

            return snapshot;
        }

        private static void AddPlayerSpawner(SnapshotBuilder snapshot)
        {
            var playerCreator = SpatialOSPlayerCreator.CreateSchemaComponentData();
            var spawner = EntityBuilder.Begin()
                .AddPosition(0, 0, 0, UnityGameLogic.WorkerType)
                .AddMetadata(ArchetypeConfig.PlayerCreator, UnityGameLogic.WorkerType)
                .SetPersistence(true)
                .SetReadAcl(UnityWorkers)
                .AddComponent(playerCreator, UnityGameLogic.WorkerType)
                .Build();
            
            snapshot.AddEntity(spawner);
        }

        private static void AddCubeGrid(SnapshotBuilder snapshot, int cubeCount)
        {
            // Calculate grid size
            var gridLength = (int) Math.Ceiling(Math.Sqrt(cubeCount));
            if (gridLength % 2 == 1) // To make sure nothing is in (0, 0)
            {
                gridLength += 1;
            }

            var cubesToSpawn = cubeCount;
            const string entityType = "Cube";

            for (var x = -gridLength + 1; x <= gridLength - 1; x += 2)
            {
                for (var z = -gridLength + 1; z <= gridLength - 1; z += 2)
                {
                    // Leave the centre empty
                    if (x == 0 && z == 0)
                    {
                        continue;
                    }

                    // Exit when we've hit our cube limit
                    if (--cubesToSpawn <= 0)
                    {
                        return;
                    }

                    var transform = SpatialOSTransform.CreateSchemaComponentData(
                        new Location { X = x, Y = 1, Z = z },
                        new Quaternion { W = 1, X = 0, Y = 0, Z = 0 },
                        0
                    );

                    var cubeColor = SpatialOSCubeColor.CreateSchemaComponentData();
                    var prefab = SpatialOSPrefab.CreateSchemaComponentData(entityType);
                    var launchable = SpatialOSLaunchable.CreateSchemaComponentData();
                    var archetypeComponent = SpatialOSArchetypeComponent.CreateSchemaComponentData(entityType);

                    var entity = EntityBuilder.Begin()
                        .AddPosition(x, 0, z, UnityGameLogic.WorkerType)
                        .AddMetadata(entityType, UnityGameLogic.WorkerType)
                        .SetPersistence(true)
                        .SetReadAcl(UnityWorkers)
                        .AddComponent(transform, UnityGameLogic.WorkerType)
                        .AddComponent(cubeColor, UnityGameLogic.WorkerType)
                        .AddComponent(prefab, UnityGameLogic.WorkerType)
                        .AddComponent(archetypeComponent, UnityGameLogic.WorkerType)
                        .AddComponent(launchable, UnityGameLogic.WorkerType)
                        .Build();

                    snapshot.AddEntity(entity);
                }
            }
        }
    }
}
