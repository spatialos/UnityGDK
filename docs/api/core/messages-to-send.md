
# MessagesToSend Class
<sup>
Namespace: Improbable.Gdk.<a href="{{urlRoot}}/api/core-index">Core</a><br/>
GDK package: Core<br/>
<a href="https://www.github.com/spatialos/gdk-for-unity/blob/f54d7cdc/workers/unity/Packages/com.improbable.gdk.core/Worker/MessagesToSend.cs/#L8">Source</a>
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
        <td style="border-right:none"><b>MessagesToSend</b></td>
        <td style="border-left:none; text-align:right"><a href="https://www.github.com/spatialos/gdk-for-unity/blob/f54d7cdc/workers/unity/Packages/com.improbable.gdk.core/Worker/MessagesToSend.cs/#L38">Source</a></td>
    </tr>
    <tr>
        <td colspan="2">
<code> MessagesToSend()</code></p>






</td>
    </tr>
</table>




</p>
<hr style="width:100%; border-top-color:#d8d8d8" />
#### Methods


</p>




<table width="100%">
    <tr>
        <td style="border-right:none"><b>Clear</b></td>
        <td style="border-left:none; text-align:right"><a href="https://www.github.com/spatialos/gdk-for-unity/blob/f54d7cdc/workers/unity/Packages/com.improbable.gdk.core/Worker/MessagesToSend.cs/#L88">Source</a></td>
    </tr>
    <tr>
        <td colspan="2">
<code>void Clear()</code></p>






</td>
    </tr>
</table>


<table width="100%">
    <tr>
        <td style="border-right:none"><b>AcknowledgeAuthorityLoss</b></td>
        <td style="border-left:none; text-align:right"><a href="https://www.github.com/spatialos/gdk-for-unity/blob/f54d7cdc/workers/unity/Packages/com.improbable.gdk.core/Worker/MessagesToSend.cs/#L105">Source</a></td>
    </tr>
    <tr>
        <td colspan="2">
<code>void AcknowledgeAuthorityLoss(long entityId, uint componentId)</code></p>



</p>

<b>Parameters</b>

<ul>
<li><code>long entityId</code> : </li>
<li><code>uint componentId</code> : </li>
</ul>





</td>
    </tr>
</table>


<table width="100%">
    <tr>
        <td style="border-right:none"><b>AddComponentUpdate&lt;T&gt;</b></td>
        <td style="border-left:none; text-align:right"><a href="https://www.github.com/spatialos/gdk-for-unity/blob/f54d7cdc/workers/unity/Packages/com.improbable.gdk.core/Worker/MessagesToSend.cs/#L110">Source</a></td>
    </tr>
    <tr>
        <td colspan="2">
<code>void AddComponentUpdate&lt;T&gt;(in T update, long entityId)</code></p>



</p>

<b>Parameters</b>

<ul>
<li><code>in T update</code> : </li>
<li><code>long entityId</code> : </li>
</ul>





</td>
    </tr>
</table>


<table width="100%">
    <tr>
        <td style="border-right:none"><b>AddEvent&lt;T&gt;</b></td>
        <td style="border-left:none; text-align:right"><a href="https://www.github.com/spatialos/gdk-for-unity/blob/f54d7cdc/workers/unity/Packages/com.improbable.gdk.core/Worker/MessagesToSend.cs/#L120">Source</a></td>
    </tr>
    <tr>
        <td colspan="2">
<code>void AddEvent&lt;T&gt;(T ev, long entityId)</code></p>



</p>

<b>Parameters</b>

<ul>
<li><code>T ev</code> : </li>
<li><code>long entityId</code> : </li>
</ul>





</td>
    </tr>
</table>


<table width="100%">
    <tr>
        <td style="border-right:none"><b>AddCommandRequest&lt;T&gt;</b></td>
        <td style="border-left:none; text-align:right"><a href="https://www.github.com/spatialos/gdk-for-unity/blob/f54d7cdc/workers/unity/Packages/com.improbable.gdk.core/Worker/MessagesToSend.cs/#L129">Source</a></td>
    </tr>
    <tr>
        <td colspan="2">
<code>void AddCommandRequest&lt;T&gt;(T request, Unity.Entities.Entity sendingEntity, long requestId)</code></p>



</p>

<b>Parameters</b>

<ul>
<li><code>T request</code> : </li>
<li><code>Unity.Entities.Entity sendingEntity</code> : </li>
<li><code>long requestId</code> : </li>
</ul>





</td>
    </tr>
</table>


<table width="100%">
    <tr>
        <td style="border-right:none"><b>AddCommandResponse&lt;T&gt;</b></td>
        <td style="border-left:none; text-align:right"><a href="https://www.github.com/spatialos/gdk-for-unity/blob/f54d7cdc/workers/unity/Packages/com.improbable.gdk.core/Worker/MessagesToSend.cs/#L135">Source</a></td>
    </tr>
    <tr>
        <td colspan="2">
<code>void AddCommandResponse&lt;T&gt;(T response)</code></p>



</p>

<b>Parameters</b>

<ul>
<li><code>T response</code> : </li>
</ul>





</td>
    </tr>
</table>


<table width="100%">
    <tr>
        <td style="border-right:none"><b>AddLogMessage</b></td>
        <td style="border-left:none; text-align:right"><a href="https://www.github.com/spatialos/gdk-for-unity/blob/f54d7cdc/workers/unity/Packages/com.improbable.gdk.core/Worker/MessagesToSend.cs/#L142">Source</a></td>
    </tr>
    <tr>
        <td colspan="2">
<code>void AddLogMessage(in <a href="{{urlRoot}}/api/core/log-message-to-send">LogMessageToSend</a> log)</code></p>



</p>

<b>Parameters</b>

<ul>
<li><code>in <a href="{{urlRoot}}/api/core/log-message-to-send">LogMessageToSend</a> log</code> : </li>
</ul>





</td>
    </tr>
</table>


<table width="100%">
    <tr>
        <td style="border-right:none"><b>AddMetrics</b></td>
        <td style="border-left:none; text-align:right"><a href="https://www.github.com/spatialos/gdk-for-unity/blob/f54d7cdc/workers/unity/Packages/com.improbable.gdk.core/Worker/MessagesToSend.cs/#L147">Source</a></td>
    </tr>
    <tr>
        <td colspan="2">
<code>void AddMetrics(Metrics metrics)</code></p>



</p>

<b>Parameters</b>

<ul>
<li><code>Metrics metrics</code> : </li>
</ul>





</td>
    </tr>
</table>





