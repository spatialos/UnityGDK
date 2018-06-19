using System;
using NUnit.Framework;
using Unity.Entities;

namespace Improbable.Gdk.TestUtils
{
    public abstract class HybridGdkSystemTestBase
    {
        private static readonly Type GameObjectArrayInjectionHookType =
            typeof(GameObjectEntity).Assembly.GetType("Unity.Entities.GameObjectArrayInjectionHook");

        private static readonly Type TransformAccessArrayInjectionHookType =
            typeof(GameObjectEntity).Assembly.GetType("Unity.Entities.TransformAccessArrayInjectionHook");

        private static readonly Type ComponentArrayInjectionHookType =
            typeof(GameObjectEntity).Assembly.GetType("Unity.Entities.ComponentArrayInjectionHook");

        private InjectionHook gameobjectArrayInjectionHook;
        private InjectionHook transformAccessArrayInjectionHook;
        private InjectionHook componentArrayInjectionHook;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            gameobjectArrayInjectionHook = (InjectionHook)Activator.CreateInstance(GameObjectArrayInjectionHookType);
            transformAccessArrayInjectionHook =
                (InjectionHook)Activator.CreateInstance(TransformAccessArrayInjectionHookType);
            componentArrayInjectionHook = (InjectionHook)Activator.CreateInstance(ComponentArrayInjectionHookType);

            InjectionHookSupport.RegisterHook(gameobjectArrayInjectionHook);
            InjectionHookSupport.RegisterHook(transformAccessArrayInjectionHook);
            InjectionHookSupport.RegisterHook(componentArrayInjectionHook);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            InjectionHookSupport.UnregisterHook(gameobjectArrayInjectionHook);
            InjectionHookSupport.UnregisterHook(transformAccessArrayInjectionHook);
            InjectionHookSupport.UnregisterHook(componentArrayInjectionHook);
        }
    }
}
