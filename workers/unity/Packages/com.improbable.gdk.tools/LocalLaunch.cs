using Improbable.Gdk.Tools.MiniJSON;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Improbable.Gdk.Tools
{
    public static class LocalLaunch
    {
        private static readonly string
            SpatialProjectRootDir = Path.GetFullPath(Path.Combine(Application.dataPath, "..", "..", ".."));

        private const string DefaultLogFileName = "*unityclient.log";

        private static readonly string ClientConfigFilename = "spatialos.UnityClient.worker.json";

        // Windows: The exit code is 0xc000013a when the user closes the console window, or presses Ctrl+C.
        private const int WindowsCtrlCExitCode = -1073741510;

        // Unix-like: The exit code is 128 + SIGINT (2).
        private const int UnixSigIntExitCode = 128 + 2;

        [MenuItem("SpatialOS/Build worker configs")]
        private static void BuildConfigMenu()
        {
            Debug.Log("Building worker configs...");
            EditorApplication.delayCall += BuildConfig;
        }

        [MenuItem("SpatialOS/Local launch %l")]
        private static void LaunchMenu()
        {
            Debug.Log("Launching SpatialOS locally...");
            EditorApplication.delayCall += LaunchLocalDeployment;
        }

        [MenuItem("SpatialOS/Launch standalone client")]
        private static void LaunchStandaloneClient()
        {
            GetClientLogFilename();
            Debug.Log("Launching a standalone client");
            EditorApplication.delayCall += LaunchClient;
        }

        public static void BuildConfig()
        {
            using (new ShowProgressBarScope("Building worker configs..."))
            {
                // Run from the root of the project to build all available worker configs.
                RedirectedProcess.RunIn(SpatialProjectRootDir, Common.SpatialBinary, "build", "build-config",
                    "--json_output");
            }
        }

        public static void LaunchClient()
        {
            var command = Common.SpatialBinary;
            var commandArgs = "local worker launch UnityClient default";

            if (Application.platform == RuntimePlatform.OSXEditor)
            {
                command = "osascript";
                commandArgs = $@"-e 'tell application ""Terminal""
                                     activate
                                     do script ""cd {SpatialProjectRootDir} && {Common.SpatialBinary} {command}""
                                     end tell'";
            }

            var processInfo = new ProcessStartInfo(command, commandArgs)
            {
                CreateNoWindow = false,
                UseShellExecute = true,
                WorkingDirectory = SpatialProjectRootDir
            };

            var process = Process.Start(processInfo);

            if (process == null)
            {
                Debug.LogError("Failed to start a standalone client locally.");
                return;
            }

            process.EnableRaisingEvents = true;
            process.Exited += (sender, args) =>
            {
                // N.B. This callback is run on a different thread.
                if (process.ExitCode == 0)
                {
                    return;
                }

                var logPath = Path.Combine(SpatialProjectRootDir, "logs");
                var latestLogFile = Directory.GetFiles(logPath, GetClientLogFilename())
                    .Select(f => new FileInfo(f))
                    .OrderBy(f => f.LastWriteTimeUtc).LastOrDefault();

                if (latestLogFile == null)
                {
                    Debug.LogError($"Could not find a standalone client log file in {logPath}.");
                    return;
                }

                var message = $"Unity Standalone Client local launch logfile: {latestLogFile.FullName}";

                if (WasProcessKilled(process))
                {
                    Debug.Log(message);
                }
                else
                {
                    var content = File.ReadAllText(latestLogFile.FullName);
                    Debug.LogError($"{message}\n{content}");
                }

                process.Dispose();
                process = null;
            };
        }

        private static string GetClientLogFilename()
        {
            try
            {
                var logConfigPath = Path.Combine(SpatialProjectRootDir, "workers", "unitye");
                var configFileJson = File.ReadAllText(Path.Combine(logConfigPath, ClientConfigFilename));
                var configFileJsonDeserialized = Json.Deserialize(configFileJson);
                var currentOS = Application.platform == RuntimePlatform.OSXEditor ? "macos" : "windows";
                Dictionary<string, object> tempDict;

                if (!configFileJsonDeserialized.TryGetValue("external", out var externalValue))
                {
                    Debug.LogError($"Config file {ClientConfigFilename} doesn't contain key 'external'.");
                    return DefaultLogFileName;
                }

                tempDict = externalValue as Dictionary<string, object>;

                if (!tempDict.TryGetValue("default", out var defaultValue))
                {
                    Debug.LogError($"Config file {ClientConfigFilename} doesn't contain key 'default' within 'external'.");
                    return DefaultLogFileName;
                }

                tempDict = defaultValue as Dictionary<string, object>;

                if (!tempDict.TryGetValue(currentOS, out var currentOSValue))
                {
                    Debug.LogError($"Config file {ClientConfigFilename} doesn't contain key '{currentOS}' within 'external' -> 'default'.");
                    return DefaultLogFileName;
                }

                tempDict = currentOSValue as Dictionary<string, object>;

                if (!tempDict.TryGetValue("arguments", out var argumentsValue))
                {
                    Debug.LogError($"Config file {ClientConfigFilename} doesn't contain key 'arguments' within 'external' -> 'default' -> '{currentOS}'.");
                    return DefaultLogFileName;
                }

                var arguments = (IList)argumentsValue;

                int argumentIdx = 0;
                for (argumentIdx = 0; argumentIdx < arguments.Count; argumentIdx++)
                {
                    // The next argument would be the name of the log file
                    if (arguments[argumentIdx].Equals("-logfile"))
                    {
                        argumentIdx++;
                        break;
                    }
                }

                // Logger file not found - using default one
                if (argumentIdx >= arguments.Count)
                {
                    Debug.LogError($"Config file {ClientConfigFilename} doesn't contain '-logfile' argument within 'external' -> 'default' -> '{currentOS}' -> arguments.");
                    return DefaultLogFileName;
                }

                // Strip any relative pathing
                var logFileName = ((string)arguments[argumentIdx]).Substring(((string)arguments[argumentIdx]).LastIndexOf('/'));
                return logFileName;
            }
            catch (System.Exception e)
            {
                Debug.LogError(e.ToString());
                return DefaultLogFileName;
            }
        }

        public static void LaunchLocalDeployment()
        {
            BuildConfig();

            var command = Common.SpatialBinary;
            var commandArgs = "local launch";

            if (Application.platform == RuntimePlatform.OSXEditor)
            {
                command = "osascript";
                commandArgs = $@"-e 'tell application ""Terminal""
                                     activate
                                     do script ""cd {SpatialProjectRootDir} && {Common.SpatialBinary} {command}""
                                     end tell'";
            }

            var processInfo = new ProcessStartInfo(command, commandArgs)
            {
                CreateNoWindow = false,
                UseShellExecute = true,
                WorkingDirectory = SpatialProjectRootDir
            };

            var process = Process.Start(processInfo);

            if (process == null)
            {
                Debug.LogError("Failed to start SpatialOS locally.");
                return;
            }

            process.EnableRaisingEvents = true;
            process.Exited += (sender, args) =>
            {
                // N.B. This callback is run on a different thread.
                if (process.ExitCode == 0)
                {
                    return;
                }

                var logPath = Path.Combine(SpatialProjectRootDir, "logs");
                var latestLogFile = Directory.GetFiles(logPath, "spatial_*.log")
                    .Select(f => new FileInfo(f))
                    .OrderBy(f => f.LastWriteTimeUtc).LastOrDefault();

                if (latestLogFile == null)
                {
                    Debug.LogError($"Could not find a spatial log file in {logPath}.");
                    return;
                }

                var message = $"Spatial local launch logfile: {latestLogFile.FullName}";

                if (WasProcessKilled(process))
                {
                    Debug.Log(message);
                }
                else
                {
                    var content = File.ReadAllText(latestLogFile.FullName);
                    Debug.LogError($"{message}\n{content}");
                }

                process.Dispose();
                process = null;
            };
        }

        private static bool WasProcessKilled(Process process)
        {
            if (process == null)
            {
                return false;
            }

            switch (Application.platform)
            {
                case RuntimePlatform.WindowsEditor:
                    return process.ExitCode == WindowsCtrlCExitCode;
                case RuntimePlatform.OSXEditor:
                case RuntimePlatform.LinuxEditor:
                    return process.ExitCode == UnixSigIntExitCode;
            }

            return false;
        }
    }
}
