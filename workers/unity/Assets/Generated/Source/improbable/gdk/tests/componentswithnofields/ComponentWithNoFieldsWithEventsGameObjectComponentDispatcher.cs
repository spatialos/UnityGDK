// ===========
// DO NOT EDIT - this file is automatically regenerated.
// ===========

using System.Collections.Generic;
using System.Linq;
using Unity.Entities;
using Improbable.Gdk.Core;
using Improbable.Gdk.Core.GameObjectRepresentation;

namespace Generated.Improbable.Gdk.Tests.ComponentsWithNoFields
{
    public partial class ComponentWithNoFieldsWithEvents
    {
        internal class GameObjectComponentDispatcher : GameObjectComponentDispatcherBase
        {
            public override ComponentType[] ComponentAddedComponentTypes => new ComponentType[]
            {
                ComponentType.ReadOnly<ComponentAdded<SpatialOSComponentWithNoFieldsWithEvents>>(), ComponentType.ReadOnly<GameObjectReference>()
            };

            public override ComponentType[] ComponentRemovedComponentTypes => new ComponentType[]
            {
                ComponentType.ReadOnly<ComponentRemoved<SpatialOSComponentWithNoFieldsWithEvents>>(), ComponentType.ReadOnly<GameObjectReference>()
            };

            public override ComponentType[] AuthoritiesChangedComponentTypes => new ComponentType[]
            {
                ComponentType.ReadOnly<AuthoritiesChanged<SpatialOSComponentWithNoFieldsWithEvents>>(), ComponentType.ReadOnly<GameObjectReference>()
            };

            public override ComponentType[] ComponentsUpdatedComponentTypes => new ComponentType[]
            {
            };

            public override ComponentType[][] EventsReceivedComponentTypeArrays => new ComponentType[][]
            {
                new ComponentType[] { ComponentType.ReadOnly<EventsReceived<EvtEvent>>(), ComponentType.ReadOnly<GameObjectReference>() },
            };

            public override ComponentType[][] CommandRequestsComponentTypeArrays => new ComponentType[][]
            {
            };

            private const uint componentId = 1004;
            private static readonly InjectableId reaederWriterInjectableId = new InjectableId(InjectableType.ReaderWriter, componentId);

            public override void MarkComponentsAddedForActivation(Dictionary<int, MonoBehaviourActivationManager> entityIndexToManagers)
            {
                if (ComponentAddedComponentGroup.IsEmptyIgnoreFilter)
                {
                    return;
                }

                var entities = ComponentAddedComponentGroup.GetEntityArray();
                for (var i = 0; i < entities.Length; i++)
                {
                    var activationManager = entityIndexToManagers[entities[i].Index];
                    activationManager.AddComponent(componentId);
                }
            }

            public override void MarkComponentsRemovedForDeactivation(Dictionary<int, MonoBehaviourActivationManager> entityIndexToManagers)
            {
                if (ComponentRemovedComponentGroup.IsEmptyIgnoreFilter)
                {
                    return;
                }

                var entities = ComponentRemovedComponentGroup.GetEntityArray();
                for (var i = 0; i < entities.Length; i++)
                {
                    var activationManager = entityIndexToManagers[entities[i].Index];
                    activationManager.RemoveComponent(componentId);
                }
            }

            public override void MarkAuthorityChangesForActivation(Dictionary<int, MonoBehaviourActivationManager> entityIndexToManagers)
            {
                if (AuthoritiesChangedComponentGroup.IsEmptyIgnoreFilter)
                {
                    return;
                }

                var authoritiesChangedTags = AuthoritiesChangedComponentGroup.GetComponentArray<AuthoritiesChanged<SpatialOSComponentWithNoFieldsWithEvents>>();
                var entities = AuthoritiesChangedComponentGroup.GetEntityArray();
                for (var i = 0; i < entities.Length; i++)
                {
                    var activationManager = entityIndexToManagers[entities[i].Index];
                    for (var j = 0; j < authoritiesChangedTags[i].Buffer.Count; j++)
                    {
                        activationManager.ChangeAuthority(componentId, authoritiesChangedTags[i].Buffer[j]);
                    }
                }
            }

            public override void InvokeOnComponentUpdateCallbacks(Dictionary<int, InjectableStore> entityIdToInjectableStore)
            {
            }

            public override void InvokeOnEventCallbacks(Dictionary<int, InjectableStore> entityIdToInjectableStore)
            {
                if (!EventsReceivedComponentGroups[0].IsEmptyIgnoreFilter)
                {
                    var entities = EventsReceivedComponentGroups[0].GetEntityArray();
                    var eventLists = EventsReceivedComponentGroups[0].GetComponentArray<EventsReceived<EvtEvent>>();
                    for (var i = 0; i < entities.Length; i++)
                    {
                        var injectableStore = entityIdToInjectableStore[entities[i].Index];
                        if (!injectableStore.TryGetInjectablesForComponent(reaederWriterInjectableId, out var readers))
                        {
                            continue;
                        }

                        var eventList = eventLists[i];

                        foreach (Accessors.ReaderWriterImpl reader in readers)
                        {
                            foreach (var e in eventList.Buffer)
                            {
                                reader.OnEvtEvent(e);
                            }
                        }
                    }
                }
            }

            public override void InvokeOnCommandRequestCallbacks(Dictionary<int, InjectableStore> entityIdToInjectableStore)
            {
            }

            public override void InvokeOnAuthorityChangeCallbacks(Dictionary<int, InjectableStore> entityIdToInjectableStore)
            {
                if (AuthoritiesChangedComponentGroup.IsEmptyIgnoreFilter)
                {
                    return;
                }

                var entities = AuthoritiesChangedComponentGroup.GetEntityArray();
                var authChangeLists = AuthoritiesChangedComponentGroup.GetComponentArray<AuthoritiesChanged<SpatialOSComponentWithNoFieldsWithEvents>>();
                for (var i = 0; i < entities.Length; i++)
                {
                    var injectableStore = entityIdToInjectableStore[entities[i].Index];
                    if (!injectableStore.TryGetInjectablesForComponent(reaederWriterInjectableId, out var readers))
                    {
                        continue;
                    }

                    var authChanges = authChangeLists[i];
                    foreach (Accessors.ReaderWriterImpl reader in readers)
                    {
                        foreach (var auth in authChanges.Buffer)
                        {
                            reader.OnAuthorityChange(auth);
                        }
                    }
                }
            }
        }
    }
}
