[//]: # (Doc of docs reference 11)
[//]: # (TODO - which module is ECS or GO-MB specific and which is generic?)

<%(TOC)%>
# Feature Modules Overview
_This document relates to both [MonoBehaviour and ECS workflows]({{urlRoot}}/reference/workflows/which-workflow)._

The SpatialOS GDK for Unity consists of several modules: the Core Module and multiple Feature Modules. The Core Module provides the functionality to enable your game for SpatialOS, while Feature Modules provide functionality that is not needed to connect to the SpatialOS [Runtime]({{urlRoot}}/reference/glossary#spatialos-runtime) but makes it easier to implement your game; such as player lifecycle or transform synchronization. Each module has helper functions which you can use to add the module’s functionality to a [worker](https://github.com/spatialos/UnityGDK/blob/master/docs/reference/workers).

See the documentation on [Workers in the GDK]({{urlRoot}}/reference/concepts/worker) for information on the relationship between workers and [ECS entities]({{urlRoot}}/reference/glossary#unity-ecs-entity).

## Core Module

The Core Module contains multiple packages (or "assemblies") that you need to use to set up your Unity-developed game to work with SpatialOS. The packages are:

* `Improbable.Gdk.Core` <br/>
This provides the basic implementation to use SpatialOS natively in Unity.

* `Improbable.Gdk.Tools`<br/>
 This contains the code generator which generates C# code from your schema file and the tools to download dependent SpatialOS packages. (See the SpatialOS documentation on [schema]({{urlRoot}}/reference/glossary#schema).)

* `Improbable.Gdk.TestUtils` <br/>
This provides both a testing framework, which you can use to test any other module and a test which you can use to validate the state of the overall project.

## Feature Modules

### Build System

This feature module provides tooling for building your GDK for Unity workers inside the Unity Editor. See our [build system documentation]({{urlRoot}}/modules/build-system/overview) for more details on installation and usage.

### GameObject Creation

This feature module contains a default implementation of spawning GameObjects for your SpatialOS entities and offers the ability to customize that process. See the [detailed documentation for set up and usage instructions]({{urlRoot}}/modules/game-object-creation/overview).

### Player lifecycle module

To access this module, use the   `Improbable.Gdk.PlayerLifecycle` namespace. It contains members which you use to implement player spawning and player heartbeats.

`Improbable.Gdk.PlayerLifecycle` is in the repository [here](https://github.com/spatialos/gdk-for-unity/tree/master/workers/unity/Packages/com.improbable.gdk.playerlifecycle).

The module consists of:

* `PlayerLifecycleHelper.AddClientSystems(world, autoRequestPlayerCreation)` -  in the repository [here](https://github.com/spatialos/gdk-for-unity/tree/master/workers/unity/Packages/com.improbable.gdk.playerlifecycle/PlayerLifecycleHelper.cs).<br/>
Call this to implement the player lifecycle module, adding all the necessary client systems to your client-worker. It also provides the option to disable automatic player creation when the worker connects to SpatialOS.<br/>
Call this when you create your [worker]({{urlRoot}}/reference/concepts/worker).

* `PlayerLifecycleHelper.AddServerSystems(world)` -  in the repository [here](https://github.com/spatialos/gdk-for-unity/tree/master/workers/unity/Packages/com.improbable.gdk.playerlifecycle/PlayerLifecycleHelper.cs).<br/>
Call this to implement the player lifecycle module, adding all the necessary server systems to your server-worker.<br/>
Call this when you create your [worker]({{urlRoot}}/reference/concepts/worker).

* `AddPlayerLifecycleComponents(entityTemplate, workerId, clientAccess, serverAccess)` - in the repository [here](https://github.com/spatialos/gdk-for-unity/tree/master/workers/unity/Packages/com.improbable.gdk.playerlifecycle/PlayerLifecycleHelper.cs).<br/>
Call this to add the SpatialOS components used by the player lifecycle module to your entity.<br/>
Call this during [entity template creation]({{urlRoot}}/reference/concepts/entity-templates).

Find out more in the [Player lifecycle feature module]({{urlRoot}}/modules/player-lifecycle-feature-module) documentation.

### Transform Synchronization

This feature module contains functionality that will automatically synchronize your entities' transform. See our [Transform Synchronization documentation]({{urlRoot}}/modules/transform-sync/overview) for more details on installation and usage.

### Mobile support module

To access this module, use the `Improbable.Gdk.Mobile` namespace. It offers support to connect mobile [client-workers]({{urlRoot}}/reference/glossary#client-worker) to SpatialOS.

`Improbable.Gdk.Mobile` is in the repository [here](https://github.com/spatialos/gdk-for-unity/tree/master/workers/unity/Packages/com.improbable.gdk.mobile).

This module consists of:

* `MobileWorkerConnector` - in the repository [here](https://github.com/spatialos/gdk-for-unity/tree/master/workers/unity/Packages/com.improbable.gdk.mobile).<br/>
Inherit from this class to define your custom mobile worker connectors.

* `Improbable.Gdk.Mobile.Android` - in the repository [here](https://github.com/spatialos/gdk-for-unity/tree/master/workers/unity/Packages/com.improbable.gdk.mobile/Android).
<br/>It provides additional functionality that you might need when developing for Android.

* `Improbable.Gdk.Mobile.iOS` - in the repository [here](https://github.com/spatialos/gdk-for-unity/tree/master/workers/unity/Packages/com.improbable.gdk.mobile/iOS).
<br/>It provides additional functionality that you might need when developing for iOS.

Find out more in the [Mobile support]({{urlRoot}}/reference/mobile/overview) documentation.
