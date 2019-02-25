using System;
using System.Collections.Generic;
using Improbable.Gdk.Core.Commands;
using Unity.Entities;
using Improbable.Gdk.Subscriptions;
using Improbable.Worker;
using Improbable.Worker.Core;
using Entity = Unity.Entities.Entity;

namespace Improbable.Gdk.Core
{
    [AutoRegisterSubscriptionManager]
    public class WorldCommandSenderSubscriptionManager : SubscriptionManager<WorldCommandSender>
    {
        private readonly Dispatcher dispatcher;
        private readonly World world;
        private readonly WorkerSystem workerSystem;

        private Dictionary<EntityId, HashSet<Subscription<WorldCommandSender>>>
            entityIdToSenderSubscriptions =
                new Dictionary<EntityId, HashSet<Subscription<WorldCommandSender>>>();

        public WorldCommandSenderSubscriptionManager(World world)
        {
            this.world = world;

            // Check that these are there
            dispatcher = world.GetExistingManager<SpatialOSReceiveSystem>().Dispatcher;
            workerSystem = world.GetExistingManager<WorkerSystem>();

            dispatcher.OnAddEntity(op =>
            {
                if (!entityIdToSenderSubscriptions.TryGetValue(op.EntityId, out var subscriptions))
                {
                    return;
                }

                foreach (var subscription in subscriptions)
                {
                    subscription.SetUnavailable();
                }
            });

            dispatcher.OnRemoveEntity(op =>
            {
                if (!entityIdToSenderSubscriptions.TryGetValue(op.EntityId, out var subscriptions))
                {
                    return;
                }

                workerSystem.TryGetEntity(op.EntityId, out var entity);
                foreach (var subscription in subscriptions)
                {
                    subscription.SetAvailable(new WorldCommandSender(entity, world));
                }
            });
        }

        public override Subscription<WorldCommandSender> Subscribe(EntityId entityId)
        {
            if (entityIdToSenderSubscriptions == null)
            {
                entityIdToSenderSubscriptions = new Dictionary<EntityId, HashSet<Subscription<WorldCommandSender>>>();
            }

            var subscription = new Subscription<WorldCommandSender>(this, entityId);

            if (!entityIdToSenderSubscriptions.TryGetValue(entityId, out var subscriptions))
            {
                subscriptions = new HashSet<Subscription<WorldCommandSender>>();
                entityIdToSenderSubscriptions.Add(entityId, subscriptions);

                if (workerSystem.TryGetEntity(entityId, out var entity))
                {
                    subscription.SetAvailable(new WorldCommandSender(entity, world));
                }
            }

            subscriptions.Add(subscription);
            return subscription;
        }

        public override void Cancel(EntityId entityId, ITypeErasedSubscription subscription)
        {
            var sub = ((Subscription<WorldCommandSender>) subscription);
            var sender = sub.Value;
            sender.IsValid = false;

            var subscriptions = entityIdToSenderSubscriptions[entityId];
            subscriptions.Remove(sub);
            if (subscriptions.Count == 0)
            {
                entityIdToSenderSubscriptions.Remove(entityId);
            }
        }

        public override void Invalidate(EntityId entityId, ITypeErasedSubscription subscription)
        {
            var sub = ((Subscription<WorldCommandSender>) subscription);
            if (sub.HasValue)
            {
                var sender = sub.Value;
                sender.IsValid = false;
            }
        }

        public override void Restore(EntityId entityId, ITypeErasedSubscription subscription)
        {
            var sub = ((Subscription<WorldCommandSender>) subscription);
            if (sub.HasValue)
            {
                sub.Value.IsValid = true;
            }
        }
    }

    public class WorldCommandSender
    {
        public bool IsValid;

        private readonly Entity entity;
        private readonly CommandSystem commandSystem;
        private readonly CommandCallbackSystem callbackSystem;

        public WorldCommandSender(Entity entity, World world)
        {
            this.entity = entity;
            IsValid = true;
            callbackSystem = world.GetOrCreateManager<CommandCallbackSystem>();
            // todo check if this exists probably put getting this in a static function that does it in one place
            commandSystem = world.GetExistingManager<CommandSystem>();
        }

        public void SendCreateEntityCommand(WorldCommands.CreateEntity.Request request,
            Action<WorldCommands.CreateEntity.ReceivedResponse> callback = null)
        {
            var requestId = commandSystem.SendCommand(request, entity);
            if (callback == null)
            {
                return;
            }

            Action<WorldCommands.CreateEntity.ReceivedResponse> wrappedCallback = response =>
            {
                if (IsValid)
                {
                    callback(response);
                }
            };
            callbackSystem.RegisterCommandResponseCallback(requestId, wrappedCallback);
        }

        public void SendDeleteEntityCommand(WorldCommands.DeleteEntity.Request request,
            Action<WorldCommands.DeleteEntity.ReceivedResponse> callback = null)
        {
            var requestId = commandSystem.SendCommand(request, entity);
            if (callback == null)
            {
                return;
            }

            Action<WorldCommands.DeleteEntity.ReceivedResponse> wrappedCallback = response =>
            {
                if (IsValid)
                {
                    callback(response);
                }
            };
            callbackSystem.RegisterCommandResponseCallback(requestId, wrappedCallback);
        }

        public void SendReserveEntityIdsCommand(WorldCommands.ReserveEntityIds.Request request,
            Action<WorldCommands.ReserveEntityIds.ReceivedResponse> callback = null)
        {
            var requestId = commandSystem.SendCommand(request, entity);
            if (callback == null)
            {
                return;
            }

            Action<WorldCommands.ReserveEntityIds.ReceivedResponse> wrappedCallback = response =>
            {
                if (IsValid)
                {
                    callback(response);
                }
            };
            callbackSystem.RegisterCommandResponseCallback(requestId, wrappedCallback);
        }

        public void SendEntityQueryCommand(WorldCommands.EntityQuery.Request request,
            Action<WorldCommands.EntityQuery.ReceivedResponse> callback = null)
        {
            var requestId = commandSystem.SendCommand(request, entity);
            if (callback == null)
            {
                return;
            }

            Action<WorldCommands.EntityQuery.ReceivedResponse> wrappedCallback = response =>
            {
                if (IsValid)
                {
                    callback(response);
                }
            };
            callbackSystem.RegisterCommandResponseCallback(requestId, wrappedCallback);
        }
    }
}
