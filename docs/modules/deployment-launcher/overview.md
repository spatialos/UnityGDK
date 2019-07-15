# Deployment Launcher Feature Module

This feature module contains Unity Editor tooling for uploading assemblies, and managing SpatialOS deployments.

## Installation

Add this feature module to your project via the [Package Manager UI](https://docs.unity3d.com/Packages/com.unity.package-manager-ui@2.1/manual/index.html#installing-a-new-package).

Or add it to your `Packages/manifest.json`:

```json
{
  "dependencies": {
    "io.improbable.gdk.deploymentlauncher": "<%(Var key="current_version")%>"
  },
}
```

## Usage

1. Create a Deployment Configuration asset by selecting **Assets** > **Create** > **SpatialOS** > **Deployment Launcher Config** from the Unity Editor menu.
1. Open the Deployment Launcher window by selecting **SpatialOS** > **Deployment Launcher** from the Unity Editor menu.

Please refer to the detailed documentation for each of the functions of the Deployment Launcher:

* [Upload an assembly]({{urlRoot}}/modules/deployment-launcher/upload-assemblies)
* [Configure and launch a deployment]({{urlRoot}}/modules/deployment-launcher/launch-deployments)
* [Manage live deployments]({{urlRoot}}/modules/deployment-launcher/manage-deployments)

### Change my project in the Deployment Launcher

The Deployment Launcher reads your SpatialOS project name from the `spatialos.json` file in the root of your SpatialOS project. To change which project the Deployment Launcher uses:

1. Change the project name in your `spatialos.json`.
2. Press the refresh button in the Deployment Launcher window, next to the **Project Name** label to reload the project name.

<img src="{{assetRoot}}assets/modules/deployment-launcher/refresh-button.png" style="margin: 0 auto; width: auto; display: block;" />
