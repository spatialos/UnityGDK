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
    public partial class ExhaustiveSingular
    {
        internal class GameObjectComponentDispatcher : GameObjectComponentDispatcherBase
        {
            public override ComponentType[] ComponentAddedComponentTypes => new ComponentType[]
            {
                ComponentType.ReadOnly<ComponentAdded<SpatialOSExhaustiveSingular>>(), ComponentType.ReadOnly<GameObjectReference>()
            };

            public override ComponentType[] ComponentRemovedComponentTypes => new ComponentType[]
            {
                ComponentType.ReadOnly<ComponentRemoved<SpatialOSExhaustiveSingular>>(), ComponentType.ReadOnly<GameObjectReference>()
            };

            public override ComponentType[] AuthoritiesChangedComponentTypes => new ComponentType[]
            {
                ComponentType.ReadOnly<AuthorityChanges<SpatialOSExhaustiveSingular>>(), ComponentType.ReadOnly<GameObjectReference>()
            };

            public override ComponentType[] ComponentsUpdatedComponentTypes => new ComponentType[]
            {
                ComponentType.ReadOnly<SpatialOSExhaustiveSingular.ReceivedUpdates>(), ComponentType.ReadOnly<GameObjectReference>()
            };

            public override ComponentType[][] EventsReceivedComponentTypeArrays => new ComponentType[][]
            {
            };

            public override ComponentType[][] CommandRequestsComponentTypeArrays => new ComponentType[][]
            {
            };

            private const uint componentId = 197715;

            private static readonly InjectableId readerWriterInjectableId = new InjectableId(InjectableType.ReaderWriter, componentId);
            private static readonly InjectableId commandRequestHandlerInjectableId = new InjectableId(InjectableType.CommandRequestHandler, componentId);

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

                var authoritiesChangedTags = AuthoritiesChangedComponentGroup.GetComponentDataArray<AuthorityChanges<SpatialOSExhaustiveSingular>>();
                var entities = AuthoritiesChangedComponentGroup.GetEntityArray();
                for (var i = 0; i < entities.Length; i++)
                {
                    var activationManager = entityIndexToManagers[entities[i].Index];
                    for (var j = 0; j < authoritiesChangedTags[i].Changes.Count; j++)
                    {
                        activationManager.ChangeAuthority(componentId, authoritiesChangedTags[i].Changes[j]);
                    }
                }
            }

            public override void InvokeOnComponentUpdateCallbacks(Dictionary<int, InjectableStore> entityIndexToInjectableStore)
            {
                if (ComponentsUpdatedComponentGroup.IsEmptyIgnoreFilter)
                {
                    return;
                }

                var entities = ComponentsUpdatedComponentGroup.GetEntityArray();
                var updateLists = ComponentsUpdatedComponentGroup.GetComponentDataArray<SpatialOSExhaustiveSingular.ReceivedUpdates>();
                for (var i = 0; i < entities.Length; i++)
                {
                    var injectableStore = entityIndexToInjectableStore[entities[i].Index];
                    if (!injectableStore.TryGetInjectablesForComponent(readerWriterInjectableId, out var readersWriters))
                    {
                        continue;
                    }

                    var updateList = updateLists[i];
                    foreach (Requirables.ReaderWriterImpl readerWriter in readersWriters)
                    {
                        foreach (var update in updateList.Updates)
                        {
                            readerWriter.OnComponentUpdate(update);
                        }
                    }
                }
            }

            public override void InvokeOnEventCallbacks(Dictionary<int, InjectableStore> entityIndexToInjectableStore)
            {
            }

            public override void InvokeOnCommandRequestCallbacks(Dictionary<int, InjectableStore> entityIndexToInjectableStore)
            {
            }

            public override void InvokeOnAuthorityChangeCallbacks(Dictionary<int, InjectableStore> entityIndexToInjectableStore)
            {
                if (AuthoritiesChangedComponentGroup.IsEmptyIgnoreFilter)
                {
                    return;
                }

                var entities = AuthoritiesChangedComponentGroup.GetEntityArray();
                var authChangeLists = AuthoritiesChangedComponentGroup.GetComponentDataArray<AuthorityChanges<SpatialOSExhaustiveSingular>>();
                for (var i = 0; i < entities.Length; i++)
                {
                    var injectableStore = entityIndexToInjectableStore[entities[i].Index];
                    if (!injectableStore.TryGetInjectablesForComponent(readerWriterInjectableId, out var readersWriters))
                    {
                        continue;
                    }

                    var authChanges = authChangeLists[i];
                    foreach (Requirables.ReaderWriterImpl readerWriter in readersWriters)
                    {
                        foreach (var auth in authChanges.Changes)
                        {
                            readerWriter.OnAuthorityChange(auth);
                        }
                    }
                }
            }
        }
    }
}
