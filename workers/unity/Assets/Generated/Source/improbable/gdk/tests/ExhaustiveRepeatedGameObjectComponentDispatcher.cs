// ===========
// DO NOT EDIT - this file is automatically regenerated.
// ===========

using System.Collections.Generic;
using System.Linq;
using Unity.Entities;
using Improbable.Gdk.Core;
using Improbable.Gdk.Core.GameObjectRepresentation;

namespace Generated.Improbable.Gdk.Tests
{
    public partial class ExhaustiveRepeated
    {
        internal class GameObjectComponentDispatcher : GameObjectComponentDispatcherBase
        {
            public override ComponentType[] ComponentAddedComponentTypes => new ComponentType[]
            {
                ComponentType.ReadOnly<ComponentAdded<SpatialOSExhaustiveRepeated>>(), ComponentType.ReadOnly<GameObjectReference>()
            };

            public override ComponentType[] ComponentRemovedComponentTypes => new ComponentType[]
            {
                ComponentType.ReadOnly<ComponentRemoved<SpatialOSExhaustiveRepeated>>(), ComponentType.ReadOnly<GameObjectReference>()
            };

            public override ComponentType[] AuthoritiesChangedComponentTypes => new ComponentType[]
            {
                ComponentType.ReadOnly<AuthoritiesChanged<SpatialOSExhaustiveRepeated>>(), ComponentType.ReadOnly<GameObjectReference>()
            };

            public override ComponentType[] ComponentsUpdatedComponentTypes => new ComponentType[]
            {
                ComponentType.ReadOnly<ComponentsUpdated<SpatialOSExhaustiveRepeated.Update>>(), ComponentType.ReadOnly<GameObjectReference>()
            };

            public override ComponentType[][] EventsReceivedComponentTypeArrays => new ComponentType[][]
            {
            };

            public override ComponentType[][] CommandRequestsComponentTypeArrays => new ComponentType[][]
            {
            };

            private const uint componentId = 197717;

            public override void InvokeOnAddComponentLifecycleMethods(Dictionary<int, MonoBehaviourActivationManager> entityIndexToManagers)
            {
                var entities = ComponentAddedComponentGroup.GetEntityArray();
                for (var i = 0; i < entities.Length; i++)
                {
                    var activationManager = entityIndexToManagers[entities[i].Index];
                    activationManager.AddComponent(componentId);
                }
            }

            public override void InvokeOnRemoveComponentLifecycleMethods(Dictionary<int, MonoBehaviourActivationManager> entityIndexToManagers)
            {
                var entities = ComponentRemovedComponentGroup.GetEntityArray();
                for (var i = 0; i < entities.Length; i++)
                {
                    var activationManager = entityIndexToManagers[entities[i].Index];
                    activationManager.RemoveComponent(componentId);
                }
            }

            public override void InvokeOnAuthorityChangeLifecycleMethods(Dictionary<int, MonoBehaviourActivationManager> entityIndexToManagers)
            {
                var authoritiesChangedTags = AuthoritiesChangedComponentGroup.GetComponentArray<AuthoritiesChanged<SpatialOSExhaustiveRepeated>>();
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

            public override void InvokeOnComponentUpdateCallbacks(Dictionary<int, ReaderWriterStore> entityIdToReaderWriterStore)
            {
                var entities = ComponentsUpdatedComponentGroup.GetEntityArray();
                var updateLists = ComponentsUpdatedComponentGroup.GetComponentArray<ComponentsUpdated<SpatialOSExhaustiveRepeated.Update>>();
                for (var i = 0; i < entities.Length; i++)
                {
                    var readerWriterStore = entityIdToReaderWriterStore[entities[i].Index];
                    if (!readerWriterStore.TryGetReaderWritersForComponent(componentId, out var readers))
                    {
                        continue;
                    }

                    var updateList = updateLists[i];
                    foreach (ReaderWriterImpl reader in readers)
                    {
                        foreach (var update in updateList.Buffer)
                        {
                            reader.OnComponentUpdate(update);
                        }
                    }
                }
            }

            public override void InvokeOnEventCallbacks(Dictionary<int, ReaderWriterStore> entityIdToReaderWriterStore)
            {
            }

            public override void InvokeOnCommandRequestCallbacks(Dictionary<int, ReaderWriterStore> entityIdToReaderWriterStore)
            {
            }

            public override void InvokeOnAuthorityChangeCallbacks(Dictionary<int, ReaderWriterStore> entityIdToReaderWriterStore)
            {
                var entities = AuthoritiesChangedComponentGroup.GetEntityArray();
                var authChangeLists = AuthoritiesChangedComponentGroup.GetComponentArray<AuthoritiesChanged<SpatialOSExhaustiveRepeated>>();
                for (var i = 0; i < entities.Length; i++)
                {
                    var readerWriterStore = entityIdToReaderWriterStore[entities[i].Index];
                    if (!readerWriterStore.TryGetReaderWritersForComponent(componentId, out var readers))
                    {
                        continue;
                    }

                    var authChanges = authChangeLists[i];
                    foreach (ReaderWriterImpl reader in readers)
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
