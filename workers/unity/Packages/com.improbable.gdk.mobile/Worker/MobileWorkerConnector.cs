using System;
using Improbable.Gdk.Core;
using Improbable.Worker.CInterop;
using Improbable.Worker.CInterop.Alpha;
using UnityEngine;

namespace Improbable.Gdk.Mobile
{
    public abstract class MobileWorkerConnector : WorkerConnector
    {
        [SerializeField] private string DevelopmentAuthToken;
        
        protected abstract string GetHostIp();

        protected override ConnectionParameters GetConnectionParameters(string workerType, ConnectionService service)
        {
            return new ConnectionParameters
            {
                WorkerType = workerType,
                Network =
                {
                    ConnectionType = NetworkConnectionType.Tcp,
                    UseExternalIp = true,
                },
                EnableProtocolLoggingAtStartup = false,
                DefaultComponentVtable = new ComponentVtable(),
            };
        }

        protected override ReceptionistConfig GetReceptionistConfig(string workerType)
        {
            return new ReceptionistConfig
            {
                ReceptionistHost = GetHostIp(),
                ReceptionistPort = RuntimeConfigDefaults.ReceptionistPort,
                WorkerId = CreateNewWorkerId(workerType)
            };
        }

        protected override LocatorConfig GetLocatorConfig()
        {
            throw new NotImplementedException("The locator flow is currently not available for mobile workers.");
        }

        protected override AlphaLocatorConfig GetAlphaLocatorConfig(string workerType)
        {
            var pit = RetrievePlayerIdentityToken(DevelopmentAuthToken, GetPlayerId(), GetDisplayName());
            var loginTokenDetails = RetrieveLoginToken(workerType, pit);
            var loginToken = SelectLoginToken(loginTokenDetails);

            return new AlphaLocatorConfig
            {
                LocatorHost = RuntimeConfigDefaults.LocatorHost,
                LocatorParameters = new Worker.CInterop.Alpha.LocatorParameters
                {
                    PlayerIdentity = new PlayerIdentityCredentials
                    {
                        PlayerIdentityToken  = pit,
                        LoginToken = loginToken,
                    },
                    UseInsecureConnection = false,
                }
            };
        }
    }
}
