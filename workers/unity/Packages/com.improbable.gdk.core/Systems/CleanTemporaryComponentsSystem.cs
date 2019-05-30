using System.Collections.Generic;
using System.Reflection;
using Unity.Collections;
using Unity.Entities;
using UnityEngine.Profiling;

namespace Improbable.Gdk.Core
{
    /// <summary>
    ///     Removes components with attribute RemoveAtEndOfTick from all entities
    /// </summary>
    [DisableAutoCreation]
    [UpdateInGroup(typeof(SpatialOSSendGroup.InternalSpatialOSCleanGroup))]
    public class CleanTemporaryComponentsSystem : ComponentSystem
    {
        private readonly List<(ComponentGroup, ComponentType)> componentGroupsToRemove =
            new List<(ComponentGroup, ComponentType)>();

        protected override void OnCreateManager()
        {
            base.OnCreateManager();

            // Find all components with the RemoveAtEndOfTick attribute
            foreach (var type in ReflectionUtility.GetNonAbstractTypes(typeof(IComponentData),
                typeof(RemoveAtEndOfTickAttribute)))
            {
                componentGroupsToRemove.Add((GetComponentGroup(ComponentType.ReadOnly(type)), type));
            }

            foreach (var type in ReflectionUtility.GetNonAbstractTypes(typeof(ISharedComponentData),
                typeof(RemoveAtEndOfTickAttribute)))
            {
                componentGroupsToRemove.Add((GetComponentGroup(ComponentType.ReadOnly(type)), type));
            }
        }

        protected override void OnUpdate()
        {
            Profiler.BeginSample("RemoveRemoveAtEndOfTick");
            foreach ((var componentGroup, var componentType) in componentGroupsToRemove)
            {
                if (componentGroup.IsEmptyIgnoreFilter)
                {
                    continue;
                }

                using (var entityArray = componentGroup.ToEntityArray(Allocator.TempJob))
                {
                    foreach (var entity in entityArray)
                    {
                        PostUpdateCommands.RemoveComponent(entity, componentType);
                    }
                }
            }

            Profiler.EndSample();
        }
    }
}
