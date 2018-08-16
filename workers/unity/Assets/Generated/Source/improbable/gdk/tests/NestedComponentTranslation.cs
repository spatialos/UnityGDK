// ===========
// DO NOT EDIT - this file is automatically regenerated.
// ===========

using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Unity.Mathematics;
using Unity.Entities;
using Improbable.Worker;
using Improbable.Gdk.Core;
using Improbable.Gdk.Core.Components;
using Improbable.Gdk.Tests;

namespace Generated.Improbable.Gdk.Tests
{
    public partial class NestedComponent
    {
        public class Translation : ComponentTranslation, IDispatcherCallbacks<global::Improbable.Gdk.Tests.NestedComponent>
        {
            private const string LoggerName = "NestedComponent.Translation";
        
            public override ComponentType TargetComponentType => targetComponentType;
            private static readonly ComponentType targetComponentType = typeof(SpatialOSNestedComponent);

            public override ComponentType[] ReplicationComponentTypes => replicationComponentTypes;
            private static readonly ComponentType[] replicationComponentTypes = { typeof(SpatialOSNestedComponent), typeof(Authoritative<SpatialOSNestedComponent>), 
                typeof(SpatialEntityId) };
                
            public override ComponentType[] AuthorityLossComponentTypes => authorityLossComponentTypes;
            private static readonly ComponentType[] authorityLossComponentTypes = { typeof(AuthorityLossImminent<SpatialOSNestedComponent>),
                typeof(SpatialEntityId) };

            public override ComponentType[] CleanUpComponentTypes => cleanUpComponentTypes;
            private static readonly ComponentType[] cleanUpComponentTypes = 
            { 
                typeof(AuthoritiesChanged<SpatialOSNestedComponent>),
                typeof(ComponentAdded<SpatialOSNestedComponent>),
                typeof(ComponentRemoved<SpatialOSNestedComponent>),
                typeof(ComponentsUpdated<SpatialOSNestedComponent.Update>), 
            };


            private static readonly ComponentPool<AuthoritiesChanged<SpatialOSNestedComponent>> AuthsPool =
                new ComponentPool<AuthoritiesChanged<SpatialOSNestedComponent>>(
                    () => new AuthoritiesChanged<SpatialOSNestedComponent>(),
                    (component) => component.Buffer.Clear());

            private static readonly ComponentPool<ComponentsUpdated<SpatialOSNestedComponent.Update>> UpdatesPool =
                new ComponentPool<ComponentsUpdated<SpatialOSNestedComponent.Update>>(
                    () => new ComponentsUpdated<SpatialOSNestedComponent.Update>(),
                    (component) => component.Buffer.Clear());

            public Translation(MutableView view) : base(view)
            {
            }

            public override void RegisterWithDispatcher(Dispatcher dispatcher)
            {
                dispatcher.OnAddComponent<global::Improbable.Gdk.Tests.NestedComponent>(OnAddComponent);
                dispatcher.OnComponentUpdate<global::Improbable.Gdk.Tests.NestedComponent>(OnComponentUpdate);
                dispatcher.OnRemoveComponent<global::Improbable.Gdk.Tests.NestedComponent>(OnRemoveComponent);
                dispatcher.OnAuthorityChange<global::Improbable.Gdk.Tests.NestedComponent>(OnAuthorityChange);

            }

            public override void AddCommandRequestSender(Unity.Entities.Entity entity, long entityId)
            {
            }

            public void OnAddComponent(AddComponentOp<global::Improbable.Gdk.Tests.NestedComponent> op)
            {
                if (!View.TryGetEntity(op.EntityId.Id, out var entity))
                {
                    LogDispatcher.HandleLog(LogType.Error, new LogEvent("Entity not found during OnAddComponent.")
                        .WithField(LoggingUtils.LoggerName, LoggerName)
                        .WithField(LoggingUtils.EntityId, op.EntityId.Id)
                        .WithField(MutableView.Component, "SpatialOSNestedComponent"));
                    return;
                }
                var data = op.Data.Get().Value;

                var spatialOSNestedComponent = new SpatialOSNestedComponent();
                spatialOSNestedComponent.NestedType = global::Generated.Improbable.Gdk.Tests.TypeName.ToNative(data.nestedType);
                spatialOSNestedComponent.DirtyBit = false;

                View.AddComponent(entity, spatialOSNestedComponent);
                View.AddComponent(entity, new NotAuthoritative<SpatialOSNestedComponent>());

                if (View.HasComponent<ComponentRemoved<SpatialOSNestedComponent>>(entity))
                {
                    View.RemoveComponent<ComponentRemoved<SpatialOSNestedComponent>>(entity);
                }
                else if (!View.HasComponent<ComponentAdded<SpatialOSNestedComponent>>(entity))
                {
                    View.AddComponent(entity, new ComponentAdded<SpatialOSNestedComponent>());
                }
                else
                {
                    LogDispatcher.HandleLog(LogType.Error, new LogEvent(
                            "Received ComponentAdded but have already received one for this entity.")
                        .WithField(LoggingUtils.LoggerName, LoggerName)
                        .WithField(LoggingUtils.EntityId, op.EntityId.Id)
                        .WithField(MutableView.Component, "SpatialOSNestedComponent"));
                }
            }

            public void OnComponentUpdate(ComponentUpdateOp<global::Improbable.Gdk.Tests.NestedComponent> op)
            {
                if (!View.TryGetEntity(op.EntityId.Id, out var entity))
                {
                    LogDispatcher.HandleLog(LogType.Error, new LogEvent("Entity not found during OnComponentUpdate.")
                        .WithField(LoggingUtils.LoggerName, LoggerName)
                        .WithField(LoggingUtils.EntityId, op.EntityId.Id)
                        .WithField(MutableView.Component, "SpatialOSNestedComponent"));
                    return;
                }

                var componentData = View.GetComponent<SpatialOSNestedComponent>(entity);
                var update = op.Update.Get();

                if (View.HasComponent<NotAuthoritative<SpatialOSNestedComponent>>(entity))
                {
                    if (update.nestedType.HasValue)
                    {
                        componentData.NestedType = global::Generated.Improbable.Gdk.Tests.TypeName.ToNative(update.nestedType.Value);
                    }
                }

                componentData.DirtyBit = false;

                View.SetComponentData(entity, componentData);

                var componentFieldsUpdated = false;
                var gdkUpdate = new SpatialOSNestedComponent.Update();
                if (update.nestedType.HasValue)
                {
                    componentFieldsUpdated = true;
                    gdkUpdate.NestedType = new Option<global::Generated.Improbable.Gdk.Tests.TypeName>(global::Generated.Improbable.Gdk.Tests.TypeName.ToNative(update.nestedType.Value));
                }

                if (componentFieldsUpdated)
                {
                    View.AddComponentsUpdated(entity, gdkUpdate, UpdatesPool);
                }
            }

            public void OnRemoveComponent(RemoveComponentOp op)
            {
                if (!View.TryGetEntity(op.EntityId.Id, out var entity))
                {
                    LogDispatcher.HandleLog(LogType.Error, new LogEvent("Entity not found during OnRemoveComponent.")
                        .WithField(LoggingUtils.LoggerName, LoggerName)
                        .WithField(LoggingUtils.EntityId, op.EntityId.Id)
                        .WithField(MutableView.Component, "SpatialOSNestedComponent"));
                    return;
                }

                View.RemoveComponent<SpatialOSNestedComponent>(entity);

                if (View.HasComponent<ComponentAdded<SpatialOSNestedComponent>>(entity))
                {
                    View.RemoveComponent<ComponentAdded<SpatialOSNestedComponent>>(entity);
                }
                else if (!View.HasComponent<ComponentRemoved<SpatialOSNestedComponent>>(entity))
                {
                    View.AddComponent(entity, new ComponentRemoved<SpatialOSNestedComponent>());
                }
                else
                {
                    LogDispatcher.HandleLog(LogType.Error, new LogEvent(
                            "Received ComponentRemoved but have already received one for this entity.")
                        .WithField(LoggingUtils.LoggerName, LoggerName)
                        .WithField(LoggingUtils.EntityId, op.EntityId.Id)
                        .WithField(MutableView.Component, "SpatialOSNestedComponent"));
                }
            }

            public void OnAuthorityChange(AuthorityChangeOp op)
            {
                var entityId = op.EntityId.Id;
                View.HandleAuthorityChange(entityId, op.Authority, AuthsPool);
            }

            public override void ExecuteReplication(Connection connection)
            {
                var componentDataArray = ReplicationComponentGroup.GetComponentDataArray<SpatialOSNestedComponent>();
                var spatialEntityIdData = ReplicationComponentGroup.GetComponentDataArray<SpatialEntityId>();

                for (var i = 0; i < componentDataArray.Length; i++)
                {
                    var componentData = componentDataArray[i];
                    var entityId = spatialEntityIdData[i].EntityId;
                    var hasPendingEvents = false;

                    if (componentData.DirtyBit || hasPendingEvents)
                    {
                        var update = new global::Improbable.Gdk.Tests.NestedComponent.Update();
                        update.SetNestedType(global::Generated.Improbable.Gdk.Tests.TypeName.ToSpatial(componentData.NestedType));
                        SendComponentUpdate(connection, entityId, update);

                        componentData.DirtyBit = false;
                        componentDataArray[i] = componentData;

                    }
                }
            }

            public static void SendComponentUpdate(Connection connection, long entityId, global::Improbable.Gdk.Tests.NestedComponent.Update update)
            {
                connection.SendComponentUpdate(new global::Improbable.EntityId(entityId), update);
            }

            public override void CleanUpComponents(ref EntityCommandBuffer entityCommandBuffer)
            {
                RemoveComponents(ref entityCommandBuffer, AuthsPool, groupIndex: 0);
                RemoveComponents<ComponentAdded<SpatialOSNestedComponent>>(ref entityCommandBuffer, groupIndex: 1);
                RemoveComponents<ComponentRemoved<SpatialOSNestedComponent>>(ref entityCommandBuffer, groupIndex: 2);
                RemoveComponents(ref entityCommandBuffer, UpdatesPool, groupIndex: 3);
                
                
            }


            public override void SendAuthorityLossImminentAcknowledgement(Connection connection)
            {
                var componentDataArray = AuthorityLossComponentGroup.GetComponentDataArray<AuthorityLossImminent<SpatialOSNestedComponent>>();
                var spatialEntityIdData = AuthorityLossComponentGroup.GetComponentDataArray<SpatialEntityId>();

                for (int i = 0; i < componentDataArray.Length; i++)
                {
                    var component = componentDataArray[i];
                    if (componentDataArray[i].AuthorityLossAcknowledged && !component.AuthorityLossAcknowledgmentSent)
                    {
                        connection.SendAuthorityLossImminentAcknowledgement<global::Improbable.Gdk.Tests.NestedComponent>(new global::Improbable.EntityId(spatialEntityIdData[i].EntityId));
                        component.AuthorityLossAcknowledgmentSent = true;
                        componentDataArray[i] = component;
                    }
                }
            }
                
            public override void SendCommands(Connection connection)
            {
            }

            public static NestedComponent.Translation GetTranslation(uint internalHandleToTranslation)
            {
                return (NestedComponent.Translation) ComponentTranslation.HandleToTranslation[internalHandleToTranslation];
            }
        }
    }


}
