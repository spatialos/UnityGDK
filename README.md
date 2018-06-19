# The SpatialOS Unity GDK readme (pre-alpha)

The Unity Game Development Kit (GDK), made by [Improbable](https://improbable.io/), uses [Unity's](http://unity3d.com) experimental [Entity Component System (ECS)](https://unity3d.com/unity/features/job-system-ECS). 

In the future you will be able to use the Unity GDK to make massively multiplayer games with [Unity](http://unity3d.com) and [SpatialOS](https://docs.improbable.io/reference/latest/shared/concepts/spatialos). This is a pre-alpha release of the GDK Core which is the foundation of the product. To find out more see the [Unity GDK deep dive blogpost](https://improbable.io/games/blog/unity-gdk-deepdive-1).

* License: use of the contents of this repository is subject to the [Improbable license](LICENSE.md)
* Version: pre-alpha (for evaluation only)
* Unity Game Development Kit repository: [github.com/spatialos/UnityGDK](https://github.com/spatialos/UnityGDK)

## Recommended use

This pre-alpha version software and its documentation is, by its very nature, rough and ready; every part of it is subject to change, including the APIs, and it isn’t optimised for performance. In addition, the GDK is based on Unity’s experimental [Entity Component System and Job System](https://unity3d.com/unity/features/job-system-ECS). Currently it's Windows only but later releases will also support MacOS.

This release is for evaluation and feedback only, with limited documentation; we aren’t supporting any game development on the pre-alpha version of the Unity GDK. 

**Who is it for?**

This pre-alpha release is for experienced Unity developers who have some understanding of [SpatialOS concepts](https://docs.improbable.io/reference/13.0/shared/concepts/spatialos), are interested in Unity's [Entity Component System](https://github.com/Unity-Technologies/EntityComponentSystemSamples/blob/master/Documentation/index.md), and want to give early feedback.

## Give us feedback

We have released the Unity GDK this early in development because we want your feedback. Please come and talk to us about the software and the documentation via:

**Discord**<br/>
Find us in the [**#unity** channel](https://discord.gg/SCZTCYm). You may need to grab Discord [here](https://discordapp.com). 

**The SpatialOS forums**<br/>
Visit the **feedback** section in our [forums](https://forums.improbable.io) and use the **unity-gdk** tag. [This link](https://forums.improbable.io/new-topic?category=Feedback&tags=unity-gdk) takes you there and pre-fills the category and tag.

**Github issues**<br/>
Create an issue [in this repository](https://github.com/spatialos/UnityGDK/issues).

## Roadmap

Here is our current roadmap, we would love your feedback on it.

|                |Faster Development Iteration |Native Workflows| High Performance
|----------------|-------------------------------|-----------------------------|--|
|First Look|  **Build Less Often**<br>Run Client and Server in your Unity editor simultaneously.<br><br> **Transform Feature Module**<br>Buffer and interpolate position and rotation updates.        |**Automatic synchronisation**<br>Changes to components are synchronised for you by generated code - but you have full control if you want to override this.            | **Harness the power of ECS**<br>Make use of the advantages of the Unity Entity Component System (ECS). 
|Coming Soon   |**Examples game**<br>An example game will both test the GDK and provide a scaled example to speed up development.           |**MonoBehaviour workflow**<br>ECS isn't the right workflow for everything. We will also provide APIs to inject state into MonoBehaviours.            |
|R&D    |**New Feature Modules**<br>We are considering pathfinding, NPC AI, shooting and character controllers. Let us know what you'd like to see! | **Schema auto-generation**<br>We are experimenting with automatically generating schema, based upon the structs and classes you define in C#.<br><br>**Synchronous spawning**<br>Asynchronous spawning on SpatialOS has been a magnet for bugs. We're looking to provide a synchornous API and to handle replication behind the scenes. | **Multithreading**<br>We want to investigate multithreading via the Unity Jobs System. We also want to make using Jobs in game logic as easy as possible. |

## Contributions 

**Public contributors**<br/>
We are currently not accepting public contributions (but we do plan to in later releases and we’ll keep you posted). However, we are taking issues and we do want your feedback.

**Improbable developers**<br/>
See the [Contributions guide](https://improbableio.atlassian.net/wiki/x/foDrDw).

## Documentation 
See the [documentation](docs/README.md#documentation) in this GitHub repository.

## Support
We are not supporting the pre-alpha release for game development, as this version is for evaluation only. However, please give us your feedback. 

## Installation and setup 
For prerequisites, installation and setup, see the [Installation and setup](docs/setup-and-installing.md) documentation. 

## Migration from the SpatialOS Unity SDK
Currently the Unity GDK is in its early development, so there is no migration path from the [Unity SDK](https://github.com/spatialos/UnitySDK) to the Unity GDK. There will be a migration path in later releases.

## Email updates
You can [sign up for SpatialOS Unity GDK updates](http://go.pardot.com/l/169082/2018-05-10/26yzpy) direct to your mailbox.

&copy; 2018 Improbable
