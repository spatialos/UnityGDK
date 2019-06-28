
# LoggingDispatcher Class
<sup>
Namespace: Improbable.Gdk.<a href="{{urlRoot}}/api/core-index">Core</a><br/>
GDK package: Core<br/>
<a href="https://www.github.com/spatialos/gdk-for-unity/blob/0.2.4/workers/unity/Packages/com.improbable.gdk.core/Logging/LoggingDispatcher.cs/#L12">Source</a>
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
<li><a href="#methods">Methods</a>
</ul></nav>

</p>



<p>Logs to the Unity Console. </p>



</p>

<b>Inheritance</b>

<code><a href="{{urlRoot}}/api/core/i-log-dispatcher">Improbable.Gdk.Core.ILogDispatcher</a></code>


</p>

<b>Notes</b>

- Forwards logs to UnityEngine.Debug.unityLogger. 







</p>
<hr style="width:100%; border-top-color:#d8d8d8" />
#### Properties


</p>




<table width="100%">
    <tr>
        <td style="border-right:none"><b>Worker</b></td>
        <td style="border-left:none; text-align:right"><a href="https://www.github.com/spatialos/gdk-for-unity/blob/0.2.4/workers/unity/Packages/com.improbable.gdk.core/Logging/LoggingDispatcher.cs/#L14">Source</a></td>
    </tr>
    <tr>
        <td colspan="2">
<code> <a href="{{urlRoot}}/api/core/worker">Worker</a> Worker { get; set; }</code></p>



</td>
    </tr>
</table>


<table width="100%">
    <tr>
        <td style="border-right:none"><b>WorkerType</b></td>
        <td style="border-left:none; text-align:right"><a href="https://www.github.com/spatialos/gdk-for-unity/blob/0.2.4/workers/unity/Packages/com.improbable.gdk.core/Logging/LoggingDispatcher.cs/#L15">Source</a></td>
    </tr>
    <tr>
        <td colspan="2">
<code> string WorkerType { get; set; }</code></p>



</td>
    </tr>
</table>






</p>
<hr style="width:100%; border-top-color:#d8d8d8" />
#### Methods


</p>




<table width="100%">
    <tr>
        <td style="border-right:none"><b>HandleLog</b></td>
        <td style="border-left:none; text-align:right"><a href="https://www.github.com/spatialos/gdk-for-unity/blob/0.2.4/workers/unity/Packages/com.improbable.gdk.core/Logging/LoggingDispatcher.cs/#L22">Source</a></td>
    </tr>
    <tr>
        <td colspan="2">
<code>void HandleLog(LogType type, <a href="{{urlRoot}}/api/core/log-event">LogEvent</a> logEvent)</code></p>
Log locally to the console. 


</p>

<b>Parameters</b>

<ul>
<li><code>LogType type</code> : The type of the log.</li>
<li><code><a href="{{urlRoot}}/api/core/log-event">LogEvent</a> logEvent</code> : A <a href="{{urlRoot}}/api/core/log-event">LogEvent</a> instance.</li>
</ul>





</td>
    </tr>
</table>


<table width="100%">
    <tr>
        <td style="border-right:none"><b>Dispose</b></td>
        <td style="border-left:none; text-align:right"><a href="https://www.github.com/spatialos/gdk-for-unity/blob/0.2.4/workers/unity/Packages/com.improbable.gdk.core/Logging/LoggingDispatcher.cs/#L41">Source</a></td>
    </tr>
    <tr>
        <td colspan="2">
<code>void Dispose()</code></p>






</td>
    </tr>
</table>





