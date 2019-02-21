using Improbable.Gdk.Core;
using Improbable.Worker.CInterop;

namespace Improbable.Gdk.TestUtils
{
    public class DiffBuilder
    {
        private ViewDiff diff = new ViewDiff();

        private uint updateId;

        public DiffBuilder CreateEntity(long entityId, EntityTemplate template)
        {
            var handler = new TemplateDynamicHandler(template, entityId, diff);
            DynamicConverter.ForEachComponent(handler);

            return this;
        }

        public DiffBuilder ChangeAuthority(long entityId, uint componentId, Authority newAuthority)
        {
            diff.SetAuthority(entityId, componentId, newAuthority);

            return this;
        }

        public DiffBuilder UpdateComponent<T>(long entityId, uint componentId, T update) where T : ISpatialComponentUpdate
        {
            diff.AddComponentUpdate(update, entityId, componentId, updateId++);
            return this;
        }

        public DiffBuilder AddEvent<T>(long entityId, uint componentId, T ev) where T : IEvent
        {
            diff.AddEvent(ev, entityId, componentId, updateId++);
            return this;
        }

        // TODO: Commands later.

        private class TemplateDynamicHandler : DynamicConverter.IConverterHandler
        {
            private EntityTemplate template;
            private ViewDiff viewDiff;
            private long entityId;

            public TemplateDynamicHandler(EntityTemplate template, long entityId, ViewDiff viewDiff)
            {
                this.template = template;
                this.viewDiff = viewDiff;
                this.entityId = entityId;

                viewDiff.AddEntity(this.entityId);
            }

            public void Accept<TSnapshot, TUpdate>(uint componentId,
                DynamicConverter.SnapshotToUpdate<TSnapshot, TUpdate> snapshotToUpdate)
                where TSnapshot : struct, ISpatialComponentSnapshot
                where TUpdate : struct, ISpatialComponentUpdate
            {
                var maybeSnapshot = template.GetComponent<TSnapshot>();

                if (!maybeSnapshot.HasValue)
                {
                    return;
                }

                var snapshot = maybeSnapshot.Value;
                viewDiff.AddComponent(snapshotToUpdate(snapshot), entityId, componentId);
            }
        }
    }
}
