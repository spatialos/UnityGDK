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

    internal class PluginPostprocessor : AssetPostprocessor
    {
        static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
        {
            var processPlugins = false;
            foreach (var asset in importedAssets)
            {
                if (DownloadCoreSdk.IsImprobablePlugin(asset))
                {
                    processPlugins = true;
                }
            }

            if (processPlugins)
            {
                DownloadCoreSdk.SetPluginsCompatibility();
            }
        }
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
            PluginDirectoryCompatibility.CreateWithCompatiblePlatforms("Assets/Plugins/Improbable/Core/OSX", new List<BuildTarget> { BuildTarget.StandaloneOSX }, editorCompatible: true),
            PluginDirectoryCompatibility.CreateWithCompatiblePlatforms("Assets/Plugins/Improbable/Core/Linux", new List<BuildTarget> { BuildTarget.StandaloneLinux64 }, editorCompatible: true),
            PluginDirectoryCompatibility.CreateWithCompatiblePlatforms("Assets/Plugins/Improbable/Core/Windows/x86_64", new List<BuildTarget> { BuildTarget.StandaloneWindows64 }, editorCompatible: true),
            PluginDirectoryCompatibility.CreateWithCompatiblePlatforms("Assets/Plugins/Improbable/Core/Windows/x86", new List<BuildTarget> { BuildTarget.StandaloneWindows }, editorCompatible: true),
            PluginDirectoryCompatibility.CreateAllCompatible("Assets/Plugins/Improbable/Sdk/Common"),
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
            SetPluginsCompatibility();
			AssetDatabase.Refresh();
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

        internal static bool IsImprobablePlugin(string assetPath)
        {
            return assetPath.StartsWith("Assets/Plugins/Improbable");
        }

        private static bool ShouldCheckPluginForLock(PluginImporter p)
        {
            if (!IsImprobablePlugin(p.assetPath))
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

            return Download();
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

            if (exitCode != 0)
            {
                return DownloadResult.Error;
            }

            return DownloadResult.Success;
        }

        /// <summary>
        ///     Sets plugin platform compatibility based on directory structure
        /// </summary>
        internal static void SetPluginsCompatibility()
        {
	        AssetDatabase.StartAssetEditing();
            foreach (var pluginDirectoryCompatibility in PluginsCompatibilityList)
            {
                if (!Directory.Exists(pluginDirectoryCompatibility.Path))
                {
                    continue;
                }
                var pluginPaths = AssetDatabase.FindAssets("", new[] { pluginDirectoryCompatibility.Path });
                foreach (var pluginPath in pluginPaths)
                {
                    var plugin = AssetImporter.GetAtPath(AssetDatabase.GUIDToAssetPath(pluginPath)) as PluginImporter;
                    if (plugin == null)
                    {
                        continue;
                    }

                    // We only update options that needs to be updated to avoid reloading plugins that have correct settings
                    bool pluginCompatibilityUpdated = false;
                    if (plugin.GetCompatibleWithAnyPlatform() != pluginDirectoryCompatibility.AnyPlatformCompatible)
                    {
                        plugin.SetCompatibleWithAnyPlatform(pluginDirectoryCompatibility.AnyPlatformCompatible);
                        pluginCompatibilityUpdated = true;
                    }

                    if (plugin.GetCompatibleWithEditor() != pluginDirectoryCompatibility.EditorCompatible)
                    {
                        plugin.SetCompatibleWithEditor(pluginDirectoryCompatibility.EditorCompatible);
                        pluginCompatibilityUpdated = true;
                    }

                    if (pluginDirectoryCompatibility.AnyPlatformCompatible)
                    {
                        foreach (var buildTarget in pluginDirectoryCompatibility.IncompatiblePlatforms)
                        {
                            if (!plugin.GetExcludeFromAnyPlatform(buildTarget))
                            {
                                plugin.SetExcludeFromAnyPlatform(buildTarget, true);
                                pluginCompatibilityUpdated = true;
                            }
                        }
                    }
                    else
                    {
                        foreach (var buildTarget in pluginDirectoryCompatibility.CompatiblePlatforms)
                        {
                            if (!plugin.GetCompatibleWithPlatform(buildTarget))
                            {
                                plugin.SetCompatibleWithPlatform(buildTarget, true);
                                pluginCompatibilityUpdated = true;
                            }
                        }
                    }

                    if (pluginCompatibilityUpdated)
                    {
                        plugin.SaveAndReimport();
                    }
                }
            }
            AssetDatabase.StopAssetEditing();
        }

        private class PluginDirectoryCompatibility
        {
            public static PluginDirectoryCompatibility CreateWithCompatiblePlatforms(string path,
                List<BuildTarget> compatiblePlatforms,
                bool editorCompatible)
            {
                return new PluginDirectoryCompatibility(path, false, compatiblePlatforms, null, editorCompatible);
            }

            public static PluginDirectoryCompatibility CreateWithIncompatiblePlatforms(string path,
                List<BuildTarget> incompatiblePlatforms,
                bool editorCompatible)
            {
                return new PluginDirectoryCompatibility(path, true, null, incompatiblePlatforms, editorCompatible);
            }

            public static PluginDirectoryCompatibility CreateAllCompatible(string path)
            {
                return new PluginDirectoryCompatibility(path, true, null, null, true);
            }

            private PluginDirectoryCompatibility(string path,
                bool anyPlatformCompatible,
                List<BuildTarget> compatiblePlatforms,
                List<BuildTarget> incompatiblePlatforms,
                bool editorCompatible)
            {
                Path = path;
                AnyPlatformCompatible = anyPlatformCompatible;
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
