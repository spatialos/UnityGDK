﻿using System;
using Improbable.Gdk.GameObjectRepresentation;
using Improbable.Worker.CInterop;
using Unity.Entities;
using Entity = Unity.Entities.Entity;

#region Diagnostic control

// ReSharper disable MemberHidesStaticFromOuterClass
// ReSharper disable UnusedMember.Local
// ReSharper disable UnusedMember.Global

#endregion

namespace Improbable.Gdk.Core.Commands
{
    public static partial class WorldCommands
    {
        public static partial class Requirable
        {
            /// <summary>
            ///     A requirable object which enables sending World Commands in Monobehaviours.
            /// </summary>
            [InjectableId(InjectableType.WorldCommandRequestSender, InjectableId.NullComponentId)]
            [InjectionCondition(InjectionCondition.RequireNothing)]
            public class WorldCommandRequestSender : RequirableBase
            {
                private readonly Entity entity;
                private readonly EntityManager entityManager;
                private readonly CommandSystem commandSystem;

                private WorldCommandRequestSender(World world, Entity entity, EntityManager entityManager,
                    ILogDispatcher logDispatcher) : base(logDispatcher)
                {
                    this.entity = entity;
                    this.entityManager = entityManager;
                    commandSystem = world.GetExistingManager<CommandSystem>();
                }

                /// <summary>
                ///     Sends a ReserveEntityIds command request.
                /// </summary>
                /// <param name="numberOfEntityIds">The number of entity IDs to reserve.</param>
                /// <param name="timeoutMillis">
                ///     (Optional) The command timeout in milliseconds. If not specified, will default to 5 seconds.
                /// </param>
                /// <param name="context">
                ///    (Optional) A context object that will be returned with the command response.
                /// </param>
                /// <returns>The request ID of the command request.</returns>
                public long ReserveEntityIds(uint numberOfEntityIds, uint? timeoutMillis = null, object context = null)
                {
                    if (!IsValid())
                    {
                        return -1;
                    }

                    var request =
                        new WorldCommands.ReserveEntityIds.Request(numberOfEntityIds, timeoutMillis, context);

                    return commandSystem.SendCommand(request, entity);
                }

                /// <summary>
                ///     Sends a ReserveEntityIds command request.
                /// </summary>
                /// <param name="numberOfEntityIds">The number of entity IDs to reserve.</param>
                /// <param name="callback">
                ///     A callback that will be called with the command response.
                /// </param>
                /// <param name="timeoutMillis">
                ///     (Optional) The command timeout in milliseconds. If not specified, will default to 5 seconds.
                /// </param>
                /// <returns>The request ID of the command request.</returns>
                public long ReserveEntityIds(uint numberOfEntityIds, Action<ReserveEntityIds.ReceivedResponse> callback,
                    uint? timeoutMillis = null)
                {
                    if (!IsValid())
                    {
                        return -1;
                    }

                    var request =
                        new WorldCommands.ReserveEntityIds.Request(numberOfEntityIds, timeoutMillis, callback);

                    return commandSystem.SendCommand(request, entity);
                }

                /// <summary>
                ///     Sends a CreateEntity command request.
                /// </summary>
                /// <param name="entityTemplate">
                ///     The EntityTemplate object that defines the SpatialOS components on the to-be-created entity.
                /// </param>
                /// <param name="entityId">
                ///     (Optional) The EntityId that the to-be-created entity should take.
                ///     This should only be provided if received as the result of a ReserveEntityIds command.
                /// </param>
                /// <param name="timeoutMillis">
                ///     (Optional) The command timeout in milliseconds. If not specified, will default to 5 seconds.
                /// </param>
                /// <param name="context">
                ///    (Optional) A context object that will be returned with the command response.
                /// </param>
                /// <returns>The request ID of the command request.</returns>
                public long CreateEntity(EntityTemplate entityTemplate, EntityId? entityId = null,
                    uint? timeoutMillis = null, object context = null)
                {
                    if (!IsValid())
                    {
                        return -1;
                    }

                    var request =
                        new WorldCommands.CreateEntity.Request(entityTemplate, entityId, timeoutMillis, context);

                    return commandSystem.SendCommand(request, entity);
                }

                /// <summary>
                ///     Sends a CreateEntity command request.
                /// </summary>
                /// <param name="entityTemplate">
                ///     The EntityTemplate object that defines the SpatialOS components on the to-be-created entity.
                /// </param>
                /// <param name="callback">
                ///     A callback that will be called with the command response.
                /// </param>
                /// <param name="timeoutMillis">
                ///     (Optional) The command timeout in milliseconds. If not specified, will default to 5 seconds.
                /// </param>
                /// <returns>The request ID of the command request.</returns>
                public long CreateEntity(EntityTemplate entityTemplate, Action<CreateEntity.ReceivedResponse> callback,
                    uint? timeoutMillis = null)
                {
                    if (!IsValid())
                    {
                        return -1;
                    }

                    var request =
                        new WorldCommands.CreateEntity.Request(entityTemplate, null, timeoutMillis, callback);

                    return commandSystem.SendCommand(request, entity);
                }

                /// <summary>
                ///     Sends a CreateEntity command request.
                /// </summary>
                /// <param name="entityTemplate">
                ///     The EntityTemplate object that defines the SpatialOS components on the to-be-created entity.
                /// </param>
                /// <param name="entityId">
                ///     (Optional) The EntityId that the to-be-created entity should take.
                ///     This should only be provided if received as the result of a ReserveEntityIds command.
                /// </param>
                /// <param name="callback">
                ///     A callback that will be called with the command response.
                /// </param>
                /// <param name="timeoutMillis">
                ///     (Optional) The command timeout in milliseconds. If not specified, will default to 5 seconds.
                /// </param>
                /// <returns>The request ID of the command request.</returns>
                public long CreateEntity(EntityTemplate entityTemplate, EntityId entityId,
                    Action<CreateEntity.ReceivedResponse> callback,
                    uint? timeoutMillis = null)
                {
                    if (!IsValid())
                    {
                        return -1;
                    }

                    var request =
                        new WorldCommands.CreateEntity.Request(entityTemplate, entityId, timeoutMillis, callback);

                    return commandSystem.SendCommand(request, entity);
                }

                /// <summary>
                ///     Sends a DeleteEntity command request.
                /// </summary>
                /// <param name="entityId"> The entity ID that is to be deleted.</param>
                /// <param name="timeoutMillis">
                ///     (Optional) The command timeout in milliseconds. If not specified, will default to 5 seconds.
                /// </param>
                /// <param name="context">
                ///    (Optional) A context object that will be returned with the command response.
                /// </param>
                /// <returns>The request ID of the command request.</returns>
                public long DeleteEntity(EntityId entityId, uint? timeoutMillis = null, object context = null)
                {
                    if (!IsValid())
                    {
                        return -1;
                    }

                    var request = new WorldCommands.DeleteEntity.Request(entityId, timeoutMillis, context);

                    return commandSystem.SendCommand(request, entity);
                }

                /// <summary>
                ///     Sends a DeleteEntity command request.
                /// </summary>
                /// <param name="entityId"> The entity ID that is to be deleted.</param>
                /// <param name="callback">
                ///     A callback that will be called with the command response.
                /// </param>
                /// <param name="timeoutMillis">
                ///     (Optional) The command timeout in milliseconds. If not specified, will default to 5 seconds.
                /// </param>
                /// <returns>The request ID of the command request.</returns>
                public long DeleteEntity(EntityId entityId, Action<DeleteEntity.ReceivedResponse> callback,
                    uint? timeoutMillis = null)
                {
                    if (!IsValid())
                    {
                        return -1;
                    }

                    var request = new WorldCommands.DeleteEntity.Request(entityId, timeoutMillis, callback);

                    return commandSystem.SendCommand(request, entity);
                }

                /// <summary>
                ///     Sends an EntityQuery command request.
                /// </summary>
                /// <param name="entityQuery">The EntityQuery object defining the constraints and query type.</param>
                /// <param name="timeoutMillis">
                ///     (Optional) The command timeout in milliseconds. If not specified, will default to 5 seconds.
                /// </param>
                /// <param name="context">
                ///     (Optional) A context object that will be returned with the command response.
                /// </param>
                /// <returns>The request ID of the command request.</returns>
                public long EntityQuery(Improbable.Worker.CInterop.Query.EntityQuery entityQuery, uint? timeoutMillis = null,
                    object context = null)
                {
                    if (!IsValid())
                    {
                        return -1;
                    }

                    var request = new WorldCommands.EntityQuery.Request(entityQuery, timeoutMillis, context);

                    return commandSystem.SendCommand(request, entity);
                }

                /// <summary>
                ///     Sends an EntityQuery command request.
                /// </summary>
                /// <param name="entityQuery">The EntityQuery object defining the constraints and query type.</param>
                /// <param name="callback">
                ///     A callback that will be called with the command response.
                /// </param>
                /// <param name="timeoutMillis">
                ///     (Optional) The command timeout in milliseconds. If not specified, will default to 5 seconds.
                /// </param>
                /// <returns>The request ID of the command request.</returns>
                public long EntityQuery(Improbable.Worker.CInterop.Query.EntityQuery entityQuery,
                    Action<EntityQuery.ReceivedResponse> callback, uint? timeoutMillis = null)
                {
                    if (!IsValid())
                    {
                        return -1;
                    }

                    var request = new WorldCommands.EntityQuery.Request(entityQuery, timeoutMillis, callback);

                    return commandSystem.SendCommand(request, entity);
                }

                [InjectableId(InjectableType.WorldCommandRequestSender, InjectableId.NullComponentId)]
                private class WorldCommandRequestSenderCreator : IInjectableCreator
                {
                    public IInjectable CreateInjectable(World world, Entity entity, EntityManager entityManager,
                        ILogDispatcher logDispatcher)
                    {
                        return new WorldCommandRequestSender(world, entity, entityManager, logDispatcher);
                    }
                }
            }
        }
    }
}
