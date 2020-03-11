// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using Unity.Entities;
using Unity.Collections;
using Improbable.Gdk.Core;
using Improbable.Gdk.Core.CodegenAdapters;
using Unity.Profiling;

namespace Improbable.TestSchema
{
    public partial class RecursiveComponent
    {
        internal class ComponentReplicator : IComponentReplicationHandler
        {
            private ProfilerMarker componentMarker = new ProfilerMarker("RecursiveComponent");

            public uint ComponentId => 18800;

            public EntityQueryDesc ComponentUpdateQuery => new EntityQueryDesc
            {
                All = new[]
                {
                    ComponentType.ReadWrite<global::Improbable.TestSchema.RecursiveComponent.Component>(),
                    ComponentType.ReadWrite<global::Improbable.TestSchema.RecursiveComponent.ComponentAuthority>(),
                    ComponentType.ReadOnly<SpatialEntityId>()
                },
            };

            public void SendUpdates(
                NativeArray<ArchetypeChunk> chunkArray,
                ComponentSystemBase system,
                EntityManager entityManager,
                ComponentUpdateSystem componentUpdateSystem)
            {
                using (componentMarker.Auto())
                {
                    var spatialOSEntityType = system.GetArchetypeChunkComponentType<SpatialEntityId>(true);
                    var componentType = system.GetArchetypeChunkComponentType<global::Improbable.TestSchema.RecursiveComponent.Component>();
                    var authorityType = system.GetArchetypeChunkSharedComponentType<ComponentAuthority>();

                    foreach (var chunk in chunkArray)
                    {
                        var entityIdArray = chunk.GetNativeArray(spatialOSEntityType);
                        var componentArray = chunk.GetNativeArray(componentType);
                        var authorityIndex = chunk.GetSharedComponentIndex(authorityType);

                        if (!entityManager.GetSharedComponentData<ComponentAuthority>(authorityIndex).HasAuthority)
                        {
                            continue;
                        }

                        for (var i = 0; i < componentArray.Length; i++)
                        {
                            var data = componentArray[i];

                            if (data.IsDataDirty())
                            {
                                var update = new Update();

                                if (data.IsDataDirty(0))
                                {
                                    update.A = data.A;
                                }

                                if (data.IsDataDirty(1))
                                {
                                    update.B = data.B;
                                }

                                if (data.IsDataDirty(2))
                                {
                                    update.C = data.C;
                                }

                                componentUpdateSystem.SendUpdate(in update, entityIdArray[i].EntityId);
                                data.MarkDataClean();
                                componentArray[i] = data;
                            }
                        }
                    }
                }
            }
        }
    }
}
