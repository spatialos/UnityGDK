using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Improbable.Gdk.Tools;
using Improbable.Gdk.Tools.MiniJSON;
using UnityEngine;

namespace Improbable.Gdk.TestUtils.Editor
{
    public class SpatialdManager : IDisposable
    {
        private static readonly string SpotBinary;
        private static readonly string ProjectName;

        private static readonly string SpotShimPath;

        static SpatialdManager()
        {
            var spotPath = Path.Combine(Common.GetPackagePath("io.improbable.worker.sdk"), ".spot/spot");

            if (Application.platform == RuntimePlatform.WindowsEditor)
            {
                spotPath = Path.ChangeExtension(spotPath, ".exe");
            }

            SpotBinary = spotPath;

            var spatialJsonFile = Path.Combine(Common.SpatialProjectRootDir, "spatialos.json");

            if (!File.Exists(spatialJsonFile))
            {
                throw new FileNotFoundException($"Could not find a spatialos.json file located at: {spatialJsonFile}");
            }

            var data = Json.Deserialize(File.ReadAllText(spatialJsonFile));

            if (data == null)
            {
                throw new FormatException($"Could not parse spatialos.json file located at: {spatialJsonFile}");
            }

            try
            {
                ProjectName = (string) data["name"];
            }
            catch (KeyNotFoundException e)
            {
                throw new FormatException($"Could not find a \"name\" field in {spatialJsonFile}.\n Raw exception: {e.Message}");
            }

            var packagePath = Common.GetPackagePath("io.improbable.gdk.testutils");

            SpotShimPath = Path.Combine(packagePath, ".SpotShim", "SpotShim", "SpotShim");
        }

        public static async Task<SpatialdManager> Start()
        {
            await RedirectedProcess.Command(Common.SpatialBinary)
                .WithArgs("service", "stop")
                .InDirectory(Common.SpatialProjectRootDir)
                .RedirectOutputOptions(OutputRedirectBehaviour.None)
                .RunAsync()
                .ConfigureAwait(false);

            var result = await RedirectedProcess.Command(Common.SpatialBinary)
                .WithArgs("service", "start")
                .InDirectory(Common.SpatialProjectRootDir)
                .RedirectOutputOptions(OutputRedirectBehaviour.None)
                .RunAsync()
                .ConfigureAwait(false);

            if (result.ExitCode != 0)
            {
                throw new Exception($"Could not start spatiald with error: {string.Join("\n", result.Stderr)}");
            }

            return new SpatialdManager();
        }

        // Hide default constructor.
        private SpatialdManager()
        {
        }

        // TODO: Implement snapshot support?
        public async Task<LocalDeployment> StartLocalDeployment(string name, string deploymentJsonPath, string snapshotPath = null)
        {
            var fullJsonPath = Path.Combine(Common.SpatialProjectRootDir, deploymentJsonPath);

            if (!File.Exists(fullJsonPath))
            {
                throw new ArgumentException($"Could not find launch config file at {fullJsonPath}");
            }

            var result = await RedirectedProcess.Command(SpotBinary)
                .WithArgs("alpha", "deployment", "create", "-p", ProjectName, "-n", name, "-c", $"\"{fullJsonPath}\"", "--json")
                .InDirectory(Common.SpatialProjectRootDir)
                .RedirectOutputOptions(OutputRedirectBehaviour.None)
                .RunAsync()
                .ConfigureAwait(false);

            if (result.ExitCode != 0)
            {
                throw new Exception($"Failed to start deployment with error: {string.Join("\n", result.Stderr)}");
            }

            var deploymentData = Json.Deserialize(string.Join("", result.Stdout));
            var content = (Dictionary<string, object>) deploymentData["content"];
            var id = (string) content["id"];

            return new LocalDeployment(this, id, name, ProjectName);
        }

        public async Task StopLocalDeployment(LocalDeployment deployment)
        {
            var result = await RedirectedProcess.Command(SpotBinary)
                .WithArgs("alpha", "deployment", "delete", "-i", deployment.Id)
                .InDirectory(Common.SpatialProjectRootDir)
                .RedirectOutputOptions(OutputRedirectBehaviour.None)
                .RunAsync()
                .ConfigureAwait(false);

            if (result.ExitCode != 0)
            {
                throw new Exception($"Failed to stop deployment with error: {string.Join("\n", result.Stderr)}");
            }
        }

        public async Task<List<LocalDeployment>> GetRunningDeployments()
        {
            var result = await RedirectedProcess.Command(SpotBinary)
                .WithArgs("alpha", "deployment", "list", "-p", ProjectName, "-f", "NOT_STOPPED_DEPLOYMENTS", "--json")
                .InDirectory(Common.SpatialProjectRootDir)
                .RedirectOutputOptions(OutputRedirectBehaviour.None)
                .RunAsync()
                .ConfigureAwait(false);

            var json = Json.Deserialize(string.Join("", result.Stdout));
            var content = (Dictionary<string, object>) json["content"];

            if (!content.TryGetValue("deployments", out var deploymentsObj))
            {
                return new List<LocalDeployment>();
            }

            var deploymentData = (List<object>) deploymentsObj;

            return deploymentData
                .OfType<Dictionary<string, object>>()
                .Select(data =>
                {
                    var id = (string) data["id"];
                    var name = (string) data["name"];
                    var tags = (List<object>) data["tag"];
                    return new LocalDeployment(this, id, name, ProjectName, tags.Cast<string>().ToArray());
                })
                .ToList();
        }

        public void Dispose()
        {
            var result = RedirectedProcess.Command(Common.SpatialBinary)
                .WithArgs("service", "stop")
                .InDirectory(Common.SpatialProjectRootDir)
                .RedirectOutputOptions(OutputRedirectBehaviour.None)
                .RunAsync()
                .Result;

            if (result.ExitCode != 0)
            {
                Debug.LogWarning($"Failed to stop spatiald with error: {string.Join("\n", result.Stderr)}");
            }
        }

        public struct LocalDeployment : IDisposable
        {
            public readonly string Id;
            public readonly string Name;
            public readonly string ProjectName;
            public readonly List<string> Tags;

            private readonly SpatialdManager spatiald;

            internal LocalDeployment(SpatialdManager spatiald, string id, string name, string projectName, params string[] tags)
            {
                this.spatiald = spatiald;
                Id = id;
                Name = name;
                ProjectName = projectName;
                Tags = tags.ToList();
            }

            public async Task AddDevLoginTag()
            {
                // TODO: Remove shim once tag functionality is added to `spot`: WF-1487 to track.
                var result = await RedirectedProcess.Command(Common.DotNetBinary)
                    .WithArgs("run", Id, Name, ProjectName)
                    .InDirectory(SpotShimPath)
                    .RedirectOutputOptions(OutputRedirectBehaviour.None)
                    .RunAsync()
                    .ConfigureAwait(false);

                if (result.ExitCode != 0)
                {
                    throw new InvalidOperationException($"Failed to set deployment tag with error: {string.Join("\n", result.Stderr)}");
                }

                Tags.Add("dev_login");
            }

            public void Dispose()
            {
                try
                {
                    spatiald.StopLocalDeployment(this).Wait();
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                }
            }
        }
    }
}
