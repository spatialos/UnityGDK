# Receiving entity updates from SpatialOS: reactive components
 _This document relates to the [ECS workflow]({{urlRoot}}/content/intro-workflows-spatialos-entities)._

To represent state changes or messages from SpatialOS, the SpatialOS GDK for Unity (GDK) uses something we're calling "reactive components": ECS components that it adds to the relevant ECS entity for the duration of a tick.

When the GDK receives an update or message from SpatialOS, it places a "reactive component" on the associated ECS entity until the end of the tick. This reactive component contains a list of all the updates or messages received, so they can be processed by any system that you want to react to the change or message.

At the end of the tick, the GDK removes the reactive component.

## Reactive component types

These are the types of reactive component available:

1. `ReceivedUpdates`:  All local and received [SpatialOS component updates](https://docs.improbable.io/reference/latest/shared/design/operations#component-related-operations) for the current SpatialOS entity.
1. `AuthorityChanges`: Updates to the [authority](https://docs.improbable.io/reference/13.2/shared/design/understanding-access#understanding-read-and-write-access-authority) the current worker instance has over a SpatialOS component. See [Authority]({{urlRoot}}/content/ecs/authority) for information on how this works.
1. `ReceivedEvents`: All received [events](https://docs.improbable.io/reference/latest/shared/design/object-interaction#events) for the current entity. See [Events]({{urlRoot}}/content/ecs/events) for information on how this works.
1. `CommandRequests`: All received [command](https://docs.improbable.io/reference/latest/shared/design/commands) requests. See [Commands]({{urlRoot}}/content/ecs/commands) for information on how this works.
1. `CommandResponses`: All received [command](https://docs.improbable.io/reference/latest/shared/design/commands) responses. See [Commands]({{urlRoot}}/content/ecs/commands) for information on how this works.

## Component Lifecycle tags

There are tags for handling the addition and removal of components:

1. `ComponentAdded`: SpatialOS component has been added to the local view of a SpatialOS entity due to checkout of an entity or a change in interest.
1. `ComponentRemoved`: SpatialOS component has been removed from the local view of a SpatialOS entity due to a change in interest.

## Example of a system using a reactive component

```csharp
public class ReactiveSystem : ComponentSystem
{
    public struct Data
    {
        public readonly int Length;
        public ComponentDataArray<Position.ReceivedUpdates> PositionUpdates;
    }

    [Inject] Data data;

    protected override void OnUpdate()
    {
        for(var i = 0; i < data.Length; i++)
        {
            var updates = data.PositionUpdates[i].Updates;
            foreach (var update in updates)
            {
                if (update.Coords.HasValue)
                {
                    // Do something
                }
            }            
        }
    }
}
```

## Removal of reactive components

The GDK automatically removes reactive components from the ECS entity as soon as `CleanReactiveComponentsSystem` is run. This means that you must run any logic processing that reactive component _before_ `CleanReactiveComponentsSystem`. (This system is run at the end of each frame.)
