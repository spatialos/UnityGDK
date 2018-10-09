# Set up the SpatialOS GDK for Unity

## Quick version

1. Sign up for a [SpatialOS account](https://improbable.io/get-spatialos).
1. Set up your machine by installing the prerequisites. See the install guide for [Windows](#windows) or [MacOS](#mac).
1. Clone the UnityGDK repository: `git clone git@github.com:spatialos/UnityGDK.git` or `git clone https://github.com/spatialos/UnityGDK.git`.
1. Follow the [quickstart]({{urlRoot}}/content/deploy#quickstart-how-to-deploy-the-playground-project) guide to run the example `Playground` project.

## Full version

### Sign up for a SpatialOS account

You'll need a SpatialOS account in order to run the SpatialOS GDK for Unity.
Follow [this link](https://improbable.io/get-spatialos) to sign up for free.

### Set up your machine

#### Windows

| Step | Requirement | |
| --- | --- | --- |
| 1 | [Unity 2018.2.8](https://unity3d.com/get-unity/download/archive) | Make sure to select the following components during installation: **Linux Build Support**, **Mac Build Support**<%(#Expandable title="How will I know when Unity is installed? (Expand for image)")%>Once Unity has been installed on your machine, the Download Assistant should prompt you to click *Finish* to close the installer.![](assets/setup/windows/unity.png)<%(/Expandable)%> |
| 2 | [.NET Core SDK (x64)](https://www.microsoft.com/net/download/dotnet-core/2.1) | Verified with versions `2.1.3xx` and `2.1.4xx`<%(#Expandable title="How will I know when .NET Core SDK is installed? (Expand for image)")%>Once the .NET Core SDK has been installed, a window should appear stating that installation was successful and to prompt you to close the installer.![](assets/setup/windows/dotnetcoresdk.png)<%(/Expandable)%> |
| 3 | [SpatialOS](https://console.improbable.io/installer/download/stable/latest/win) | This installs the [spatial CLI](https://docs.improbable.io/reference/latest/shared/spatial-cli-introduction), the [SpatialOS Launcher](https://docs.improbable.io/reference/latest/shared/operate/launcher), and 32-bit and 64-bit Visual C++ Redistributables<%(#Expandable title="How will I know when SpatialOS is installed? (Expand for image)")%>Once SpatialOS has been installed, the installer should prompt you to click *Finish* to complete the installation.![](assets/setup/windows/spatialos.png)<%(/Expandable)%> |
| 4 | Code Editor | We recommend either [Visual Studio 2017](https://www.visualstudio.com/downloads/) or [Rider](https://www.jetbrains.com/rider/).<%(#Expandable title="How will I know when Visual Studio is installed? (Expand for image)")%>Once Visual Studio has been installed, the installer should prompt you to restart your computer.![](assets/setup/windows/visualstudio.png)<%(/Expandable)%><%(#Expandable title="How will I know when Rider is installed? (Expand for image)")%>Once Rider is installed, the installer should prompt you to click *Finish* to close Setup.![](assets/setup/windows/rider.png)<%(/Expandable)%> |

> After installing the .NET Core SDK, you should restart any Unity and Unity Hub processes. This will prevent errors where Unity cannot find the `dotnet` executable.

##### Visual Studio

If you are using Visual Studio, within the Visual Studio Installer, on the **Workloads** tab:

- Select **Game development with Unity**
- Select **.NET Core cross-platform development**
- In the **Summary** on the right:
  - Deselect **Unity 2017.2 64-bit Editor** (the SpatialOS GDK for Unity requires Unity 2018.2.8)
  - Make sure **Visual Studio Tools for Unity** is selected

> **Warning**: Older versions of Visual Studio 2017 have been known to cause some issues with Unity 2018.2.8 - the issues are projects loading and unloading frequently, and Intellisense breaking. If you do experience these issues, try updating to a newer version of Visual Studio 2017.

##### Rider

If you are using Rider, install the [**Unity Support** plugin](https://github.com/JetBrains/resharper-unity) for a better experience

#### Mac

| Step | Requirement | |
| --- | --- | --- |
| 1 | [Unity 2018.2.8](https://unity3d.com/get-unity/download/archive) | Make sure to select the following components during installation: **Linux Build Support**, **Windows Build Support**<%(#Expandable title="How will I know when Unity is installed? (Expand for image)")%>Once Unity has been installed on your machine, the Download Assistant should tell you that installation was successful.![](assets/setup/mac/unity.png)<%(/Expandable)%> |
| 2 | [.NET Core SDK (x64)](https://www.microsoft.com/net/download/dotnet-core/2.1) | Verified with versions `2.1.3xx` and `2.1.4xx`<%(#Expandable title="How will I know when .NET Core SDK is installed? (Expand for image)")%>Once the .NET Core SDK has been installed, a window should appear stating that installation was successful and to prompt you to close the installer.![](assets/setup/mac/dotnetcoresdk.png)<%(/Expandable)%> |
| 3 | [SpatialOS](https://console.improbable.io/installer/download/stable/latest/mac) | This installs the [spatial CLI](https://docs.improbable.io/reference/latest/shared/spatial-cli-introduction), the [SpatialOS Launcher](https://docs.improbable.io/reference/latest/shared/operate/launcher), and 32-bit and 64-bit Visual C++ Redistributables<%(#Expandable title="How will I know when SpatialOS is installed? (Expand for image)")%>Once SpatialOS has been installed, the installer should should tell you that installation was successful.![](assets/setup/mac/spatialos.png)<%(/Expandable)%> |
| 4 | Code Editor | We recommend either [Visual Studio](https://www.visualstudio.com/downloads/) or [Rider](https://www.jetbrains.com/rider/).<%(#Expandable title="How will I know when Visual Studio is installed? (Expand for image)")%>Once Visual Studio has been installed, the installer should should tell you that installation was successful.![](assets/setup/mac/visualstudio.png)<%(/Expandable)%><%(#Expandable title="How will I know when Rider is installed? (Expand for image)")%>When installing Rider, the installer will prompt you to drag the Rider icon into your `Applications` folder.![](assets/setup/mac/rider.png)If no errors are thrown, then your installation was successful.<%(/Expandable)%> |

> After installing the .NET Core SDK, you should restart any Unity and Unity Hub processes. This will prevent errors where Unity cannot find the `dotnet` executable.

##### Visual Studio

If you are using Visual Studio, within the Visual Studio Installer, select **.NET Core + ASP .NET Core**

##### Rider

If you are using Rider, install the [**Unity Support** plugin](https://github.com/JetBrains/resharper-unity) for a better experience

### Clone the SpatialOS GDK for Unity repository

|     |     |
| --- | --- |
| SSH | `git clone git@github.com:spatialos/UnityGDK.git` |
| HTTPS | `git clone https://github.com/spatialos/UnityGDK.git` |

The GDK repository is a SpatialOS project called `UnityGDK`. It contains:

- a Unity project at `UnityGDK/workers/unity`, which you need to open to use the GDK
- SpatialOS features, such as the schema and snapshot files
- development code

## Next steps

To learn how to build and run the included `Playground` project - follow the [quickstart]({{urlRoot}}/content/deploy#quickstart-how-to-deploy-the-playground-project).
