using System.Collections.Generic;
using Improbable.Worker;
using Improbable.Worker.Core;
using UnityEngine;
using Entity = Unity.Entities.Entity;

namespace Improbable.Gdk.Core.GameObjectRepresentation
{
    /// <summary>
    ///     Keeps track of Component availability for MonoBehaviours on a particular GameObject and decides when
    ///     a MonoBehaviour has all the conditions associated with its [Require] tags fulfilled, at which point they
    ///     are enabled , calling into the RequiredFieldInjector for injection, storing the created Injectables in the
    ///     given ReaderWriterStore.
    /// </summary>
    internal class MonoBehaviourActivationManager
    {
        private readonly Entity entity;
        private readonly EntityId spatialId;

        private readonly Dictionary<uint, HashSet<MonoBehaviour>> behavioursRequiringComponentsPresent
            = new Dictionary<uint, HashSet<MonoBehaviour>>();

        private readonly Dictionary<uint, HashSet<MonoBehaviour>> behavioursRequiringComponentsWithAuth
            = new Dictionary<uint, HashSet<MonoBehaviour>>();

        private readonly Dictionary<MonoBehaviour, int> numUnsatisfiedRequirements
            = new Dictionary<MonoBehaviour, int>();

        private readonly HashSet<MonoBehaviour> behavioursToEnable = new HashSet<MonoBehaviour>();
        private readonly HashSet<MonoBehaviour> behavioursToDisable = new HashSet<MonoBehaviour>();

        private readonly InjectableStore store;
        private readonly RequiredFieldInjector injector;

        private readonly ILogDispatcher logger;

        private const string LoggerName = nameof(MonoBehaviourActivationManager);

        public MonoBehaviourActivationManager(GameObject gameObject, RequiredFieldInjector injector,
            InjectableStore store, ILogDispatcher logger)
        {
            this.logger = logger;
            this.store = store;
            this.injector = injector;

            var spatialComponent = gameObject.GetComponent<SpatialOSComponent>();
            entity = spatialComponent.Entity;
            spatialId = spatialComponent.SpatialEntityId;

            foreach (var behaviour in gameObject.GetComponents<MonoBehaviour>())
            {
                var behaviourType = behaviour.GetType();
                if (injector.HasRequiredFields(behaviourType))
                {
                    var componentReadRequirements = injector.GetComponentPresenceRequirements(behaviourType);
                    var componentAuthRequirements = injector.GetComponentAuthorityRequirements(behaviourType);
                    var readRequirementCount = componentReadRequirements.Count;
                    var authRequirementCount = componentAuthRequirements.Count;

                    if (readRequirementCount == 0 && authRequirementCount == 0)
                    {
                        behavioursToEnable.Add(behaviour);
                    }

                    if (readRequirementCount > 0)
                    {
                        AddBehaviourForComponentIds(behaviour, componentReadRequirements, behavioursRequiringComponentsPresent);
                    }

                    if (authRequirementCount > 0)
                    {
                        AddBehaviourForComponentIds(behaviour, componentAuthRequirements, behavioursRequiringComponentsWithAuth);
                    }

                    numUnsatisfiedRequirements[behaviour] = componentReadRequirements.Count + componentAuthRequirements.Count;

                    behaviour.enabled = false;
                }
            }
        }

        private void AddBehaviourForComponentIds(MonoBehaviour behaviour, List<uint> componentIds,
            Dictionary<uint, HashSet<MonoBehaviour>> componentIdsToBehaviours)
        {
            foreach (var id in componentIds)
            {
                if (!componentIdsToBehaviours.TryGetValue(id, out var behaviours))
                {
                    behaviours = new HashSet<MonoBehaviour>();
                    componentIdsToBehaviours[id] = behaviours;
                }

                behaviours.Add(behaviour);
            }
        }

        public void EnableSpatialOSBehaviours()
        {
            foreach (var behaviour in behavioursToEnable)
            {
                var injectedInjectables = injector.InjectAllRequiredFields(behaviour, entity);
                store.AddInjectablesForBehaviour(behaviour, injectedInjectables);
            }

            foreach (var behaviour in behavioursToEnable)
            {
                behaviour.enabled = true;
            }

            behavioursToEnable.Clear();
        }

        public void DisableSpatialOSBehaviours()
        {
            // Dispose all Requirables before OnDisable() so that users can't access potentially inaccessible ecs entity components.
            foreach (var behaviour in behavioursToDisable)
            {
                injector.DisposeAllRequiredFields(behaviour);
            }

            foreach (var behaviour in behavioursToDisable)
            {
                behaviour.enabled = false;
            }

            foreach (var behaviour in behavioursToDisable)
            {
                injector.DeInjectAllRequiredFields(behaviour);
                store.RemoveInjectablesForBehaviour(behaviour);
            }

            behavioursToDisable.Clear();
        }

        public void AddComponent(uint componentId)
        {
            if (!behavioursRequiringComponentsPresent.ContainsKey(componentId))
            {
                return;
            }

            // Mark reader components ready in relevant SpatialOSBehaviours
            var relevantReaderSpatialOSBehaviours = behavioursRequiringComponentsPresent[componentId];
            MarkComponentRequirementSatisfied(relevantReaderSpatialOSBehaviours);
        }

        public void RemoveComponent(uint componentId)
        {
            if (!behavioursRequiringComponentsPresent.ContainsKey(componentId))
            {
                return;
            }

            // Mark reader components not ready in relevant SpatialOSBehaviours
            var relevantReaderSpatialOSBehaviours = behavioursRequiringComponentsPresent[componentId];
            MarkComponentRequirementUnsatisfied(relevantReaderSpatialOSBehaviours);
        }

        public void ChangeAuthority(uint componentId, Authority authority)
        {
            if (!behavioursRequiringComponentsWithAuth.ContainsKey(componentId))
            {
                return;
            }

            if (authority == Authority.Authoritative)
            {
                // Mark writer components ready in relevant SpatialOSBehaviours
                var relevantWriterSpatialOSBehaviours = behavioursRequiringComponentsWithAuth[componentId];
                MarkComponentRequirementSatisfied(relevantWriterSpatialOSBehaviours);
            }
            else if (authority == Authority.NotAuthoritative)
            {
                // Mark writer components not ready in relevant SpatialOSBehaviours
                var relevantWriterSpatialOSBehaviours = behavioursRequiringComponentsWithAuth[componentId];
                MarkComponentRequirementUnsatisfied(relevantWriterSpatialOSBehaviours);
            }
        }

        private void MarkComponentRequirementSatisfied(IEnumerable<MonoBehaviour> behaviours)
        {
            // Inject all Readers/Writers at once when all requirements are met
            foreach (var behaviour in behaviours)
            {
                numUnsatisfiedRequirements[behaviour]--;
                if (numUnsatisfiedRequirements[behaviour] == 0)
                {
                    if (!behaviour.enabled)
                    {
                        // Schedule activation
                        behavioursToEnable.Add(behaviour);
                    }

                    if (behavioursToDisable.Contains(behaviour))
                    {
                        // Must be enabled already, so we were going to disable it - let's not
                        behavioursToDisable.Remove(behaviour);
                    }
                }
            }
        }

        private void MarkComponentRequirementUnsatisfied(IEnumerable<MonoBehaviour> behaviours)
        {
            foreach (var behaviour in behaviours)
            {
                // De-inject all Readers/Writers at once when a single requirement is not met
                if (numUnsatisfiedRequirements[behaviour] == 0)
                {
                    if (behaviour.enabled)
                    {
                        // Schedule deactivation
                        behavioursToDisable.Add(behaviour);
                    }

                    if (behavioursToEnable.Contains(behaviour))
                    {
                        // Must be disabled already, so we were going to enable it - let's not
                        behavioursToEnable.Remove(behaviour);
                    }
                }

                numUnsatisfiedRequirements[behaviour]++;
            }
        }
    }
}
