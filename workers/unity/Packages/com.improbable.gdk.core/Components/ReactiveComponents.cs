using Unity.Entities;

namespace Improbable.Gdk.Core
{
    /// <summary>
    ///     ECS component that denotes that a SpatialOS component has just been added.
    /// </summary>
    /// <remarks>
    ///    This is a reactive component and will be removed in the
    ///    <see cref="Improbable.Gdk.Core.CleanReactiveComponentsSystem"/> at the end of the frame.
    /// </remarks>
    /// <typeparam name="T">
    ///     The SpatialOS component that has just been added.
    /// </typeparam>
    public struct ComponentAdded<T> : IComponentData where T : ISpatialComponentData
    {
    }

    /// <summary>
    ///     ECS component that denotes that a SpatialOS component has just been removed.
    /// </summary>
    /// <remarks>
    ///    This is a reactive component and will be removed in the
    ///    <see cref="Improbable.Gdk.Core.CleanReactiveComponentsSystem"/> at the end of the frame.
    /// </remarks>
    /// <typeparam name="T">
    ///     The SpatialOS component that has just been removed.
    /// </typeparam>
    public struct ComponentRemoved<T> : IComponentData where T : ISpatialComponentData
    {
    }
}
