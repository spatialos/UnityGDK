[//]: # (Doc of docs reference 21)
[//]: # (TODO - technical author pass)
<%(TOC)%>
# SpatialOS entities: update entity lifecycle
_This document relates to both [MonoBehaviour and ECS workflows]({{urlRoot}}/content/intro-workflows-spatialos-entities)._

The [SpatialOS runtime]({{urlRoot}}/content/glossary#spatialos-runtime) manages the lifecycle of [SpatialOS entities]({{urlRoot}}/content/glossary#spatialos-entity) in your [worker’s view]({{urlRoot}}/content/glossary#worker-s-view), or the part of the [game world]({{urlRoot}}/content/glossary#spatialos-world) that your worker has access to. The SpatialOS GDK for Unity interacts with the SpatialOS runtime through [Operations](https://docs.improbable.io/reference/latest/shared/design/operations#operations-how-workers-communicate-with-spatialos) and integrates the lifecycle natively into Unity.
This means that interacting with the entity lifecycle outside of the provided APIs can cause runtime errors or undefined behaviour.
> Warning: Manually deleting entities locally will cause runtime errors. Use the [`DeleteEntity` world command]({{urlRoot}}/content/ecs/world-commands) instead.

## What happens when an entity enters your view

When an entity moves into your worker's [view]({{urlRoot}}/content/glossary#worker-s-view), the SpatialOS runtime sends a set of operations to your worker describing the current state of that entity. For a single entity, your worker receives a set of messages describing the entity:

 - A message stating which entity has entered your view
 - A message stating the current state of each [SpatialOS component]({{urlRoot}}/content/glossary#spatialos-component) on that entity that your worker has interest in
 - (Optionally) A message stating that your worker has been delegated [authority]({{urlRoot}}/content/glossary#authority) over a SpatialOS component.

The SpatialOS GDK for Unity turns these messages into a single ECS Entity in a process described in the [Entity Contracts documentation]({{urlRoot}}/content/ecs/entity-contracts). You can also optionally associate a GameObject with this entity as described [in this doc]({{urlRoot}}/content/gameobject/linking-spatialos-entities).

## What happens when an entity leaves your view

When an entity moves out of your worker's [checkout region](https://docs.improbable.io/reference/latest/shared/concepts/workers-load-balancing), the SpatialOS runtime sends a set of operations to your worker to represent that change. For a single entity, your worker receives a set of messages:

- (Optionally) A message stating that your worker has been undelegated authority over a SpatialOS component.
- A message stating that a SpatialOS component has been removed from your view for each SpatialOS component your worker has interest in.
- A message stating which entity has been removed from your view.

The SpatialOS GDK for Unity uses these messages to remove the ECS Entity and clean up any data associated with it. If you choose to associate a GameObject with this entity, you will receive a callback to clean up the GameObject.
