using Improbable.Gdk.Core.GameObjectRepresentation;
using Improbable.Gdk.TestUtils;
using Improbable.Worker;
using NUnit.Framework;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Improbable.Gdk.Core.EditmodeTests
{
    [TestFixture]
    public class EntityGameObjectLinkerTests
    {
        private ViewCommandBuffer viewCommandBuffer;
        private World world;
        private EntityManager entityManager;
        private EntityGameObjectLinker entityGameObjectLinker;
        private GameObject testGameObject;
        private Entity testEntity;
        private EntityCommandBuffer entityCommandBuffer;
        private readonly EntityId testSpatialEntityId = new EntityId(1337);

        [SetUp]
        public void Setup()
        {
            world = new World("TestWorld");
            entityManager = world.GetOrCreateManager<EntityManager>();
            world.CreateManager<WorkerSystem>(null, null, "TestWorker", Vector3.zero);
            entityGameObjectLinker = new EntityGameObjectLinker(world, new LoggingDispatcher());
            testGameObject = new GameObject();
            testEntity = entityManager.CreateEntity();
            viewCommandBuffer = new ViewCommandBuffer(entityManager, new LoggingDispatcher());
            entityCommandBuffer = new EntityCommandBuffer(Allocator.TempJob);
        }

        [TearDown]
        public void TearDown()
        {
            if (testGameObject != null)
            {
                Object.DestroyImmediate(testGameObject);
            }

            entityCommandBuffer.Dispose();
            world.Dispose();
        }

        [Test]
        public void LinkGameObjectToEntity_adds_SpatialOSComponent_component()
        {
            entityGameObjectLinker.LinkGameObjectToEntity(testGameObject, testEntity, testSpatialEntityId,
                viewCommandBuffer);
            var spatialOSComponent = testGameObject.GetComponent<SpatialOSComponent>();
            Assert.NotNull(spatialOSComponent);
            Assert.AreEqual(testEntity, spatialOSComponent.Entity);
            Assert.AreEqual(testSpatialEntityId, spatialOSComponent.SpatialEntityId);
            Assert.AreEqual(world, spatialOSComponent.World);
        }

        [Test]
        public void LinkGameObjectToEntity_adds_GameObject_components_to_entity()
        {
            testGameObject.AddComponent<TestMonoBehaviour>();
            entityGameObjectLinker.LinkGameObjectToEntity(testGameObject, testEntity, testSpatialEntityId,
                viewCommandBuffer);
            Assert.IsFalse(entityManager.HasComponent<TestMonoBehaviour>(testEntity));
            viewCommandBuffer.FlushBuffer();
            Assert.IsTrue(entityManager.HasComponent<TestMonoBehaviour>(testEntity));
        }

        [Test]
        public void LinkGameObjectToEntity_adds_duplicate_GameObject_components_only_once()
        {
            testGameObject.AddComponent<TestMonoBehaviour>();
            testGameObject.AddComponent<TestMonoBehaviour>();
            entityGameObjectLinker.LinkGameObjectToEntity(testGameObject, testEntity, testSpatialEntityId,
                viewCommandBuffer);
            viewCommandBuffer.FlushBuffer();
            Assert.IsTrue(entityManager.HasComponent<TestMonoBehaviour>(testEntity));
        }
    }
}
