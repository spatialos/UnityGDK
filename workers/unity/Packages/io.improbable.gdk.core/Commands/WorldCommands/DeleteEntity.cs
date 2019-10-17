using Improbable.Worker.CInterop;
using Entity = Unity.Entities.Entity;

namespace Improbable.Gdk.Core.Commands
{
    public static partial class WorldCommands
    {
        public static class DeleteEntity
        {
            /// <summary>
            ///     An object that is a DeleteEntity command request.
            /// </summary>
            public struct Request : ICommandRequest
            {
                public EntityId EntityId;
                public uint? TimeoutMillis;
                public object Context;

                /// <summary>
                ///     Method to create a DeleteEntity command request payload.
                /// </summary>
                /// <param name="entityId"> The entity ID that is to be deleted.</param>
                /// <param name="timeoutMillis">
                ///     (Optional) The command timeout in milliseconds. If not specified, will default to 5 seconds.
                /// </param>
                /// <param name="context">
                ///    (Optional) A context object that will be returned with the command response.
                /// </param>
                /// <returns>The DeleteEntity command request payload.</returns>
                public Request(EntityId entityId, uint? timeoutMillis = null, object context = null)
                {
                    EntityId = entityId;
                    TimeoutMillis = timeoutMillis;
                    Context = context;
                }
            }

            /// <summary>
            ///     An object that is the response of a DeleteEntity command from the SpatialOS runtime.
            /// </summary>
            public readonly struct ReceivedResponse : IReceivedCommandResponse
            {
                public readonly Entity SendingEntity;

                /// <summary>
                ///     The status code of the command response. If equal to <see cref="StatusCode"/>.Success then
                ///     the command succeeded.
                /// </summary>
                public readonly StatusCode StatusCode;

                /// <summary>
                ///     The failure message of the command. Will only be non-null if the command failed.
                /// </summary>
                public readonly string Message;

                /// <summary>
                ///     The Entity ID that was the target of the DeleteEntity command.
                /// </summary>
                public readonly EntityId EntityId;

                /// <summary>
                ///     The request payload that was originally sent with this command.
                /// </summary>
                public readonly Request RequestPayload;

                /// <summary>
                ///     The context object that was provided when sending the command.
                /// </summary>
                public readonly object Context;

                /// <summary>
                ///     The unique request ID of this command. Will match the request ID in the corresponding request.
                /// </summary>
                public readonly long RequestId;

                internal ReceivedResponse(DeleteEntityResponseOp op, Entity sendingEntity, Request req, long requestId)
                {
                    SendingEntity = sendingEntity;
                    StatusCode = op.StatusCode;
                    Message = op.Message;
                    EntityId = new EntityId(op.EntityId);
                    RequestPayload = req;
                    Context = req.Context;
                    RequestId = requestId;
                }

                long IReceivedCommandResponse.GetRequestId()
                {
                    return RequestId;
                }
            }
        }
    }
}
