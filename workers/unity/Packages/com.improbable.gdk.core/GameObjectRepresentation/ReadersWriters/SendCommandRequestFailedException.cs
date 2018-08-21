using System;

namespace Improbable.Gdk.Core.GameObjectRepresentation
{
    public class SendCommandRequestFailedException : Exception
    {
        // entity index to be added at the end
        private const string FailureMessage = "Failed to send command request on entity with ECS entity index ";

        public SendCommandRequestFailedException(Exception innerException, int entityIndex)
            : base(FailureMessage + entityIndex, innerException)
        {
        }
    }
}
