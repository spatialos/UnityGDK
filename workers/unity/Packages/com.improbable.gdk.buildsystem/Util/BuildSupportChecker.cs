using System.Collections.Generic;
using System.IO;
using System.Linq;
using Improbable.Gdk.BuildSystem.Configuration;
using UnityEditor;
using UnityEngine;

public static class BuildSupportChecker
{
    public static BuildTarget[] GetBuildTargetsMissingBuildSupport(params BuildTarget[] buildTargets)
    {
        var editorDirectory = Directory.GetParent(EditorApplication.applicationPath);

        string playbackEnginesDirectory;

        switch (Application.platform)
        {
            case RuntimePlatform.OSXEditor:
                playbackEnginesDirectory = Path.Combine(editorDirectory.FullName, "PlaybackEngines");
                break;
            case RuntimePlatform.WindowsEditor:
                playbackEnginesDirectory = Path.Combine(editorDirectory.FullName, "Data", "PlaybackEngines");
                break;
            default:
                return new BuildTarget[0];
        }

        return buildTargets
            .Where(target =>
            {
                if (WorkerBuildData.BuildTargetSupportDirectoryNames.TryGetValue(target, out var playbackEnginesDirectoryName))
                {
                    return !Directory.Exists(Path.Combine(playbackEnginesDirectory, playbackEnginesDirectoryName));
                }

                Debug.LogWarning($"Unsupported build target: {target}");

                return false;
            })
            .ToArray();
    }

    public static string ConstructMissingSupportMessage(string workerType, BuildEnvironment environment,
        BuildTarget[] buildTargetsMissingBuildSupport)
    {
        return
            $"The worker \"{workerType}\" cannot be built for a {environment} deployment -" +
            $" the Unity Editor is missing build support for {string.Join(", ", buildTargetsMissingBuildSupport)}.\n" +
            "Please add the missing build support options to your Unity Editor.";
    }
}
