// ===========
// DO NOT EDIT - this file is automatically regenerated.
// ===========

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Unity.Mathematics;
using Unity.Entities;
using Improbable.Worker.Core;
using Improbable.Gdk.Core;
using Improbable.Gdk.Core.CodegenAdapters;
using Improbable.Gdk.Core.Commands;

namespace Generated.Improbable.Gdk.Tests
{
    public partial class ExhaustiveMapKey
    {
        public class DispatcherHandler : ComponentDispatcherHandler
        {
            public override uint ComponentId => 197719;

            private readonly EntityManager entityManager;

            private const string LoggerName = "ExhaustiveMapKey.DispatcherHandler";


            public DispatcherHandler(Worker worker, World world) : base(worker, world)
            {
                entityManager = world.GetOrCreateManager<EntityManager>();
                var bookkeepingSystem = world.GetOrCreateManager<CommandRequestTrackerSystem>();
            }

            public override void Dispose()
            {
                ExhaustiveMapKey.ReferenceTypeProviders.Field1Provider.CleanDataInWorld(World);
                ExhaustiveMapKey.ReferenceTypeProviders.Field2Provider.CleanDataInWorld(World);
                ExhaustiveMapKey.ReferenceTypeProviders.Field3Provider.CleanDataInWorld(World);
                ExhaustiveMapKey.ReferenceTypeProviders.Field4Provider.CleanDataInWorld(World);
                ExhaustiveMapKey.ReferenceTypeProviders.Field5Provider.CleanDataInWorld(World);
                ExhaustiveMapKey.ReferenceTypeProviders.Field6Provider.CleanDataInWorld(World);
                ExhaustiveMapKey.ReferenceTypeProviders.Field7Provider.CleanDataInWorld(World);
                ExhaustiveMapKey.ReferenceTypeProviders.Field8Provider.CleanDataInWorld(World);
                ExhaustiveMapKey.ReferenceTypeProviders.Field9Provider.CleanDataInWorld(World);
                ExhaustiveMapKey.ReferenceTypeProviders.Field10Provider.CleanDataInWorld(World);
                ExhaustiveMapKey.ReferenceTypeProviders.Field11Provider.CleanDataInWorld(World);
                ExhaustiveMapKey.ReferenceTypeProviders.Field12Provider.CleanDataInWorld(World);
                ExhaustiveMapKey.ReferenceTypeProviders.Field13Provider.CleanDataInWorld(World);
                ExhaustiveMapKey.ReferenceTypeProviders.Field14Provider.CleanDataInWorld(World);
                ExhaustiveMapKey.ReferenceTypeProviders.Field15Provider.CleanDataInWorld(World);
                ExhaustiveMapKey.ReferenceTypeProviders.Field16Provider.CleanDataInWorld(World);
                ExhaustiveMapKey.ReferenceTypeProviders.Field17Provider.CleanDataInWorld(World);
            }

            public override void OnAddComponent(AddComponentOp op)
            {
                if (!IsValidEntityId(op.EntityId, "AddComponentOp", out var entity))
                {
                    return;
                }

                var data = global::Generated.Improbable.Gdk.Tests.SpatialOSExhaustiveMapKey.Serialization.Deserialize(op.Data.SchemaData.Value.GetFields(), World);
                data.DirtyBit = false;
                entityManager.AddComponentData(entity, data);
                entityManager.AddComponentData(entity, new NotAuthoritative<SpatialOSExhaustiveMapKey>());

                if (entityManager.HasComponent<ComponentRemoved<SpatialOSExhaustiveMapKey>>(entity))
                {
                    entityManager.RemoveComponent<ComponentRemoved<SpatialOSExhaustiveMapKey>>(entity);
                }
                else if (!entityManager.HasComponent<ComponentAdded<SpatialOSExhaustiveMapKey>>(entity))
                {
                    entityManager.AddComponentData(entity, new ComponentAdded<SpatialOSExhaustiveMapKey>());
                }
                else
                {
                    LogDispatcher.HandleLog(LogType.Error, new LogEvent(ReceivedDuplicateComponentAdded)
                        .WithField(LoggingUtils.LoggerName, LoggerName)
                        .WithField(LoggingUtils.EntityId, op.EntityId.Id)
                        .WithField("Component", "SpatialOSExhaustiveMapKey")
                    );
                }
            }

            public override void OnRemoveComponent(RemoveComponentOp op)
            {
                if (!IsValidEntityId(op.EntityId, "RemoveComponentOp", out var entity))
                {
                    return;
                }

                var data = entityManager.GetComponentData<SpatialOSExhaustiveMapKey>(entity);
                ExhaustiveMapKey.ReferenceTypeProviders.Field1Provider.Free(data.field1Handle);
                ExhaustiveMapKey.ReferenceTypeProviders.Field2Provider.Free(data.field2Handle);
                ExhaustiveMapKey.ReferenceTypeProviders.Field3Provider.Free(data.field3Handle);
                ExhaustiveMapKey.ReferenceTypeProviders.Field4Provider.Free(data.field4Handle);
                ExhaustiveMapKey.ReferenceTypeProviders.Field5Provider.Free(data.field5Handle);
                ExhaustiveMapKey.ReferenceTypeProviders.Field6Provider.Free(data.field6Handle);
                ExhaustiveMapKey.ReferenceTypeProviders.Field7Provider.Free(data.field7Handle);
                ExhaustiveMapKey.ReferenceTypeProviders.Field8Provider.Free(data.field8Handle);
                ExhaustiveMapKey.ReferenceTypeProviders.Field9Provider.Free(data.field9Handle);
                ExhaustiveMapKey.ReferenceTypeProviders.Field10Provider.Free(data.field10Handle);
                ExhaustiveMapKey.ReferenceTypeProviders.Field11Provider.Free(data.field11Handle);
                ExhaustiveMapKey.ReferenceTypeProviders.Field12Provider.Free(data.field12Handle);
                ExhaustiveMapKey.ReferenceTypeProviders.Field13Provider.Free(data.field13Handle);
                ExhaustiveMapKey.ReferenceTypeProviders.Field14Provider.Free(data.field14Handle);
                ExhaustiveMapKey.ReferenceTypeProviders.Field15Provider.Free(data.field15Handle);
                ExhaustiveMapKey.ReferenceTypeProviders.Field16Provider.Free(data.field16Handle);
                ExhaustiveMapKey.ReferenceTypeProviders.Field17Provider.Free(data.field17Handle);

                entityManager.RemoveComponent<SpatialOSExhaustiveMapKey>(entity);

                if (entityManager.HasComponent<ComponentAdded<SpatialOSExhaustiveMapKey>>(entity))
                {
                    entityManager.RemoveComponent<ComponentAdded<SpatialOSExhaustiveMapKey>>(entity);
                }
                else if (!entityManager.HasComponent<ComponentRemoved<SpatialOSExhaustiveMapKey>>(entity))
                {
                    entityManager.AddComponentData(entity, new ComponentRemoved<SpatialOSExhaustiveMapKey>());
                }
                else
                {
                    LogDispatcher.HandleLog(LogType.Error, new LogEvent(ReceivedDuplicateComponentRemoved)
                        .WithField(LoggingUtils.LoggerName, LoggerName)
                        .WithField(LoggingUtils.EntityId, op.EntityId.Id)
                        .WithField("Component", "SpatialOSExhaustiveMapKey")
                    );
                }
            }

            public override void OnComponentUpdate(ComponentUpdateOp op)
            {
                if (!IsValidEntityId(op.EntityId, "OnComponentUpdate", out var entity))
                {
                    return;
                }

                var data = entityManager.GetComponentData<SpatialOSExhaustiveMapKey>(entity);

                var update = global::Generated.Improbable.Gdk.Tests.SpatialOSExhaustiveMapKey.Serialization.GetAndApplyUpdate(op.Update.SchemaData.Value.GetFields(), ref data);

                List<SpatialOSExhaustiveMapKey.Update> updates;
                if (entityManager.HasComponent<SpatialOSExhaustiveMapKey.ReceivedUpdates>(entity))
                {
                    updates = entityManager.GetComponentData<SpatialOSExhaustiveMapKey.ReceivedUpdates>(entity).Updates;

                }
                else
                {
                    var updatesComponent = new SpatialOSExhaustiveMapKey.ReceivedUpdates
                    {
                        handle = ReferenceTypeProviders.UpdatesProvider.Allocate(World)
                    };
                    ReferenceTypeProviders.UpdatesProvider.Set(updatesComponent.handle, new List<SpatialOSExhaustiveMapKey.Update>());
                    updates = updatesComponent.Updates;
                    entityManager.AddComponentData(entity, updatesComponent);
                }

                updates.Add(update);

                data.DirtyBit = false;
                entityManager.SetComponentData(entity, data);
            }

            public override void OnAuthorityChange(AuthorityChangeOp op)
            {
                if (!IsValidEntityId(op.EntityId, "AuthorityChangeOp", out var entity))
                {
                    return;
                }

                ApplyAuthorityChange(entity, op.Authority, op.EntityId);
            }

            public override void OnCommandRequest(CommandRequestOp op)
            {
                if (!IsValidEntityId(op.EntityId, "CommandRequestOp", out var entity))
                {
                    return;
                }

                var commandIndex = op.Request.SchemaData.Value.GetCommandIndex();
                switch (commandIndex)
                {
                    default:
                        LogDispatcher.HandleLog(LogType.Error, new LogEvent(CommandIndexNotFound)
                            .WithField(LoggingUtils.LoggerName, LoggerName)
                            .WithField(LoggingUtils.EntityId, op.EntityId.Id)
                            .WithField("CommandIndex", commandIndex)
                            .WithField("Component", "SpatialOSExhaustiveMapKey")
                        );
                        break;
                }
            }

            public override void OnCommandResponse(CommandResponseOp op)
            {
                var commandIndex = op.Response.CommandIndex;
                switch (commandIndex)
                {
                    default:
                        LogDispatcher.HandleLog(LogType.Error, new LogEvent(CommandIndexNotFound)
                            .WithField(LoggingUtils.LoggerName, LoggerName)
                            .WithField(LoggingUtils.EntityId, op.EntityId.Id)
                            .WithField("CommandIndex", commandIndex)
                            .WithField("Component", "SpatialOSExhaustiveMapKey")
                        );
                        break;
                }
            }

            public override void AddCommandComponents(Unity.Entities.Entity entity)
            {
            }

            private void ApplyAuthorityChange(Unity.Entities.Entity entity, Authority authority, global::Improbable.Worker.EntityId entityId)
            {
                switch (authority)
                {
                    case Authority.Authoritative:
                        if (!entityManager.HasComponent<NotAuthoritative<SpatialOSExhaustiveMapKey>>(entity))
                        {
                            LogInvalidAuthorityTransition(Authority.Authoritative, Authority.NotAuthoritative, entityId);
                            return;
                        }

                        entityManager.RemoveComponent<NotAuthoritative<SpatialOSExhaustiveMapKey>>(entity);
                        entityManager.AddComponentData(entity, new Authoritative<SpatialOSExhaustiveMapKey>());

                        // Add event senders
                        break;
                    case Authority.AuthorityLossImminent:
                        if (!entityManager.HasComponent<Authoritative<SpatialOSExhaustiveMapKey>>(entity))
                        {
                            LogInvalidAuthorityTransition(Authority.AuthorityLossImminent, Authority.Authoritative, entityId);
                            return;
                        }

                        entityManager.AddComponentData(entity, new AuthorityLossImminent<SpatialOSExhaustiveMapKey> {
                            AuthorityLossAcknowledged = false,
                            AuthorityLossAcknowledgmentSent = false
                        });
                        break;
                    case Authority.NotAuthoritative:
                        if (!entityManager.HasComponent<Authoritative<SpatialOSExhaustiveMapKey>>(entity))
                        {
                            LogInvalidAuthorityTransition(Authority.NotAuthoritative, Authority.Authoritative, entityId);
                            return;
                        }

                        if (entityManager.HasComponent<AuthorityLossImminent<SpatialOSExhaustiveMapKey>>(entity))
                        {
                            entityManager.RemoveComponent<AuthorityLossImminent<SpatialOSExhaustiveMapKey>>(entity);
                        }

                        entityManager.RemoveComponent<Authoritative<SpatialOSExhaustiveMapKey>>(entity);
                        entityManager.AddComponentData(entity, new NotAuthoritative<SpatialOSExhaustiveMapKey>());

                        // Remove event senders
                        break;
                }

                List<Authority> authorityChanges;
                if (entityManager.HasComponent<AuthorityChanges<SpatialOSExhaustiveMapKey>>(entity))
                {
                    authorityChanges = entityManager.GetComponentData<AuthorityChanges<SpatialOSExhaustiveMapKey>>(entity).Changes;

                }
                else
                {
                    var changes = new AuthorityChanges<SpatialOSExhaustiveMapKey>
                    {
                        Handle = AuthorityChangesProvider.Allocate(World)
                    };
                    AuthorityChangesProvider.Set(changes.Handle, new List<Authority>());
                    authorityChanges = changes.Changes;
                    entityManager.AddComponentData(entity, changes);
                }

                authorityChanges.Add(authority);
            }

            private bool IsValidEntityId(global::Improbable.Worker.EntityId entityId, string opType, out Unity.Entities.Entity entity)
            {
                if (!Worker.TryGetEntity(entityId, out entity))
                {
                    LogDispatcher.HandleLog(LogType.Error, new LogEvent(EntityNotFound)
                        .WithField(LoggingUtils.LoggerName, LoggerName)
                        .WithField(LoggingUtils.EntityId, entityId.Id)
                        .WithField("Op", opType)
                        .WithField("Component", "SpatialOSExhaustiveMapKey")
                    );
                    return false;
                }

                return true;
            }

            private void LogInvalidAuthorityTransition(Authority newAuthority, Authority expectedOldAuthority, global::Improbable.Worker.EntityId entityId)
            {
                LogDispatcher.HandleLog(LogType.Error, new LogEvent(InvalidAuthorityChange)
                    .WithField(LoggingUtils.LoggerName, LoggerName)
                    .WithField(LoggingUtils.EntityId, entityId.Id)
                    .WithField("New Authority", newAuthority)
                    .WithField("Expected Old Authority", expectedOldAuthority)
                    .WithField("Component", "SpatialOSExhaustiveMapKey")
                );
            }

        }

        public class ComponentReplicator : ComponentReplicationHandler
        {
            public override ComponentType[] ReplicationComponentTypes => new ComponentType[] {
                ComponentType.Create<SpatialOSExhaustiveMapKey>(),
                ComponentType.ReadOnly<Authoritative<SpatialOSExhaustiveMapKey>>(),
                ComponentType.ReadOnly<SpatialEntityId>()
            };

            public override ComponentType[] CommandTypes => new ComponentType[] {
            };
            
            public override ComponentType[] AuthorityLossComponentTypes => new ComponentType[] {
                ComponentType.Create<AuthorityLossImminent<SpatialOSExhaustiveMapKey>>(),
                ComponentType.ReadOnly<SpatialEntityId>()
            };


            public ComponentReplicator(EntityManager entityManager, Unity.Entities.World world) : base(entityManager)
            {
                var bookkeepingSystem = world.GetOrCreateManager<CommandRequestTrackerSystem>();
            }

            public override void ExecuteReplication(ComponentGroup replicationGroup, global::Improbable.Worker.Core.Connection connection)
            {
                var entityIdDataArray = replicationGroup.GetComponentDataArray<SpatialEntityId>();
                var componentDataArray = replicationGroup.GetComponentDataArray<SpatialOSExhaustiveMapKey>();

                for (var i = 0; i < componentDataArray.Length; i++)
                {
                    var data = componentDataArray[i];
                    var dirtyEvents = 0;

                    if (data.DirtyBit || dirtyEvents > 0)
                    {
                        var update = new global::Improbable.Worker.Core.SchemaComponentUpdate(197719);
                        SpatialOSExhaustiveMapKey.Serialization.Serialize(data, update.GetFields());

                        // Send serialized update over the wire
                        connection.SendComponentUpdate(entityIdDataArray[i].EntityId, new global::Improbable.Worker.Core.ComponentUpdate(update));

                        data.DirtyBit = false;
                        componentDataArray[i] = data;
                    }
                }
            }
            
            public override void SendAuthorityLossImminentAcknowledgement(ComponentGroup authorityLossComponentGroup, global::Improbable.Worker.Core.Connection connection)
            {
                var componentDataArray = authorityLossComponentGroup.GetComponentDataArray<AuthorityLossImminent<SpatialOSExhaustiveMapKey>>();
                var spatialEntityIdData = authorityLossComponentGroup.GetComponentDataArray<SpatialEntityId>();
                for (int i = 0; i < componentDataArray.Length; i++)
                {
                    var component = componentDataArray[i];
                    if (componentDataArray[i].AuthorityLossAcknowledged && !component.AuthorityLossAcknowledgmentSent)
                    {
                        connection.SendAuthorityLossImminentAcknowledgement(spatialEntityIdData[i].EntityId, 197719);
                        component.AuthorityLossAcknowledgmentSent = true;
                        componentDataArray[i] = component;
                    }
                }
            }

            public override void SendCommands(List<ComponentGroup> commandComponentGroups, global::Improbable.Worker.Core.Connection connection)
            {
            }

        }

        public class ComponentCleanup : ComponentCleanupHandler
        {
            public override ComponentType[] CleanUpComponentTypes => new ComponentType[] {
                typeof(ComponentAdded<SpatialOSExhaustiveMapKey>),
                typeof(ComponentRemoved<SpatialOSExhaustiveMapKey>),
            };

            public override ComponentType[] EventComponentTypes => new ComponentType[] {
            };

            public override ComponentType ComponentUpdateType => ComponentType.ReadOnly<SpatialOSExhaustiveMapKey.ReceivedUpdates>();
            public override ComponentType AuthorityChangesType => ComponentType.ReadOnly<AuthorityChanges<SpatialOSExhaustiveMapKey>>();

            public override ComponentType[] CommandReactiveTypes => new ComponentType[] {
            };

            public override void CleanupUpdates(ComponentGroup updateGroup, ref EntityCommandBuffer buffer)
            {
                var entities = updateGroup.GetEntityArray();
                var data = updateGroup.GetComponentDataArray<SpatialOSExhaustiveMapKey.ReceivedUpdates>();
                for (var i = 0; i < entities.Length; i++)
                {
                    buffer.RemoveComponent<SpatialOSExhaustiveMapKey.ReceivedUpdates>(entities[i]);
                    ReferenceTypeProviders.UpdatesProvider.Free(data[i].handle);
                }
            }

            public override void CleanupAuthChanges(ComponentGroup authorityChangeGroup, ref EntityCommandBuffer buffer)
            {
                var entities = authorityChangeGroup.GetEntityArray();
                var data = authorityChangeGroup.GetComponentDataArray<AuthorityChanges<SpatialOSExhaustiveMapKey>>();
                for (var i = 0; i < entities.Length; i++)
                {
                    buffer.RemoveComponent<AuthorityChanges<SpatialOSExhaustiveMapKey>>(entities[i]);
                    AuthorityChangesProvider.Free(data[i].Handle);
                }
            }

            public override void CleanupEvents(ComponentGroup[] eventGroups, ref EntityCommandBuffer buffer)
            {
            }

            public override void CleanupCommands(ComponentGroup[] commandCleanupGroups, ref EntityCommandBuffer buffer)
            {
            }
        }
    }

}
