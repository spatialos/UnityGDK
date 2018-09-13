**Warning:** The [alpha](https://docs.improbable.io/reference/latest/shared/release-policy#maturity-stages) release is for evaluation purposes only, with limited documentation - see the guidance on [Recommended use](../../../README.md#recommended-use).

-----


## ECS: World commands

World commands are special commands that are sent to the SpatialOS runtime to ask it to reserve entity ids, create or delete entities, or request information about entities. (See the SpatialOS documentation on [world commands](https://www.google.com/url?q=https://docs.improbable.io/reference/latest/shared/design/commands%23world-commands&sa=D&ust=1536752675413000) for more information.) 

Each ECS entity that represents a SpatialOS entity has a set of components for sending world commands. For each world command, there is a component to send the command and receive the response. 

### 1. Reserve an entity ID

You can use the `ReserveEntityIds` world command before entity creation which makes it easier to create multiple entities in a group.

To send a request use a `WorldCommands.ReserveEntityIds.CommandSender` component. This contains a list of `WorldCommands.ReserveEntityIds.Request` structs. Add a struct to the list to send the command.

- `TimeoutMillis` is optional.

To receive a response use `WorldCommands.ReserveEntityIds.CommandResponses`. This contains a list of `WorldCommands.ReserveEntityIds.ReceivedResponse` structs.

### 2. Create an entity

You can use the `CreateEntity` world command to request the creation of a new SpatialOS entity which you specified using an [entity template](../entity-templates.md).

To send a request use a `WorldCommands.CreateEntity.CommandSender` component. This contains a list of `WorldCommands.CreateEntity.Request` structs. Add a struct to the list to send the command.

- `EntityId` and `TimeoutMillis` are optional.
- If you do specify an `EntityId`, you need to get this from a `ReserveEntityIds` command.

To receive a response use `WorldCommands.CreateEntity.CommandResponses`. This contains a list of `WorldCommands.CreateEntity.ReceivedResponse`.

Below is an example of creating a SpatialOS entity. For more information on how to create a `CreatureTemplate`, see the [creating entity templates](../creating-entities.md) page. 

```csharp
public class CreateCreatureSystem : ComponentSystem
{
    public struct Data
    {
        public readonly int Length;
        [ReadOnly] public ComponentDataArray<Foo> Foo;
        public ComponentDataArray<WorldCommands.CreateEntity.CommandSender> CreateEntitySender;
    }

    [Inject] Data data;

    protected override void OnUpdate()
    {
        for(var i = 0; i < data.Length; i++)
        {
            var requests = data.CreateEntitySender[i].RequestsToSend;
            var entity = CreatureTemplate.CreateCreatureEntityTemplate(
                new Coordinates(0, 0, 0));

            requests.Add(new WorldCommands.CreateEntity.CreateRequest
            (
                entity
            ));

            data.CreateEntitySender[i].requestsd;
        }
    }
}
```

This system iterates through every entity with a `Foo` component and sends a create entity request.

### 3.  Delete an entity

Deleting entities can be done similarly via the `DeleteEntity` world command. You need to know the SpatialOS entity ID of the entity you want to delete.

To send a request use a `WorldCommands.DeleteEntity.CommandSender` component. This contains a list of `WorldCommands.DeleteEntity.Request` structs. Add a struct to the list to send the command.

- `TimeoutMillis` is optional.

To receive a response use `WorldCommands.DeleteEntity.CommandResponses`. This contains a list of `WorldCommands.DeleteEntity.ReceivedResponse`.

```csharp
public class DeleteCreatureSystem : ComponentSystem
{
    public struct Data
    {
        public readonly int Length;
        [ReadOnly] public ComponentDataArray<Bar> Bar;
        public ComponentDataArray<WorldCommands.DeleteEntity.CommandSender> DeleteEntitySender;
        [ReadOnly] public ComponentDataArray<SpatialEntityId> SpatialEntityIds;
    }

    [Inject] Data data;

    protected override void OnUpdate()
    {
        for(var i = 0; i < data.Length; i++)
        {
            var requests = data.DeleteEntitySender[i].RequestsToSend;
            var entityId = data.SpatialEntityIds[i].EntityId;
        	
            requests.Add(new WorldCommands.DeleteEntity.CreateRequest
            (
                entityId
            ));

            data.DeleteEntitySender[i].RequestsToSend = requests;
        }
    }
}
```

This system iterates through every entity with a `Bar` component and sends a delete entity request.

### 4. Entity query

You can use entity queries to get information about entities in the world. 

To send a request use a `WorldCommands.EntityQuery.CommandSender` component. This contains a list of `WorldCommands.EntityQuery.Request` structs. Add a struct to the list to send the command

- For more information, see [entity queries](https://docs.improbable.io/reference/latest/shared/glossary#queries) in the SpatialOS documentation.
- `TimeoutMillis` is optional.

To receive a response use `WorldCommands.EntityQuery.CommandResponses`. This contains a list of `WorldCommands.EntityQuery.ReceivedResponse`.

**Warning**: Entity queries only exist in the GDK in a prototype form, the methods for sending and receiving them exist, but you can only access some information  safely in the responses. It is not recommended to use them.

------

**Give us feedback:** We want your feedback on the SpatialOS GDK for Unity and its documentation  - see [How to give us feedback](../../README.md#give-us-feedback).