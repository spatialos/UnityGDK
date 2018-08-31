﻿using Generated.Improbable.Gdk.Tests.ComponentsWithNoFields;
using Generated.Improbable.Gdk.Tests.NonblittableTypes;
using Improbable.Worker;
using Improbable.Worker.Core;
using NUnit.Framework;
using Unity.Entities;

namespace Improbable.Gdk.Core.EditmodeTests.MonoBehaviours.CommandSenders
{
    [TestFixture]
    public class CommandResponseHandlerTests
    {
        [Test]
        public void OnCmdResponseInternal_calls_OnCmdResponse_delegates()
        {
            using (var world = new World("test-world"))
            {
                var entityManager = world.GetOrCreateManager<EntityManager>();
                var entity = entityManager.CreateEntity();

                var commandResponseHandler =
                    new ComponentWithNoFieldsWithCommands.Requirables.CommandRequestSender(entity, entityManager,
                        new LoggingDispatcher());

                var responseCallbackCalled = false;

                commandResponseHandler.OnCmdResponse += response => { responseCallbackCalled = true; };

                commandResponseHandler.OnCmdResponseInternal(
                    new ComponentWithNoFieldsWithCommands.Cmd.ReceivedResponse(
                        new EntityId(0),
                        string.Empty,
                        StatusCode.Success,
                        new Empty(),
                        new Empty()
                    ));

                Assert.IsTrue(responseCallbackCalled);
            }
        }
    }
}
