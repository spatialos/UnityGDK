using System;
using System.Linq;
using System.Net;
using Improbable.Gdk.Tools;
using NUnit.Framework;
using UnityEngine;

namespace Improbable.Gdk.TestUtils.Editor.Tests
{
    [TestFixture]
    public class SpatialdManagerTests
    {
        [Test]
        public void Spatiald_is_running_after_Start()
        {
            using (SpatialdManager.Start().Result)
            {
                var result = RedirectedProcess.Command(Common.SpatialBinary)
                    .WithArgs("service", "status")
                    .InDirectory(Common.SpatialProjectRootDir)
                    .RedirectOutputOptions(OutputRedirectBehaviour.None)
                    .RunAsync()
                    .Result;

                Assert.IsTrue(result.Stdout.Any(line => line.Contains("Local API service is running")));
            }
        }

        [Test]
        public void Spatiald_is_not_running_after_Dispose()
        {
            using (SpatialdManager.Start().Result)
            {
            }

            var result = RedirectedProcess.Command(Common.SpatialBinary)
                .WithArgs("service", "status")
                .InDirectory(Common.SpatialProjectRootDir)
                .RedirectOutputOptions(OutputRedirectBehaviour.None)
                .RunAsync()
                .Result;

            Assert.IsTrue(result.Stdout.Any(line => line.Contains("Local API service is not running")));
        }

        [Test]
        public void StartLocalDeployment_throws_if_invalid_launch_config_path()
        {
            using (var manager = SpatialdManager.Start().Result)
            {
                var aggregateException = Assert.Throws<AggregateException>(() =>
                {
                    var deployment = manager.StartLocalDeployment("test", "doesnt_exist.json").Result;

                    // Shouldn't get here, but just in case ;)
                    deployment.Dispose();
                });

                Assert.IsInstanceOf<ArgumentException>(aggregateException.InnerExceptions[0]);
            }
        }

        [Test]
        public void StartLocalDeployment_throws_if_invalid_snapshot_name()
        {
            using (var manager = SpatialdManager.Start().Result)
            {
                var aggregateException = Assert.Throws<AggregateException>(() =>
                {
                    var deployment = manager.StartLocalDeployment("test", "default_launch.json", "doesnt_exist.snapshot").Result;

                    // Shouldn't get here, but just in case ;)
                    deployment.Dispose();
                });

                Assert.IsInstanceOf<ArgumentException>(aggregateException.InnerExceptions[0]);
            }
        }

        [Test]
        public void StartLocalDeployment_starts_a_deployment()
        {
            using (var manager = SpatialdManager.Start().Result)
            using (manager.StartLocalDeployment("test", "default_launch.json").Result)
            {
                Assert.IsNotEmpty(manager.GetRunningDeployments().Result);
            }
        }

        [Test]
        public void LocalDeployment_closes_deployment_on_dispose()
        {
            using (var manager = SpatialdManager.Start().Result)
            {
                using (manager.StartLocalDeployment("test", "default_launch.json").Result)
                {
                }

                Assert.IsEmpty(manager.GetRunningDeployments().Result);
            }
        }

        [Test]
        public void LocalDeployment_can_add_dev_login_tag()
        {
            using (var manager = SpatialdManager.Start().Result)
            {
                using (var depl = manager.StartLocalDeployment("test", "default_launch.json").Result)
                {
                    Assert.DoesNotThrow(() => depl.AddDevLoginTag().Wait());
                    var deployments = manager.GetRunningDeployments().Result;
                    var myDeployment = deployments[0];
                    Assert.Contains("dev_login", myDeployment.Tags);
                    Assert.Contains("dev_login", depl.Tags);
                }
            }
        }
    }
}
