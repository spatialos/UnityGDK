
# PlayerLifecycleHelper Class
<sup>
Namespace: Improbable.Gdk.<a href="{{urlRoot}}/api/player-lifecycle-index">PlayerLifecycle</a><br/>
GDK package: PlayerLifecycle<br/>
<a href="https://www.github.com/spatialos/gdk-for-unity/blob/0.2.2/workers/unity/Packages/com.improbable.gdk.playerlifecycle/PlayerLifecycleHelper.cs/#L10">Source</a>
<style>
a code {
                    padding: 0em 0.25em!important;
}
code {
                    background-color: #ffffff!important;
}
</style>
</sup>
<nav id="pageToc" class="page-toc"><ul><li><a href="#static-methods">Static Methods</a>
</ul></nav>











</p>
<hr style="width:100%; border-top-color:#d8d8d8" />
#### Static Methods


</p>




<table width="100%">
    <tr>
        <td style="border-right:none"><b>AddPlayerLifecycleComponents</b></td>
        <td style="border-left:none; text-align:right"><a href="https://www.github.com/spatialos/gdk-for-unity/blob/0.2.2/workers/unity/Packages/com.improbable.gdk.playerlifecycle/PlayerLifecycleHelper.cs/#L18">Source</a></td>
    </tr>
    <tr>
        <td colspan="2">
<code>void AddPlayerLifecycleComponents(<a href="{{urlRoot}}/api/core/entity-template">EntityTemplate</a> template, string clientWorkerId, string serverAccess)</code></p>
Adds the SpatialOS components used by the player lifecycle module to an entity template. 


</p>

<b>Parameters</b>

<ul>
<li><code><a href="{{urlRoot}}/api/core/entity-template">EntityTemplate</a> template</code> : The entity template to add player lifecycle components to.</li>
<li><code>string clientWorkerId</code> : The ID of the client-worker.</li>
<li><code>string serverAccess</code> : The server-worker write access attribute.</li>
</ul>





</td>
    </tr>
</table>


<table width="100%">
    <tr>
        <td style="border-right:none"><b>IsOwningWorker</b></td>
        <td style="border-left:none; text-align:right"><a href="https://www.github.com/spatialos/gdk-for-unity/blob/0.2.2/workers/unity/Packages/com.improbable.gdk.playerlifecycle/PlayerLifecycleHelper.cs/#L41">Source</a></td>
    </tr>
    <tr>
        <td colspan="2">
<code>bool IsOwningWorker(<a href="{{urlRoot}}/api/core/spatial-entity-id">SpatialEntityId</a> entityId, World workerWorld)</code></p>
Returns whether an entity is owned by a worker. It can be used to determine whether a client-worker is responsible for a particular player entity. 
</p><b>Returns:</b></br>True if the entity with ID entityId contains an OwningWorker component with a value matching the workerWorld's workerId. False if the entity does not contain an OwningWorker component, or if the value does not match the workerId. Throws an InvalidOperationException if workerWorld does not contain a WorkerSystem, or if the entity does not exist in the worker's view. 

</p>

<b>Parameters</b>

<ul>
<li><code><a href="{{urlRoot}}/api/core/spatial-entity-id">SpatialEntityId</a> entityId</code> : An ECS component containing a SpatialOS Entity ID.</li>
<li><code>World workerWorld</code> : An ECS World associated with a worker.</li>
</ul>





</td>
    </tr>
</table>


<table width="100%">
    <tr>
        <td style="border-right:none"><b>AddClientSystems</b></td>
        <td style="border-left:none; text-align:right"><a href="https://www.github.com/spatialos/gdk-for-unity/blob/0.2.2/workers/unity/Packages/com.improbable.gdk.playerlifecycle/PlayerLifecycleHelper.cs/#L72">Source</a></td>
    </tr>
    <tr>
        <td colspan="2">
<code>void AddClientSystems(World world, bool autoRequestPlayerCreation = true)</code></p>
Adds all the systems a client-worker requires for the player lifecycle module. 


</p>

<b>Parameters</b>

<ul>
<li><code>World world</code> : A world that belongs to a client-worker.</li>
<li><code>bool autoRequestPlayerCreation</code> : An option to toggle automatic player creation.</li>
</ul>





</td>
    </tr>
</table>


<table width="100%">
    <tr>
        <td style="border-right:none"><b>AddServerSystems</b></td>
        <td style="border-left:none; text-align:right"><a href="https://www.github.com/spatialos/gdk-for-unity/blob/0.2.2/workers/unity/Packages/com.improbable.gdk.playerlifecycle/PlayerLifecycleHelper.cs/#L83">Source</a></td>
    </tr>
    <tr>
        <td colspan="2">
<code>void AddServerSystems(World world)</code></p>
Adds all the systems a server-worker requires for the player lifecycle module. 


</p>

<b>Parameters</b>

<ul>
<li><code>World world</code> : A world that belongs to a server-worker.</li>
</ul>





</td>
    </tr>
</table>







