// ===========
// DO NOT EDIT - this file is automatically regenerated.
// ===========

using System.Collections.Generic;
using System.Linq;
using Unity.Entities;
using Improbable.Gdk.Core;
using Improbable.Gdk.Core.GameObjectRepresentation;
using Improbable.Worker.Core;

namespace Generated.Improbable
{
    public partial class EntityAcl
    {
        internal class GameObjectComponentDispatcher : GameObjectComponentDispatcherBase
        {
            public override ComponentType[] ComponentAddedComponentTypes => new ComponentType[]
            {
                ComponentType.ReadOnly<ComponentAdded<Generated.Improbable.EntityAcl.Component>>(), ComponentType.ReadOnly<GameObjectReference>()
            };

            public override ComponentType[] ComponentRemovedComponentTypes => new ComponentType[]
            {
                ComponentType.ReadOnly<ComponentRemoved<Generated.Improbable.EntityAcl.Component>>(), ComponentType.ReadOnly<GameObjectReference>()
            };

            public override ComponentType[] AuthorityGainedComponentTypes => new ComponentType[]
            {
                ComponentType.ReadOnly<AuthorityChanges<Generated.Improbable.EntityAcl.Component>>(), ComponentType.ReadOnly<GameObjectReference>(),
                ComponentType.ReadOnly<Authoritative<Generated.Improbable.EntityAcl.Component>>()
            };

            public override ComponentType[] AuthorityLostComponentTypes => new ComponentType[]
            {
                ComponentType.ReadOnly<AuthorityChanges<Generated.Improbable.EntityAcl.Component>>(), ComponentType.ReadOnly<GameObjectReference>(),
                ComponentType.ReadOnly<NotAuthoritative<Generated.Improbable.EntityAcl.Component>>()
            };

            public override ComponentType[] AuthorityLossImminentComponentTypes => new ComponentType[]
            {
                ComponentType.ReadOnly<AuthorityChanges<Generated.Improbable.EntityAcl.Component>>(), ComponentType.ReadOnly<GameObjectReference>(),
                ComponentType.ReadOnly<AuthorityLossImminent<Generated.Improbable.EntityAcl.Component>>()
            };

            public override ComponentType[] ComponentsUpdatedComponentTypes => new ComponentType[]
            {
                ComponentType.ReadOnly<Generated.Improbable.EntityAcl.ReceivedUpdates>(), ComponentType.ReadOnly<GameObjectReference>()
            };

            public override ComponentType[][] EventsReceivedComponentTypeArrays => new ComponentType[][]
            {
            };

            public override ComponentType[][] CommandRequestsComponentTypeArrays => new ComponentType[][]
            {
            };

            public override ComponentType[][] CommandResponsesComponentTypeArrays => new ComponentType[][]
            {
            };

            private const uint componentId = 50;
            private static readonly InjectableId readerWriterInjectableId = new InjectableId(InjectableType.ReaderWriter, componentId);

            public override void MarkComponentsAddedForActivation(Dictionary<Unity.Entities.Entity, MonoBehaviourActivationManager> entityToManagers)
            {
                if (ComponentAddedComponentGroup.IsEmptyIgnoreFilter)
                {
                    return;
                }

                var entities = ComponentAddedComponentGroup.GetEntityArray();
                for (var i = 0; i < entities.Length; i++)
                {
                    var activationManager = entityToManagers[entities[i]];
                    activationManager.AddComponent(componentId);
                }
            }

            public override void MarkComponentsRemovedForDeactivation(Dictionary<Unity.Entities.Entity, MonoBehaviourActivationManager> entityToManagers)
            {
                if (ComponentRemovedComponentGroup.IsEmptyIgnoreFilter)
                {
                    return;
                }

                var entities = ComponentRemovedComponentGroup.GetEntityArray();
                for (var i = 0; i < entities.Length; i++)
                {
                    var activationManager = entityToManagers[entities[i]];
                    activationManager.RemoveComponent(componentId);
                }
            }

            public override void MarkAuthorityGainedForActivation(Dictionary<Unity.Entities.Entity, MonoBehaviourActivationManager> entityToManagers)
            {
                if (AuthorityGainedComponentGroup.IsEmptyIgnoreFilter)
                {
                    return;
                }

                var authoritiesChangedTags = AuthorityGainedComponentGroup.GetComponentDataArray<AuthorityChanges<Generated.Improbable.EntityAcl.Component>>();
                var entities = AuthorityGainedComponentGroup.GetEntityArray();
                for (var i = 0; i < entities.Length; i++)
                {
                    var activationManager = entityToManagers[entities[i]];
                    // Call once except if flip-flopped back to starting state
                    if (IsFirstAuthChange(Authority.Authoritative, authoritiesChangedTags[i]))
                    {
                        activationManager.ChangeAuthority(componentId, Authority.Authoritative);
                    }
                }
            }

            public override void MarkAuthorityLostForDeactivation(Dictionary<Unity.Entities.Entity, MonoBehaviourActivationManager> entityToManagers)
            {
                if (AuthorityLostComponentGroup.IsEmptyIgnoreFilter)
                {
                    return;
                }

                var authoritiesChangedTags = AuthorityLostComponentGroup.GetComponentDataArray<AuthorityChanges<Generated.Improbable.EntityAcl.Component>>();
                var entities = AuthorityLostComponentGroup.GetEntityArray();
                for (var i = 0; i < entities.Length; i++)
                {
                    var activationManager = entityToManagers[entities[i]];
                    // Call once except if flip-flopped back to starting state
                    if (IsFirstAuthChange(Authority.NotAuthoritative, authoritiesChangedTags[i]))
                    {
                        activationManager.ChangeAuthority(componentId, Authority.NotAuthoritative);
                    }
                }
            }

            public override void InvokeOnComponentUpdateCallbacks(Dictionary<Unity.Entities.Entity, InjectableStore> entityToInjectableStore)
            {
                if (ComponentsUpdatedComponentGroup.IsEmptyIgnoreFilter)
                {
                    return;
                }

                var entities = ComponentsUpdatedComponentGroup.GetEntityArray();
                var updateLists = ComponentsUpdatedComponentGroup.GetComponentDataArray<Generated.Improbable.EntityAcl.ReceivedUpdates>();
                for (var i = 0; i < entities.Length; i++)
                {
                    var injectableStore = entityToInjectableStore[entities[i]];
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

            public override void InvokeOnEventCallbacks(Dictionary<Unity.Entities.Entity, InjectableStore> entityToInjectableStore)
            {
            }

            public override void InvokeOnCommandRequestCallbacks(Dictionary<Unity.Entities.Entity, InjectableStore> entityToInjectableStore)
            {
            }

            public override void InvokeOnCommandResponseCallbacks(Dictionary<Unity.Entities.Entity, InjectableStore> entityToInjectableStore)
            {
            }

            public override void InvokeOnAuthorityGainedCallbacks(Dictionary<Unity.Entities.Entity, InjectableStore> entityToInjectableStore)
            {
                if (AuthorityGainedComponentGroup.IsEmptyIgnoreFilter)
                {
                    return;
                }

                var entities = AuthorityGainedComponentGroup.GetEntityArray();
                var changeOpsLists = AuthorityGainedComponentGroup.GetComponentDataArray<AuthorityChanges<Generated.Improbable.EntityAcl.Component>>();

                // Call once on all entities unless they flip-flopped back into the state they started in
                for (var i = 0; i < entities.Length; i++)
                {
                    var injectableStore = entityToInjectableStore[entities[i]];
                    if (!injectableStore.TryGetInjectablesForComponent(readerWriterInjectableId, out var readersWriters))
                    {
                        continue;
                    }

                    if (IsFirstAuthChange(Authority.Authoritative, changeOpsLists[i]))
                    {
                        foreach (Requirables.ReaderWriterImpl readerWriter in readersWriters)
                        {
                            readerWriter.OnAuthorityChange(Authority.Authoritative);
                        }
                    }
                }
            }

            public override void InvokeOnAuthorityLostCallbacks(Dictionary<Unity.Entities.Entity, InjectableStore> entityToInjectableStore)
            {
                if (AuthorityLostComponentGroup.IsEmptyIgnoreFilter)
                {
                    return;
                }

                var entities = AuthorityLostComponentGroup.GetEntityArray();
                var changeOpsLists = AuthorityLostComponentGroup.GetComponentDataArray<AuthorityChanges<Generated.Improbable.EntityAcl.Component>>();

                // Call once on all entities unless they flip-flopped back into the state they started in
                for (var i = 0; i < entities.Length; i++)
                {
                    var injectableStore = entityToInjectableStore[entities[i]];
                    if (!injectableStore.TryGetInjectablesForComponent(readerWriterInjectableId, out var readersWriters))
                    {
                        continue;
                    }

                    if (IsFirstAuthChange(Authority.NotAuthoritative, changeOpsLists[i]))
                    {
                        foreach (Requirables.ReaderWriterImpl readerWriter in readersWriters)
                        {
                            readerWriter.OnAuthorityChange(Authority.NotAuthoritative);
                        }
                    }
                }
            }

            private bool IsFirstAuthChange(Authority authToMatch, AuthorityChanges<Generated.Improbable.EntityAcl.Component> changeOps)
            {
                foreach (var auth in changeOps.Changes)
                {
                    if (auth != Authority.AuthorityLossImminent) // not relevant
                    {
                        return auth == authToMatch;
                    }
                }
                return false;
            }

            public override void InvokeOnAuthorityLossImminentCallbacks(Dictionary<Unity.Entities.Entity, InjectableStore> entityToInjectableStore)
            {
                if (AuthorityLossImminentComponentGroup.IsEmptyIgnoreFilter)
                {
                    return;
                }

                var entities = AuthorityLossImminentComponentGroup.GetEntityArray();

                // Call once on all entities
                for (var i = 0; i < entities.Length; i++)
                {
                    var injectableStore = entityToInjectableStore[entities[i]];
                    if (!injectableStore.TryGetInjectablesForComponent(readerWriterInjectableId, out var readersWriters))
                    {
                        continue;
                    }
                    foreach (Requirables.ReaderWriterImpl readerWriter in readersWriters)
                    {
                        readerWriter.OnAuthorityChange(Authority.AuthorityLossImminent);
                    }
                }
            }
        }
    }
}
