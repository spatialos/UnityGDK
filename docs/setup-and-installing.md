# Get the dependencies

<%(TOC)%>

To get set you'll need to create a SpatialOS account, install some dependencies and clone the GDK repository.

### Sign up for a SpatialOS account

In order to run the SpatialOS GDK for Unity, sign up for a [SpatialOS account](https://improbable.io/get-spatialos) for free.

### Set up your machine

<%(#Expandable title="Setup for Windows")%>

**Step 1.** Install **<a href="https://unity3d.com/get-unity/download/archive" data-track-link="Unity Download Link Clicked|product=Docs|platform=Win|label=Win" target="_blank"><strong>Unity 2018.2.14</strong></a>**

Ensure you install this exact version as other Unity versions may not work with the GDK.

- Make sure you download the **Installer** version, and select the following components during installation:
    - **Linux Build Support**
    - **Mac Build Support**

> **Note:** 
Even though you are developing on a Windows PC, you need:<br/>
**Linux Build Support** because all server-workers in a cloud deployment run in a Linux environment. <br/>
**Mac Build Support** if you want to share your game with end-users on a Mac.<br/>
Unity gives you Windows build support by default.

**Step 2.** Install **<a href="https://www.microsoft.com/net/download/dotnet-core/2.1" data-track-link=".NET Core Download Link Clicked|product=Docs|platform=Win|label=Win" target="_blank"><strong>.NET Core SDK (x64)</strong></a>**

- Verified with versions `2.1.3xx` and `2.1.4xx`

> **Note:** After installing the .NET Core SDK, you should restart any Unity and Unity Hub processes. This will prevent errors where Unity cannot find the `dotnet` executable.

**Step 3.** Run the **<a href="https://console.improbable.io/installer/download/stable/latest/win" data-track-link="SpatialOS Installer Downloaded|product=Docs|platform=Win|label=Win" target="_blank">SpatialOS Installer</a>**

- This installs the [SpatialOS CLI]({{urlRoot}}/content/glossary#spatial-command-line-tool-cli) , the [SpatialOS Launcher]({{urlRoot}}/content/glossary#launcher), and 32-bit and 64-bit Visual C++ Redistributables

**Step 4.** Install a **code editor** if you don't have one already

- We recommend either [Visual Studio 2017](https://www.visualstudio.com/downloads/) or [Rider](https://www.jetbrains.com/rider/).

**Using Visual Studio?**

As you install [Visual Studio](https://www.visualstudio.com/downloads/), click on the **Workloads** tab in the Installer. If you already have Visual Studio installed, you can find this by clicking on the **More** option for *Visual Studio Build Tools* in the Visual Studio Installer, and selecting **Modify** from the drop-down menu.

![Click Modify to find the Workloads tab.]({{assetRoot}}assets/setup/windows/visualstudioworkloads.png)

Once you have navigated to the **Workloads** tab:

* Select **.NET Core cross-platform development**

* After selecting **Game development with Unity**:
	- Deselect any options in the **Summary** on the right that mention a Unity Editor (e.g. Unity 2017.2 64-bit Editor or Unity 2018.1 64-bit Editor)
    - The SpatialOS GDK for Unity requires **Unity 2018.2.14**, which should already be installed if you have followed the setup guide correctly.
	- Make sure **Visual Studio Tools for Unity** is included (there should be a tick next to it)

> **Warning**: Older versions of Visual Studio 2017 have been known to cause some issues with Unity 2018.2.14 - the issues are projects loading and unloading frequently, and Intellisense breaking. If you do experience these issues, try updating to a newer version of Visual Studio 2017.

**Using Rider?**

Once you have installed [Rider](https://www.jetbrains.com/rider/), install the [**Unity Support** plugin](https://github.com/JetBrains/resharper-unity) for a better experience.

<%(/Expandable)%>

<%(#Expandable title="Setup for Mac")%>

**Step 1.** Install **<a href="https://unity3d.com/get-unity/download/archive" data-track-link="Unity Download Link Clicked|product=Docs|platform=Mac|label=Mac" target="_blank"><strong>Unity 2018.2.14</strong></a>**

Ensure you install this exact version as other Unity versions may not work with the GDK.

- Make sure to download the **Installer** version, and select the following components during installation:
    - **Linux Build Support**
    - **Windows Build Support**

> **Note:** Even though you are developing on a Mac, you need:<br/>
**Linux Build Support** because all server-workers in a cloud deployment run in a Linux environment. <br/>
**WIndows Build Support** if you want to share your game with end-users on a Windows PC.<br/>
Unity gives you Mac build support by default.

**Step 2.** Install **<a href="https://www.microsoft.com/net/download/dotnet-core/2.1" data-track-link=".NET Core Download Link Clicked|product=Docs|platform=Mac|label=Mac" target="_blank"><strong>.NET Core SDK (x64)</strong></a>**

- Verified with versions `2.1.3xx` and `2.1.4xx`

> **Note:** After installing the .NET Core SDK, you should restart any Unity and Unity Hub processes. This will prevent errors where Unity cannot find the `dotnet` executable.

**Step 3.** Run the **<a href="https://console.improbable.io/installer/download/stable/latest/mac" data-track-link="SpatialOS Installer Downloaded|product=Docs|platform=Mac|label=Mac" target="_blank">SpatialOS installer</a>**

- This installs the [SpatialOS CLI]({{urlRoot}}/content/glossary#spatial-command-line-tool-cli) , the [SpatialOS Launcher]({{urlRoot}}/content/glossary#launcher), and 32-bit and 64-bit Visual C++ Redistributables

**Step 4.** Install a **code editor** if you don't have one already

- We recommend either [Visual Studio](https://www.visualstudio.com/downloads/) or [Rider](https://www.jetbrains.com/rider/).

**Using Visual Studio?**

Once you have installed [Visual Studio](https://www.visualstudio.com/downloads/), within the Visual Studio Installer, select **.NET Core + ASP .NET Core**.

**Using Rider?**

Once you have installed [Rider](https://www.jetbrains.com/rider/), install the [**Unity Support** plugin](https://github.com/JetBrains/resharper-unity) for a better experience.

<%(/Expandable)%>

<%(Callout type="alert" message="
* You need **Linux** build support. This is because server-workers in a cloud deployment run in a Linux environment. In the `Assets/Fps/Config/BuildConfiguration`, do not change the `UnityGameLogic Cloud Environment` from Linux.<br/>
* You need **Mac** build support if you are developing on a Windows PC and want to share your game with Mac users.<br/>
* You need **Windows** build support if you are developing on a Mac and want to share your game with Windows PC users. <br/>
* Unity gives you build support for your development machine (Windows or Mac) by default.")%>

<%(#Expandable title="Having problems?")%>
If you need help using the GDK, please come and talk to us about the software and the documentation via:

**The SpatialOS forums**

Visit the [support section](https://forums.improbable.io/new-topic?category=Support&tags=unity-gdk) in our forums and use the unity-gdk tag.

**Discord**

Find us in the [#unity channel](https://discord.gg/SCZTCYm). You may need to grab Discord [here](https://discordapp.com/).

**Github issues**

Create an [issue](https://github.com/spatialos/gdk-for-unity/issues) in this repository.
<%(/Expandable)%>

### Clone the SpatialOS GDK for Unity repository

|     |     |
| --- | --- |
| SSH | `git clone git@github.com:spatialos/gdk-for-unity.git` |
| HTTPS | `git clone https://github.com/spatialos/gdk-for-unity.git` |

The GDK repository is a SpatialOS project called `gdk-for-unity`. It contains:

  * a Unity project at `gdk-for-unity/workers/unity`, which you need to open in the Unity editor in order to use the GDK
  * SpatialOS features, such as the schema and snapshot files

### Licensing

*Your access to and use of the Unity Engine is governed by the Unity Engine End User License Agreement. Please ensure that you have agreed to those terms before you access or use the Unity Engine. For more about licensing for the SpatialOS GDK see the [licensing]({{urlRoot}}/license) section.*
