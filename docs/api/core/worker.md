
# Worker Class
<sup>
Namespace: Improbable.Gdk.<a href="{{urlRoot}}/api/core-index">Core</a><br/>
GDK package: Core<br/>
<a href="https://www.github.com/spatialos/gdk-for-unity/blob/0.3.3/workers/unity/Packages/io.improbable.gdk.core/Worker/Worker.cs/#L13">Source</a>
<style>
a code {
                    padding: 0em 0.25em!important;
}
code {
                    background-color: #ffffff!important;
}
</style>
</sup>
<nav id="pageToc" class="page-toc"><ul><li><a href="#fields">Fields</a>
<li><a href="#static-methods">Static Methods</a>
<li><a href="#constructors">Constructors</a>
<li><a href="#methods">Methods</a>
</ul></nav>

</p>



<p>Represents a SpatialOS worker. </p>



</p>

<b>Inheritance</b>

<code>IDisposable</code>






</p>
<hr style="width:100%; border-top-color:#d8d8d8" />
#### Fields


</p>




<table width="100%">
    <tr>
        <td style="border-right:none"><a id="workertype"></a><b>WorkerType</b></td>
        <td style="border-left:none; text-align:right"><a href="https://www.github.com/spatialos/gdk-for-unity/blob/0.3.3/workers/unity/Packages/io.improbable.gdk.core/Worker/Worker.cs/#L18">Source</a></td>
    </tr>
    <tr>
        <td colspan="2">
<code> readonly string WorkerType</code></p>
The type of the worker. 

</td>
    </tr>
</table>


<table width="100%">
    <tr>
        <td style="border-right:none"><a id="workerid"></a><b>WorkerId</b></td>
        <td style="border-left:none; text-align:right"><a href="https://www.github.com/spatialos/gdk-for-unity/blob/0.3.3/workers/unity/Packages/io.improbable.gdk.core/Worker/Worker.cs/#L26">Source</a></td>
    </tr>
    <tr>
        <td colspan="2">
<code> readonly string WorkerId</code></p>
The worker ID. 

</p>

<b>Notes:</b>

<ul>
<li>Unique for a given SpatialOS deployment. </li>
</ul>


</td>
    </tr>
</table>


<table width="100%">
    <tr>
        <td style="border-right:none"><a id="attributes"></a><b>Attributes</b></td>
        <td style="border-left:none; text-align:right"><a href="https://www.github.com/spatialos/gdk-for-unity/blob/0.3.3/workers/unity/Packages/io.improbable.gdk.core/Worker/Worker.cs/#L31">Source</a></td>
    </tr>
    <tr>
        <td colspan="2">
<code> readonly List&lt;string&gt; Attributes</code></p>
The worker attribute list 

</td>
    </tr>
</table>


<table width="100%">
    <tr>
        <td style="border-right:none"><a id="logdispatcher"></a><b>LogDispatcher</b></td>
        <td style="border-left:none; text-align:right"><a href="https://www.github.com/spatialos/gdk-for-unity/blob/0.3.3/workers/unity/Packages/io.improbable.gdk.core/Worker/Worker.cs/#L36">Source</a></td>
    </tr>
    <tr>
        <td colspan="2">
<code> <a href="{{urlRoot}}/api/core/i-log-dispatcher">ILogDispatcher</a> LogDispatcher</code></p>
The logger for this worker. 

</td>
    </tr>
</table>


<table width="100%">
    <tr>
        <td style="border-right:none"><a id="isconnected"></a><b>IsConnected</b></td>
        <td style="border-left:none; text-align:right"><a href="https://www.github.com/spatialos/gdk-for-unity/blob/0.3.3/workers/unity/Packages/io.improbable.gdk.core/Worker/Worker.cs/#L41">Source</a></td>
    </tr>
    <tr>
        <td colspan="2">
<code> bool IsConnected</code></p>
Denotes whether this worker is connected or not. 

</td>
    </tr>
</table>


<table width="100%">
    <tr>
        <td style="border-right:none"><a id="connectionhandler"></a><b>ConnectionHandler</b></td>
        <td style="border-left:none; text-align:right"><a href="https://www.github.com/spatialos/gdk-for-unity/blob/0.3.3/workers/unity/Packages/io.improbable.gdk.core/Worker/Worker.cs/#L43">Source</a></td>
    </tr>
    <tr>
        <td colspan="2">
<code> <a href="{{urlRoot}}/api/core/i-connection-handler">IConnectionHandler</a> ConnectionHandler</code></p>


</td>
    </tr>
</table>






</p>
<hr style="width:100%; border-top-color:#d8d8d8" />
#### Static Methods


</p>




<table width="100%">
    <tr>
        <td style="border-right:none"><a id="createworkerasync-iconnectionhandlerbuilder-string-ilogdispatcher-cancellationtoken"></a><b>CreateWorkerAsync</b></td>
        <td style="border-left:none; text-align:right"><a href="https://www.github.com/spatialos/gdk-for-unity/blob/0.3.3/workers/unity/Packages/io.improbable.gdk.core/Worker/Worker.cs/#L76">Source</a></td>
    </tr>
    <tr>
        <td colspan="2">
<code>async Task&lt;<a href="{{urlRoot}}/api/core/worker">Worker</a>&gt; CreateWorkerAsync(<a href="{{urlRoot}}/api/core/i-connection-handler-builder">IConnectionHandlerBuilder</a> connectionHandlerBuilder, string workerType, <a href="{{urlRoot}}/api/core/i-log-dispatcher">ILogDispatcher</a> logDispatcher, CancellationToken? token = null)</code></p>
Creates a <a href="{{urlRoot}}/api/core/worker">Worker</a> object asynchronously. 
</p><b>Returns:</b></br>A task which represents the asynchronous creation of a worker.

</p>

<b>Parameters</b>

<ul>
<li><code><a href="{{urlRoot}}/api/core/i-connection-handler-builder">IConnectionHandlerBuilder</a> connectionHandlerBuilder</code> : A builder which describes how to create the <a href="{{urlRoot}}/api/core/i-connection-handler">IConnectionHandler</a> for this worker. </li>
<li><code>string workerType</code> : The type of worker to connect as.</li>
<li><code><a href="{{urlRoot}}/api/core/i-log-dispatcher">ILogDispatcher</a> logDispatcher</code> : The logger to use for this worker.</li>
<li><code>CancellationToken? token</code> : A cancellation token which will cancel this asynchronous operation</li>
</ul>





</td>
    </tr>
</table>




</p>
<hr style="width:100%; border-top-color:#d8d8d8" />
#### Constructors


</p>




<table width="100%">
    <tr>
        <td style="border-right:none"><a id="worker-iconnectionhandler-string-ilogdispatcher"></a><b>Worker</b></td>
        <td style="border-left:none; text-align:right"><a href="https://www.github.com/spatialos/gdk-for-unity/blob/0.3.3/workers/unity/Packages/io.improbable.gdk.core/Worker/Worker.cs/#L51">Source</a></td>
    </tr>
    <tr>
        <td colspan="2">
<code> Worker(<a href="{{urlRoot}}/api/core/i-connection-handler">IConnectionHandler</a> connectionHandler, string workerType, <a href="{{urlRoot}}/api/core/i-log-dispatcher">ILogDispatcher</a> logDispatcher)</code></p>



</p>

<b>Parameters</b>

<ul>
<li><code><a href="{{urlRoot}}/api/core/i-connection-handler">IConnectionHandler</a> connectionHandler</code> : </li>
<li><code>string workerType</code> : </li>
<li><code><a href="{{urlRoot}}/api/core/i-log-dispatcher">ILogDispatcher</a> logDispatcher</code> : </li>
</ul>





</td>
    </tr>
</table>




</p>
<hr style="width:100%; border-top-color:#d8d8d8" />
#### Methods


</p>




<table width="100%">
    <tr>
        <td style="border-right:none"><a id="tick"></a><b>Tick</b></td>
        <td style="border-left:none; text-align:right"><a href="https://www.github.com/spatialos/gdk-for-unity/blob/0.3.3/workers/unity/Packages/io.improbable.gdk.core/Worker/Worker.cs/#L87">Source</a></td>
    </tr>
    <tr>
        <td colspan="2">
<code>void Tick()</code></p>
Ticks the worker. Fetches all messages received since the last Tick call and applies the diff. 





</td>
    </tr>
</table>


<table width="100%">
    <tr>
        <td style="border-right:none"><a id="ensuremessagesflushed-netframestats"></a><b>EnsureMessagesFlushed</b></td>
        <td style="border-left:none; text-align:right"><a href="https://www.github.com/spatialos/gdk-for-unity/blob/0.3.3/workers/unity/Packages/io.improbable.gdk.core/Worker/Worker.cs/#L93">Source</a></td>
    </tr>
    <tr>
        <td colspan="2">
<code>void EnsureMessagesFlushed(<a href="{{urlRoot}}/api/core/network-stats/net-frame-stats">NetFrameStats</a> frameStats)</code></p>



</p>

<b>Parameters</b>

<ul>
<li><code><a href="{{urlRoot}}/api/core/network-stats/net-frame-stats">NetFrameStats</a> frameStats</code> : </li>
</ul>





</td>
    </tr>
</table>


<table width="100%">
    <tr>
        <td style="border-right:none"><a id="sendlogmessage-loglevel-string-string-entityid"></a><b>SendLogMessage</b></td>
        <td style="border-left:none; text-align:right"><a href="https://www.github.com/spatialos/gdk-for-unity/blob/0.3.3/workers/unity/Packages/io.improbable.gdk.core/Worker/Worker.cs/#L110">Source</a></td>
    </tr>
    <tr>
        <td colspan="2">
<code>void SendLogMessage(LogLevel logLevel, string message, string loggerName, <a href="{{urlRoot}}/api/core/entity-id">EntityId</a>? entityId)</code></p>
Sends a log message to SpatialOS from this worker. 


</p>

<b>Parameters</b>

<ul>
<li><code>LogLevel logLevel</code> : The log verbosity level.</li>
<li><code>string message</code> : The log message.</li>
<li><code>string loggerName</code> : A name for the sender of the log.</li>
<li><code><a href="{{urlRoot}}/api/core/entity-id">EntityId</a>? entityId</code> : The <a href="{{urlRoot}}/api/core/entity-id">EntityId</a> to associate with the log message. Set to null for no <a href="{{urlRoot}}/api/core/entity-id">EntityId</a>. </li>
</ul>





</td>
    </tr>
</table>


<table width="100%">
    <tr>
        <td style="border-right:none"><a id="getworkerflag-string"></a><b>GetWorkerFlag</b></td>
        <td style="border-left:none; text-align:right"><a href="https://www.github.com/spatialos/gdk-for-unity/blob/0.3.3/workers/unity/Packages/io.improbable.gdk.core/Worker/Worker.cs/#L120">Source</a></td>
    </tr>
    <tr>
        <td colspan="2">
<code>string GetWorkerFlag(string key)</code></p>
Gets the value for a given worker flag. 
</p><b>Returns:</b></br>The value of the flag, if it exists, null otherwise.

</p>

<b>Parameters</b>

<ul>
<li><code>string key</code> : The key of the worker flag.</li>
</ul>





</td>
    </tr>
</table>


<table width="100%">
    <tr>
        <td style="border-right:none"><a id="dispose"></a><b>Dispose</b></td>
        <td style="border-left:none; text-align:right"><a href="https://www.github.com/spatialos/gdk-for-unity/blob/0.3.3/workers/unity/Packages/io.improbable.gdk.core/Worker/Worker.cs/#L125">Source</a></td>
    </tr>
    <tr>
        <td colspan="2">
<code>void Dispose()</code></p>






</td>
    </tr>
</table>





