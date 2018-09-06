using System;
using System.Linq;
using Improbable.Gdk.Core.Commands;
using Unity.Collections;
using Unity.Entities;

#region Diagnostic control

// Disable the "variable is never assigned" for injected fields.
#pragma warning disable 649

// ReSharper disable ClassNeverInstantiated.Global

#endregion


namespace Improbable.Gdk.Core.GameObjectRepresentation
{
    public class GameObjectWorldCommandSystem : ComponentSystem
    {
        private struct ReserveEntityIdsResponseData
        {
            [ReadOnly] public readonly int Length;
            [ReadOnly] public EntityArray Entities;
            [ReadOnly] public ComponentDataArray<WorldCommands.ReserveEntityIds.CommandResponses> CommandResponses;
            [ReadOnly] public ComponentArray<GameObjectReference> HasGameObjectReference;
        }

        private struct CreateEntityResponseData
        {
            [ReadOnly] public readonly int Length;
            [ReadOnly] public EntityArray Entities;
            [ReadOnly] public ComponentDataArray<WorldCommands.CreateEntity.CommandResponses> CommandResponses;
            [ReadOnly] public ComponentArray<GameObjectReference> HasGameObjectReference;
        }

        private struct DeleteEntityResponseData
        {
            [ReadOnly] public readonly int Length;
            [ReadOnly] public EntityArray Entities;
            [ReadOnly] public ComponentDataArray<WorldCommands.DeleteEntity.CommandResponses> CommandResponses;
            [ReadOnly] public ComponentArray<GameObjectReference> HasGameObjectReference;
        }

        [Inject] private GameObjectDispatcherSystem gameObjectDispatcherSystem;
        [Inject] private ReserveEntityIdsResponseData reserveEntityIdsResponseData;
        [Inject] private CreateEntityResponseData createEntityResponseData;
        [Inject] private DeleteEntityResponseData deleteEntityResponseData;

        private static readonly InjectableId WorldCommandResponseHandlerInjectableId =
            new InjectableId(InjectableType.WorldCommandResponseHandler, InjectableId.NullComponentId);

        protected override void OnUpdate()
        {
            for (var i = 0; i < reserveEntityIdsResponseData.Length; ++i)
            {
                var entity = reserveEntityIdsResponseData.Entities[i];
                var worldCommandResponseHandlers = GetWorldCommandResponseHandlersForEntity(entity);

                if (worldCommandResponseHandlers == null)
                {
                    continue;
                }

                foreach (var receivedResponse in reserveEntityIdsResponseData.CommandResponses[i].Responses)
                {
                    foreach (var worldCommandHandler in worldCommandResponseHandlers)
                    {
                        worldCommandHandler.OnReserveEntityIdsResponseInternal(receivedResponse);
                    }
                }
            }

            for (var i = 0; i < createEntityResponseData.Length; ++i)
            {
                var entity = createEntityResponseData.Entities[i];
                var worldCommandResponseHandlers = GetWorldCommandResponseHandlersForEntity(entity);

                if (worldCommandResponseHandlers == null)
                {
                    continue;
                }

                foreach (var receivedResponse in createEntityResponseData.CommandResponses[i].Responses)
                {
                    foreach (var worldCommandHandler in worldCommandResponseHandlers)
                    {
                        worldCommandHandler.OnCreateEntityResponseInternal(receivedResponse);
                    }
                }
            }

            for (var i = 0; i < deleteEntityResponseData.Length; ++i)
            {
                var entity = deleteEntityResponseData.Entities[i];
                var worldCommandResponseHandlers = GetWorldCommandResponseHandlersForEntity(entity);

                if (worldCommandResponseHandlers == null)
                {
                    continue;
                }

                foreach (var receivedResponse in deleteEntityResponseData.CommandResponses[i].Responses)
                {
                    foreach (var worldCommandHandler in worldCommandResponseHandlers)
                    {
                        worldCommandHandler.OnDeleteEntityResponseInternal(receivedResponse);
                    }
                }
            }
        }

        private WorldCommands.Requirables.WorldCommandResponseHandler[] GetWorldCommandResponseHandlersForEntity(
            Entity entity)
        {
            var entityToReaderWriterStore = gameObjectDispatcherSystem.entityToReaderWriterStore;

            if (!entityToReaderWriterStore.TryGetValue(entity, out var injectableStore))
            {
                return null;
            }

            if (!injectableStore.TryGetInjectablesForComponent(WorldCommandResponseHandlerInjectableId,
                out var injectables))
            {
                return null;
            }

            if (injectables.Count == 0)
            {
                return null;
            }

            return Array.ConvertAll(injectables.ToArray(),
                injectable => (WorldCommands.Requirables.WorldCommandResponseHandler) injectable);
        }
    }
}
