# Get started: 4 - Upload and launch your game

This has 3 steps:

* Set your project name
* Upload worker assemblies
* Launch a cloud deployment


### Set your project name

When you signed up for SpatialOS, your account was automatically associated with an organisation and a project, both of which have the same generated name. To find this name enter the [Console](https://console.improbable.io/projects). It should looks like `beta_randomword_anotherword_randomnumber`:

<img src="{{assetRoot}}assets/project-page.png" style="margin: 0 auto; display: block;" />

Using a text editor of your choice, open `gdk-for-unity-fps-starter-project/spatialos.json` and replace the `unity_gdk` project name with the project name you were assigned in the Console. This will tell SpatialOS which project you intend to upload to. Your `spatialos.json` should look like this:

```json
{
  "name": "beta_yankee_hawaii_621",
  "project_version": "0.0.1",
  "sdk_version": "14.0-b6143-48ac8-WORKER-SNAPSHOT",
  "dependencies": [
      {"name": "standard_library", "version": "14.0-b6143-48ac8-WORKER-SNAPSHOT"}
  ]
}
```

<br/>
### Upload worker assemblies

An [assembly](https://docs.improbable.io/reference/latest/shared/glossary#assembly) is a bundle of code, art assets and other files necessary to run your game in the cloud.

To run a deployment in the cloud, you must upload the worker assemblies to your SpatialOS project. You can only do this in a terminal, via the [spatial CLI](https://docs.improbable.io/reference/latest/shared/glossary#the-spatial-command-line-tool-cli). You must also give the worker assemblies a name so that you can reference them when launching a deployment.

Do this using a terminal of your choice - for example, PowerShell on Windows - navigate to `gdk-for-unity-fps-starter-project/` and run `spatial cloud upload <assembly_name>`. The `<assembly_name>` is a string of your choice made up of alphanumeric characters, `_`, `.`, and `-`; for example `my_assembly`. A valid upload command would look like this:
```
spatial cloud upload my_assembly
```

> **It’s finished uploading when:** You see an upload report printed in your terminal output, for example:
```
Upload report:
- 5 artifacts uploaded (4 successful, 1 skipped, 0 failed)
```

Based on your network speed, this may take a little while (1-10 minutes) to complete.

<br/>
### Launch a cloud deployment

The next step is to [launch a cloud deployment](https://docs.improbable.io/reference/latest/shared/deploy/deploy-cloud#5-deploy-the-project) using the assembly that you just uploaded. This can only be done through the spatial CLI.

When launching a cloud deployment you must provide three parameters:

* **the assembly name**, which identifies the worker assemblies to use. These are the assemblies you uploaded earlier so the name should match the one you passed to `spatial cloud upload`.
* **a launch configuration**, which is a JSON file that declares the world and load balancing configuration.
* **a name for your deployment**, which is used to label the deployment in the SpatialOS web Console. It consists of lower-case letters, digits, and `_` and can be up to 32 characters long.

Using a terminal of your choice, navigate to the root directory of your SpatialOS project and run `spatial cloud launch --snapshot=snapshots/default.snapshot <assembly_name> cloud_launch_large.json <deployment_name>` where `assembly_name` is the name you gave the assembly in the previous step and `deployment_name` is a name of your choice (for example, shootyshooty). A valid launch command would look like this:
```
spatial cloud launch --snapshot=snapshots/default.snapshot my_assembly cloud_launch_large.json shootyshooty
```

This command defaults to deploying to clusters located in the US. If you’re in Europe, add the `--cluster_region=eu` flag for lower latency.

> **It's finished when:** You see `Deployment launched successfully` printed in your terminal output.

## Well done getting set up!
It’s time to play your game.

#### Next: [Get playing!]({{urlRoot}}/content/get-started/get-playing.md)

