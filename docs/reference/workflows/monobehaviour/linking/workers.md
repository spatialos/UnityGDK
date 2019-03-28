[//]: # (Doc of docs reference 5.3)

<%(TOC)%>
# Link workers to GameObjects
_This document relates to the [MonoBehaviour workflow]({{urlRoot}}/reference/workflows/which-workflow)._

Before reading this document, make sure you are familiar with:

* the SpatialOS entities section of  [MonoBehaviour workflow and ECS workflow]({{urlRoot}}/reference/workflows/which-workflow#spatialos-entities)
* [Workers in the GDK]({{urlRoot}}/reference/concepts/worker)
* [How to link SpatialOS entities with GameObjects]({{urlRoot}}/reference/workflows/monobehaviour/linking/spatialos-entities)

Not only can you [represent SpatialOS entities with GameObjects]({{urlRoot}}/reference/workflows/monobehaviour/linking/spatialos-entities) in a Scene by creating the SpatialOS entity first, then linking it to a GameObject in a Scene, you can also represent a worker with a GameObject in a Scene.

By representing a worker as a GameObject, the worker can send SpatialOS [component commands]({{urlRoot}}/reference/workflows/monobehaviour/interaction/commands/component-commands) and [world commands]({{urlRoot}}/reference/workflows/monobehaviour/interaction/commands/world-commands) even when the worker has no SpatialOS entities [checked out]({{urlRoot}}/reference/glossary#authority). 

To represent a worker with a GameObject, you use the GameObject Creation Feature Module. Find out how the module works in the documentation on [The Creation Feature Module]({{urlRoot}}/reference/workflows/monobehaviour/linking/spatialos-entities).

To represent a worker as a GameObject:
1. Create a GameObject in your Scene.

1. Pass the GameObject into the Creation Feature Module using the following methods:
  *  If you are using the default implementation of `GameObjectCreationHelper.EnableStandardGameObjectCreation(Worker.World, YourWorkerGameObject)` if you use the default implementation.
  * GameObjectCreationHelper.EnableStandardGameObjectCreation(Worker.World, new YourEntityGameObjectCreator(), YourWorkerGameObject) if you customized the `IEntityGameObjectCreator` where `YourWorkerGameObject` is the GameObject that should represent your worker.
1.  When your game runs, the GameObject Creation Feature Module attaches a GameObject component called `LinkedEntityComponent` to the GameObject representing the SpatialOS entity.</br>
  * Note that the `SpatialEntityId` field of the `LinkedEntityComponent` is set to 0. This is an invalid SpatialOS Entity ID.</br>

> The GameObject representing your worker is not automatically destroyed when you disconnect from SpatialOS.
