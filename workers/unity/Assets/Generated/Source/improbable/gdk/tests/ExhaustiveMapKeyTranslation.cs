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
    public partial class ExhaustiveMapKey
    {
        public class Translation : ComponentTranslation, IDispatcherCallbacks<global::Improbable.Gdk.Tests.ExhaustiveMapKey>
        {
            private const string LoggerName = "ExhaustiveMapKey.Translation";
        
            public override ComponentType TargetComponentType => targetComponentType;
            private static readonly ComponentType targetComponentType = typeof(SpatialOSExhaustiveMapKey);

            public override ComponentType[] ReplicationComponentTypes => replicationComponentTypes;
            private static readonly ComponentType[] replicationComponentTypes = { typeof(SpatialOSExhaustiveMapKey), typeof(Authoritative<SpatialOSExhaustiveMapKey>), 
                typeof(SpatialEntityId) };
                
            public override ComponentType[] AuthorityLossComponentTypes => authorityLossComponentTypes;
            private static readonly ComponentType[] authorityLossComponentTypes = { typeof(AuthorityLossImminent<SpatialOSExhaustiveMapKey>),
                typeof(SpatialEntityId) };

            public override ComponentType[] CleanUpComponentTypes => cleanUpComponentTypes;
            private static readonly ComponentType[] cleanUpComponentTypes = 
            { 
                typeof(AuthoritiesChanged<SpatialOSExhaustiveMapKey>),
                typeof(ComponentAdded<SpatialOSExhaustiveMapKey>),
                typeof(ComponentRemoved<SpatialOSExhaustiveMapKey>),
                typeof(ComponentsUpdated<SpatialOSExhaustiveMapKey.Update>), 
            };


            private static readonly ComponentPool<AuthoritiesChanged<SpatialOSExhaustiveMapKey>> AuthsPool =
                new ComponentPool<AuthoritiesChanged<SpatialOSExhaustiveMapKey>>(
                    () => new AuthoritiesChanged<SpatialOSExhaustiveMapKey>(),
                    (component) => component.Buffer.Clear());

            private static readonly ComponentPool<ComponentsUpdated<SpatialOSExhaustiveMapKey.Update>> UpdatesPool =
                new ComponentPool<ComponentsUpdated<SpatialOSExhaustiveMapKey.Update>>(
                    () => new ComponentsUpdated<SpatialOSExhaustiveMapKey.Update>(),
                    (component) => component.Buffer.Clear());

            public Translation(MutableView view) : base(view)
            {
            }

            public override void RegisterWithDispatcher(Dispatcher dispatcher)
            {
                dispatcher.OnAddComponent<global::Improbable.Gdk.Tests.ExhaustiveMapKey>(OnAddComponent);
                dispatcher.OnComponentUpdate<global::Improbable.Gdk.Tests.ExhaustiveMapKey>(OnComponentUpdate);
                dispatcher.OnRemoveComponent<global::Improbable.Gdk.Tests.ExhaustiveMapKey>(OnRemoveComponent);
                dispatcher.OnAuthorityChange<global::Improbable.Gdk.Tests.ExhaustiveMapKey>(OnAuthorityChange);

            }

            public override void AddCommandRequestSender(Unity.Entities.Entity entity, long entityId)
            {
            }

            public void OnAddComponent(AddComponentOp<global::Improbable.Gdk.Tests.ExhaustiveMapKey> op)
            {
                if (!View.TryGetEntity(op.EntityId.Id, out var entity))
                {
                    LogDispatcher.HandleLog(LogType.Error, new LogEvent("Entity not found during OnAddComponent.")
                        .WithField(LoggingUtils.LoggerName, LoggerName)
                        .WithField(LoggingUtils.EntityId, op.EntityId.Id)
                        .WithField(MutableView.Component, "SpatialOSExhaustiveMapKey"));
                    return;
                }
                var data = op.Data.Get().Value;

                var spatialOSExhaustiveMapKey = new SpatialOSExhaustiveMapKey();
                spatialOSExhaustiveMapKey.Field2 = data.field2.ToDictionary(entry => entry.Key, entry => entry.Value);
                spatialOSExhaustiveMapKey.Field4 = data.field4.ToDictionary(entry => entry.Key, entry => entry.Value);
                spatialOSExhaustiveMapKey.Field5 = data.field5.ToDictionary(entry => entry.Key, entry => entry.Value);
                spatialOSExhaustiveMapKey.Field6 = data.field6.ToDictionary(entry => entry.Key, entry => entry.Value);
                spatialOSExhaustiveMapKey.Field7 = data.field7.ToDictionary(entry => entry.Key, entry => entry.Value);
                spatialOSExhaustiveMapKey.Field8 = data.field8.ToDictionary(entry => entry.Key, entry => entry.Value);
                spatialOSExhaustiveMapKey.Field9 = data.field9.ToDictionary(entry => entry.Key, entry => entry.Value);
                spatialOSExhaustiveMapKey.Field10 = data.field10.ToDictionary(entry => entry.Key, entry => entry.Value);
                spatialOSExhaustiveMapKey.Field11 = data.field11.ToDictionary(entry => entry.Key, entry => entry.Value);
                spatialOSExhaustiveMapKey.Field12 = data.field12.ToDictionary(entry => entry.Key, entry => entry.Value);
                spatialOSExhaustiveMapKey.Field13 = data.field13.ToDictionary(entry => entry.Key, entry => entry.Value);
                spatialOSExhaustiveMapKey.Field14 = data.field14.ToDictionary(entry => entry.Key, entry => entry.Value);
                spatialOSExhaustiveMapKey.Field15 = data.field15.ToDictionary(entry => entry.Key, entry => entry.Value);
                spatialOSExhaustiveMapKey.Field16 = data.field16.ToDictionary(entry => entry.Key.Id, entry => entry.Value);
                spatialOSExhaustiveMapKey.Field17 = data.field17.ToDictionary(entry => global::Generated.Improbable.Gdk.Tests.SomeType.ToNative(entry.Key), entry => entry.Value);
                spatialOSExhaustiveMapKey.DirtyBit = false;

                View.SetComponentObject(entity, spatialOSExhaustiveMapKey);
                View.AddComponent(entity, new NotAuthoritative<SpatialOSExhaustiveMapKey>());

                if (View.HasComponent<ComponentRemoved<SpatialOSExhaustiveMapKey>>(entity))
                {
                    View.RemoveComponent<ComponentRemoved<SpatialOSExhaustiveMapKey>>(entity);
                }
                else if (!View.HasComponent<ComponentAdded<SpatialOSExhaustiveMapKey>>(entity))
                {
                    View.AddComponent(entity, new ComponentAdded<SpatialOSExhaustiveMapKey>());
                }
                else
                {
                    LogDispatcher.HandleLog(LogType.Error, new LogEvent(
                            "Received ComponentAdded but have already received one for this entity.")
                        .WithField(LoggingUtils.LoggerName, LoggerName)
                        .WithField(LoggingUtils.EntityId, op.EntityId.Id)
                        .WithField(MutableView.Component, "SpatialOSExhaustiveMapKey"));
                }
            }

            public void OnComponentUpdate(ComponentUpdateOp<global::Improbable.Gdk.Tests.ExhaustiveMapKey> op)
            {
                if (!View.TryGetEntity(op.EntityId.Id, out var entity))
                {
                    LogDispatcher.HandleLog(LogType.Error, new LogEvent("Entity not found during OnComponentUpdate.")
                        .WithField(LoggingUtils.LoggerName, LoggerName)
                        .WithField(LoggingUtils.EntityId, op.EntityId.Id)
                        .WithField(MutableView.Component, "SpatialOSExhaustiveMapKey"));
                    return;
                }

                var componentData = View.GetComponentObject<SpatialOSExhaustiveMapKey>(entity);
                var update = op.Update.Get();

                if (View.HasComponent<NotAuthoritative<SpatialOSExhaustiveMapKey>>(entity))
                {
                    if (update.field2.HasValue)
                    {
                        componentData.Field2 = update.field2.Value.ToDictionary(entry => entry.Key, entry => entry.Value);
                    }
                    if (update.field4.HasValue)
                    {
                        componentData.Field4 = update.field4.Value.ToDictionary(entry => entry.Key, entry => entry.Value);
                    }
                    if (update.field5.HasValue)
                    {
                        componentData.Field5 = update.field5.Value.ToDictionary(entry => entry.Key, entry => entry.Value);
                    }
                    if (update.field6.HasValue)
                    {
                        componentData.Field6 = update.field6.Value.ToDictionary(entry => entry.Key, entry => entry.Value);
                    }
                    if (update.field7.HasValue)
                    {
                        componentData.Field7 = update.field7.Value.ToDictionary(entry => entry.Key, entry => entry.Value);
                    }
                    if (update.field8.HasValue)
                    {
                        componentData.Field8 = update.field8.Value.ToDictionary(entry => entry.Key, entry => entry.Value);
                    }
                    if (update.field9.HasValue)
                    {
                        componentData.Field9 = update.field9.Value.ToDictionary(entry => entry.Key, entry => entry.Value);
                    }
                    if (update.field10.HasValue)
                    {
                        componentData.Field10 = update.field10.Value.ToDictionary(entry => entry.Key, entry => entry.Value);
                    }
                    if (update.field11.HasValue)
                    {
                        componentData.Field11 = update.field11.Value.ToDictionary(entry => entry.Key, entry => entry.Value);
                    }
                    if (update.field12.HasValue)
                    {
                        componentData.Field12 = update.field12.Value.ToDictionary(entry => entry.Key, entry => entry.Value);
                    }
                    if (update.field13.HasValue)
                    {
                        componentData.Field13 = update.field13.Value.ToDictionary(entry => entry.Key, entry => entry.Value);
                    }
                    if (update.field14.HasValue)
                    {
                        componentData.Field14 = update.field14.Value.ToDictionary(entry => entry.Key, entry => entry.Value);
                    }
                    if (update.field15.HasValue)
                    {
                        componentData.Field15 = update.field15.Value.ToDictionary(entry => entry.Key, entry => entry.Value);
                    }
                    if (update.field16.HasValue)
                    {
                        componentData.Field16 = update.field16.Value.ToDictionary(entry => entry.Key.Id, entry => entry.Value);
                    }
                    if (update.field17.HasValue)
                    {
                        componentData.Field17 = update.field17.Value.ToDictionary(entry => global::Generated.Improbable.Gdk.Tests.SomeType.ToNative(entry.Key), entry => entry.Value);
                    }
                }

                componentData.DirtyBit = false;

                View.SetComponentObject(entity, componentData);

                var componentFieldsUpdated = false;
                var gdkUpdate = new SpatialOSExhaustiveMapKey.Update();
                if (update.field2.HasValue)
                {
                    componentFieldsUpdated = true;
                    gdkUpdate.Field2 = new Option<global::System.Collections.Generic.Dictionary<float, string>>(update.field2.Value.ToDictionary(entry => entry.Key, entry => entry.Value));
                }
                if (update.field4.HasValue)
                {
                    componentFieldsUpdated = true;
                    gdkUpdate.Field4 = new Option<global::System.Collections.Generic.Dictionary<int, string>>(update.field4.Value.ToDictionary(entry => entry.Key, entry => entry.Value));
                }
                if (update.field5.HasValue)
                {
                    componentFieldsUpdated = true;
                    gdkUpdate.Field5 = new Option<global::System.Collections.Generic.Dictionary<long, string>>(update.field5.Value.ToDictionary(entry => entry.Key, entry => entry.Value));
                }
                if (update.field6.HasValue)
                {
                    componentFieldsUpdated = true;
                    gdkUpdate.Field6 = new Option<global::System.Collections.Generic.Dictionary<double, string>>(update.field6.Value.ToDictionary(entry => entry.Key, entry => entry.Value));
                }
                if (update.field7.HasValue)
                {
                    componentFieldsUpdated = true;
                    gdkUpdate.Field7 = new Option<global::System.Collections.Generic.Dictionary<string, string>>(update.field7.Value.ToDictionary(entry => entry.Key, entry => entry.Value));
                }
                if (update.field8.HasValue)
                {
                    componentFieldsUpdated = true;
                    gdkUpdate.Field8 = new Option<global::System.Collections.Generic.Dictionary<uint, string>>(update.field8.Value.ToDictionary(entry => entry.Key, entry => entry.Value));
                }
                if (update.field9.HasValue)
                {
                    componentFieldsUpdated = true;
                    gdkUpdate.Field9 = new Option<global::System.Collections.Generic.Dictionary<ulong, string>>(update.field9.Value.ToDictionary(entry => entry.Key, entry => entry.Value));
                }
                if (update.field10.HasValue)
                {
                    componentFieldsUpdated = true;
                    gdkUpdate.Field10 = new Option<global::System.Collections.Generic.Dictionary<int, string>>(update.field10.Value.ToDictionary(entry => entry.Key, entry => entry.Value));
                }
                if (update.field11.HasValue)
                {
                    componentFieldsUpdated = true;
                    gdkUpdate.Field11 = new Option<global::System.Collections.Generic.Dictionary<long, string>>(update.field11.Value.ToDictionary(entry => entry.Key, entry => entry.Value));
                }
                if (update.field12.HasValue)
                {
                    componentFieldsUpdated = true;
                    gdkUpdate.Field12 = new Option<global::System.Collections.Generic.Dictionary<uint, string>>(update.field12.Value.ToDictionary(entry => entry.Key, entry => entry.Value));
                }
                if (update.field13.HasValue)
                {
                    componentFieldsUpdated = true;
                    gdkUpdate.Field13 = new Option<global::System.Collections.Generic.Dictionary<ulong, string>>(update.field13.Value.ToDictionary(entry => entry.Key, entry => entry.Value));
                }
                if (update.field14.HasValue)
                {
                    componentFieldsUpdated = true;
                    gdkUpdate.Field14 = new Option<global::System.Collections.Generic.Dictionary<int, string>>(update.field14.Value.ToDictionary(entry => entry.Key, entry => entry.Value));
                }
                if (update.field15.HasValue)
                {
                    componentFieldsUpdated = true;
                    gdkUpdate.Field15 = new Option<global::System.Collections.Generic.Dictionary<long, string>>(update.field15.Value.ToDictionary(entry => entry.Key, entry => entry.Value));
                }
                if (update.field16.HasValue)
                {
                    componentFieldsUpdated = true;
                    gdkUpdate.Field16 = new Option<global::System.Collections.Generic.Dictionary<long, string>>(update.field16.Value.ToDictionary(entry => entry.Key.Id, entry => entry.Value));
                }
                if (update.field17.HasValue)
                {
                    componentFieldsUpdated = true;
                    gdkUpdate.Field17 = new Option<global::System.Collections.Generic.Dictionary<global::Generated.Improbable.Gdk.Tests.SomeType, string>>(update.field17.Value.ToDictionary(entry => global::Generated.Improbable.Gdk.Tests.SomeType.ToNative(entry.Key), entry => entry.Value));
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
                        .WithField(MutableView.Component, "SpatialOSExhaustiveMapKey"));
                    return;
                }

                View.RemoveComponent<SpatialOSExhaustiveMapKey>(entity);

                if (View.HasComponent<ComponentAdded<SpatialOSExhaustiveMapKey>>(entity))
                {
                    View.RemoveComponent<ComponentAdded<SpatialOSExhaustiveMapKey>>(entity);
                }
                else if (!View.HasComponent<ComponentRemoved<SpatialOSExhaustiveMapKey>>(entity))
                {
                    View.AddComponent(entity, new ComponentRemoved<SpatialOSExhaustiveMapKey>());
                }
                else
                {
                    LogDispatcher.HandleLog(LogType.Error, new LogEvent(
                            "Received ComponentRemoved but have already received one for this entity.")
                        .WithField(LoggingUtils.LoggerName, LoggerName)
                        .WithField(LoggingUtils.EntityId, op.EntityId.Id)
                        .WithField(MutableView.Component, "SpatialOSExhaustiveMapKey"));
                }
            }

            public void OnAuthorityChange(AuthorityChangeOp op)
            {
                var entityId = op.EntityId.Id;
                View.HandleAuthorityChange(entityId, op.Authority, AuthsPool);
            }

            public override void ExecuteReplication(Connection connection)
            {
                var componentDataArray = ReplicationComponentGroup.GetComponentArray<SpatialOSExhaustiveMapKey>();
                var spatialEntityIdData = ReplicationComponentGroup.GetComponentDataArray<SpatialEntityId>();

                for (var i = 0; i < componentDataArray.Length; i++)
                {
                    var componentData = componentDataArray[i];
                    var entityId = spatialEntityIdData[i].EntityId;
                    var hasPendingEvents = false;

                    if (componentData.DirtyBit || hasPendingEvents)
                    {
                        var update = new global::Improbable.Gdk.Tests.ExhaustiveMapKey.Update();
                        update.SetField2(new global::Improbable.Collections.Map<float,string>(componentData.Field2.ToDictionary(entry => entry.Key, entry => entry.Value)));
                        update.SetField4(new global::Improbable.Collections.Map<int,string>(componentData.Field4.ToDictionary(entry => entry.Key, entry => entry.Value)));
                        update.SetField5(new global::Improbable.Collections.Map<long,string>(componentData.Field5.ToDictionary(entry => entry.Key, entry => entry.Value)));
                        update.SetField6(new global::Improbable.Collections.Map<double,string>(componentData.Field6.ToDictionary(entry => entry.Key, entry => entry.Value)));
                        update.SetField7(new global::Improbable.Collections.Map<string,string>(componentData.Field7.ToDictionary(entry => entry.Key, entry => entry.Value)));
                        update.SetField8(new global::Improbable.Collections.Map<uint,string>(componentData.Field8.ToDictionary(entry => entry.Key, entry => entry.Value)));
                        update.SetField9(new global::Improbable.Collections.Map<ulong,string>(componentData.Field9.ToDictionary(entry => entry.Key, entry => entry.Value)));
                        update.SetField10(new global::Improbable.Collections.Map<int,string>(componentData.Field10.ToDictionary(entry => entry.Key, entry => entry.Value)));
                        update.SetField11(new global::Improbable.Collections.Map<long,string>(componentData.Field11.ToDictionary(entry => entry.Key, entry => entry.Value)));
                        update.SetField12(new global::Improbable.Collections.Map<uint,string>(componentData.Field12.ToDictionary(entry => entry.Key, entry => entry.Value)));
                        update.SetField13(new global::Improbable.Collections.Map<ulong,string>(componentData.Field13.ToDictionary(entry => entry.Key, entry => entry.Value)));
                        update.SetField14(new global::Improbable.Collections.Map<int,string>(componentData.Field14.ToDictionary(entry => entry.Key, entry => entry.Value)));
                        update.SetField15(new global::Improbable.Collections.Map<long,string>(componentData.Field15.ToDictionary(entry => entry.Key, entry => entry.Value)));
                        update.SetField16(new global::Improbable.Collections.Map<global::Improbable.EntityId,string>(componentData.Field16.ToDictionary(entry => new global::Improbable.EntityId(entry.Key), entry => entry.Value)));
                        update.SetField17(new global::Improbable.Collections.Map<global::Improbable.Gdk.Tests.SomeType,string>(componentData.Field17.ToDictionary(entry => global::Generated.Improbable.Gdk.Tests.SomeType.ToSpatial(entry.Key), entry => entry.Value)));
                        SendComponentUpdate(connection, entityId, update);

                        componentData.DirtyBit = false;
                        View.SetComponentObject(entityId, componentData);

                    }
                }
            }

            public static void SendComponentUpdate(Connection connection, long entityId, global::Improbable.Gdk.Tests.ExhaustiveMapKey.Update update)
            {
                connection.SendComponentUpdate(new global::Improbable.EntityId(entityId), update);
            }

            public override void CleanUpComponents(ref EntityCommandBuffer entityCommandBuffer)
            {
                RemoveComponents(ref entityCommandBuffer, AuthsPool, groupIndex: 0);
                RemoveComponents<ComponentAdded<SpatialOSExhaustiveMapKey>>(ref entityCommandBuffer, groupIndex: 1);
                RemoveComponents<ComponentRemoved<SpatialOSExhaustiveMapKey>>(ref entityCommandBuffer, groupIndex: 2);
                RemoveComponents(ref entityCommandBuffer, UpdatesPool, groupIndex: 3);
                
                
            }


            public override void SendAuthorityLossImminentAcknowledgement(Connection connection)
            {
                var componentDataArray = AuthorityLossComponentGroup.GetComponentDataArray<AuthorityLossImminent<SpatialOSExhaustiveMapKey>>();
                var spatialEntityIdData = AuthorityLossComponentGroup.GetComponentDataArray<SpatialEntityId>();

                for (int i = 0; i < componentDataArray.Length; i++)
                {
                    var component = componentDataArray[i];
                    if (componentDataArray[i].AuthorityLossAcknowledged && !component.AuthorityLossAcknowledgmentSent)
                    {
                        connection.SendAuthorityLossImminentAcknowledgement<global::Improbable.Gdk.Tests.ExhaustiveMapKey>(new global::Improbable.EntityId(spatialEntityIdData[i].EntityId));
                        component.AuthorityLossAcknowledgmentSent = true;
                        componentDataArray[i] = component;
                    }
                }
            }
                
            public override void SendCommands(Connection connection)
            {
            }

            public static ExhaustiveMapKey.Translation GetTranslation(uint internalHandleToTranslation)
            {
                return (ExhaustiveMapKey.Translation) ComponentTranslation.HandleToTranslation[internalHandleToTranslation];
            }
        }
    }


}
