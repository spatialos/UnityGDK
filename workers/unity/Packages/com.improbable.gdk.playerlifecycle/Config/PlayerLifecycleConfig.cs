using Improbable.Gdk.Core;

namespace Improbable.Gdk.PlayerLifecycle
{
    public delegate EntityTemplate GetPlayerEntityTemplateDelegate(
        string clientWorkerId,
        byte[] serializedArguments);

    public static class PlayerLifecycleConfig
    {
        public const float PlayerHeartbeatIntervalSeconds = 5f;
        public const int MaxNumFailedPlayerHeartbeats = 2;

        public const int MaxPlayerCreationRetries = 5;
        public const int MaxPlayerCreatorQueryRetries = 5;

        public static bool AutoRequestPlayerCreation = true;

        public static GetPlayerEntityTemplateDelegate CreatePlayerEntityTemplate;
    }
}
