using Unity.Entities;

namespace Improbable.Gdk.Core.Commands
{
    public interface ICommandComponentManager
    {
        void PopulateCommandComponents(CommandSystem commandSystem, EntityManager entityManger, WorkerSystem workerSystem, World world);
        void Clean(World world);
    }
}
