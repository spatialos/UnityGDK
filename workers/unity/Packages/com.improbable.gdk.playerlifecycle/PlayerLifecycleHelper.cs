using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Improbable.Gdk.Core;
using Improbable.PlayerLifecycle;
using Unity.Entities;

namespace Improbable.Gdk.PlayerLifecycle
{
    public static class PlayerLifecycleHelper
    {
        public static void AddPlayerLifecycleComponents(EntityTemplate template,
            string workerId,
            string clientAccess,
            string serverAccess)
        {
            var clientHeartbeat = new PlayerHeartbeatClient.Snapshot();
            var serverHeartbeat = new PlayerHeartbeatServer.Snapshot();
            var owningComponent = new OwningWorker.Snapshot { WorkerId = workerId };

            template.AddComponent(clientHeartbeat, clientAccess);
            template.AddComponent(serverHeartbeat, serverAccess);
            template.AddComponent(owningComponent, serverAccess);
        }

        public static bool SerializeArguments(Object playerCreationArguments, out byte[] serializedArguments)
        {
            try
            {
                using (var memoryStream = new MemoryStream())
                {
                    var binaryFormatter = new BinaryFormatter();
                    binaryFormatter.Serialize(memoryStream, playerCreationArguments);
                    serializedArguments = memoryStream.ToArray();
                    return true;
                }
            }
            catch (Exception e)
            {
                UnityEngine.Debug.LogError($"Unable to serialize player creation arguments. {e.Message}");
                serializedArguments = null;
                return false;
            }
        }

        public static bool DeserializeArguments<T>(byte[] serializedArguments, out T deserializedArguments)
        {
            try
            {
                using (var memoryStream = new MemoryStream())
                {
                    var binaryFormatter = new BinaryFormatter();
                    memoryStream.Write(serializedArguments, 0, serializedArguments.Length);
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    deserializedArguments = (T) binaryFormatter.Deserialize(memoryStream);
                    return true;
                }
            }
            catch (Exception e)
            {
                UnityEngine.Debug.LogError($"Unable to deserialize player creation arguments. {e.Message}");
                deserializedArguments = default;
                return false;
            }
        }

        public static bool IsOwningWorker(SpatialEntityId entityId, World workerWorld)
        {
            var entityManager = workerWorld.GetOrCreateManager<EntityManager>();
            var worker = workerWorld.GetExistingManager<WorkerSystem>();

            if (worker == null)
            {
                throw new InvalidOperationException("Provided World does not have an associated worker");
            }

            if (!worker.TryGetEntity(entityId.EntityId, out var entity))
            {
                throw new InvalidOperationException(
                    $"Entity with SpatialOS Entity ID {entityId.EntityId.Id} is not in this worker's view");
            }

            if (!entityManager.HasComponent<OwningWorker.Component>(entity))
            {
                return false;
            }

            var ownerId = entityManager.GetComponentData<OwningWorker.Component>(entity).WorkerId;

            return worker.Connection.GetWorkerId() == ownerId;
        }

        public static void AddClientSystems(World world)
        {
            world.GetOrCreateManager<SendCreatePlayerRequestSystem>();
            world.GetOrCreateManager<HandlePlayerHeartbeatRequestSystem>();
        }

        public static void AddServerSystems(World world)
        {
            world.GetOrCreateManager<HandleCreatePlayerRequestSystem>();
            world.GetOrCreateManager<PlayerHeartbeatInitializationSystem>();
            world.GetOrCreateManager<SendPlayerHeartbeatRequestSystem>();
            world.GetOrCreateManager<HandlePlayerHeartbeatResponseSystem>();
        }
    }
}
