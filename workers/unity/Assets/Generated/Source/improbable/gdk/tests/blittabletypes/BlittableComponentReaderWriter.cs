
// ===========
// DO NOT EDIT - this file is automatically regenerated.
// ===========

using System;
using System.Collections.Generic;
using Unity.Entities;
using Improbable.Gdk.Core;
using Improbable.Gdk.Core.GameObjectRepresentation;
using Entity = Unity.Entities.Entity;

namespace Generated.Improbable.Gdk.Tests.BlittableTypes
{
    public partial class BlittableComponent
    {
        [ComponentId(1001)]
        internal class ReaderWriterCreator : IReaderWriterCreator
        {
            public IReaderWriterInternal CreateReaderWriter(Entity entity, EntityManager entityManager, ILogDispatcher logDispatcher)
            {
                return new ReaderWriterImpl(entity, entityManager, logDispatcher);
            }
        }

        [ReaderInterface]
        [ComponentId(1001)]
        public interface Reader : IReader<SpatialOSBlittableComponent, SpatialOSBlittableComponent.Update>
        {
            event Action<BlittableBool> BoolFieldUpdated;
            event Action<int> IntFieldUpdated;
            event Action<long> LongFieldUpdated;
            event Action<float> FloatFieldUpdated;
            event Action<double> DoubleFieldUpdated;
            event Action<global::Generated.Improbable.Gdk.Tests.BlittableTypes.FirstEventPayload> OnFirstEvent;
            event Action<global::Generated.Improbable.Gdk.Tests.BlittableTypes.SecondEventPayload> OnSecondEvent;
        }

        [WriterInterface]
        [ComponentId(1001)]
        public interface Writer : IWriter<SpatialOSBlittableComponent, SpatialOSBlittableComponent.Update>
        {
            void SendFirstEvent( global::Generated.Improbable.Gdk.Tests.BlittableTypes.FirstEventPayload payload);
            void SendSecondEvent( global::Generated.Improbable.Gdk.Tests.BlittableTypes.SecondEventPayload payload);
        }

        internal class ReaderWriterImpl :
            ReaderWriterBase<SpatialOSBlittableComponent, SpatialOSBlittableComponent.Update>, Reader, Writer
        {
            public ReaderWriterImpl(Entity entity,EntityManager entityManager,ILogDispatcher logDispatcher)
                : base(entity, entityManager, logDispatcher)
            {
            }

            private readonly List<Action<BlittableBool>> boolFieldDelegates = new List<Action<BlittableBool>>();

            public event Action<BlittableBool> BoolFieldUpdated
            {
                add => boolFieldDelegates.Add(value);
                remove => boolFieldDelegates.Remove(value);
            }

            private readonly List<Action<int>> intFieldDelegates = new List<Action<int>>();

            public event Action<int> IntFieldUpdated
            {
                add => intFieldDelegates.Add(value);
                remove => intFieldDelegates.Remove(value);
            }

            private readonly List<Action<long>> longFieldDelegates = new List<Action<long>>();

            public event Action<long> LongFieldUpdated
            {
                add => longFieldDelegates.Add(value);
                remove => longFieldDelegates.Remove(value);
            }

            private readonly List<Action<float>> floatFieldDelegates = new List<Action<float>>();

            public event Action<float> FloatFieldUpdated
            {
                add => floatFieldDelegates.Add(value);
                remove => floatFieldDelegates.Remove(value);
            }

            private readonly List<Action<double>> doubleFieldDelegates = new List<Action<double>>();

            public event Action<double> DoubleFieldUpdated
            {
                add => doubleFieldDelegates.Add(value);
                remove => doubleFieldDelegates.Remove(value);
            }

            protected override void TriggerFieldCallbacks(SpatialOSBlittableComponent.Update update)
            {
                DispatchWithErrorHandling(update.BoolField, boolFieldDelegates);
                DispatchWithErrorHandling(update.IntField, intFieldDelegates);
                DispatchWithErrorHandling(update.LongField, longFieldDelegates);
                DispatchWithErrorHandling(update.FloatField, floatFieldDelegates);
                DispatchWithErrorHandling(update.DoubleField, doubleFieldDelegates);
            }
            protected override void ApplyUpdate(SpatialOSBlittableComponent.Update update, ref SpatialOSBlittableComponent data)
            {
                if (update.BoolField.HasValue)
                {
                    data.BoolField = update.BoolField.Value;
                }
                if (update.IntField.HasValue)
                {
                    data.IntField = update.IntField.Value;
                }
                if (update.LongField.HasValue)
                {
                    data.LongField = update.LongField.Value;
                }
                if (update.FloatField.HasValue)
                {
                    data.FloatField = update.FloatField.Value;
                }
                if (update.DoubleField.HasValue)
                {
                    data.DoubleField = update.DoubleField.Value;
                }
            }

            private readonly List<Action<global::Generated.Improbable.Gdk.Tests.BlittableTypes.FirstEventPayload>> firstEventDelegates = new System.Collections.Generic.List<System.Action<global::Generated.Improbable.Gdk.Tests.BlittableTypes.FirstEventPayload>>();

            public event Action<global::Generated.Improbable.Gdk.Tests.BlittableTypes.FirstEventPayload> OnFirstEvent
            {
                add => firstEventDelegates.Add(value);
                remove => firstEventDelegates.Remove(value);
            }

            public void OnFirstEventEvent(global::Generated.Improbable.Gdk.Tests.BlittableTypes.FirstEventPayload payload)
            {
                DispatchEventWithErrorHandling(payload, firstEventDelegates);
            }

            public void SendFirstEvent(global::Generated.Improbable.Gdk.Tests.BlittableTypes.FirstEventPayload payload)
            {
                var sender = EntityManager.GetComponentData<EventSender.FirstEvent>(Entity);
                sender.Events.Add(payload);
            }

            private readonly List<Action<global::Generated.Improbable.Gdk.Tests.BlittableTypes.SecondEventPayload>> secondEventDelegates = new System.Collections.Generic.List<System.Action<global::Generated.Improbable.Gdk.Tests.BlittableTypes.SecondEventPayload>>();

            public event Action<global::Generated.Improbable.Gdk.Tests.BlittableTypes.SecondEventPayload> OnSecondEvent
            {
                add => secondEventDelegates.Add(value);
                remove => secondEventDelegates.Remove(value);
            }

            public void OnSecondEventEvent(global::Generated.Improbable.Gdk.Tests.BlittableTypes.SecondEventPayload payload)
            {
                DispatchEventWithErrorHandling(payload, secondEventDelegates);
            }

            public void SendSecondEvent(global::Generated.Improbable.Gdk.Tests.BlittableTypes.SecondEventPayload payload)
            {
                var sender = EntityManager.GetComponentData<EventSender.SecondEvent>(Entity);
                sender.Events.Add(payload);
            }

            public void OnFirstCommandCommandRequest(FirstCommand.ReceivedRequest request)
            {
                throw new System.NotImplementedException();
            }

            public void OnSecondCommandCommandRequest(SecondCommand.ReceivedRequest request)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
