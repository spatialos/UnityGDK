[//]: # (Doc of docs reference 15)
<%(TOC)%>
# Workers: Workers in the GDK

Before reading this document, make sure you are familiar with the [MonoBehaviour and  ECS workflow]({{urlRoot}}/content/intro-workflows-spatialos-entities).

## What is a SpatialOS worker?

The SpatialOS [Runtime]({{urlRoot}}/content/glossary.md#spatialos-runtime) manages your [game world]({{urlRoot}}/content/glossary#world) by keeping track of all [SpatialOS entities]({{urlRoot}}/content/glossary#spatialos-entity) and the current state of their [components]({{urlRoot}}/content/glossary#spatialos-component).

To execute any kind of logic on these entities, we use [workers]({{urlRoot}}/content/glossary#worker).
They perform the computation associated with a world: they can read what’s happening, watch for changes, and make changes of their own.

We differentiate between [client-workers]({{urlRoot}}/content/glossary#client-worker) and [server-workers]({{urlRoot}}/content/glossary#server-worker).

>Find out more about SpatialOS entity, component, and worker concepts, in the [SpatialOS concept documentaiton](https://docs.improbable.io/reference/latest/shared/concepts/spatialos).

## Workers and ECS worlds

As described in the [MonoBehaviour and  ECS workflow]({{urlRoot}}/content/intro-workflows-spatialos-entities) document, the GDK uses ECS under the hood, even if you are using the MonoBehaviour workflow. So, in your project, the GDK represents SpatialOS entities as ECS entities.

In the GDK, any server-worker or client-worker essentially consists of its connection to the SpatialOS Runtime and a list of ECS systems - which hold the logic relevant to the game world. When your GDK-created game runs and creates either a client-worker or server-worker, that worker tries to connect to the SpatialOS Runtime.

When it connects, the worker creates an ECS world to keep track of all SpatialOS entities that are in its view and adds all systems that are defined inside it to its ECS world. These systems contain the logic necessary to simulate your game and synchronize changes with the SpatialOS Runtime.

This means that, along with a SpatialOS game world and SpatialOS entities, there is an ECS world with ECS entities. However, while the SpatialOS world is game-wide and represents all SpatialOS entities, the ECS world is much narrower; it’s worker-specific and represents only the ECS entities which are currently in a [worker’s view]({{urlRoot}}/content/glossary#worker-s-view).   Of course, this means that you have as many ECS worlds in your game as you have workers.

You add definitions of the systems inside your worker using the worker API `worker.World.GetOrCreateManager<YourSystem>()`. (See the [worker API]({{urlRoot}}/content/workers/api-worker) documentation for more information.)


## Further information
To learn about a workers’ connection to the SpatialOS Runtime, see:

  * [Connecting to SpatialOS]({{urlRoot}}/content/connecting-to-spatialos)

To learn more about how to create and use workers in the GDK, please see the following documentation:

  * MonoBehaviour workflow - [Workers: Creating workers with WorkerConnector]({{urlRoot}}/content/gameobject/creating-workers-with-workerconnector)
  * ECS workflow - [worker entity]({{urlRoot}}/content/workers/worker-entity)
  * [API - worker]({{urlRoot}}/content/workers/api-worker)
  * [API - worker system]({{urlRoot}}/content/workers/api-worker-system)

## Example implementation

In the GDK's [Playground project](https://github.com/spatialos/gdk-for-unity/tree/master/workers/unity/Assets/Playground) we provide an example implementation of the connection logic necessary for the workers to connect to the SpatialOS Runtime. These are stored as prefabs, so that you can use them directly in Scenes. We provide three sample Scenes:

* `SampleScene`: This Scenes contains both the `UnityClient` and the `UnityGameLogic` prefabs and will start both workers as soon as you load the scene.

* `ClientScene`: This Scene contains only the `UnityClient` prefab and can be used to build your client worker for cloud deployments.

* `GameLogicScene`: This Scene contains only the `UnityGameLogic` prefab and can be used to build your server worker for cloud deployments.

The position of these prefabs in the Scene define the [`Origin` of the worker]({{urlRoot}}/content/glossary#worker-origin), which is used to translate all entities that have been added to this worker. This ensures that entities checked out by different workers don't interfere with each other when running multiple workers in the same scene.
