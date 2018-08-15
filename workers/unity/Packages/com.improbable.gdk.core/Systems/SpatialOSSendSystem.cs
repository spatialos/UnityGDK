using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Improbable.Gdk.Core
{
    [UpdateInGroup(typeof(SpatialOSSendGroup.InternalSpatialOSSendGroup))]
    public class SpatialOSSendSystem : ComponentSystem
    {
        private readonly List<int> registeredReplicators = new List<int>();
        private readonly List<int> commandSenders = new List<int>();

        public struct Data
        {
            public readonly int Length;
            [ReadOnly] public SharedComponentDataArray<WorkerConfig> WorkerConfigs;
        }

        [Inject] private Data data;

        protected override void OnCreateManager(int capacity)
        {
            base.OnCreateManager(capacity);
            var worker = data.WorkerConfigs[0].Worker;
            GenerateComponentGroups(worker);
        }
        
        private void GenerateComponentGroups(Worker worker)
        {
            foreach (var componentTranslatorPair in worker.TranslationUnits)
            {
                var componentIndex = componentTranslatorPair.Key;
                var componentTranslator = componentTranslatorPair.Value;

                var replicationComponentGroup = GetComponentGroup(componentTranslator.ReplicationComponentTypes);
                componentTranslator.ReplicationComponentGroup = replicationComponentGroup;

                registeredReplicators.Add(componentIndex);
                commandSenders.Add(componentIndex);
            }
        }

        public bool TryRegisterCustomReplicationSystem(ComponentType type)
        {
            if (!registeredReplicators.Contains(type.TypeIndex))
            {
                return false;
            }

            // The default replication system is removed, instead the custom one is responsible for replication.
            return registeredReplicators.Remove(type.TypeIndex);
        }


        protected override void OnUpdate()
        {
            var worker = data.WorkerConfigs[0].Worker;

            foreach (var componentTypeIndex in registeredReplicators)
            {
                worker.TranslationUnits[componentTypeIndex].ExecuteReplication(worker.Connection);
            }

            foreach (var componentTypeIndex in commandSenders)
            {
                worker.TranslationUnits[componentTypeIndex].SendCommands(worker.Connection);
            }
        }
    }
}
