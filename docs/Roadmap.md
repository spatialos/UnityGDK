# SpatialOS Unity GDK roadmap
**Date:** 2018-06-19

We'd love to hear what you think about the roadmap; [give us feedback](../README.MD#give-us-feedback) on what you'd like to see in it.

| | Faster development iteration | Native workflows| High performance|
|------|---|----|--|
|First look: pre-alpha (from 2018-06-19)|**Build less often**<br/>Run client and server running simultaneously in your Unity Editor.<br/><br/>**Transform Feature Module**<br/>Buffer and interpolate position and rotation updates.|**Automatic synchronisation**<br/>Generated code synchronises changes to components for you with a full override control option.|**Harness the power of ECS**<br/>Tale full advantage of the Unity Entity Component System (ECS).
|Coming soon|**Example game**<br/>An example game to test the GDK and provide a scalable starting point to speed up development.           |**MonoBehaviour workflow**<br/>ECS isn't the right workflow for everything - we will provide APIs to inject entity states into MonoBehaviours.|
|R&D|**New Feature Modules**<br/>We are considering pathfinding, NPC AI, shooting and character controllers. Let us know what you'd like to see.| **Schema auto-generation**<br/>We are experimenting with automatically generating schema, based upon the structs and classes you define in C#.<br/><br/>**Synchronous spawning**<br/>Asynchronous spawning on SpatialOS has been a magnet for bugs. We're looking to provide a synchronous API and to handle replication behind the scenes.|**Multithreading**<br/>We want to investigate multithreading via the Unity Jobs System. We also want to make using Jobs in game logic as easy as possible. |
