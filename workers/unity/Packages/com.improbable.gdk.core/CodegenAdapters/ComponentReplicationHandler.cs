using System.Collections.Generic;
using Improbable.Worker.Core;
using Unity.Entities;

namespace Improbable.Gdk.Core.CodegenAdapters
{
    public abstract class ComponentReplicationHandler
    {
        public abstract ComponentType[] ReplicationComponentTypes { get; }
        public abstract ComponentType[] CommandTypes { get; }
        public abstract ComponentType[] AuthorityLossComponentTypes { get; }

        public abstract void ExecuteReplication(ComponentGroup replicationGroup, Connection connection);
        public abstract void SendCommands(List<ComponentGroup> commandComponentGroups, Connection connection);

        public abstract void SendAuthorityLossImminentAcknowledgement(ComponentGroup authorityLossComponentGroup,
            Connection connection);

        protected EntityManager EntityManager;
        protected readonly CommandParameters ShortCircuitParameters;

        protected ComponentReplicationHandler(EntityManager entityManager)
        {
            EntityManager = entityManager;
            ShortCircuitParameters = new CommandParameters { AllowShortCircuiting = true };
        }
    }
}
