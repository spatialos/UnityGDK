using System;
using System.Collections.Generic;
using System.IO;
using Improbable.Gdk.BuildSystem.Configuration;
using Improbable.Gdk.Core;
using Improbable.Gdk.Tools;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

namespace Improbable.Gdk.BuildSystem
{
    public static class WorkerBuilder
    {
        internal static readonly string IncompatibleWindowsPlatformsErrorMessage =
            $"Please choose only one of {SpatialBuildPlatforms.Windows32} or {SpatialBuildPlatforms.Windows32} as a build platform.";

        private static readonly string PlayerBuildDirectory =
            Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), EditorPaths.AssetDatabaseDirectory,
                "worker"));

        private const string BuildWorkerTypes = "buildWorkerTypes";

        /// <summary>
        ///     Build method that is invoked by commandline
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public static void Build()
        {
            try
            {
                var commandLine = Environment.GetCommandLineArgs();
                var buildTargetArg = CommandLineUtility.GetCommandLineValue(commandLine, "buildTarget", "local");

                BuildEnvironment buildEnvironment;
                switch (buildTargetArg.ToLower())
                {
                    case "cloud":
                        buildEnvironment = BuildEnvironment.Cloud;
                        break;
                    case "local":
                        buildEnvironment = BuildEnvironment.Local;
                        break;
                    default:
                        throw new BuildFailedException("Unknown build target value: " + buildTargetArg);
                }

                var workerTypesArg =
                    CommandLineUtility.GetCommandLineValue(commandLine, BuildWorkerTypes,
                        "UnityClient,UnityGameLogic");

                var wantedWorkerTypes = workerTypesArg.Split(',');
                foreach (var wantedWorkerType in wantedWorkerTypes)
                {
                    AssertWorkerCanBuildForEnvironment(wantedWorkerType, buildEnvironment);
                }

                LocalLaunch.BuildConfig();

                foreach (var wantedWorkerType in wantedWorkerTypes)
                {
                    BuildWorkerForEnvironment(wantedWorkerType, buildEnvironment);
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                if (e is BuildFailedException)
                {
                    throw;
                }

                throw new BuildFailedException(e);
            }
        }

        public static void AssertWorkerCanBuildForEnvironment(string workerType, BuildEnvironment targetEnvironment)
        {
            var spatialOSBuildConfiguration = SpatialOSBuildConfiguration.GetInstance();
            var environmentConfig = spatialOSBuildConfiguration.GetEnvironmentConfigForWorker(workerType, targetEnvironment);
            if (environmentConfig == null)
            {
                return;
            }

            var buildTargets = GetUnityBuildTargets(environmentConfig.BuildPlatforms);
            var buildSupportResult = BuildSupportChecker.CheckBuildSupport(buildTargets);

            if (buildSupportResult.CanBuild)
            {
                return;
            }

            var targetsString = string.Join(", ", buildSupportResult.TargetsWithoutBuildSupport);
            throw new BuildFailedException(
                $"{workerType} cannot be built for {targetEnvironment}, missing build support for {targetsString}.\n" +
                "Please configure your Unity Editor installation to add the missing build support components.");
        }

        public static void BuildWorkerForEnvironment(string workerType, BuildEnvironment targetEnvironment)
        {
            var spatialOSBuildConfiguration = SpatialOSBuildConfiguration.GetInstance();
            var environmentConfig = spatialOSBuildConfiguration.GetEnvironmentConfigForWorker(workerType, targetEnvironment);
            if (environmentConfig == null)
            {
                Debug.LogWarning($"Skipping build for {workerType}.");
                return;
            }

            var buildPlatforms = environmentConfig.BuildPlatforms;
            var buildOptions = environmentConfig.BuildOptions;

            if (!Directory.Exists(PlayerBuildDirectory))
            {
                Directory.CreateDirectory(PlayerBuildDirectory);
            }

            foreach (var unityBuildTarget in GetUnityBuildTargets(buildPlatforms))
            {
                BuildWorkerForTarget(workerType, unityBuildTarget, buildOptions, targetEnvironment);
            }
        }

        public static void Clean()
        {
            Directory.Delete(PlayerBuildDirectory, true);
            Directory.Delete(EditorPaths.BuildScratchDirectory, true);
        }

        public static BuildTarget[] GetUnityBuildTargets(SpatialBuildPlatforms actualPlatforms)
        {
            var result = new List<BuildTarget>();
            if ((actualPlatforms & SpatialBuildPlatforms.Current) != 0)
            {
                actualPlatforms |= GetCurrentBuildPlatform();
            }

            if ((actualPlatforms & SpatialBuildPlatforms.Linux) != 0)
            {
                result.Add(BuildTarget.StandaloneLinux64);
            }

            if ((actualPlatforms & SpatialBuildPlatforms.OSX) != 0)
            {
                result.Add(BuildTarget.StandaloneOSX);
            }

            if ((actualPlatforms & SpatialBuildPlatforms.Windows32) != 0)
            {
                if ((actualPlatforms & SpatialBuildPlatforms.Windows64) != 0)
                {
                    throw new Exception(IncompatibleWindowsPlatformsErrorMessage);
                }

                result.Add(BuildTarget.StandaloneWindows);
            }
            else if ((actualPlatforms & SpatialBuildPlatforms.Windows64) != 0)
            {
                result.Add(BuildTarget.StandaloneWindows64);
            }

            return result.ToArray();
        }

        internal static SpatialBuildPlatforms GetCurrentBuildPlatform()
        {
            switch (Application.platform)
            {
                case RuntimePlatform.WindowsEditor:
                    return SpatialBuildPlatforms.Windows64;
                case RuntimePlatform.OSXEditor:
                    return SpatialBuildPlatforms.OSX;
                case RuntimePlatform.LinuxEditor:
                    return SpatialBuildPlatforms.Linux;
                default:
                    throw new Exception($"Unsupported platform detected: {Application.platform}");
            }
        }

        private static void BuildWorkerForTarget(string workerType, BuildTarget buildTarget,
            BuildOptions buildOptions, BuildEnvironment targetEnvironment)
        {
            Debug.LogFormat("Building \"{0}\" for worker platform: \"{1}\", environment: \"{2}\"", buildTarget,
                workerType, targetEnvironment);

            var spatialOSBuildConfiguration = SpatialOSBuildConfiguration.GetInstance();
            var workerBuildData = new WorkerBuildData(workerType, buildTarget);
            var scenes = spatialOSBuildConfiguration.GetScenePathsForWorker(workerType);

            var buildPlayerOptions = new BuildPlayerOptions
            {
                options = buildOptions,
                target = buildTarget,
                scenes = scenes,
                locationPathName = workerBuildData.BuildScratchDirectory
            };

            var result = BuildPipeline.BuildPlayer(buildPlayerOptions);
            if (result.summary.result != BuildResult.Succeeded)
            {
                throw new BuildFailedException($"Build failed for {workerType}");
            }

            var zipPath = Path.Combine(PlayerBuildDirectory, workerBuildData.PackageName);
            var basePath = Path.Combine(EditorPaths.BuildScratchDirectory, workerBuildData.PackageName);
            Zip(zipPath, basePath, targetEnvironment == BuildEnvironment.Cloud);
        }

        private static void Zip(string zipAbsolutePath, string basePath, bool useCompression)
        {
            using (new ShowProgressBarScope($"Package {basePath}"))
            {
                RedirectedProcess.Run(Common.SpatialBinary, "file", "zip",
                    $"--output=\"{Path.GetFullPath(zipAbsolutePath)}\"",
                    $"--basePath=\"{Path.GetFullPath(basePath)}\"", "\"**\"",
                    $"--compression={useCompression}");
            }
        }
    }
}
