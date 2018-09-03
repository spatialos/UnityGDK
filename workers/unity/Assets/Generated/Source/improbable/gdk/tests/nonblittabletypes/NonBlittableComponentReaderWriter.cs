
// ===========
// DO NOT EDIT - this file is automatically regenerated.
// ===========

using System;
using System.Collections.Generic;
using Unity.Entities;
using Improbable.Gdk.Core;
using Improbable.Gdk.Core.GameObjectRepresentation;
using Entity = Unity.Entities.Entity;

namespace Generated.Improbable.Gdk.Tests.NonblittableTypes
{
    public partial class NonBlittableComponent
    {
        public partial class Requirables
        {
            [InjectableId(InjectableType.ReaderWriter, 1002)]
            internal class ReaderWriterCreator : IInjectableCreator
            {
                public IInjectable CreateInjectable(Entity entity, EntityManager entityManager, ILogDispatcher logDispatcher)
                {
                    return new ReaderWriterImpl(entity, entityManager, logDispatcher);
                }
            }

            [InjectableId(InjectableType.ReaderWriter, 1002)]
            [InjectionCondition(InjectionCondition.RequireComponentPresent)]
            public interface Reader : IReader<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.Component, Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.Update>
            {
                event Action<BlittableBool> BoolFieldUpdated;
                event Action<int> IntFieldUpdated;
                event Action<long> LongFieldUpdated;
                event Action<float> FloatFieldUpdated;
                event Action<double> DoubleFieldUpdated;
                event Action<string> StringFieldUpdated;
                event Action<int?> OptionalFieldUpdated;
                event Action<global::System.Collections.Generic.List<int>> ListFieldUpdated;
                event Action<global::System.Collections.Generic.Dictionary<int,string>> MapFieldUpdated;
                event Action<global::Generated.Improbable.Gdk.Tests.NonblittableTypes.FirstEventPayload> OnFirstEvent;
                event Action<global::Generated.Improbable.Gdk.Tests.NonblittableTypes.SecondEventPayload> OnSecondEvent;
            }

            [InjectableId(InjectableType.ReaderWriter, 1002)]
            [InjectionCondition(InjectionCondition.RequireComponentWithAuthority)]
            public interface Writer : IWriter<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.Component, Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.Update>
            {
                void SendFirstEvent( global::Generated.Improbable.Gdk.Tests.NonblittableTypes.FirstEventPayload payload);
                void SendSecondEvent( global::Generated.Improbable.Gdk.Tests.NonblittableTypes.SecondEventPayload payload);
            }

            internal class ReaderWriterImpl :
                ReaderWriterBase<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.Component, Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.Update>, Reader, Writer
            {
                public ReaderWriterImpl(Entity entity, EntityManager entityManager, ILogDispatcher logDispatcher)
                    : base(entity, entityManager, logDispatcher)
                {
                }

                private readonly List<Action<BlittableBool>> boolFieldDelegates = new List<Action<BlittableBool>>();

                public event Action<BlittableBool> BoolFieldUpdated
                {
                    add
                    {
                        if (LogErrorIfDisposed())
                        {
                            return;
                        }

                        boolFieldDelegates.Add(value);
                    }
                    remove
                    {
                        if (LogErrorIfDisposed())
                        {
                            return;
                        }

                        boolFieldDelegates.Remove(value);
                    }
                }

                private readonly List<Action<int>> intFieldDelegates = new List<Action<int>>();

                public event Action<int> IntFieldUpdated
                {
                    add
                    {
                        if (LogErrorIfDisposed())
                        {
                            return;
                        }

                        intFieldDelegates.Add(value);
                    }
                    remove
                    {
                        if (LogErrorIfDisposed())
                        {
                            return;
                        }

                        intFieldDelegates.Remove(value);
                    }
                }

                private readonly List<Action<long>> longFieldDelegates = new List<Action<long>>();

                public event Action<long> LongFieldUpdated
                {
                    add
                    {
                        if (LogErrorIfDisposed())
                        {
                            return;
                        }

                        longFieldDelegates.Add(value);
                    }
                    remove
                    {
                        if (LogErrorIfDisposed())
                        {
                            return;
                        }

                        longFieldDelegates.Remove(value);
                    }
                }

                private readonly List<Action<float>> floatFieldDelegates = new List<Action<float>>();

                public event Action<float> FloatFieldUpdated
                {
                    add
                    {
                        if (LogErrorIfDisposed())
                        {
                            return;
                        }

                        floatFieldDelegates.Add(value);
                    }
                    remove
                    {
                        if (LogErrorIfDisposed())
                        {
                            return;
                        }

                        floatFieldDelegates.Remove(value);
                    }
                }

                private readonly List<Action<double>> doubleFieldDelegates = new List<Action<double>>();

                public event Action<double> DoubleFieldUpdated
                {
                    add
                    {
                        if (LogErrorIfDisposed())
                        {
                            return;
                        }

                        doubleFieldDelegates.Add(value);
                    }
                    remove
                    {
                        if (LogErrorIfDisposed())
                        {
                            return;
                        }

                        doubleFieldDelegates.Remove(value);
                    }
                }

                private readonly List<Action<string>> stringFieldDelegates = new List<Action<string>>();

                public event Action<string> StringFieldUpdated
                {
                    add
                    {
                        if (LogErrorIfDisposed())
                        {
                            return;
                        }

                        stringFieldDelegates.Add(value);
                    }
                    remove
                    {
                        if (LogErrorIfDisposed())
                        {
                            return;
                        }

                        stringFieldDelegates.Remove(value);
                    }
                }

                private readonly List<Action<int?>> optionalFieldDelegates = new List<Action<int?>>();

                public event Action<int?> OptionalFieldUpdated
                {
                    add
                    {
                        if (LogErrorIfDisposed())
                        {
                            return;
                        }

                        optionalFieldDelegates.Add(value);
                    }
                    remove
                    {
                        if (LogErrorIfDisposed())
                        {
                            return;
                        }

                        optionalFieldDelegates.Remove(value);
                    }
                }

                private readonly List<Action<global::System.Collections.Generic.List<int>>> listFieldDelegates = new List<Action<global::System.Collections.Generic.List<int>>>();

                public event Action<global::System.Collections.Generic.List<int>> ListFieldUpdated
                {
                    add
                    {
                        if (LogErrorIfDisposed())
                        {
                            return;
                        }

                        listFieldDelegates.Add(value);
                    }
                    remove
                    {
                        if (LogErrorIfDisposed())
                        {
                            return;
                        }

                        listFieldDelegates.Remove(value);
                    }
                }

                private readonly List<Action<global::System.Collections.Generic.Dictionary<int,string>>> mapFieldDelegates = new List<Action<global::System.Collections.Generic.Dictionary<int,string>>>();

                public event Action<global::System.Collections.Generic.Dictionary<int,string>> MapFieldUpdated
                {
                    add
                    {
                        if (LogErrorIfDisposed())
                        {
                            return;
                        }

                        mapFieldDelegates.Add(value);
                    }
                    remove
                    {
                        if (LogErrorIfDisposed())
                        {
                            return;
                        }

                        mapFieldDelegates.Remove(value);
                    }
                }

                protected override void TriggerFieldCallbacks(Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.Update update)
                {
                    DispatchWithErrorHandling(update.BoolField, boolFieldDelegates);
                    DispatchWithErrorHandling(update.IntField, intFieldDelegates);
                    DispatchWithErrorHandling(update.LongField, longFieldDelegates);
                    DispatchWithErrorHandling(update.FloatField, floatFieldDelegates);
                    DispatchWithErrorHandling(update.DoubleField, doubleFieldDelegates);
                    DispatchWithErrorHandling(update.StringField, stringFieldDelegates);
                    DispatchWithErrorHandling(update.OptionalField, optionalFieldDelegates);
                    DispatchWithErrorHandling(update.ListField, listFieldDelegates);
                    DispatchWithErrorHandling(update.MapField, mapFieldDelegates);
                }

                protected override void ApplyUpdate(Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.Update update, ref Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.Component data)
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
                    if (update.StringField.HasValue)
                    {
                        data.StringField = update.StringField.Value;
                    }
                    if (update.OptionalField.HasValue)
                    {
                        data.OptionalField = update.OptionalField.Value;
                    }
                    if (update.ListField.HasValue)
                    {
                        data.ListField = update.ListField.Value;
                    }
                    if (update.MapField.HasValue)
                    {
                        data.MapField = update.MapField.Value;
                    }
                }

                private readonly List<Action<global::Generated.Improbable.Gdk.Tests.NonblittableTypes.FirstEventPayload>> FirstEventDelegates = new List<Action<global::Generated.Improbable.Gdk.Tests.NonblittableTypes.FirstEventPayload>>();

                public event Action<global::Generated.Improbable.Gdk.Tests.NonblittableTypes.FirstEventPayload> OnFirstEvent
                {
                    add
                    {
                        if (LogErrorIfDisposed())
                        {
                            return;
                        }

                        FirstEventDelegates.Add(value);
                    }
                    remove
                    {
                        if (LogErrorIfDisposed())
                        {
                            return;
                        }

                        FirstEventDelegates.Remove(value);
                    }
                }

                public void OnFirstEventEvent(global::Generated.Improbable.Gdk.Tests.NonblittableTypes.FirstEventPayload payload)
                {
                    GameObjectDelegates.DispatchWithErrorHandling(payload, FirstEventDelegates, logDispatcher);
                }

                public void SendFirstEvent(global::Generated.Improbable.Gdk.Tests.NonblittableTypes.FirstEventPayload payload)
                {
                    if (LogErrorIfDisposed())
                    {
                        return;
                    }

                    var sender = EntityManager.GetComponentData<EventSender.FirstEvent>(Entity);
                    sender.Events.Add(payload);
                }

                private readonly List<Action<global::Generated.Improbable.Gdk.Tests.NonblittableTypes.SecondEventPayload>> SecondEventDelegates = new List<Action<global::Generated.Improbable.Gdk.Tests.NonblittableTypes.SecondEventPayload>>();

                public event Action<global::Generated.Improbable.Gdk.Tests.NonblittableTypes.SecondEventPayload> OnSecondEvent
                {
                    add
                    {
                        if (LogErrorIfDisposed())
                        {
                            return;
                        }

                        SecondEventDelegates.Add(value);
                    }
                    remove
                    {
                        if (LogErrorIfDisposed())
                        {
                            return;
                        }

                        SecondEventDelegates.Remove(value);
                    }
                }

                public void OnSecondEventEvent(global::Generated.Improbable.Gdk.Tests.NonblittableTypes.SecondEventPayload payload)
                {
                    GameObjectDelegates.DispatchWithErrorHandling(payload, SecondEventDelegates, logDispatcher);
                }

                public void SendSecondEvent(global::Generated.Improbable.Gdk.Tests.NonblittableTypes.SecondEventPayload payload)
                {
                    if (LogErrorIfDisposed())
                    {
                        return;
                    }

                    var sender = EntityManager.GetComponentData<EventSender.SecondEvent>(Entity);
                    sender.Events.Add(payload);
                }
            }
        }
    }
}
