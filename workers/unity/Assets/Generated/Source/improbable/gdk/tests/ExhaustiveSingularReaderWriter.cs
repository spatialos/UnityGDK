
// ===========
// DO NOT EDIT - this file is automatically regenerated.
// ===========

using Unity.Entities;
using Improbable.Gdk.Core;
using Improbable.Gdk.Core.GameObjectRepresentation;
using Improbable.Gdk.Core.MonoBehaviours;
using Improbable.Worker;
using Entity = Unity.Entities.Entity;

namespace Generated.Improbable.Gdk.Tests
{
    public partial class ExhaustiveSingular
    {
        [ComponentId(197715)]
        internal class ReaderWriterCreator : IReaderWriterCreator
        {
            public IReaderWriterInternal CreateReaderWriter(Entity entity, EntityManager entityManager, ILogDispatcher logDispatcher)
            {
                return new ReaderWriterImpl(entity, entityManager, logDispatcher);
            }
        }

        [ReaderInterface]
        [ComponentId(197715)]
        public interface Reader : IReader<SpatialOSExhaustiveSingular, SpatialOSExhaustiveSingular.Update>
        {
            event Action<BlittableBool> Field1Updated;
            event Action<float> Field2Updated;
            event Action<int> Field4Updated;
            event Action<long> Field5Updated;
            event Action<double> Field6Updated;
            event Action<string> Field7Updated;
            event Action<uint> Field8Updated;
            event Action<ulong> Field9Updated;
            event Action<int> Field10Updated;
            event Action<long> Field11Updated;
            event Action<uint> Field12Updated;
            event Action<ulong> Field13Updated;
            event Action<int> Field14Updated;
            event Action<long> Field15Updated;
            event Action<long> Field16Updated;
            event Action<global::Generated.Improbable.Gdk.Tests.SomeType> Field17Updated;
        }

        [WriterInterface]
        [ComponentId(197715)]
        public interface Writer : IWriter<SpatialOSExhaustiveSingular, SpatialOSExhaustiveSingular.Update>
        {
        }

        internal class ReaderWriterImpl :
            NonBlittableReaderWriterBase<SpatialOSExhaustiveSingular, SpatialOSExhaustiveSingular.Update>, Reader, Writer
        {
            public ReaderWriterImpl(Entity entity,EntityManager entityManager,ILogDispatcher logDispatcher)
                : base(entity, entityManager, logDispatcher)
            {
            }

            private readonly List<Action<BlittableBool>> field1Delegates = new List<Action<BlittableBool>>();

            public event Action<BlittableBool> Field1Updated
            {
                add => field1Delegates.Add(value);
                remove => field1Delegates.Remove(value);
            }

            private readonly List<Action<float>> field2Delegates = new List<Action<float>>();

            public event Action<float> Field2Updated
            {
                add => field2Delegates.Add(value);
                remove => field2Delegates.Remove(value);
            }

            private readonly List<Action<int>> field4Delegates = new List<Action<int>>();

            public event Action<int> Field4Updated
            {
                add => field4Delegates.Add(value);
                remove => field4Delegates.Remove(value);
            }

            private readonly List<Action<long>> field5Delegates = new List<Action<long>>();

            public event Action<long> Field5Updated
            {
                add => field5Delegates.Add(value);
                remove => field5Delegates.Remove(value);
            }

            private readonly List<Action<double>> field6Delegates = new List<Action<double>>();

            public event Action<double> Field6Updated
            {
                add => field6Delegates.Add(value);
                remove => field6Delegates.Remove(value);
            }

            private readonly List<Action<string>> field7Delegates = new List<Action<string>>();

            public event Action<string> Field7Updated
            {
                add => field7Delegates.Add(value);
                remove => field7Delegates.Remove(value);
            }

            private readonly List<Action<uint>> field8Delegates = new List<Action<uint>>();

            public event Action<uint> Field8Updated
            {
                add => field8Delegates.Add(value);
                remove => field8Delegates.Remove(value);
            }

            private readonly List<Action<ulong>> field9Delegates = new List<Action<ulong>>();

            public event Action<ulong> Field9Updated
            {
                add => field9Delegates.Add(value);
                remove => field9Delegates.Remove(value);
            }

            private readonly List<Action<int>> field10Delegates = new List<Action<int>>();

            public event Action<int> Field10Updated
            {
                add => field10Delegates.Add(value);
                remove => field10Delegates.Remove(value);
            }

            private readonly List<Action<long>> field11Delegates = new List<Action<long>>();

            public event Action<long> Field11Updated
            {
                add => field11Delegates.Add(value);
                remove => field11Delegates.Remove(value);
            }

            private readonly List<Action<uint>> field12Delegates = new List<Action<uint>>();

            public event Action<uint> Field12Updated
            {
                add => field12Delegates.Add(value);
                remove => field12Delegates.Remove(value);
            }

            private readonly List<Action<ulong>> field13Delegates = new List<Action<ulong>>();

            public event Action<ulong> Field13Updated
            {
                add => field13Delegates.Add(value);
                remove => field13Delegates.Remove(value);
            }

            private readonly List<Action<int>> field14Delegates = new List<Action<int>>();

            public event Action<int> Field14Updated
            {
                add => field14Delegates.Add(value);
                remove => field14Delegates.Remove(value);
            }

            private readonly List<Action<long>> field15Delegates = new List<Action<long>>();

            public event Action<long> Field15Updated
            {
                add => field15Delegates.Add(value);
                remove => field15Delegates.Remove(value);
            }

            private readonly List<Action<long>> field16Delegates = new List<Action<long>>();

            public event Action<long> Field16Updated
            {
                add => field16Delegates.Add(value);
                remove => field16Delegates.Remove(value);
            }

            private readonly List<Action<global::Generated.Improbable.Gdk.Tests.SomeType>> field17Delegates = new List<Action<global::Generated.Improbable.Gdk.Tests.SomeType>>();

            public event Action<global::Generated.Improbable.Gdk.Tests.SomeType> Field17Updated
            {
                add => field17Delegates.Add(value);
                remove => field17Delegates.Remove(value);
            }

            protected override void TriggerFieldCallbacks(SpatialOSExhaustiveSingular.Update update)
            {
                DispatchWithErrorHandling(update.Field1, field1Delegates);
                DispatchWithErrorHandling(update.Field2, field2Delegates);
                DispatchWithErrorHandling(update.Field4, field4Delegates);
                DispatchWithErrorHandling(update.Field5, field5Delegates);
                DispatchWithErrorHandling(update.Field6, field6Delegates);
                DispatchWithErrorHandling(update.Field7, field7Delegates);
                DispatchWithErrorHandling(update.Field8, field8Delegates);
                DispatchWithErrorHandling(update.Field9, field9Delegates);
                DispatchWithErrorHandling(update.Field10, field10Delegates);
                DispatchWithErrorHandling(update.Field11, field11Delegates);
                DispatchWithErrorHandling(update.Field12, field12Delegates);
                DispatchWithErrorHandling(update.Field13, field13Delegates);
                DispatchWithErrorHandling(update.Field14, field14Delegates);
                DispatchWithErrorHandling(update.Field15, field15Delegates);
                DispatchWithErrorHandling(update.Field16, field16Delegates);
                DispatchWithErrorHandling(update.Field17, field17Delegates);
            }
            protected override void ApplyUpdate(SpatialOSExhaustiveSingular.Update update, SpatialOSExhaustiveSingular data)
            {
                if (update.Field1.HasValue)
                {
                    data.Field1 = update.Field1.Value;
                }
                if (update.Field2.HasValue)
                {
                    data.Field2 = update.Field2.Value;
                }
                if (update.Field4.HasValue)
                {
                    data.Field4 = update.Field4.Value;
                }
                if (update.Field5.HasValue)
                {
                    data.Field5 = update.Field5.Value;
                }
                if (update.Field6.HasValue)
                {
                    data.Field6 = update.Field6.Value;
                }
                if (update.Field7.HasValue)
                {
                    data.Field7 = update.Field7.Value;
                }
                if (update.Field8.HasValue)
                {
                    data.Field8 = update.Field8.Value;
                }
                if (update.Field9.HasValue)
                {
                    data.Field9 = update.Field9.Value;
                }
                if (update.Field10.HasValue)
                {
                    data.Field10 = update.Field10.Value;
                }
                if (update.Field11.HasValue)
                {
                    data.Field11 = update.Field11.Value;
                }
                if (update.Field12.HasValue)
                {
                    data.Field12 = update.Field12.Value;
                }
                if (update.Field13.HasValue)
                {
                    data.Field13 = update.Field13.Value;
                }
                if (update.Field14.HasValue)
                {
                    data.Field14 = update.Field14.Value;
                }
                if (update.Field15.HasValue)
                {
                    data.Field15 = update.Field15.Value;
                }
                if (update.Field16.HasValue)
                {
                    data.Field16 = update.Field16.Value;
                }
                if (update.Field17.HasValue)
                {
                    data.Field17 = update.Field17.Value;
                }
            }

        }
    }
}
