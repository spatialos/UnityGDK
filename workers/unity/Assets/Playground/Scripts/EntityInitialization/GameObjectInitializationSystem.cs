using System.Collections.Generic;
using Generated.Playground;
using Improbable.Gdk.Core;
using Improbable.Gdk.Core.GameObjectRepresentation;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;
using Transform = Generated.Improbable.Transform.Transform;

namespace Playground
{
    /// <summary>
    ///     Creates a companion gameobject for newly spawned entities according to a prefab definition.
    /// </summary>
    [UpdateInGroup(typeof(SpatialOSReceiveGroup.EntityInitialisationGroup))]
    internal class GameObjectInitializationSystem : ComponentSystem
    {
        private struct AddedEntitiesData
        {
            public readonly int Length;
            public EntityArray Entities;
            [ReadOnly] public ComponentDataArray<Prefab.Component> PrefabNames;
            [ReadOnly] public ComponentDataArray<Transform.Component> Transforms;
            [ReadOnly] public ComponentDataArray<SpatialEntityId> SpatialEntityIds;
            [ReadOnly] public ComponentDataArray<NewlyAddedSpatialOSEntity> NewlyCreatedEntities;
        }

        private struct RemovedEntitiesData
        {
            public readonly int Length;
            public EntityArray Entities;
            [ReadOnly] public ComponentDataArray<GameObjectReferenceHandle> GameObjectReferenceHandles;
            public SubtractiveComponent<GameObjectReference> NoGameObjectReference;
        }

        [Inject] private AddedEntitiesData addedEntitiesData;
        [Inject] private RemovedEntitiesData removedEntitiesData;

        private WorkerSystem worker;
        private ViewCommandBuffer viewCommandBuffer;
        private EntityGameObjectCreator entityGameObjectCreator;
        private EntityGameObjectLinker entityGameObjectLinker;
        private readonly Dictionary<Entity, GameObject> entityGameObjectCache = new Dictionary<Entity, GameObject>();

        protected override void OnCreateManager(int capacity)
        {
            base.OnCreateManager(capacity);

            worker = World.GetExistingManager<WorkerSystem>();
            viewCommandBuffer = new ViewCommandBuffer(EntityManager, worker.LogDispatcher);
            entityGameObjectCreator = new EntityGameObjectCreator(World);
            entityGameObjectLinker = new EntityGameObjectLinker(World, worker.LogDispatcher);
        }

        protected override void OnUpdate()
        {
            for (var i = 0; i < addedEntitiesData.Length; i++)
            {
                var prefabMapping = PrefabConfig.PrefabMappings[addedEntitiesData.PrefabNames[i].Prefab];
                var transform = addedEntitiesData.Transforms[i];
                var entity = addedEntitiesData.Entities[i];
                var spatialEntityId = addedEntitiesData.SpatialEntityIds[i].EntityId;

                if (!WorkerUtils.UnityClient.Equals(worker.WorkerType) &&
                    !WorkerUtils.UnityGameLogic.Equals(worker.WorkerType))
                {
                    worker.LogDispatcher.HandleLog(LogType.Error, new LogEvent(
                            "Worker type isn't supported by the GameObjectInitializationSystem.")
                        .WithField("WorldName", World.Name)
                        .WithField("WorkerType", worker));
                    continue;
                }

                var prefabName = WorkerUtils.UnityGameLogic.Equals(worker.WorkerType)
                    ? prefabMapping.UnityGameLogic
                    : prefabMapping.UnityClient;

                var position = new Vector3(transform.Location.X, transform.Location.Y, transform.Location.Z) +
                    worker.Origin;
                var rotation = new Quaternion(transform.Rotation.X, transform.Rotation.Y,
                    transform.Rotation.Z, transform.Rotation.W);

                var gameObject = entityGameObjectCreator.CreateEntityGameObject(entity, prefabName, position, rotation,
                    spatialEntityId);
                entityGameObjectLinker.LinkGameObjectToEntity(gameObject, entity, spatialEntityId, PostUpdateCommands,
                    viewCommandBuffer);
                entityGameObjectCache.Add(entity, gameObject);
            }

            for (var i = 0; i < removedEntitiesData.Length; i++)
            {
                var entity = removedEntitiesData.Entities[i];

                if (!entityGameObjectCache.TryGetValue(entity, out var gameObject))
                {
                    worker.LogDispatcher.HandleLog(LogType.Error, new LogEvent(
                            "GameObject corresponding to removed entity not found.")
                        .WithField("EntityIndex", entity.Index)
                        .WithField("EntityVersion", entity.Version));
                    continue;
                }

                entityGameObjectCache.Remove(entity);
                entityGameObjectLinker.UnlinkGameObjectFromEntity(gameObject, entity, PostUpdateCommands);
                entityGameObjectCreator.DeleteGameObject(entity, gameObject);
            }

            viewCommandBuffer.FlushBuffer();
        }

        protected override void OnDestroyManager()
        {
            base.OnDestroyManager();

            foreach (var entityToGameObject in entityGameObjectCache)
            {
                entityGameObjectLinker
                    .UnlinkGameObjectFromEntity(entityToGameObject.Value, entityToGameObject.Key, PostUpdateCommands);
                entityGameObjectCreator
                    .DeleteGameObject(entityToGameObject.Key, entityToGameObject.Value);
            }
            entityGameObjectCache.Clear();
        }
    }
}
