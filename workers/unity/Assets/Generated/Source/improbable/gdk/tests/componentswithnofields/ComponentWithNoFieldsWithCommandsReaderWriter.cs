
// ===========
// DO NOT EDIT - this file is automatically regenerated.
// ===========

using System;
using System.Collections.Generic;
using Unity.Entities;
using Improbable.Gdk.Core;
using Improbable.Gdk.Core.GameObjectRepresentation;
using Entity = Unity.Entities.Entity;

namespace Generated.Improbable.Gdk.Tests.ComponentsWithNoFields
{
    public partial class ComponentWithNoFieldsWithCommands
    {
        [InjectableId(InjectableType.ReaderWriter, 1005)]
        internal class ReaderWriterCreator : IInjectableCreator
        {
            public IInjectable CreateReaderWriter(Entity entity, EntityManager entityManager, ILogDispatcher logDispatcher)
            {
                return new ReaderWriterImpl(entity, entityManager, logDispatcher);
            }
        }

        [InjectableId(InjectableType.ReaderWriter, 1005)]
        [InjectionCondition(InjectionCondition.RequireComponentToRead)]
        public interface Reader : IReader<SpatialOSComponentWithNoFieldsWithCommands, SpatialOSComponentWithNoFieldsWithCommands.Update>
        {
        }

        [InjectableId(InjectableType.ReaderWriter, 1005)]
        [InjectionCondition(InjectionCondition.RequireComponentWithAuthority)]
        public interface Writer : IWriter<SpatialOSComponentWithNoFieldsWithCommands, SpatialOSComponentWithNoFieldsWithCommands.Update>
        {
        }

        internal class ReaderWriterImpl :
            BlittableReaderWriterBase<SpatialOSComponentWithNoFieldsWithCommands, SpatialOSComponentWithNoFieldsWithCommands.Update>, Reader, Writer
        {
            public ReaderWriterImpl(Entity entity,EntityManager entityManager,ILogDispatcher logDispatcher)
                : base(entity, entityManager, logDispatcher)
            {
            }

            protected override void TriggerFieldCallbacks(SpatialOSComponentWithNoFieldsWithCommands.Update update)
            {
            }
            protected override void ApplyUpdate(SpatialOSComponentWithNoFieldsWithCommands.Update update, ref SpatialOSComponentWithNoFieldsWithCommands data)
            {
            }

            public void OnCmdCommandRequest(Cmd.Request request)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
