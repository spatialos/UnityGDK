using System;
using System.Collections.Generic;
using Improbable.Gdk.Core;
using Improbable.Worker.CInterop;
using Unity.Entities;
using Entity = Unity.Entities.Entity;

namespace Improbable.Gdk.Subscriptions
{
    public interface ICommandSender : IRequireable
    {
    }

    public interface ICommandReceiver : IRequireable
    {
    }

    public abstract class CommandSenderSubscriptionManagerBase<T> : SubscriptionManager<T>
        where T : ICommandSender
    {
        private Dictionary<EntityId, HashSet<Subscription<T>>>
            entityIdToSenderSubscriptions =
                new Dictionary<EntityId, HashSet<Subscription<T>>>();

        protected CommandSenderSubscriptionManagerBase(World world) : base(world)
        {
            var constraintSystem = world.GetExistingSystem<ComponentConstraintsCallbackSystem>();

            constraintSystem.RegisterEntityAddedCallback(entityId =>
            {
                if (!entityIdToSenderSubscriptions.TryGetValue(entityId, out var subscriptions))
                {
                    return;
                }

                var entity = WorkerSystem.GetEntity(entityId);

                foreach (var subscription in subscriptions)
                {
                    if (!subscription.HasValue)
                    {
                        subscription.SetAvailable(CreateSender(entity, world));
                    }
                }
            });

            constraintSystem.RegisterEntityRemovedCallback(entityId =>
            {
                if (!entityIdToSenderSubscriptions.TryGetValue(entityId, out var subscriptions))
                {
                    return;
                }

                foreach (var subscription in subscriptions)
                {
                    if (subscription.HasValue)
                    {
                        ResetValue(subscription);
                        subscription.SetUnavailable();
                    }
                }
            });
        }

        protected abstract T CreateSender(Entity entity, World world);

        public override Subscription<T> Subscribe(EntityId entityId)
        {
            if (entityIdToSenderSubscriptions == null)
            {
                entityIdToSenderSubscriptions = new Dictionary<EntityId, HashSet<Subscription<T>>>();
            }

            if (entityId.Id < 0)
            {
                throw new ArgumentException("EntityId can not be < 0");
            }

            var subscription = new Subscription<T>(this, entityId);

            if (!entityIdToSenderSubscriptions.TryGetValue(entityId, out var subscriptions))
            {
                subscriptions = new HashSet<Subscription<T>>();
                entityIdToSenderSubscriptions.Add(entityId, subscriptions);
            }

            if (WorkerSystem.TryGetEntity(entityId, out var entity))
            {
                subscription.SetAvailable(CreateSender(entity, World));
            }
            else if (entityId.Id == 0)
            {
                subscription.SetAvailable(CreateSender(Entity.Null, World));
            }

            subscriptions.Add(subscription);
            return subscription;
        }

        public override void Cancel(ISubscription subscription)
        {
            var sub = ((Subscription<T>) subscription);
            ResetValue(sub);

            var subscriptions = entityIdToSenderSubscriptions[sub.EntityId];
            subscriptions.Remove(sub);
            if (subscriptions.Count == 0)
            {
                entityIdToSenderSubscriptions.Remove(sub.EntityId);
            }
        }

        public override void ResetValue(ISubscription subscription)
        {
            var sub = ((Subscription<T>) subscription);
            if (sub.HasValue)
            {
                var sender = sub.Value;
                sender.IsValid = false;
            }
        }
    }

    public abstract class CommandReceiverSubscriptionManagerBase<T> : SubscriptionManager<T>
        where T : ICommandReceiver
    {
        private readonly EntityManager entityManager;

        private Dictionary<EntityId, HashSet<Subscription<T>>> entityIdToReceiveSubscriptions;

        private HashSet<EntityId> entitiesMatchingRequirements = new HashSet<EntityId>();
        private HashSet<EntityId> entitiesNotMatchingRequirements = new HashSet<EntityId>();

        private readonly ComponentType componentAuthType;

        protected CommandReceiverSubscriptionManagerBase(World world, uint componentId) : base(world)
        {
            var componentMetaClass = ComponentDatabase.GetMetaclass(componentId);
            componentAuthType = componentMetaClass.Authority;

            entityManager = world.EntityManager;

            var constraintSystem = world.GetExistingSystem<ComponentConstraintsCallbackSystem>();

            constraintSystem.RegisterAuthorityCallback(componentId, authorityChange =>
            {
                if (authorityChange.Authority == Authority.Authoritative)
                {
                    if (!entitiesNotMatchingRequirements.Contains(authorityChange.EntityId))
                    {
                        return;
                    }

                    var entity = WorkerSystem.GetEntity(authorityChange.EntityId);

                    foreach (var subscription in entityIdToReceiveSubscriptions[authorityChange.EntityId])
                    {
                        subscription.SetAvailable(CreateReceiver(world, entity, authorityChange.EntityId));
                    }

                    entitiesMatchingRequirements.Add(authorityChange.EntityId);
                    entitiesNotMatchingRequirements.Remove(authorityChange.EntityId);
                }
                else if (authorityChange.Authority == Authority.NotAuthoritative)
                {
                    if (!entitiesMatchingRequirements.Contains(authorityChange.EntityId))
                    {
                        return;
                    }

                    foreach (var subscription in entityIdToReceiveSubscriptions[authorityChange.EntityId])
                    {
                        ResetValue(subscription);
                        subscription.SetUnavailable();
                    }

                    entitiesNotMatchingRequirements.Add(authorityChange.EntityId);
                    entitiesMatchingRequirements.Remove(authorityChange.EntityId);
                }
            });
        }

        protected abstract T CreateReceiver(World world, Entity entity, EntityId entityId);

        public override Subscription<T> Subscribe(EntityId entityId)
        {
            if (entityIdToReceiveSubscriptions == null)
            {
                entityIdToReceiveSubscriptions = new Dictionary<EntityId, HashSet<Subscription<T>>>();
            }

            var subscription = new Subscription<T>(this, entityId);

            if (!entityIdToReceiveSubscriptions.TryGetValue(entityId, out var subscriptions))
            {
                subscriptions = new HashSet<Subscription<T>>();
                entityIdToReceiveSubscriptions.Add(entityId, subscriptions);
            }

            if (WorkerSystem.TryGetEntity(entityId, out var entity)
                && entityManager.HasComponent(entity, componentAuthType))
            {
                entitiesMatchingRequirements.Add(entityId);
                subscription.SetAvailable(CreateReceiver(World, entity, entityId));
            }
            else
            {
                entitiesNotMatchingRequirements.Add(entityId);
            }

            subscriptions.Add(subscription);
            return subscription;
        }

        public override void Cancel(ISubscription subscription)
        {
            var sub = ((Subscription<T>) subscription);
            ResetValue(sub);

            var subscriptions = entityIdToReceiveSubscriptions[sub.EntityId];
            subscriptions.Remove(sub);
            if (subscriptions.Count == 0)
            {
                entityIdToReceiveSubscriptions.Remove(sub.EntityId);
                entitiesMatchingRequirements.Remove(sub.EntityId);
                entitiesNotMatchingRequirements.Remove(sub.EntityId);
            }
        }

        public override void ResetValue(ISubscription subscription)
        {
            var sub = ((Subscription<T>) subscription);
            if (sub.HasValue)
            {
                var receiver = sub.Value;
                receiver.IsValid = false;
                receiver.RemoveAllCallbacks();
            }
        }
    }
}
