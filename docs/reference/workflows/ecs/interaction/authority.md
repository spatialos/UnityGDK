<%(TOC)%>

# ECS: Authority

<%(Callout message="
Before reading this document, make sure you are familiar with:

* [Authority in SpatialOS](https://docs.improbable.io/reference/<%(Var key="worker_sdk_version")%>/shared/concepts/interest-authority#authority-also-known-as-write-access)
* [Authority and interest](https://docs.improbable.io/reference/<%(Var key="worker_sdk_version")%>/shared/authority-and-interest/introduction)
")%>

Authority is how SpatialOS represents which worker instances can write to a specific [SpatialOS component]({{urlRoot}}/reference/glossary#spatialos-component).

## How authority is represented

For every [SpatialOS component]({{urlRoot}}/reference/glossary#spatialos-component) on a checked out SpatialOS entity, the GDK attaches a component to the ECS entity of the type `{component name}.ComponentAuthority`. This component contains a single field, `HasAuthority`, a `bool` that indicates whether the worker instance has authority over the SpatialOS component.

> Note that this component does not contain information about `AuthorityLossImminent` notifications. To get these notifications, iterate through the list of authority changes received from `GetAuthorityChangesReceived`.

## How to interact with authority

The `ComponentAuthority` component described above is a shared component (implements `ISharedComponentData`) which allows you to filter your ECS entity queries by authority.

Below is an example of how to write a system that runs when a worker instance has authority over the `Position` SpatialOS component. You can iterate through the matching components using the ECS `.ForEach` syntax.

```csharp
public class AuthoritativePositionSystem : ComponentSystem
{
    private EntityQuery query;

    protected override void OnCreate()
    {
        base.OnCreate();

        query = GetEntityQuery(
            ComponentType.ReadWrite<Position.Component>(),
            ComponentType.ReadOnly<Position.ComponentAuthority>()
        );

        // Position.ComponentAuthority.Authoritative is a static copy of the
        // Position.ComponentAuthority component with HasAuthority set to true
        query.SetFilter(Position.ComponentAuthority.Authoritative);
    }

    protected override void OnUpdate()
    {
        Entities.With(query).ForEach((ref Position.Component position) =>
        {
            // This will only run for entities for which the worker instance
            // is authoritative over the Position component.
        });
    }
}
```

## How to interact with authority changes

The `GetAuthorityChangesReceived` method on the [`ComponentUpdateSystem`]({{urlRoot}}/api/core/component-update-system) allows you to retrieve a list of all the authority changes for an entity-component pair that have occured since the previous frame.

Below is an example of iterating through all `PlayerInput` components that the worker instance has just gained authority over. You can iterate through the matching components using the ECS `.ForEach` syntax.

```csharp
public class OnPlayerSpawnSystem : ComponentSystem
{
    private ComponentUpdateSystem updateSystem;

    private EntityQuery query;

    protected override void OnCreate()
    {
        base.OnCreate();

        updateSystem = World.GetExistingSystem<ComponentUpdateSystem>();

        query = GetEntityQuery(
            ComponentType.ReadOnly<SpatialEntityId>(),
            ComponentType.ReadWrite<PlayerInput.Component>(),
            ComponentType.ReadOnly<PlayerInput.ComponentAuthority>()
        );
        query.SetFilter(PlayerInput.ComponentAuthority.Authoritative);
    }

    protected override void OnUpdate()
    {
        // We iterate over all entities with the PlayerInput Component that we are authoritative over.
        Entities.With(query).ForEach(
            (ref SpatialEntityId spatialEntityId, ref PlayerInput.Component playerInput) =>
            {
                var authorityChanges = updateSystem.GetAuthorityChangesReceived(
                    spatialEntityId.EntityId,
                    PlayerInput.ComponentId);

                // Skip if there were no authority changes.
                if (authorityChanges.Count <= 0)
                {
                    return;
                }

                for (var i = 0; i < authorityChanges.Count; i++)
                {
                    // In here we iterate through entities with a PlayerInput component
                    // which we have authority over, and where there have been changes
                    // of authority. Therefore, write code here that you want to run
                    // when the worker instance receives authority over PlayerInput.
                }
            });
    }
}
```

### Authority loss imminent

Authority loss imminent notifications can be found in the list of authority changes retrieved by `GetAuthorityChangesReceived`. Each authority change in the list indicates whether your authority state changed to either `NotAuthoritative`, `Authoritative` or `AuthorityLossImminent`.
