// ===========
// DO NOT EDIT - this file is automatically regenerated.
// ===========

using System.Collections.Generic;
using Improbable.Worker;
using Improbable.Worker.Core;

namespace Improbable.Gdk.Tests.ComponentsWithNoFields
{
    public partial class ComponentWithNoFieldsWithCommands
    {
        public partial class Cmd
        {
            /// <summary>
            ///     Please do not use the default constructor. Use CreateRequest instead.
            ///     Using CreateRequest will ensure a correctly formed structure.
            /// </summary>
            public struct Request
            {
                public EntityId TargetEntityId { get; internal set; }
                public global::Improbable.Gdk.Tests.ComponentsWithNoFields.Empty Payload { get; internal set; }
                public uint? TimeoutMillis { get; internal set; }
                public bool AllowShortCircuiting { get; internal set; }
                public System.Object Context { get; internal set; }
                public long RequestId { get; internal set; }
            }

            public static Request CreateRequest(EntityId targetEntityId,
                global::Improbable.Gdk.Tests.ComponentsWithNoFields.Empty request,
                uint? timeoutMillis = null,
                bool allowShortCircuiting = false,
                System.Object context = null)
            {
                return new Request
                {
                    TargetEntityId = targetEntityId,
                    Payload = request,
                    TimeoutMillis = timeoutMillis,
                    AllowShortCircuiting = allowShortCircuiting,
                    Context = context,
                    RequestId = global::Improbable.Gdk.Core.CommandRequestIdGenerator.GetNext(),
                };
            }

            public struct ReceivedRequest
            {
                public long RequestId { get; }
                public string CallerWorkerId { get; }
                public List<string> CallerAttributeSet { get; }
                public global::Improbable.Gdk.Tests.ComponentsWithNoFields.Empty Payload { get; }

                public ReceivedRequest(long requestId,
                    string callerWorkerId,
                    List<string> callerAttributeSet,
                    global::Improbable.Gdk.Tests.ComponentsWithNoFields.Empty request)
                {
                    RequestId = requestId;
                    CallerWorkerId = callerWorkerId;
                    CallerAttributeSet = callerAttributeSet;
                    Payload = request;
                }
            }

            /// <summary>
            ///     Please do not use the default constructor. Use CreateResponse or CreateFailure instead.
            ///     Using CreateResponse or CreateFailure will ensure a correctly formed structure.
            /// </summary>
            public struct Response
            {
                public long RequestId { get; internal set; }
                public global::Improbable.Gdk.Tests.ComponentsWithNoFields.Empty? Payload { get; internal set; }
                public string FailureMessage { get; internal set; }
            }

            public static Response CreateResponse(ReceivedRequest req, global::Improbable.Gdk.Tests.ComponentsWithNoFields.Empty payload)
            {
                return new Response
                {
                    RequestId = req.RequestId,
                    Payload = payload,
                    FailureMessage = null,
                };
            }

            public static Response CreateResponseFailure(ReceivedRequest req, string failureMessage)
            {
                return new Response
                {
                    RequestId = req.RequestId,
                    Payload = null,
                    FailureMessage = failureMessage,
                };
            }

            public struct ReceivedResponse
            {
                public EntityId EntityId { get; }
                public string Message { get; }
                public StatusCode StatusCode { get; }
                public global::Improbable.Gdk.Tests.ComponentsWithNoFields.Empty? ResponsePayload { get; }
                public global::Improbable.Gdk.Tests.ComponentsWithNoFields.Empty RequestPayload { get; }
                public System.Object Context { get; }
                public long RequestId { get; }

                public ReceivedResponse(EntityId entityId,
                    string message,
                    StatusCode statusCode,
                    global::Improbable.Gdk.Tests.ComponentsWithNoFields.Empty? response,
                    global::Improbable.Gdk.Tests.ComponentsWithNoFields.Empty request,
                    System.Object context,
                    long requestId)
                {
                    EntityId = entityId;
                    Message = message;
                    StatusCode = statusCode;
                    ResponsePayload = response;
                    RequestPayload = request;
                    Context = context;
                    RequestId = requestId;
                }
            }
        }
    }
}
