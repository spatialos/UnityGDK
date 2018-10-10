**Warning:** The [alpha](https://docs.improbable.io/reference/latest/shared/release-policy#maturity-stages) release is for evaluation purposes only.

------
[//]: # (Doc of docs reference 5.3)

# (GameObject-MonoBehaviour) Workers: How to represent a worker as a GameObject
_This document relates to the GameObject-MonoBehaviour workflow._

Before reading this document, make sure you are familiar with: 
* the SpatialOS entities section of  [GameObject-MonoBehaviour workflow and ECS workflow](../intro-workflows-spos-entities.md#spatialos-entities)
* [Workers in the GDK](../workers/workers-in-the-gdk.md)
* [How to link SpatialOS entities with GameObjects](./linking-spos-entities-gameobjects.md)


Not only can you [represent SpatialOS entities with GameObjects](./linking-spos-entities-gameobjects.md) in a Scene by creating the SpatialOS entity first, then linking it to a GameObject in a Scene, you can also represent a worker with a GameObject in a Scene. 

By representing a worker as a GameObject, the worker can send SpatialOS [component commands](../world-component-commands-requests-responses.md) and [world commands](./gomb-world-commands.md) even when the worker has no SpatialOS entities [checked out](../glossary.md#authority).  



To represent a worker with a GameObject, you use the Creation Feature Module. Find out how the module works in the documentation on [The Creation Feature Module](./gameobject/linking-spos-entities-gameobjects.md).

To represent a worker as a GameObject:
1. Create a GameObject in your Scene. 

2. Pass the GameObject into the Creation Feature Module using the following methods:
  *  If you are using the default implementation of `GameObjectCreationHelper.EnableStandardGameObjectCreation(Worker.World, YourWorkerGameObject) if you use the default implementation.
  * GameObjectCreationHelper.EnableStandardGameObjectCreation(Worker.World, new YourEntityGameObjectCreator(), YourWorkerGameObject) if you customized the `IEntityGameObjectCreator`
where `YourWorkerGameObject` is the GameObject that should represent your worker. 


3.  When your game runs,  the Creation Feature Module attaches a GameObject component called `SpatialOSComponent` to the GameObject representing the SpatialOS entity.</br>
* Note that the `SpatialEntityId` field of the `SpatialOSComponent` is set to 0.</br>
* See the documentation to find out more about the [`SpatialOSComponent`](TODO LINK to GDoc 10) .


**Note:** The GameObject representing your worker is not automatically destroyed when you disconnect from SpatialOS.


------

**Give us feedback:** We want your feedback on the SpatialOS GDK for Unity and its documentation  - see [How to give us feedback](../../../README.md#give-us-feedback).

