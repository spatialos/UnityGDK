using System;
using System.Collections.Generic;
using System.Reflection;
using Unity.Entities;

namespace Improbable.Gdk.Core
{
    /// <summary>
    ///     Removes GDK reactive components and components with attribute RemoveAtEndOfTick from all entities
    /// </summary>
    [UpdateInGroup(typeof(SpatialOSSendGroup.InternalSpatialOSCleanGroup))]
    public class CleanReactiveComponentsSystem : ComponentSystem
    {
        private MutableView view;

        private readonly List<Action> removeComponentActions = new List<Action>();

        // Here to prevent adding an action for the same type multiple times
        private readonly HashSet<Type> typesToRemove = new HashSet<Type>();

        protected override void OnCreateManager(int capacity)
        {
            base.OnCreateManager(capacity);

            var worker = WorkerRegistry.GetWorkerForWorld(World);
            view = worker.View;

            GenerateComponentGroups();
        }

        private void GenerateComponentGroups()
        {
            foreach (var translationUnit in view.TranslationUnits.Values)
            {
                translationUnit.CleanUpComponentGroups = new List<ComponentGroup>();
                foreach (ComponentType componentType in translationUnit.CleanUpComponentTypes)
                {
                    translationUnit.CleanUpComponentGroups.Add(GetComponentGroup(componentType));
                }
            }
            
            // Find all components with the RemoveAtEndOfTick attribute
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (var type in assembly.GetTypes())
                {
                    if (!typeof(RemoveAtEndOfTick).IsAssignableFrom(type) ||
                        (!typeof(IComponentData).IsAssignableFrom(type)
                         && !typeof(ISharedComponentData).IsAssignableFrom(type)))
                    {
                        continue;
                    }

                    if (typesToRemove.Contains(type))
                    {
                        continue;
                    }

                    typesToRemove.Add(type);
                    AddRemoveComponentAction(type);
                }
            }
        }

        private void AddRemoveComponentAction(ComponentType type)
        {
            var componentGroup = GetComponentGroup(type);
            removeComponentActions.Add(() =>
            {
                if (componentGroup.IsEmptyIgnoreFilter)
                {
                    return;
                }

                RemoveAtEndOfTick typeInstance = (RemoveAtEndOfTick)Activator.CreateInstance(type.GetManagedType());

                var entityArray = componentGroup.GetEntityArray();
                for (var i = 0; i < entityArray.Length; ++i)
                {
                    typeInstance.RemoveComponent(PostUpdateCommands, entityArray[i]);
                }
            });
        }
        
        protected override void OnUpdate()
        {
            var commandBuffer = PostUpdateCommands;

            // Clean generated components
            foreach (var translationUnit in view.TranslationUnits.Values)
            {
                translationUnit.CleanUpComponents(ref commandBuffer);
            }

            // Clean components with RemoveAtEndOfTick attribute
            foreach (var removeComponentAction in removeComponentActions)
            {
                removeComponentAction();
            }
        }
    }
}
