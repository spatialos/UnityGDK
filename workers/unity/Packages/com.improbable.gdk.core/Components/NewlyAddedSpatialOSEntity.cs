using Unity.Entities;

namespace Improbable.Gdk.Core
{
    /// <summary>
    ///     Tag component for marking SpatialOS entities that were just checked-out and still require setup.
    ///     This component is automatically added to an entity upon its creation and automatically removed at the end of the
    ///     same frame.
    /// </summary>
    public struct NewlyAddedSpatialOSEntity : IComponentData, RemoveAtEndOfTick
    {
        public void RemoveComponent(EntityCommandBuffer commands, Entity entity)
        {
            commands.RemoveComponent<NewlyAddedSpatialOSEntity>(entity);
        }
    }
}
