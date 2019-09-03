
# SerializedMessagesToSend Class
<sup>
Namespace: Improbable.Gdk.<a href="{{urlRoot}}/api/core-index">Core</a><br/>
GDK package: Core<br/>
<a href="https://www.github.com/spatialos/gdk-for-unity/blob/c62f1703b591ee684fba123ba0dc6c231eca5126/workers/unity/Packages/io.improbable.gdk.core/Worker/SerializedMessagesToSend.cs/#L8">Source</a>
<style>
a code {
                    padding: 0em 0.25em!important;
}
code {
                    background-color: #ffffff!important;
}
</style>
</sup>
<nav id="pageToc" class="page-toc"><ul><li><a href="#constructors">Constructors</a>
<li><a href="#methods">Methods</a>
</ul></nav>












</p>
<hr style="width:100%; border-top-color:#d8d8d8" />
#### Constructors


</p>




<table width="100%">
    <tr>
        <td style="border-right:none"><a id="serializedmessagestosend"></a><b>SerializedMessagesToSend</b></td>
        <td style="border-left:none; text-align:right"><a href="https://www.github.com/spatialos/gdk-for-unity/blob/c62f1703b591ee684fba123ba0dc6c231eca5126/workers/unity/Packages/io.improbable.gdk.core/Worker/SerializedMessagesToSend.cs/#L48">Source</a></td>
    </tr>
    <tr>
        <td colspan="2">
<code> SerializedMessagesToSend()</code></p>






</td>
    </tr>
</table>




</p>
<hr style="width:100%; border-top-color:#d8d8d8" />
#### Methods


</p>




<table width="100%">
    <tr>
        <td style="border-right:none"><a id="serializefrom-messagestosend-commandmetadata"></a><b>SerializeFrom</b></td>
        <td style="border-left:none; text-align:right"><a href="https://www.github.com/spatialos/gdk-for-unity/blob/c62f1703b591ee684fba123ba0dc6c231eca5126/workers/unity/Packages/io.improbable.gdk.core/Worker/SerializedMessagesToSend.cs/#L86">Source</a></td>
    </tr>
    <tr>
        <td colspan="2">
<code>void SerializeFrom(<a href="{{urlRoot}}/api/core/messages-to-send">MessagesToSend</a> messages, <a href="{{urlRoot}}/api/core/command-meta-data">CommandMetaData</a> commandMetaData)</code></p>



</p>

<b>Parameters</b>

<ul>
<li><code><a href="{{urlRoot}}/api/core/messages-to-send">MessagesToSend</a> messages</code> : </li>
<li><code><a href="{{urlRoot}}/api/core/command-meta-data">CommandMetaData</a> commandMetaData</code> : </li>
</ul>





</td>
    </tr>
</table>


<table width="100%">
    <tr>
        <td style="border-right:none"><a id="clear"></a><b>Clear</b></td>
        <td style="border-left:none; text-align:right"><a href="https://www.github.com/spatialos/gdk-for-unity/blob/c62f1703b591ee684fba123ba0dc6c231eca5126/workers/unity/Packages/io.improbable.gdk.core/Worker/SerializedMessagesToSend.cs/#L110">Source</a></td>
    </tr>
    <tr>
        <td colspan="2">
<code>void Clear()</code></p>






</td>
    </tr>
</table>


<table width="100%">
    <tr>
        <td style="border-right:none"><a id="sendandclear-connection"></a><b>SendAndClear</b></td>
        <td style="border-left:none; text-align:right"><a href="https://www.github.com/spatialos/gdk-for-unity/blob/c62f1703b591ee684fba123ba0dc6c231eca5126/workers/unity/Packages/io.improbable.gdk.core/Worker/SerializedMessagesToSend.cs/#L125">Source</a></td>
    </tr>
    <tr>
        <td colspan="2">
<code><a href="{{urlRoot}}/api/core/command-meta-data">CommandMetaData</a> SendAndClear(Connection connection)</code></p>



</p>

<b>Parameters</b>

<ul>
<li><code>Connection connection</code> : </li>
</ul>





</td>
    </tr>
</table>


<table width="100%">
    <tr>
        <td style="border-right:none"><a id="addcomponentupdate-componentupdate-long"></a><b>AddComponentUpdate</b></td>
        <td style="border-left:none; text-align:right"><a href="https://www.github.com/spatialos/gdk-for-unity/blob/c62f1703b591ee684fba123ba0dc6c231eca5126/workers/unity/Packages/io.improbable.gdk.core/Worker/SerializedMessagesToSend.cs/#L203">Source</a></td>
    </tr>
    <tr>
        <td colspan="2">
<code>void AddComponentUpdate(ComponentUpdate update, long entityId)</code></p>



</p>

<b>Parameters</b>

<ul>
<li><code>ComponentUpdate update</code> : </li>
<li><code>long entityId</code> : </li>
</ul>





</td>
    </tr>
</table>


<table width="100%">
    <tr>
        <td style="border-right:none"><a id="addrequest-commandrequest-uint-long-uint-long"></a><b>AddRequest</b></td>
        <td style="border-left:none; text-align:right"><a href="https://www.github.com/spatialos/gdk-for-unity/blob/c62f1703b591ee684fba123ba0dc6c231eca5126/workers/unity/Packages/io.improbable.gdk.core/Worker/SerializedMessagesToSend.cs/#L208">Source</a></td>
    </tr>
    <tr>
        <td colspan="2">
<code>void AddRequest(CommandRequest request, uint commandId, long entityId, uint? timeout, long requestId)</code></p>



</p>

<b>Parameters</b>

<ul>
<li><code>CommandRequest request</code> : </li>
<li><code>uint commandId</code> : </li>
<li><code>long entityId</code> : </li>
<li><code>uint? timeout</code> : </li>
<li><code>long requestId</code> : </li>
</ul>





</td>
    </tr>
</table>


<table width="100%">
    <tr>
        <td style="border-right:none"><a id="addresponse-commandresponse-uint"></a><b>AddResponse</b></td>
        <td style="border-left:none; text-align:right"><a href="https://www.github.com/spatialos/gdk-for-unity/blob/c62f1703b591ee684fba123ba0dc6c231eca5126/workers/unity/Packages/io.improbable.gdk.core/Worker/SerializedMessagesToSend.cs/#L213">Source</a></td>
    </tr>
    <tr>
        <td colspan="2">
<code>void AddResponse(CommandResponse response, uint requestId)</code></p>



</p>

<b>Parameters</b>

<ul>
<li><code>CommandResponse response</code> : </li>
<li><code>uint requestId</code> : </li>
</ul>





</td>
    </tr>
</table>


<table width="100%">
    <tr>
        <td style="border-right:none"><a id="addfailure-string-uint"></a><b>AddFailure</b></td>
        <td style="border-left:none; text-align:right"><a href="https://www.github.com/spatialos/gdk-for-unity/blob/c62f1703b591ee684fba123ba0dc6c231eca5126/workers/unity/Packages/io.improbable.gdk.core/Worker/SerializedMessagesToSend.cs/#L218">Source</a></td>
    </tr>
    <tr>
        <td colspan="2">
<code>void AddFailure(string reason, uint requestId)</code></p>



</p>

<b>Parameters</b>

<ul>
<li><code>string reason</code> : </li>
<li><code>uint requestId</code> : </li>
</ul>





</td>
    </tr>
</table>


<table width="100%">
    <tr>
        <td style="border-right:none"><a id="addcreateentityrequest-entity-long-uint-long"></a><b>AddCreateEntityRequest</b></td>
        <td style="border-left:none; text-align:right"><a href="https://www.github.com/spatialos/gdk-for-unity/blob/c62f1703b591ee684fba123ba0dc6c231eca5126/workers/unity/Packages/io.improbable.gdk.core/Worker/SerializedMessagesToSend.cs/#L223">Source</a></td>
    </tr>
    <tr>
        <td colspan="2">
<code>void AddCreateEntityRequest(Entity entity, long? entityId, uint? timeout, long requestId)</code></p>



</p>

<b>Parameters</b>

<ul>
<li><code>Entity entity</code> : </li>
<li><code>long? entityId</code> : </li>
<li><code>uint? timeout</code> : </li>
<li><code>long requestId</code> : </li>
</ul>





</td>
    </tr>
</table>


<table width="100%">
    <tr>
        <td style="border-right:none"><a id="adddeleteentityrequest-long-uint-long"></a><b>AddDeleteEntityRequest</b></td>
        <td style="border-left:none; text-align:right"><a href="https://www.github.com/spatialos/gdk-for-unity/blob/c62f1703b591ee684fba123ba0dc6c231eca5126/workers/unity/Packages/io.improbable.gdk.core/Worker/SerializedMessagesToSend.cs/#L228">Source</a></td>
    </tr>
    <tr>
        <td colspan="2">
<code>void AddDeleteEntityRequest(long entityId, uint? timeout, long requestId)</code></p>



</p>

<b>Parameters</b>

<ul>
<li><code>long entityId</code> : </li>
<li><code>uint? timeout</code> : </li>
<li><code>long requestId</code> : </li>
</ul>





</td>
    </tr>
</table>


<table width="100%">
    <tr>
        <td style="border-right:none"><a id="addreserveentityidsrequest-uint-uint-long"></a><b>AddReserveEntityIdsRequest</b></td>
        <td style="border-left:none; text-align:right"><a href="https://www.github.com/spatialos/gdk-for-unity/blob/c62f1703b591ee684fba123ba0dc6c231eca5126/workers/unity/Packages/io.improbable.gdk.core/Worker/SerializedMessagesToSend.cs/#L233">Source</a></td>
    </tr>
    <tr>
        <td colspan="2">
<code>void AddReserveEntityIdsRequest(uint numberOfEntityIds, uint? timeout, long requestId)</code></p>



</p>

<b>Parameters</b>

<ul>
<li><code>uint numberOfEntityIds</code> : </li>
<li><code>uint? timeout</code> : </li>
<li><code>long requestId</code> : </li>
</ul>





</td>
    </tr>
</table>


<table width="100%">
    <tr>
        <td style="border-right:none"><a id="addentityqueryrequest-entityquery-uint-long"></a><b>AddEntityQueryRequest</b></td>
        <td style="border-left:none; text-align:right"><a href="https://www.github.com/spatialos/gdk-for-unity/blob/c62f1703b591ee684fba123ba0dc6c231eca5126/workers/unity/Packages/io.improbable.gdk.core/Worker/SerializedMessagesToSend.cs/#L238">Source</a></td>
    </tr>
    <tr>
        <td colspan="2">
<code>void AddEntityQueryRequest(EntityQuery query, uint? timeout, long requestId)</code></p>



</p>

<b>Parameters</b>

<ul>
<li><code>EntityQuery query</code> : </li>
<li><code>uint? timeout</code> : </li>
<li><code>long requestId</code> : </li>
</ul>





</td>
    </tr>
</table>





