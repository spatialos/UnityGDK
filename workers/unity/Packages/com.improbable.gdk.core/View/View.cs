using System;
using System.Collections.Generic;
using Improbable.Worker.CInterop;
using UnityEngine;

namespace Improbable.Gdk.Core
{
    public class View
    {
        private readonly Dictionary<Type, IViewStorage> typeToViewStorage = new Dictionary<Type, IViewStorage>();
        private readonly List<IViewStorage> viewStorages = new List<IViewStorage>();

        private readonly HashSet<EntityId> entities = new HashSet<EntityId>();

        private ComponentUpdateSystem componentUpdateSystem;

        public View()
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (var type in assembly.GetTypes())
                {
                    if (typeof(IViewStorage).IsAssignableFrom(type) && !type.IsAbstract)
                    {
                        var instance = (IViewStorage) Activator.CreateInstance(type);

                        typeToViewStorage[instance.GetSnapshotType()] = instance;

                        viewStorages.Add(instance);
                    }
                }
            }
        }

        public void Init(ComponentUpdateSystem componentUpdateSystem)
        {
            this.componentUpdateSystem = componentUpdateSystem;
        }

        public void ApplyDiff(ViewDiff diff)
        {
            var entitiesAdded = diff.GetEntitiesAdded();
            foreach (var entity in entitiesAdded)
            {
                entities.Add(entity);
            }

            var entitiesRemoved = diff.GetEntitiesRemoved();
            foreach (var entity in entitiesRemoved)
            {
                entities.Remove(entity);
            }

            foreach (var storage in viewStorages)
            {
                // Resolve this with an actual diff!
                storage.ApplyDiff(componentUpdateSystem);
            }
        }

        public bool HasEntity(EntityId entityId)
        {
            return entities.Contains(entityId);
        }

        // TODO: Make ref readonly when we have a dictionary type with ref indexing semantics.
        public T GetComponent<T>(EntityId entityId) where T : struct, ISpatialComponentSnapshot
        {
            if (!HasEntity(entityId))
            {
                throw new ArgumentException($"The view does not have entity with Entity ID: {entityId.Id}");
            }

            var storage = (IViewComponentStorage<T>) typeToViewStorage[typeof(T)];
            return storage.GetComponent(entityId.Id);
        }

        public bool HasComponent<T>(EntityId entityId) where T : struct, ISpatialComponentSnapshot
        {
            if (!HasEntity(entityId))
            {
                return false;
            }

            var storage = (IViewComponentStorage<T>) typeToViewStorage[typeof(T)];
            return storage.HasComponent(entityId.Id);
        }

        public Authority GetAuthority<T>(EntityId entityId) where T : struct, ISpatialComponentSnapshot
        {
            if (!HasEntity(entityId))
            {
                throw new ArgumentException($"The view does not have entity with Entity ID: {entityId.Id}");
            }

            return ((IViewComponentStorage<T>) typeToViewStorage[typeof(T)]).GetAuthority(entityId.Id);
        }

        public bool IsAuthoritative<T>(EntityId entityId) where T : struct, ISpatialComponentSnapshot
        {
            if (!HasComponent<T>(entityId))
            {
                return false;
            }

            return ((IViewComponentStorage<T>) typeToViewStorage[typeof(T)]).GetAuthority(entityId.Id) == Authority.Authoritative;
        }
    }
}
