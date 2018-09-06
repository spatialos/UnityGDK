﻿using Generated.Improbable.Gdk.Tests.BlittableTypes;
using Improbable.Gdk.Core;
using NUnit.Framework;
using Unity.Entities;

namespace Improbable.Gdk.Generated.EditmodeTests.MonoBehaviours.Readers
{
    internal abstract class ReaderWriterTestsBase
    {
        protected BlittableComponent.Requirables.Reader ReaderPublic;
        protected BlittableComponent.Requirables.Writer WriterPublic;
        protected BlittableComponent.Requirables.ReaderWriterImpl ReaderWriterInternal;
        protected EntityManager EntityManager;
        protected Entity Entity;
        private World world;

        [SetUp]
        public void SetUp()
        {
            world = new World("test-world");
            EntityManager = world.GetOrCreateManager<EntityManager>();
            Entity = EntityManager.CreateEntity(typeof(BlittableComponent.Component));
            ReaderWriterInternal =
                new BlittableComponent.Requirables.ReaderWriterImpl(Entity, EntityManager, new LoggingDispatcher());
            ReaderPublic = ReaderWriterInternal;
            WriterPublic = ReaderWriterInternal;
        }

        [TearDown]
        public void TearDown()
        {
            world.Dispose();
        }

        protected struct SomeOtherComponent : IComponentData
        {
        }
    }
}
