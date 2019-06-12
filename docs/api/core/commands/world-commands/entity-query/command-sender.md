
# CommandSender Struct
<sup>
Namespace: Improbable.Gdk.<a href="{{urlRoot}}/api/core-index">Core</a>.<a href="{{urlRoot}}/api/core/commands-index">Commands</a>.<a href="{{urlRoot}}/api/core/commands/world-commands">WorldCommands</a>.<a href="{{urlRoot}}/api/core/commands/world-commands/entity-query">EntityQuery</a><br/>
GDK package: Core<br/>
<a href="https://www.github.com/spatialos/gdk-for-unity/blob/0.2.3/workers/unity/Packages/com.improbable.gdk.core/Commands/WorldCommands/EntityQuery.cs/#L121">Source</a>
<style>
a code {
                    padding: 0em 0.25em!important;
}
code {
                    background-color: #ffffff!important;
}
</style>
</sup>
<nav id="pageToc" class="page-toc"><ul><li><a href="#properties">Properties</a>
</ul></nav>

</p>



<p>ECS component is for sending EntityQuery command requests to the SpatialOS runtime. </p>



</p>

<b>Inheritance</b>

<code>IComponentData</code>








</p>
<hr style="width:100%; border-top-color:#d8d8d8" />
#### Properties


</p>




<table width="100%">
    <tr>
        <td style="border-right:none"><b>RequestsToSend</b></td>
        <td style="border-left:none; text-align:right"><a href="https://www.github.com/spatialos/gdk-for-unity/blob/0.2.3/workers/unity/Packages/com.improbable.gdk.core/Commands/WorldCommands/EntityQuery.cs/#L129">Source</a></td>
    </tr>
    <tr>
        <td colspan="2">
<code> List&lt;<a href="{{urlRoot}}/api/core/commands/world-commands/entity-query/request">Request</a>&gt; RequestsToSend { get; set; }</code></p>
The list of pending EntityQuery command requests. To send a command request, add an element to this list. 


</td>
    </tr>
</table>








