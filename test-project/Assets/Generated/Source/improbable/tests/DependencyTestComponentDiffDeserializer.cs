// ===========
// DO NOT EDIT - this file is automatically regenerated.
// ===========

using Improbable.Gdk.Core;
using Improbable.Worker.CInterop;

namespace Improbable.Tests
{
    public partial class DependencyTest
    {
        public class DiffComponentDeserializer : IComponentDiffDeserializer
        {
            public uint GetComponentId()
            {
                return ComponentId;
            }

            public void AddUpdateToDiff(ComponentUpdateOp op, ViewDiff diff, uint updateId)
            {
                if (op.Update.SchemaData.Value.GetFields().GetUniqueFieldIdCount() > 0)
                {
                    var update = global::Improbable.Tests.DependencyTest.Serialization.DeserializeUpdate(op.Update.SchemaData.Value);
                    diff.AddComponentUpdate(update, op.EntityId, op.Update.ComponentId, updateId);
                }
            }

            public void AddComponentToDiff(AddComponentOp op, ViewDiff diff)
            {
                var data = Serialization.DeserializeUpdate(op.Data.SchemaData.Value);
                diff.AddComponent(data, op.EntityId, op.Data.ComponentId);
            }
        }

        public class ComponentSerializer : IComponentSerializer
        {
            public uint GetComponentId()
            {
                return ComponentId;
            }

            public void Serialize(MessagesToSend messages, SerializedMessagesToSend serializedMessages)
            {
                var storage = messages.GetComponentDiffStorage(ComponentId);

                var updates = ((IDiffUpdateStorage<Update>) storage).GetUpdates();

                for (int i = 0; i < updates.Count; ++i)
                {
                    ref readonly var update = ref updates[i];
                    var schemaUpdate = SchemaComponentUpdate.Create();
                    var componentUpdate = new ComponentUpdate(ComponentId, schemaUpdate);
                    Serialization.SerializeUpdate(update.Update, schemaUpdate);
                    serializedMessages.AddComponentUpdate(componentUpdate, update.EntityId.Id);
                }

            }
        }
    }
}
