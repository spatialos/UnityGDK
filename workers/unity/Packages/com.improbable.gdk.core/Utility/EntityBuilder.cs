using System;
using System.Collections.Generic;
using System.Linq;
using Improbable.Worker.Core;

namespace Improbable.Gdk.Core
{
    public class EntityBuilder
    {
        private readonly Entity entity;
        private Acl acl = new Acl();
        private bool hasBuiltOnce;

        private readonly HashSet<uint> componentsAdded = new HashSet<uint>();

        private const uint EntityAclComponentId = 50;
        private const uint MetadataComponentId = 53;
        private const uint PositionComponentId = 54;
        private const uint PersistenceComponentId = 55;

        private static readonly HashSet<uint> requiredComponents = new HashSet<uint>{ EntityAclComponentId, PositionComponentId};


        public static EntityBuilder Begin()
        {
            return new EntityBuilder();
        }

        private EntityBuilder()
        {
            entity = new Entity();
        }

        public EntityBuilder AddComponent(ComponentData componentData, string writeAccess)
        {
            if (componentsAdded.Contains(componentData.ComponentId))
            {
                throw new InvalidOperationException(
                    $"Cannot add multiple components of the same type to the same entity. " +
                    $"Attempted to add componentId: {componentData.ComponentId} more than once.");
            }

            entity.Add(componentData);
            componentsAdded.Add(componentData.ComponentId);
            acl.SetComponentWriteAccess(componentData.ComponentId, writeAccess);
            return this;
        }

        public EntityBuilder AddPosition(double x, double y, double z, string writeAccess)
        {
            var schemaData = new SchemaComponentData(PositionComponentId);
            var fields = schemaData.GetFields();
            fields.AddDouble(1, x);
            fields.AddDouble(2, y);
            fields.AddDouble(3, z);

            return AddComponent(new ComponentData(schemaData), writeAccess);
        }

        public EntityBuilder SetPersistence(bool persistence)
        {
            if (persistence)
            {
                var schemaData = new SchemaComponentData(PersistenceComponentId);
                entity.Add(new ComponentData(schemaData));
            }
            else
            {
                if (entity.Get(PersistenceComponentId).HasValue)
                {
                    entity.Remove(PersistenceComponentId);
                }
            }

            return this;
        }

        public EntityBuilder AddMetadata(string metadata, string writeAccess)
        {
            var schemaData = new SchemaComponentData(MetadataComponentId);
            var fields = schemaData.GetFields();
            fields.AddString(1, metadata);

            return AddComponent(new ComponentData(schemaData), writeAccess);
        }

        public EntityBuilder SetReadAcl(string attribute, params string[] attributes)
        {
            acl.AddReadAccess(attribute);
            foreach (var attr in attributes)
            {
                acl.AddReadAccess(attr);
            }

            return this;
        }

        public EntityBuilder SetReadAcl(List<string> attributes)
        {
            foreach (var attribute in attributes)
            {
                acl.AddReadAccess(attribute);
            }

            return this;
        }

        public EntityBuilder SetEntityAclComponentWriteAccess(string attribute)
        {
            acl.SetComponentWriteAccess(EntityAclComponentId, attribute);
            return this;
        }

        public Entity Build()
        {
            entity.Add(acl.Build());
            CheckRequiredComponents();
            return entity;
        }

        private void CheckRequiredComponents()
        {
            if (!requiredComponents.All(c => componentsAdded.Contains(c)))
            {
                throw new InvalidEntityException(
                    "Entity is invalid. Missing one of required component: Position and EntityAcl");
            }
        }

        private class InvalidEntityException : Exception
        {
            public InvalidEntityException(string message) : base(message)
            {
            }
        }

        private class Acl
        {
            private Dictionary<uint, string> writePermissions = new Dictionary<uint, string>();
            private List<string> readPermissions = new List<string>();

            public void SetComponentWriteAccess(uint componentId, string attribute)
            {
                writePermissions[componentId] = attribute;
            }

            public void AddReadAccess(string attribute)
            {
                readPermissions.Add(attribute);
            }

            public ComponentData Build()
            {
                var schemaComponentData = new SchemaComponentData(EntityAclComponentId);
                var fields = schemaComponentData.GetFields();

                // Write the read acl
                var workerRequirementSet = fields.AddObject(1);
                foreach (var attr in readPermissions)
                {
                    // Add another WorkerAttributeSet to the list
                    var set = workerRequirementSet.AddObject(1);
                    set.AddString(1, attr);
                }

                // Write the component write acl
                foreach (var writePermission in writePermissions)
                {
                    var keyValuePair = fields.AddObject(2);
                    keyValuePair.AddUint32(1, writePermission.Key);
                    var containedRequirementSet = keyValuePair.AddObject(2);
                    var containedAttributeSet = containedRequirementSet.AddObject(1);
                    containedAttributeSet.AddString(1, writePermission.Value);
                }

                return new ComponentData(schemaComponentData);
            }
        }
    }
}
