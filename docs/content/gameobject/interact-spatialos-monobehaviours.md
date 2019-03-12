[//]: # (Doc of docs reference 5.2)
[//]: # (TODO - tech writer review)
<%(TOC)%>
# How to interact with SpatialOS using MonoBehaviours
_This document relates to the [MonoBehaviour workflow]({{urlRoot}}/content/intro-workflows-spatialos-entities)._

Before reading this document, make sure you are familiar with

  * [Workers]({{urlRoot}}/content/workers/workers-in-the-gdk)
  * [Readers and Writers]({{urlRoot}}/content/gameobject/readers-writers)

You can [represent your SpatialOS entities as GameObjects]({{urlRoot}}/content/gameobject/linking-spatialos-entities).
By representing your SpatialOS entity by a GameObject, you are able to interact with the SpatialOS Runtime using the GameObject instead of the ECS entity.
This is enabled by [code-generating]({{urlRoot}}/content/code-generator) the following types:

 * [Readers and Writers]({{urlRoot}}/content/gameobject/readers-writers) - For accessing the component data of the SpatialOS entity.
 * [Sending and Receiving component commands]({{urlRoot}}/content/gameobject/sending-receiving-commands) - For sending and receiving commands.

To use these types, you define fields in a MonoBehaviour that is attached to
your linked GameObject and decorate these fields with the `[Require]` attribute.

```csharp
[Require] private Health.Requirable.Reader healthReader;
```

> These fields can only be used on the GameObject that is directly linked to a [SpatialOS entity]({{urlRoot}}/content/glossary#spatialos-entity).
Parent or child GameObjects will be ignored.

The requirements depend on which types are marked as required in the Monobehaviour. Please read their API documentation to learn more:

  * [Readers and Writers API]({{urlRoot}}/content/gameobject/readers-writers)
  * [Command sender and handler API]({{urlRoot}}/content/gameobject/sending-receiving-commands)

The SpatialOS GDK for Unity automatically injects the correct values into the these fields
as soon as the worker that this GameObject belongs to fulfills all the requirements.


> The `[Require]` attribute can only be used in combination with the above mentioned types.

## MonoBehaviour lifecycle
The GDK manages the lifecycle of all MonoBehaviours that contain at least
one field with a `[Require]` attribute. It ensures that these MonoBehaviours are disabled for

  * all Prefabs stored inside the `Resources` folder of your Unity project
  * all MonoBehaviours on instantiated GameObjects that have at least one requirement not fulfilled during runtime
Whenever a MonoBehaviour is disabled, all fields decorated with the `[Require]` attribute are `null` and you can not use them anymore as soon as `OnDisable` is called on that MonoBehaviour.

>  `OnTriggerEnter()` and `OnCollisionEnter()` might be called even if the MonoBehaviour is disabled. You need to check whether your required types are available, if you want to use them in these methods. You can verify a field’s availability by checking if that field is equal to null or not. If it is not null, it is safe to use.

The GDK only enables them, if all requirements for injecting these types are fulfilled during runtime. All fields decorated with the `[Require]` attribute are available for use as soon as `OnEnable` is called.  

> Do not manually enable / disable these MonoBehaviours as it will lead to undefined behaviour.

If an object was injected, the GDK disposes of it upon disabling the MonoBehaviour. Any reference stored of it, will be invalid at that point.
Here is an example on how to inject a reader and how to use it in different scenarios:

```csharp
public class ReadHealthBehaviour : MonoBehaviour
{
	[Require] private Health.Requirable.Reader healthReader;

	void OnEnable()
	{
    	// The MonoBehaviour is automatically enabled and disabled based on
    	// whether requirements for your injected types are met.
    	// OnEnable() is only called when healthReader is available.
    	Debug.Log($"Current health: {healthReader.Data.Value}");
	}

	void OnDisable()
	{
    	// It will be automatically called when at least one requirements
    	// for your declared Requirables is not met anymore.
    	// Your injected types will be automatically disposed.
	}

	void OnTriggerEnter()
	{
    	if (healthReader != null)
    	{
        	// OnTriggerEnter() can be called even if the MonoBehaviour
        	// is disabled. You need to check whether the reader is available.
    	}
	}

	void OnCollisionEnter()
	{
    	if (healthReader != null)
    	{
        	// OnCollisionEnter() can be called even if the MonoBehaviour
        	// is disabled. You need to check whether the reader is available.
    	}
	}
}
```
