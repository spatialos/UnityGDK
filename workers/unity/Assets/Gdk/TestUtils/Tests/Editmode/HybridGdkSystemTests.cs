using System;
using JetBrains.Annotations;
using NUnit.Framework;
using Unity.Entities;
using UnityEngine;

namespace Improbable.Gdk.TestUtils.EditmodeTests
{
    public class HybridSystemTests
    {
        private struct TestPreparation : IComponentData
        {
            public int Value;
        }

        [UsedImplicitly]
        [DisableAutoCreation]
        private class ExampleHybridSystem : ComponentSystem
        {
            private struct PreparationData
            {
                public int Length;

                // The ComponentArray<> here makes this a hybrid system.
                public ComponentArray<Rigidbody> GameObjectRigidBody;

                public ComponentDataArray<TestPreparation> PreparationStruct;
            }

            [Inject] private PreparationData testDataToPrepare;

            public void TestInjection(World world)
            {
                OnBeforeCreateManagerInternal(world, 10);
            }

            public void ManualDispose()
            {
                OnBeforeDestroyManagerInternal();
                OnDestroyManager();
                OnAfterDestroyManagerInternal();
            }

            protected override void OnUpdate()
            {
                for (var i = 0; i < testDataToPrepare.Length; ++i)
                {
                    var preparation = testDataToPrepare.PreparationStruct[i];

                    preparation.Value = 1;

                    testDataToPrepare.PreparationStruct[i] = preparation;
                }
            }
        }

        [TestFixture]
        private class FixtureNotImplementingHybridTestBase
        {
            // If this test fails, then we can get rid of HybridGdkSystemTestBase!
            [Test]
            public static void
                HybridSystems_will_result_in_errors_when_created_if_fixture_does_not_extend_HybridGdkSystemTestBase()
            {
                using (var world = new World("test-world"))
                {
                    var system = new ExampleHybridSystem();

                    var argumentException = Assert.Throws<ArgumentException>(() =>
                        {
                            // This is basically the same action as world.GetOrCreateManager<ExampleHybridSystem>();
                            // However, if we actually called the above it would cause memory leaks and make other tests fail.
                            system.TestInjection(world);
                        },
                        "The `{0}` class may no longer be necessary, since an `{1}` system could be created without InjectionHooks.",
                        nameof(HybridGdkSystemTestBase),
                        nameof(ExampleHybridSystem));

                    Assert.IsTrue(argumentException.Message.Contains("[Inject]"),
                        "The error message ({0}) was not about an injection annotation.",
                        argumentException.Message);

                    // Ensure that the system does not leak.
                    system.ManualDispose();
                }
            }
        }

        [TestFixture]
        private class FixtureImplementingHybridTestBase : HybridGdkSystemTestBase
        {
            [Test]
            public static void ExampleHybridSystem_can_be_created_and_updated()
            {
                using (var world = new World("test-world"))
                {
                    var entityManager = world.GetOrCreateManager<EntityManager>();

                    var entity = entityManager.CreateEntity(
                        typeof(Rigidbody)
                    );

                    entityManager.AddComponentData(entity, new TestPreparation { Value = 0 });

                    var testSystem = world.GetOrCreateManager<ExampleHybridSystem>();

                    testSystem.Update();

                    Assert.AreEqual(1, entityManager.GetComponentData<TestPreparation>(entity).Value,
                        "The system did not process the TestPreparation component of the entity.");
                }
            }
        }
    }
}
