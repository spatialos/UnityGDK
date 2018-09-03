﻿using System;
using System.Collections.Generic;
using Improbable.Worker;
using Improbable.Worker.Core;
using Unity.Entities;
using UnityEngine;
using Entity = Unity.Entities.Entity;

namespace Improbable.Gdk.Core.GameObjectRepresentation
{
    internal abstract class ReaderWriterBase<TSpatialComponentData, TComponentUpdate>
        : RequirableBase
        where TSpatialComponentData : struct, ISpatialComponentData, IComponentData
        where TComponentUpdate : ISpatialComponentUpdate
    {
        protected readonly Entity Entity;
        protected readonly EntityManager EntityManager;
        protected readonly ILogDispatcher logDispatcher;

        protected ReaderWriterBase(Entity entity, EntityManager entityManager, ILogDispatcher logDispatcher) : base(logDispatcher)
        {
            Entity = entity;
            EntityManager = entityManager;
            this.logDispatcher = logDispatcher;
        }

        public TSpatialComponentData Data
        {
            get
            {
                if (LogErrorIfDisposed())
                {
                    return default(TSpatialComponentData);
                }

                try
                {
                    return EntityManager.GetComponentData<TSpatialComponentData>(Entity);
                }
                catch (Exception e)
                {
                    throw new ReaderDataGetFailedException(e, Entity.Index);
                }
            }
        }

        public void Send(TComponentUpdate update)
        {
            if (LogErrorIfDisposed())
            {
                return;
            }

            try
            {
                var data = EntityManager.GetComponentData<TSpatialComponentData>(Entity);
                ApplyUpdate(update, ref data);
                EntityManager.SetComponentData(Entity, data);
            }
            catch (Exception e)
            {
                throw new WriterDataUpdateFailedException(e, Entity.Index);
            }
        }

        protected abstract void ApplyUpdate(TComponentUpdate update, ref TSpatialComponentData data);

        public Authority Authority
        {
            get
            {
                if (LogErrorIfDisposed())
                {
                    return Authority.NotAuthoritative;
                }

                if (EntityManager.HasComponent<AuthorityLossImminent<TSpatialComponentData>>(Entity))
                {
                    return Authority.AuthorityLossImminent;
                }

                if (EntityManager.HasComponent<Authoritative<TSpatialComponentData>>(Entity))
                {
                    return Authority.Authoritative;
                }

                if (EntityManager.HasComponent<NotAuthoritative<TSpatialComponentData>>(Entity))
                {
                    return Authority.NotAuthoritative;
                }

                throw new AuthorityComponentNotFoundException(
                    $"No authority component found for the entity with index {Entity.Index}.");
            }
        }

        private readonly List<GameObjectDelegates.AuthorityChanged> authorityChangedDelegates
            = new List<GameObjectDelegates.AuthorityChanged>();

        public event GameObjectDelegates.AuthorityChanged AuthorityChanged
        {
            add
            {
                if (LogErrorIfDisposed())
                {
                    return;
                }

                authorityChangedDelegates.Add(value);
            }
            remove
            {
                if (LogErrorIfDisposed())
                {
                    return;
                }

                authorityChangedDelegates.Remove(value);
            }
        }

        /// <summary>
        /// Helper method to dispatch property updates to callbacks while forwarding exceptions to the log dispatcher.
        /// </summary>
        /// <param name="payload">The value for the property update.</param>
        /// <param name="callbacks">The property update handlers.</param>
        /// <typeparam name="T">The property update type.</typeparam>
        protected void DispatchWithErrorHandling<T>(Option<T> payload, List<Action<T>> callbacks)
        {
            if (!payload.HasValue)
            {
                return;
            }

            GameObjectDelegates.DispatchWithErrorHandling(payload.Value, callbacks, logDispatcher);
        }

        public void OnAuthorityChange(Authority authority)
        {
            foreach (var callback in authorityChangedDelegates)
            {
                try
                {
                    callback(authority);
                }
                catch (Exception e)
                {
                    // Log the exception but do not rethrow it, as other delegates should still get called
                    logDispatcher.HandleLog(LogType.Exception, new LogEvent().WithException(e));
                }
            }
        }

        private readonly List<GameObjectDelegates.ComponentUpdated<TComponentUpdate>> componentUpdateDelegates
            = new List<GameObjectDelegates.ComponentUpdated<TComponentUpdate>>();

        public event GameObjectDelegates.ComponentUpdated<TComponentUpdate> ComponentUpdated
        {
            add
            {
                if (LogErrorIfDisposed())
                {
                    return;
                }

                componentUpdateDelegates.Add(value);
            }
            remove
            {
                if (LogErrorIfDisposed())
                {
                    return;
                }

                componentUpdateDelegates.Remove(value);
            }
        }

        public void OnComponentUpdate(TComponentUpdate update)
        {
            foreach (var callback in componentUpdateDelegates)
            {
                try
                {
                    callback(update);
                }
                catch (Exception e)
                {
                    // Log the exception but do not rethrow it, as other delegates should still get called
                    logDispatcher.HandleLog(LogType.Exception, new LogEvent().WithException(e));
                }
            }

            TriggerFieldCallbacks(update);
        }

        /// <summary>
        ///     Reader implementations will override this if their components have fields.
        /// </summary>
        /// <param name="update"></param>
        protected virtual void TriggerFieldCallbacks(TComponentUpdate update)
        {
        }
    }
}
