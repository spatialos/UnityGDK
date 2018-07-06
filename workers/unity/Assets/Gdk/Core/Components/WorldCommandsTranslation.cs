using System.Collections.Generic;
using Improbable.Gdk.Core.Components;
using Improbable.Worker;
using Improbable.Worker.Query;
using Tests;
using Unity.Entities;
using UnityEngine;
using Entity = Unity.Entities.Entity;
using TimeoutOption = Improbable.Collections.Option<uint>;

namespace Improbable.Gdk.Core
{
    public struct CreateEntityRequest
    {
        public Worker.Entity Entity;
        public Collections.Option<EntityId> EntityId;
        public uint TimeoutMillis;
        public long SenderEntityId;
    }

    public struct DeleteEntityRequest
    {
        public long EntityId;
        public uint TimeoutMillis;
        public long SenderEntityId;
    }

    public struct ReserveEntityIdsRequest
    {
        public uint NumberOfEntityIds;
        public uint TimeoutMillis;
        public long SenderEntityId;
    }

    public struct EntityQueryRequest
    {
        public Worker.Query.EntityQuery EntityQuery;
        public uint TimeoutMillis;
        public long SenderEntityId;
    }

    public struct CreateEntityResponse : IIncomingCommandResponse
    {
        public CommandStatusCode StatusCode { get; }
        public string Message { get; }
        public long EntityId { get; }
        public CreateEntityRequest RawRequest { get; }

        internal CreateEntityResponse(CommandStatusCode statusCode, string message, long entityId,
            CreateEntityRequest req)
        {
            StatusCode = statusCode;
            Message = message;
            EntityId = entityId;
            RawRequest = req;
        }
    }

    public struct DeleteEntityResponse : IIncomingCommandResponse
    {
        public CommandStatusCode StatusCode { get; }
        public string Message { get; }
        public long EntityId { get; }
        public DeleteEntityRequest RawRequest { get; }

        internal DeleteEntityResponse(CommandStatusCode statusCode, string message, long entityId,
            DeleteEntityRequest req)
        {
            StatusCode = statusCode;
            Message = message;
            EntityId = entityId;
            RawRequest = req;
        }
    }

    public struct ReserveEntityIdsResponse : IIncomingCommandResponse
    {
        public CommandStatusCode StatusCode { get; }
        public string Message { get; }
        public long FirstEntityId { get; }
        public int NumberOfEntityIds { get; }
        public ReserveEntityIdsRequest RawRequest { get; }

        internal ReserveEntityIdsResponse(CommandStatusCode statusCode, string message, long firstEntityId,
            int numberOfEntityIds, ReserveEntityIdsRequest req)
        {
            StatusCode = statusCode;
            Message = message;
            FirstEntityId = firstEntityId;
            NumberOfEntityIds = numberOfEntityIds;
            RawRequest = req;
        }
    }

    public struct EntityQueryResponse : IIncomingCommandResponse
    {
        public CommandStatusCode StatusCode { get; }
        public string Message { get; }
        public int ResultCount { get; }
        public Dictionary<long, Worker.Entity> Result { get; }
        public EntityQueryRequest RawRequest { get; }

        internal EntityQueryResponse(CommandStatusCode statusCode, string message, int resultCount,
            Dictionary<long, Worker.Entity> result, EntityQueryRequest req)
        {
            StatusCode = statusCode;
            Message = message;
            ResultCount = resultCount;
            Result = result;
            RawRequest = req;
        }
    }

    public struct WorldCommandSender : IComponentData
    {
        private long EntityId { get; }

        private uint HandleToTranslation { get; }

        public WorldCommandSender(long entityId, uint handleToTranslation)
        {
            EntityId = entityId;
            HandleToTranslation = handleToTranslation;
        }

        public void SendCreateEntityRequest(Worker.Entity entity, long entityId = 0, uint timeoutMillis = 0)
        {
            WorldCommandsTranslation translation =
                (WorldCommandsTranslation) ComponentTranslation.HandleToTranslation[HandleToTranslation];

            var entityIdOption = entityId != 0
                ? new Collections.Option<EntityId>(new EntityId(entityId))
                : new Collections.Option<EntityId>();

            translation.CreateEntityRequests.Add(new CreateEntityRequest
            {
                Entity = entity,
                EntityId = entityIdOption,
                TimeoutMillis = timeoutMillis,
                SenderEntityId = EntityId
            });
        }

        public void SendDeleteEntityRequest(long entityId, uint timeoutMillis = 0)
        {
            WorldCommandsTranslation translation =
                (WorldCommandsTranslation) ComponentTranslation.HandleToTranslation[HandleToTranslation];
            translation.DeleteEntityRequests.Add(new DeleteEntityRequest
            {
                EntityId = entityId,
                TimeoutMillis = timeoutMillis,
                SenderEntityId = EntityId
            });
        }

        public void SendReserveEntityIdsRequest(uint numberOfEntities, uint timeoutMillis = 0)
        {
            WorldCommandsTranslation translation =
                (WorldCommandsTranslation) ComponentTranslation.HandleToTranslation[HandleToTranslation];
            translation.ReserveEntityIdsRequests.Add(new ReserveEntityIdsRequest
            {
                NumberOfEntityIds = numberOfEntities,
                TimeoutMillis = timeoutMillis,
                SenderEntityId = EntityId
            });
        }

        public void SendEntityQueryRequest(Worker.Query.EntityQuery entityQuery, uint timeoutMillis = 0)
        {
            WorldCommandsTranslation translation =
                (WorldCommandsTranslation) ComponentTranslation.HandleToTranslation[HandleToTranslation];
            translation.EntityQueryRequests.Add(new EntityQueryRequest
            {
                EntityQuery = entityQuery,
                TimeoutMillis = timeoutMillis,
                SenderEntityId = EntityId
            });
        }
    }

    public class WorldCommandsTranslation : ComponentTranslation
    {
        public override ComponentType TargetComponentType => targetComponentType;
        private static readonly ComponentType targetComponentType = null;

        public override ComponentType[] ReplicationComponentTypes => replicationComponentTypes;
        private static readonly ComponentType[] replicationComponentTypes = { };

        public override ComponentType[] CleanUpComponentTypes => cleanUpComponentTypes;

        private static readonly ComponentType[] cleanUpComponentTypes =
        {
            typeof(CommandResponses<CreateEntityResponse>),
            typeof(CommandResponses<DeleteEntityResponse>),
            typeof(CommandResponses<ReserveEntityIdsResponse>),
            typeof(CommandResponses<EntityQueryResponse>),
        };

        private readonly Dictionary<uint, CreateEntityRequest> requestIdToCreateEntityRequest
            = new Dictionary<uint, CreateEntityRequest>();

        private Dictionary<uint, DeleteEntityRequest> requestIdToDeleteEntityRequest
            = new Dictionary<uint, DeleteEntityRequest>();

        private Dictionary<uint, ReserveEntityIdsRequest> requestIdToReserveEntityIdsRequest
            = new Dictionary<uint, ReserveEntityIdsRequest>();

        private Dictionary<uint, EntityQueryRequest> requestIdToEntityQueryRequest
            = new Dictionary<uint, EntityQueryRequest>();
        // Also for other 3!

        internal List<CreateEntityRequest> CreateEntityRequests = new List<CreateEntityRequest>();
        internal List<DeleteEntityRequest> DeleteEntityRequests = new List<DeleteEntityRequest>();
        internal List<ReserveEntityIdsRequest> ReserveEntityIdsRequests = new List<ReserveEntityIdsRequest>();
        internal List<EntityQueryRequest> EntityQueryRequests = new List<EntityQueryRequest>();

        private static readonly ComponentPool<CommandResponses<CreateEntityResponse>> createEntityResponsePool =
            new ComponentPool<CommandResponses<CreateEntityResponse>>(
                () => new CommandResponses<CreateEntityResponse>(),
                component => component.Buffer.Clear());

        private static readonly ComponentPool<CommandResponses<DeleteEntityResponse>> deleteEntityResponsePool =
            new ComponentPool<CommandResponses<DeleteEntityResponse>>(
                () => new CommandResponses<DeleteEntityResponse>(),
                component => component.Buffer.Clear());

        private static readonly ComponentPool<CommandResponses<ReserveEntityIdsResponse>> reserveEntityIdsResponsesPool
            = new ComponentPool<CommandResponses<ReserveEntityIdsResponse>>(
                () => new CommandResponses<ReserveEntityIdsResponse>(),
                component => component.Buffer.Clear());

        private static readonly ComponentPool<CommandResponses<EntityQueryResponse>> entityQueryResponsePool =
            new ComponentPool<CommandResponses<EntityQueryResponse>>(
                () => new CommandResponses<EntityQueryResponse>(),
                component => component.Buffer.Clear());

        public WorldCommandsTranslation(MutableView view) : base(view)
        {
        }

        public override void AddCommandRequestSender(Entity entity, long EntityId)
        {
            view.AddComponent(entity, new WorldCommandSender(EntityId, translationHandle));
        }

        public override void ExecuteReplication(Connection connection)
        {
        }

        public override void SendCommands(Connection connection)
        {
            foreach (var request in CreateEntityRequests)
            {
                var requestId = connection.SendCreateEntityRequest(request.Entity, request.EntityId,
                    new TimeoutOption(request.TimeoutMillis));

                requestIdToCreateEntityRequest.Add(requestId.Id, request);
            }

            CreateEntityRequests.Clear();

            foreach (var request in DeleteEntityRequests)
            {
                var requestId = connection.SendDeleteEntityRequest(new EntityId(request.EntityId),
                    new TimeoutOption(request.TimeoutMillis));

                requestIdToDeleteEntityRequest.Add(requestId.Id, request);
            }

            DeleteEntityRequests.Clear();

            foreach (var request in ReserveEntityIdsRequests)
            {
                var requestId = connection.SendReserveEntityIdsRequest(request.NumberOfEntityIds,
                    new TimeoutOption(request.TimeoutMillis));

                requestIdToReserveEntityIdsRequest.Add(requestId.Id, request);
            }

            ReserveEntityIdsRequests.Clear();

            foreach (var request in EntityQueryRequests)
            {
                var requestId = connection.SendEntityQueryRequest(request.EntityQuery,
                    new TimeoutOption(request.TimeoutMillis));

                requestIdToEntityQueryRequest.Add(requestId.Id, request);
            }

            EntityQueryRequests.Clear();
        }

        public override void CleanUpComponents(ref EntityCommandBuffer entityCommandBuffer)
        {
            RemoveComponents<CommandResponses<CreateEntityResponse>>(ref entityCommandBuffer, 0);
            RemoveComponents<CommandResponses<DeleteEntityResponse>>(ref entityCommandBuffer, 1);
            RemoveComponents<CommandResponses<ReserveEntityIdsResponse>>(ref entityCommandBuffer, 2);
            RemoveComponents<CommandResponses<EntityQueryResponse>>(ref entityCommandBuffer, 3);
        }

        public override void RegisterWithDispatcher(Dispatcher dispatcher)
        {
            dispatcher.OnCreateEntityResponse(OnCreateEntityResponse);
            dispatcher.OnDeleteEntityResponse(OnDeleteEntityResponse);
            dispatcher.OnReserveEntityIdsResponse(OnReserveEntityIdResponse);
            dispatcher.OnEntityQueryResponse(OnEntityQueryResponse);
        }

        public void OnCreateEntityResponse(CreateEntityResponseOp op)
        {
            CreateEntityRequest request = requestIdToCreateEntityRequest[op.RequestId.Id];
            requestIdToCreateEntityRequest.Remove(op.RequestId.Id);

            var response =
                new CreateEntityResponse((CommandStatusCode) op.StatusCode, op.Message, op.EntityId.Value.Id, request);
            Entity entity;
            if (!TryGetEntityFromEntityId(request.SenderEntityId, "CreateEntity", out entity))
            {
                return;
            }

            view.AddCommandResponse(entity, response, createEntityResponsePool);
        }

        public void OnDeleteEntityResponse(DeleteEntityResponseOp op)
        {
            DeleteEntityRequest request = requestIdToDeleteEntityRequest[op.RequestId.Id];
            requestIdToDeleteEntityRequest.Remove(op.RequestId.Id);

            var response =
                new DeleteEntityResponse((CommandStatusCode) op.StatusCode, op.Message, op.EntityId.Id, request);
            Entity entity;
            if (!TryGetEntityFromEntityId(request.SenderEntityId, "DeleteEntity", out entity))
            {
                return;
            }

            view.AddCommandResponse(entity, response, deleteEntityResponsePool);
        }

        public void OnReserveEntityIdResponse(ReserveEntityIdsResponseOp op)
        {
            ReserveEntityIdsRequest request = requestIdToReserveEntityIdsRequest[op.RequestId.Id];
            requestIdToReserveEntityIdsRequest.Remove(op.RequestId.Id);

            var response = new ReserveEntityIdsResponse((CommandStatusCode) op.StatusCode, op.Message,
                op.FirstEntityId.Value.Id, op.NumberOfEntityIds, request);
            Entity entity;
            if (!TryGetEntityFromEntityId(request.SenderEntityId, "ReserveEntityIds", out entity))
            {
                return;
            }

            view.AddCommandResponse(entity, response, reserveEntityIdsResponsesPool);
        }

        public void OnEntityQueryResponse(EntityQueryResponseOp op)
        {
            EntityQueryRequest request = requestIdToEntityQueryRequest[op.RequestId.Id];
            requestIdToEntityQueryRequest.Remove(op.RequestId.Id);

            var result = new Dictionary<long, Worker.Entity>();
            foreach (var pair in op.Result)
            {
                result.Add(pair.Key.Id, pair.Value);
            }

            var response =
                new EntityQueryResponse((CommandStatusCode) op.StatusCode, op.Message, op.ResultCount, result, request);

            Entity entity;
            if (!TryGetEntityFromEntityId(request.SenderEntityId, "EntityQuery", out entity))
            {
                return;
            }

            view.AddCommandResponse(entity, response, entityQueryResponsePool);
        }

        private bool TryGetEntityFromEntityId(long entityId, string responseName, out Entity entity)
        {
            entity = Entity.Null;
            if (entityId == MutableView.WorkerEntityId)
            {
                entity = view.WorkerEntity;
            }
            else if (!view.TryGetEntity(entityId, out entity))
            {
                Debug.LogWarningFormat(TranslationErrors.CannotFindEntityForWorldCommandResponse, entityId,
                    responseName);
                return false;
            }

            return true;
        }
    }
}
