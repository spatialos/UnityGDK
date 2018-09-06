using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using Unity.Entities;

namespace Improbable.Gdk.Core.GameObjectRepresentation
{
    /// <summary>
    ///     Gathers incoming dispatcher ops and invokes callbacks on relevant GameObjects.
    /// </summary>
    [DisableAutoCreation]
    [AlwaysUpdateSystem]
    [UpdateInGroup(typeof(SpatialOSReceiveGroup.GameObjectReceiveGroup))]
    internal class GameObjectDispatcherSystem : ComponentSystem
    {
        public struct GameObjectReferenceHandle : ISystemStateComponentData
        {
        }

        public struct AddedEntitiesData
        {
            public readonly int Length;
            public EntityArray Entities;
            [ReadOnly] public ComponentArray<GameObjectReference> GameObjectReferences;
            [ReadOnly] public SubtractiveComponent<GameObjectReferenceHandle> GameObjectReferenceHandles;
        }

        public struct RemovedEntitiesData
        {
            public readonly int Length;
            public EntityArray Entities;
            [ReadOnly] public ComponentDataArray<GameObjectReferenceHandle> GameObjectReferenceHandles;
            [ReadOnly] public SubtractiveComponent<GameObjectReference> NoGameObjectReference;
        }
        
        internal readonly Dictionary<Entity, InjectableStore> entityToReaderWriterStore =
            new Dictionary<Entity, InjectableStore>();

        private readonly List<GameObjectComponentDispatcherBase> gameObjectComponentDispatchers =
            new List<GameObjectComponentDispatcherBase>();

        private readonly Dictionary<Entity, MonoBehaviourActivationManager> entityToActivationManager =
            new Dictionary<Entity, MonoBehaviourActivationManager>();

        [Inject] private AddedEntitiesData addedEntitiesData;
        [Inject] private RemovedEntitiesData removedEntitiesData;

        private RequiredFieldInjector injector;
        private ILogDispatcher logger;

        protected override void OnCreateManager(int capacity)
        {
            base.OnCreateManager(capacity);

            FindGameObjectComponentDispatchers();
            GenerateComponentGroups();

            var entityManager = World.GetOrCreateManager<EntityManager>();
            logger = World.GetExistingManager<WorkerSystem>().LogDispatcher;
            injector = new RequiredFieldInjector(entityManager, logger);
        }


        protected override void OnUpdate()
        {
            for (var i = 0; i < addedEntitiesData.Length; i++)
            {
                var entity = addedEntitiesData.Entities[i];
                CreateActivationManagerAndReaderWriterStore(entity);
                PostUpdateCommands.AddComponent(entity, new GameObjectReferenceHandle());
            }

            for (var i = 0; i < removedEntitiesData.Length; i++)
            {
                var entity = removedEntitiesData.Entities[i];
                RemoveActivationManagerAndReaderWriterStore(entity);
                PostUpdateCommands.RemoveComponent<GameObjectReferenceHandle>(entity);
            }

            RunDispatchers();
        }

        protected override void OnDestroyManager()
        {
            foreach (var entity in new List<Entity>(entityToActivationManager.Keys))
            {
                RemoveActivationManagerAndReaderWriterStore(entity);
            }

            base.OnDestroyManager();
        }

        private void FindGameObjectComponentDispatchers()
        {
            var gameObjectComponentDispatcherTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => typeof(GameObjectComponentDispatcherBase).IsAssignableFrom(type) && !type.IsAbstract)
                .ToList();

            gameObjectComponentDispatchers.AddRange(gameObjectComponentDispatcherTypes.Select(type =>
                (GameObjectComponentDispatcherBase)Activator.CreateInstance(type)));
        }

        private void GenerateComponentGroups()
        {
            foreach (var gameObjectComponentDispatcher in gameObjectComponentDispatchers)
            {
                gameObjectComponentDispatcher.ComponentAddedComponentGroup =
                    GetComponentGroup(gameObjectComponentDispatcher.ComponentAddedComponentTypes);
                gameObjectComponentDispatcher.ComponentRemovedComponentGroup =
                    GetComponentGroup(gameObjectComponentDispatcher.ComponentRemovedComponentTypes);
                gameObjectComponentDispatcher.AuthorityGainedComponentGroup =
                    GetComponentGroup(gameObjectComponentDispatcher.AuthorityGainedComponentTypes);
                gameObjectComponentDispatcher.AuthorityLostComponentGroup =
                    GetComponentGroup(gameObjectComponentDispatcher.AuthorityLostComponentTypes);
                gameObjectComponentDispatcher.AuthorityLossImminentComponentGroup =
                    GetComponentGroup(gameObjectComponentDispatcher.AuthorityLossImminentComponentTypes);

                if (gameObjectComponentDispatcher.ComponentsUpdatedComponentTypes.Length > 0)
                {
                    gameObjectComponentDispatcher.ComponentsUpdatedComponentGroup =
                        GetComponentGroup(gameObjectComponentDispatcher.ComponentsUpdatedComponentTypes);
                }

                if (gameObjectComponentDispatcher.EventsReceivedComponentTypeArrays.Length > 0)
                {
                    gameObjectComponentDispatcher.EventsReceivedComponentGroups =
                        new ComponentGroup[gameObjectComponentDispatcher.EventsReceivedComponentTypeArrays.Length];
                    for (var i = 0; i < gameObjectComponentDispatcher.EventsReceivedComponentTypeArrays.Length; i++)
                    {
                        gameObjectComponentDispatcher.EventsReceivedComponentGroups[i] =
                            GetComponentGroup(gameObjectComponentDispatcher.EventsReceivedComponentTypeArrays[i]);
                    }
                }

                if (gameObjectComponentDispatcher.CommandRequestsComponentTypeArrays.Length > 0)
                {
                    gameObjectComponentDispatcher.CommandRequestsComponentGroups =
                        new ComponentGroup[gameObjectComponentDispatcher.CommandRequestsComponentTypeArrays.Length];
                    for (var i = 0; i < gameObjectComponentDispatcher.CommandRequestsComponentTypeArrays.Length; i++)
                    {
                        gameObjectComponentDispatcher.CommandRequestsComponentGroups[i] =
                            GetComponentGroup(gameObjectComponentDispatcher.CommandRequestsComponentTypeArrays[i]);
                    }
                }

                if (gameObjectComponentDispatcher.CommandResponsesComponentTypeArrays.Length > 0)
                {
                    gameObjectComponentDispatcher.CommandResponsesComponentGroups =
                        new ComponentGroup[gameObjectComponentDispatcher.CommandResponsesComponentTypeArrays.Length];
                    for (var i = 0; i < gameObjectComponentDispatcher.CommandResponsesComponentTypeArrays.Length; i++)
                    {
                        gameObjectComponentDispatcher.CommandResponsesComponentGroups[i] =
                            GetComponentGroup(gameObjectComponentDispatcher.CommandResponsesComponentTypeArrays[i]);
                    }
                }
            }
        }

        private void RunDispatchers()
        {
            foreach (var gameObjectComponentDispatcher in gameObjectComponentDispatchers)
            {
                gameObjectComponentDispatcher.MarkComponentsRemovedForDeactivation(entityToActivationManager);
                gameObjectComponentDispatcher.MarkAuthorityLostForDeactivation(entityToActivationManager);
            }

            foreach (var indexManagerPair in entityToActivationManager)
            {
                indexManagerPair.Value.DisableSpatialOSBehaviours();
            }

            foreach (var gameObjectComponentDispatcher in gameObjectComponentDispatchers)
            {
                gameObjectComponentDispatcher.InvokeOnAuthorityLostCallbacks(entityToReaderWriterStore);
            }

            foreach (var gameObjectComponentDispatcher in gameObjectComponentDispatchers)
            {
                gameObjectComponentDispatcher.InvokeOnComponentUpdateCallbacks(entityToReaderWriterStore);
                gameObjectComponentDispatcher.InvokeOnEventCallbacks(entityToReaderWriterStore);
            }

            foreach (var gameObjectComponentDispatcher in gameObjectComponentDispatchers)
            {
                gameObjectComponentDispatcher.InvokeOnAuthorityGainedCallbacks(entityToReaderWriterStore);
            }

            foreach (var gameObjectComponentDispatcher in gameObjectComponentDispatchers)
            {
                gameObjectComponentDispatcher.MarkAuthorityGainedForActivation(entityToActivationManager);
                gameObjectComponentDispatcher.MarkComponentsAddedForActivation(entityToActivationManager);
            }

            foreach (var indexManagerPair in entityToActivationManager)
            {
                indexManagerPair.Value.EnableSpatialOSBehaviours();
            }

            foreach (var gameObjectComponentDispatcher in gameObjectComponentDispatchers)
            {
                gameObjectComponentDispatcher.InvokeOnAuthorityLossImminentCallbacks(entityToReaderWriterStore);
                gameObjectComponentDispatcher.InvokeOnCommandRequestCallbacks(entityToReaderWriterStore);
                gameObjectComponentDispatcher.InvokeOnCommandResponseCallbacks(entityToReaderWriterStore);
            }
        }

        private void CreateActivationManagerAndReaderWriterStore(Entity entity)
        {
            if (entityToActivationManager.ContainsKey(entity))
            {
                throw new SystemException($"MonoBehaviourActivationManager already exists for entity {entity.Index}.");
            }

            var store = new InjectableStore();
            entityToReaderWriterStore.Add(entity, store);
            var gameObject = EntityManager.GetComponentObject<GameObjectReference>(entity).GameObject;
            var manager = new MonoBehaviourActivationManager(gameObject, injector, store, logger);
            entityToActivationManager.Add(entity, manager);
        }

        private void RemoveActivationManagerAndReaderWriterStore(Entity entity)
        {
            if (!entityToActivationManager.TryGetValue(entity, out var activationManager))
            {
                throw new KeyNotFoundException($"MonoBehaviourActivationManager not found for entity {entity.Index}.");
            }

            entityToActivationManager.Remove(entity);
            entityToReaderWriterStore.Remove(entity);

            // Disable enabled SpatialOSBehaviours and dispose leftover Requirables.
            activationManager.Dispose();
        }
    }
}
