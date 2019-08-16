using System;
using System.Collections.Generic;
using Improbable.Worker.CInterop;
using NUnit.Framework;

namespace Improbable.Gdk.Core.EditmodeTests.Connection
{
    [TestFixture]
    public class CommandLineConnectionParametersInitializerTests
    {
        [TestCase("RakNet", NetworkConnectionType.RakNet)]
        [TestCase("Tcp", NetworkConnectionType.Tcp)]
        [TestCase("Kcp", NetworkConnectionType.Kcp)]
        [TestCase("ModularUdp", NetworkConnectionType.ModularUdp)]
        public void Initialize_should_set_network_protocol(string protocolStr, NetworkConnectionType connectionType)
        {
            var args = new Dictionary<string, string>
            {
                { RuntimeConfigNames.LinkProtocol, protocolStr }
            };

            var connParams = new ConnectionParameters();

            new CommandLineConnectionParameterInitializer(args).Initialize(connParams);

            Assert.AreEqual(connectionType, connParams.Network.ConnectionType);
        }

        [TestCase("ranket")]
        [TestCase("raknet")]
        [TestCase("")]
        public void Initialize_should_throw_with_invalid_protocol(string protocolStr)
        {
            var args = new Dictionary<string, string>
            {
                { RuntimeConfigNames.LinkProtocol, protocolStr }
            };

            var connParams = new ConnectionParameters();
            var initializer = new CommandLineConnectionParameterInitializer(args);

            Assert.Throws<FormatException>(() => initializer.Initialize(connParams));
        }
    }
}
