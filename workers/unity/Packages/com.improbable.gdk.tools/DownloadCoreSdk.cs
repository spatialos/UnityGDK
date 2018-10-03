using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Improbable.Gdk.Tools
{
    internal enum DownloadResult
    {
        Success,
        AlreadyInstalled,
        Error
    }

    internal static class DownloadCoreSdk
    {
        private const int DownloadForcePriority = 50;

        private static readonly string InstallMarkerFile =
            Path.GetFullPath($"build/CoreSdk/{Common.CoreSdkVersion}.installed");

        private static readonly string ProjectPath =
            Path.GetFullPath(Path.Combine(Common.GetThisPackagePath(), ".DownloadCoreSdk/DownloadCoreSdk.csproj"));

        private const string DownloadForceMenuItem = "SpatialOS/Download CoreSdk (force)";

        private static readonly List<PluginDirectoryCompatibility> PluginsCompatibilityList = new List<PluginDirectoryCompatibility>
        {
            new PluginDirectoryCompatibility("Assets/Plugins/Improbable/Core/OSX", false, new List<BuildTarget> { BuildTarget.StandaloneOSX }, null, true),
            new PluginDirectoryCompatibility("Assets/Plugins/Improbable/Core/Linux", false, new List<BuildTarget> { BuildTarget.StandaloneLinuxUniversal }, null, true),
            new PluginDirectoryCompatibility("Assets/Plugins/Improbable/Core/Windows", false, new List<BuildTarget> { BuildTarget.StandaloneWindows64 }, null, true),
            new PluginDirectoryCompatibility("Assets/Plugins/Improbable/Sdk/OSX", true, null, null, true),
        };

        [MenuItem(DownloadForceMenuItem, false, DownloadForcePriority)]
        private static void DownloadForceMenu()
        {
            if (!CanDownload())
            {
                EditorUtility.DisplayDialog(Common.ProductName,
                    $"Files in the {Common.ProductName} libraries have been locked by Unity.\n\nPlease restart the Unity editor and try again.",
                    "Ok");
                return;
            }

            Download();
            AssetDatabase.Refresh();
            SetPluginsCompatibility();
        }

        private static void RemoveMarkerFile()
        {
            try
            {
                File.Delete(InstallMarkerFile);
            }
            catch
            {
                // Nothing to handle if this fails - no need to abort the process.
            }
        }

        /// <summary>
        ///     Windows only: Ensures that the user can't try to force a download if any of Improbable's native plugins are loaded
        ///     by Unity.
        /// </summary>
        private static bool CanDownload()
        {
            var failedPlugins = new List<PluginImporter>();

            // Unity never unloads native plugins. Detect them here and give a more useful error message.
            foreach (var plugin in PluginImporter.GetAllImporters().Where(ShouldCheckPluginForLock))
            {
                var path = plugin.assetPath;
                try
                {
                    // Try to open the file to see if it's locked.
                    using (new FileStream(path, FileMode.Open, FileAccess.Write, FileShare.None))
                    {
                    }
                }
                catch
                {
                    failedPlugins.Add(plugin);
                }
            }

            return !failedPlugins.Any();
        }

        private static bool ShouldCheckPluginForLock(PluginImporter p)
        {
            if (!p.assetPath.StartsWith("Assets/Plugins/Improbable"))
            {
                return false;
            }

            return p.isNativePlugin && File.Exists(p.assetPath);
        }

        /// <summary>
        ///     Downloads the Core Sdk only if it has not already been downloaded and unzipped.
        /// </summary>
        internal static DownloadResult TryDownload()
        {
            if (File.Exists(InstallMarkerFile))
            {
                return DownloadResult.AlreadyInstalled;
            }

            DownloadResult result = Download();
            SetPluginsCompatibility();
            return result;
        }

        /// <summary>
        ///     Downloads and extracts the Core Sdk and associated libraries and tools.
        /// </summary>
        private static DownloadResult Download()
        {
            RemoveMarkerFile();

            int exitCode;
            try
            {
                EditorApplication.LockReloadAssemblies();

                using (new ShowProgressBarScope($"Installing SpatialOS libraries, version {Common.CoreSdkVersion}..."))
                {
                    exitCode = RedirectedProcess.Run(Common.DotNetBinary, ConstructArguments());
                    if (exitCode != 0)
                    {
                        Debug.LogError($"Failed to download SpatialOS Core Sdk version {Common.CoreSdkVersion}. You can use SpatialOS -> Download CoreSDK (force) to retry this.");
                    }
                    else
                    {
                        File.WriteAllText(InstallMarkerFile, string.Empty);
                    }
                }
            }
            finally
            {
                EditorApplication.UnlockReloadAssemblies();
            }

            return exitCode == 0 ? DownloadResult.Success : DownloadResult.Error;
        }

        private static void SetPluginsCompatibility()
        {
            foreach (var pluginDirectoryCompatibility in PluginsCompatibilityList)
            {
                var pluginPaths = AssetDatabase.FindAssets("", new[] { pluginDirectoryCompatibility.Path });
                foreach (var pluginPath in pluginPaths)
                {
                    var plugin = AssetImporter.GetAtPath(AssetDatabase.GUIDToAssetPath(pluginPath)) as PluginImporter;
                    if (plugin == null)
                    {
                        continue;
                    }

                    plugin.SetCompatibleWithAnyPlatform(pluginDirectoryCompatibility.AnyPlatformCompatible);
                    plugin.SetCompatibleWithEditor(pluginDirectoryCompatibility.EditorCompatible);
                    if (pluginDirectoryCompatibility.AnyPlatformCompatible)
                    {
                        foreach (var buildTarget in pluginDirectoryCompatibility.IncompatiblePlatforms)
                        {
                            plugin.SetExcludeFromAnyPlatform(buildTarget, true);
                        }
                    }
                    else
                    {
                        foreach (var buildTarget in pluginDirectoryCompatibility.CompatiblePlatforms)
                        {
                            plugin.SetCompatibleWithPlatform(buildTarget, true);
                        }
                    }

                    plugin.SaveAndReimport();
                }
            }
        }

        private class PluginDirectoryCompatibility
        {
            public PluginDirectoryCompatibility(string path,
                bool anyPlatformCompatible,
                List<BuildTarget> compatiblePlatforms,
                List<BuildTarget> incompatiblePlatforms,
                bool editorCompatible)
            {
                Path = path;
                AnyPlatformCompatible = anyPlatformCompatible;
                if (anyPlatformCompatible && compatiblePlatforms != null)
                {
                    Debug.LogError($"Bad plugin compatibility configuration for  {path}. Compatible with any shouldn't be used with a list of compatible platforms");
                }

                if (!anyPlatformCompatible && incompatiblePlatforms != null)
                {
                    Debug.LogError($"Bad plugin compatibility configuration for  {path}. Not compatible with any shouldn't be used with a list of incompatible platforms");
                }

                CompatiblePlatforms = compatiblePlatforms ?? new List<BuildTarget>();
                IncompatiblePlatforms = incompatiblePlatforms ?? new List<BuildTarget>();
                EditorCompatible = editorCompatible;
            }

            public string Path { get; }
            public bool AnyPlatformCompatible { get; }
            public List<BuildTarget> CompatiblePlatforms { get; }
            public List<BuildTarget> IncompatiblePlatforms { get; }
            public bool EditorCompatible { get; }
        }

        private static string[] ConstructArguments()
        {
            var toolsConfig = GdkToolsConfiguration.GetOrCreateInstance();

            var baseArgs = new List<string>
            {
                "run",
                "-p",
                $"\"{ProjectPath}\"",
                "--",
                $"\"{Common.SpatialBinary}\"",
                $"\"{Common.CoreSdkVersion}\"",
                $"\"{toolsConfig.SchemaStdLibDir}\""
            };

            return baseArgs.ToArray();
        }
    }
}
