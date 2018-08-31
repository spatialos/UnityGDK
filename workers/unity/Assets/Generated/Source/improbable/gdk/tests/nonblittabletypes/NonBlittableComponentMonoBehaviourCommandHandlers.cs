
// ===========
// DO NOT EDIT - this file is automatically regenerated.
// ===========

using System;
using System.Collections.Generic;
using Improbable;
using Improbable.Gdk.Core;
using Improbable.Gdk.Core.GameObjectRepresentation;
using Improbable.Worker;
using Unity.Entities;
using UnityEngine;

namespace Generated.Improbable.Gdk.Tests.NonblittableTypes
{
    public partial class NonBlittableComponent
    {
        public partial class FirstCommand
        {
            public struct RequestResponder {
                private readonly EntityManager entityManager;
                private readonly Entity entity;
                public FirstCommand.ReceivedRequest Request { get; }

                internal RequestResponder(EntityManager entityManager, Entity entity, FirstCommand.ReceivedRequest request)
                {
                    this.entity = entity;
                    this.entityManager = entityManager;
                    Request = request;
                }

                public void SendResponse(global::Generated.Improbable.Gdk.Tests.NonblittableTypes.FirstCommandResponse payload)
                {
                    entityManager.GetComponentData<CommandResponders.FirstCommand>(entity).ResponsesToSend
                        .Add(FirstCommand.CreateResponse(Request, payload));
                }

                public void SendResponseFailure(string message)
                {
                    entityManager.GetComponentData<CommandResponders.FirstCommand>(entity).ResponsesToSend
                        .Add(FirstCommand.CreateResponseFailure(Request, message));
                }
            }
        }
        public partial class SecondCommand
        {
            public struct RequestResponder {
                private readonly EntityManager entityManager;
                private readonly Entity entity;
                public SecondCommand.ReceivedRequest Request { get; }

                internal RequestResponder(EntityManager entityManager, Entity entity, SecondCommand.ReceivedRequest request)
                {
                    this.entity = entity;
                    this.entityManager = entityManager;
                    Request = request;
                }

                public void SendResponse(global::Generated.Improbable.Gdk.Tests.NonblittableTypes.SecondCommandResponse payload)
                {
                    entityManager.GetComponentData<CommandResponders.SecondCommand>(entity).ResponsesToSend
                        .Add(SecondCommand.CreateResponse(Request, payload));
                }

                public void SendResponseFailure(string message)
                {
                    entityManager.GetComponentData<CommandResponders.SecondCommand>(entity).ResponsesToSend
                        .Add(SecondCommand.CreateResponseFailure(Request, message));
                }
            }
        }

        public partial class Requirables
        {
            [InjectableId(InjectableType.CommandRequestSender, 1002)]
            internal class CommandRequestSenderCreator : IInjectableCreator
            {
                public IInjectable CreateInjectable(Entity entity, EntityManager entityManager, ILogDispatcher logDispatcher)
                {
                    return new CommandRequestSender(entity, entityManager, logDispatcher);
                }
            }

            [InjectableId(InjectableType.CommandRequestSender, 1002)]
            [InjectionCondition(InjectionCondition.RequireNothing)]
            public class CommandRequestSender : IInjectable
            {
                private Entity entity;
                private readonly EntityManager entityManager;
                private readonly ILogDispatcher logger;

                public CommandRequestSender(Entity entity, EntityManager entityManager, ILogDispatcher logger)
                {
                    this.entity = entity;
                    this.entityManager = entityManager;
                    this.logger = logger;
                }

                public void SendFirstCommandRequest(EntityId entityId, global::Generated.Improbable.Gdk.Tests.NonblittableTypes.FirstCommandRequest request)
                {
                    var ecsCommandRequestSender = entityManager.GetComponentData<CommandSenders.FirstCommand>(entity);
                    ecsCommandRequestSender.RequestsToSend.Add(FirstCommand.CreateRequest(entityId, request));
                }

                private readonly List<Action<FirstCommand.ReceivedResponse>> firstCommandDelegates = new List<Action<FirstCommand.ReceivedResponse>>();
                public event Action<FirstCommand.ReceivedResponse> OnFirstCommandResponse
                {
                    add => firstCommandDelegates.Add(value);
                    remove => firstCommandDelegates.Remove(value);
                }

                internal void OnFirstCommandResponseInternal(FirstCommand.ReceivedResponse response)
                {
                    GameObjectDelegates.DispatchWithErrorHandling(response, firstCommandDelegates, logger);
                }
                public void SendSecondCommandRequest(EntityId entityId, global::Generated.Improbable.Gdk.Tests.NonblittableTypes.SecondCommandRequest request)
                {
                    var ecsCommandRequestSender = entityManager.GetComponentData<CommandSenders.SecondCommand>(entity);
                    ecsCommandRequestSender.RequestsToSend.Add(SecondCommand.CreateRequest(entityId, request));
                }

                private readonly List<Action<SecondCommand.ReceivedResponse>> secondCommandDelegates = new List<Action<SecondCommand.ReceivedResponse>>();
                public event Action<SecondCommand.ReceivedResponse> OnSecondCommandResponse
                {
                    add => secondCommandDelegates.Add(value);
                    remove => secondCommandDelegates.Remove(value);
                }

                internal void OnSecondCommandResponseInternal(SecondCommand.ReceivedResponse response)
                {
                    GameObjectDelegates.DispatchWithErrorHandling(response, secondCommandDelegates, logger);
                }
            }

            [InjectableId(InjectableType.CommandRequestHandler, 1002)]
            internal class CommandRequestHandlerCreator : IInjectableCreator
            {
                public IInjectable CreateInjectable(Entity entity, EntityManager entityManager, ILogDispatcher logDispatcher)
                {
                    return new CommandRequestHandler(entity, entityManager, logDispatcher);
                }
            }

            [InjectableId(InjectableType.CommandRequestHandler, 1002)]
            [InjectionCondition(InjectionCondition.RequireComponentWithAuthority)]
            public class CommandRequestHandler : IInjectable
            {
                private Entity entity;
                private readonly EntityManager entityManager;
                private readonly ILogDispatcher logger;

                public CommandRequestHandler(Entity entity, EntityManager entityManager, ILogDispatcher logger)
                {
                    this.entity = entity;
                    this.entityManager = entityManager;
                    this.logger = logger;
                }
                private readonly List<Action<FirstCommand.RequestResponder>> firstCommandDelegates = new List<Action<FirstCommand.RequestResponder>>();
                public event Action<FirstCommand.RequestResponder> OnFirstCommandRequest
                {
                    add => firstCommandDelegates.Add(value);
                    remove => firstCommandDelegates.Remove(value);
                }

                internal void OnFirstCommandRequestInternal(FirstCommand.ReceivedRequest request)
                {
                    GameObjectDelegates.DispatchWithErrorHandling(new FirstCommand.RequestResponder(entityManager, entity, request), firstCommandDelegates, logger);
                }
                private readonly List<Action<SecondCommand.RequestResponder>> secondCommandDelegates = new List<Action<SecondCommand.RequestResponder>>();
                public event Action<SecondCommand.RequestResponder> OnSecondCommandRequest
                {
                    add => secondCommandDelegates.Add(value);
                    remove => secondCommandDelegates.Remove(value);
                }

                internal void OnSecondCommandRequestInternal(SecondCommand.ReceivedRequest request)
                {
                    GameObjectDelegates.DispatchWithErrorHandling(new SecondCommand.RequestResponder(entityManager, entity, request), secondCommandDelegates, logger);
                }
            }
        }
    }
}
