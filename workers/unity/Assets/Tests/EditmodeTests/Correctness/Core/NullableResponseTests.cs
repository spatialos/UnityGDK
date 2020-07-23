using Improbable.Gdk.Core;
using Improbable.Gdk.Core.Commands;
using Improbable.Gdk.Subscriptions;
using Improbable.Gdk.Test;
using Improbable.Gdk.TestUtils;
using Improbable.Worker.CInterop;
using NUnit.Framework;
using Playground;
using UnityEngine;
using Entity = Unity.Entities.Entity;

namespace Improbable.Gdk.EditmodeTests.Core
{
    public class NullableResponseTests : MockBase
    {
        private const long EntityId = 101;
        private const long LaunchedId = 102;

        [Test]
        public void ReceivedResponse_isNull_when_Response_is_not_received()
        {
            World.Setup<Launcher.LaunchEntity.Request>(Launcher.ComponentId);
            World.Step(world =>
            {
                world.Connection.CreateEntity(EntityId, GetTemplate());
            }).Step(world => world.GetSystem<CommandSystem>().SendCommand(GetRequest())).Step((world, id) =>
            {
                Assert.IsFalse(world.GetSystem<CommandSystem>().GetResponse<Launcher.LaunchEntity.ReceivedResponse>(id)
                    .HasValue);
            });
        }

        [Test]
        public void ReceivedResponse_isNotNull_when_Response_is_received()
        {
            World.Setup<Launcher.LaunchEntity.Request>(Launcher.ComponentId);
            World.Step(world =>
            {
                world.Connection.CreateEntity(EntityId, GetTemplate());
            }).Step(world =>
            {
                var id = world.GetSystem<CommandSystem>().SendCommand(GetRequest());
                world.GenerateResponse<Launcher.LaunchEntity.Request, Launcher.LaunchEntity.ReceivedResponse>(id, ResponseGenerator);
                return id;
            }).Step((world, id) =>
            {
                Assert.IsTrue(world.GetSystem<CommandSystem>().GetResponse<Launcher.LaunchEntity.ReceivedResponse>(id)
                    .HasValue);
            });
        }

        [Test]
        public void SubscriptionSystem_invokes_callback_on_receiving_response()
        {
            var pass = false;
            World.Setup<Launcher.LaunchEntity.Request>(Launcher.ComponentId);
            World.Step(world =>
                {
                    world.Connection.CreateEntity(EntityId, GetTemplate());
                })
                .Step(world =>
                {
                    var (_, commander) = world.CreateGameObject<LaunchCommander>(EntityId);
                    return commander.Sender;
                }).Step((world, sender) =>
                {
                    sender.SendLaunchEntityCommand(GetRequest(), response => pass = true);
                    world.GenerateResponses<Launcher.LaunchEntity.Request, Launcher.LaunchEntity.ReceivedResponse>(ResponseGenerator);
                }).Step(world =>
                {
                    Assert.IsTrue(pass);
                });
        }

        private static Launcher.LaunchEntity.ReceivedResponse ResponseGenerator(CommandRequestId id, Launcher.LaunchEntity.Request request)
        {
            return new Launcher.LaunchEntity.ReceivedResponse(
                default,
                request.TargetEntityId,
                null,
                StatusCode.Success,
                default,
                request.Payload,
                null,
                id
            );
        }

        private static EntityTemplate GetTemplate()
        {
            var template = new EntityTemplate();
            template.AddComponent(new Position.Snapshot(), "worker");
            template.AddComponent(new Launcher.Snapshot(), "worker");
            return template;
        }

        private static Launcher.LaunchEntity.Request GetRequest()
        {
            return new Launcher.LaunchEntity.Request(new EntityId(EntityId), new LaunchCommandRequest(new EntityId(LaunchedId),
                new Vector3f(1, 0, 1),
                new Vector3f(0, 1, 0), 5, new EntityId(EntityId)));
        }

        private class LaunchCommander : MonoBehaviour
        {
            [Require] public LauncherCommandSender Sender;
        }
    }
}