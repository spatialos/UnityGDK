using System;
using System.Collections.Generic;
using Improbable.Gdk.Core;
using Improbable.Gdk.Core.Commands;
using Unity.Entities;

namespace Improbable.Gdk.Subscriptions
{
    // meant to be an example of abstractions that can be made on top of stuff rather than core core stuff
    // for example a more efficient callback thing might have functors that can be reused to remove allocation
    // could also use this to create tasks out of commands rather than callbacks
    [DisableAutoCreation]
    [UpdateInGroup(typeof(SpatialOSReceiveGroup.InternalSpatialOSReceiveGroup))]
    public class CommandCallbackSystem : ComponentSystem
    {
        private readonly GuardedCallbackManagerSet<Type, ICallbackManager> callbackManagers =
            new GuardedCallbackManagerSet<Type, ICallbackManager>();

        private readonly Dictionary<ulong, (ulong key, ICallbackManager manager)> keyToInternalKeyAndManager =
            new Dictionary<ulong, (ulong key, ICallbackManager manager)>();

        private ulong callbacksRegistered = 1;

        public ulong RegisterCommandRequestCallback<T>(EntityId entityId, Action<T> callback)
            where T : struct, IReceivedCommandRequest
        {
            if (!callbackManagers.TryGetManager(typeof(T), out var manager))
            {
                manager = new CommandRequestCallbackManager<T>(World);
                callbackManagers.AddCallbackManager(typeof(T), manager);
            }

            var key = ((CommandRequestCallbackManager<T>) manager).RegisterCallback(entityId, callback);
            keyToInternalKeyAndManager.Add(callbacksRegistered, (key, manager));
            return callbacksRegistered++;
        }

        public void RegisterCommandResponseCallback<T>(long requestId, Action<T> callback)
            where T : struct, IReceivedCommandResponse
        {
            if (!callbackManagers.TryGetManager(typeof(T), out var manager))
            {
                manager = new CommandResponseCallbackManager<T>(World);
                callbackManagers.AddCallbackManager(typeof(T), manager);
            }

            ((CommandResponseCallbackManager<T>) manager).RegisterCallback(requestId, callback);
        }

        public bool UnregisterCommandRequestCallback(ulong callbackKey)
        {
            if (!keyToInternalKeyAndManager.TryGetValue(callbackKey, out var keyAndManager))
            {
                return false;
            }

            return keyAndManager.manager.UnregisterCallback(keyAndManager.key);
        }

        internal void InvokeCallbacks()
        {
            // todo could split these out to ensure requests are done before responses
            callbackManagers.InvokeEach(manager => manager.InvokeCallbacks());
        }

        protected override void OnCreate()
        {
            base.OnCreate();
            Enabled = false;
        }

        protected override void OnUpdate()
        {
        }
    }
}
