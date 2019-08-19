<%(TOC)%>

# Connection flows

<%(Callout message="
Before reading this document, make sure you are familiar with:

  * [Workers in the GDK]({{urlRoot}}/reference/concepts/worker)
")%>

## Which connection flow to use

We provide two connection flows, which have different use cases depending on the kind of worker and the kind of [deployment]({{urlRoot}}/reference/glossary#deploying) you want to connect to.

In all cases, your worker contains a reference to a `Connection` object after successfully connecting to the SpatialOS Runtime.

### Receptionist connection flow

Use the Receptionist connection flow in the following cases:

* Connecting a server-worker or a client-worker instance to a local deployment.
* Connecting a server-worker instance to a cloud deployment.
* (For debugging) Connecting a server-worker or a client-worker instance to a cloud deployment from your local machine.

<%(#Expandable title="How do I connect to a cloud deployment from my local machine?")%>
There are three steps for connecting a worker to a cloud deployment:

1. In your terminal, execute `spatial cloud connect external <deployment_name>`, where `<deployment_name>` is the deployment you want to connect to.
2. Ensure that `UseExternalIp` is set to true in the connection parameters for the worker you want to connect.
3. Run your worker, either in the Unity Editor or built out as if you were connecting to a local deployment.

Note that this debugging flow **does not work** for mobile clients. You need to use the new v13.5+ Locator connection flow instead.

For more information about the `spatial cloud connect external` command, see the [CLI documentation](https://docs.improbable.io/reference/<%(Var key="worker_sdk_version")%>/shared/spatial-cli/spatial-cloud-connect-external).

<%(/Expandable)%>

### Locator connection flow

Use the Locator connection flow for:

* Connecting a client-worker to a cloud deployment via the [SpatialOS Launcher](https://docs.improbable.io/reference/<%(Var key="worker_sdk_version")%>/shared/operate/launcher#the-launcher).
* [Connecting a mobile worker-instance to a cloud deployment]({{urlRoot}}/modules/mobile/cloud-deploy).
* (For debugging) Connecting a server-worker or client-worker instance to a cloud deployment from your local machine.
