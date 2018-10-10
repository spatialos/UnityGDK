**Warning:** The [alpha](https://docs.improbable.io/reference/latest/shared/release-policy#maturity-stages) release is for evaluation purposes only.

-----
[//]: # (Doc of docs reference 10)
[//]: # (TODO: technical writer review)

# (GameObject-MonoBehaviour) API - SpatialOSComponent
 _This document relates to the GameObject-MonoBehaviour workflow._

Before reading this document, make sure you are familiar with
  * [Workers](../workers/workers-in-the-gdk.md)
  * [Linking SpatialOS entites as GameObjects](./linking-spos-entities-gameobjects.md)
  * [Workers as GameObjects](./linking-workers-gameobjects.md)

The SpatialOS GDK automatically adds a `SpatialOSComponent` MonoBehaviour to each GameObject that is linked to a SpatialOS entity to allow you to access information about the corresponding worker and the underlying SpatialOS entity.

## API - SpatialOSComponent

**Fields:**

| Field         	| Type 	| Description                        	|
|-------------------|----------|----------------------------------------|
| SpatialEntityId | EntityId | The SpatialOS Entity Id of the entity that this GameObject is linked to. |
| Entity | Entity | The linked ECS entity. |
| World | World | The [world](link to Unity docs) that the linked ECS entity belongs to. |
| Worker | WorkerSystem | The worker that is responsible for the linked SpatialOS entity. |

**Methods:**
```csharp
bool IsEntityOnThisWorker(EntityId entityId)
```
Parameters:
  * `EntityId entityId`: The SpatialOS entity id of the entity that we want to check.
Returns: true, if the specified entity is checked out on the same worker as the GameObject that we call this from.

```csharp
bool TryGetGameObjectForSpatialOSEntityId(EntityId entityId, out GameObject linkedGameObject);
```
Parameters:
  * `EntityId entityId`: The SpatialOS entity id of the entity that we want to retrieve the linked GameObject from.
  * `GameObject linkedGameObject`: Will contain the linked GameObject after calling this method or null, if none is linked to the specified entity id.
Returns: true, if the entity is checked out on the same worker as the component from which we call the method and it is linked to a GameObject, false otherwise.

```csharp
bool TryGetSpatialOSEntityIdForGameObject(GameObject linkedGameObject, out EntityId entityId);
```
Parameters:
  * `GameObject linkedGameObject`: The GameObject that we want to get the linked SpatialOS entity from.
  * `EntityId entityId`: Will contain the SpatialOS entity id of the linked GameObject.
Returns: true, if the GameObject is linked to a SpatialOs entity and that entity is checked out on the same worker as the component from which we call the method, false otherwise.

### How to use the `SpatialOSComponent`
The following code snippets shows an example reading the SpatialOS EntityId of the entity that a GameObject represents:

```csharp
public class MyEntityIdMonoBehaviour : MonoBehaviour
{
  private EntityId myEntityId;

  private void OnEnable()
  {
    var spatialOSComponent = GetComponent<SpatialOSComponent>();
    myEntityId = spatialOSComponent.SpatialEntityId;
  }
}
```

The following code snippets shows shows how to use the logger from the corresponding worker::

```csharp
public class LogToSpatialOSMonoBehaviour : MonoBehaviour
{
  private ILogDispatcher logDispatcher;

  private void OnEnable()
  {
    var spatialOSComponent = GetComponent<SpatialOSComponent>();
    logDispatcher = spatialOSComponent.Worker.LogDispatcher;
  }

  public void LogMessage(LogType logType, string message)
  {
    logDispatcher.HandleLog(logType, new LogEvent(message));
  }
}
```
