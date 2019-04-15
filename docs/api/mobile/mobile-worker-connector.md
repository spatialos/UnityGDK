
# MobileWorkerConnector Class
<sup>
Namespace: Improbable.Gdk.<a href="{{urlRoot}}/api/mobile-index">Mobile</a><br/>
GDK package: Mobile<br/>
<a href="https://www.github.com/spatialos/gdk-for-unity/blob/0.2.1/workers/unity/Packages/com.improbable.gdk.mobile/Worker/MobileWorkerConnector.cs/#L9">Source</a>
<style>
a code {
                    padding: 0em 0.25em!important;
}
code {
                    background-color: #ffffff!important;
}
</style>
</sup>
<nav id="pageToc" class="page-toc"><ul><li><a href="#methods">Methods</a>
<li><a href="#overrides">Overrides</a>
</ul></nav>



</p>

<b>Inheritance</b>

<code><a href="{{urlRoot}}/api/core/worker-connector">Improbable.Gdk.Core.WorkerConnector</a></code>











</p>
<hr style="width:100%; border-top-color:#d8d8d8" />
#### Methods


</p>




<table width="100%">
    <tr>
        <td style="border-right:none"><b>GetHostIp</b></td>
        <td style="border-left:none; text-align:right"><a href="https://www.github.com/spatialos/gdk-for-unity/blob/0.2.1/workers/unity/Packages/com.improbable.gdk.mobile/Worker/MobileWorkerConnector.cs/#L11">Source</a></td>
    </tr>
    <tr>
        <td colspan="2">
<code>abstract string GetHostIp()</code></p>






</td>
    </tr>
</table>




</p>
<hr style="width:100%; border-top-color:#d8d8d8" />
#### Overrides


</p>




<table width="100%">
    <tr>
        <td style="border-right:none"><b>GetConnectionParameters</b></td>
        <td style="border-left:none; text-align:right"><a href="https://www.github.com/spatialos/gdk-for-unity/blob/0.2.1/workers/unity/Packages/com.improbable.gdk.mobile/Worker/MobileWorkerConnector.cs/#L13">Source</a></td>
    </tr>
    <tr>
        <td colspan="2">
<code>override ConnectionParameters GetConnectionParameters(string workerType, <a href="{{urlRoot}}/api/core/connection-service">ConnectionService</a> service)</code></p>
Retrieves the ConnectionParameters needed to be able to connect to any connection service. 
</p><b>Returns:</b></br>A ConnectionParameters object.

</p>

<b>Parameters</b>

<ul>
<li><code>string workerType</code> : The type of worker you want to connect.</li>
<li><code><a href="{{urlRoot}}/api/core/connection-service">ConnectionService</a> service</code> : The connection service used to connect.</li>
</ul>





</td>
    </tr>
</table>


<table width="100%">
    <tr>
        <td style="border-right:none"><b>GetReceptionistConfig</b></td>
        <td style="border-left:none; text-align:right"><a href="https://www.github.com/spatialos/gdk-for-unity/blob/0.2.1/workers/unity/Packages/com.improbable.gdk.mobile/Worker/MobileWorkerConnector.cs/#L36">Source</a></td>
    </tr>
    <tr>
        <td colspan="2">
<code>override <a href="{{urlRoot}}/api/core/receptionist-config">ReceptionistConfig</a> GetReceptionistConfig(string workerType)</code></p>
Retrieves the configuration needed to connect via the Receptionist service. 
</p><b>Returns:</b></br>A ReceptionistConfig object.

</p>

<b>Parameters</b>

<ul>
<li><code>string workerType</code> : The type of worker you want to connect.</li>
</ul>





</td>
    </tr>
</table>


<table width="100%">
    <tr>
        <td style="border-right:none"><b>GetLocatorConfig</b></td>
        <td style="border-left:none; text-align:right"><a href="https://www.github.com/spatialos/gdk-for-unity/blob/0.2.1/workers/unity/Packages/com.improbable.gdk.mobile/Worker/MobileWorkerConnector.cs/#L46">Source</a></td>
    </tr>
    <tr>
        <td colspan="2">
<code>override <a href="{{urlRoot}}/api/core/locator-config">LocatorConfig</a> GetLocatorConfig()</code></p>
Retrieves the configuration needed to connect via the Locator service. 
</p><b>Returns:</b></br>A LocatorConfig object.




</td>
    </tr>
</table>


<table width="100%">
    <tr>
        <td style="border-right:none"><b>GetAlphaLocatorConfig</b></td>
        <td style="border-left:none; text-align:right"><a href="https://www.github.com/spatialos/gdk-for-unity/blob/0.2.1/workers/unity/Packages/com.improbable.gdk.mobile/Worker/MobileWorkerConnector.cs/#L51">Source</a></td>
    </tr>
    <tr>
        <td colspan="2">
<code>override <a href="{{urlRoot}}/api/core/alpha-locator-config">AlphaLocatorConfig</a> GetAlphaLocatorConfig(string workerType)</code></p>
Retrieves the configuration needed to connect via the Alpha Locator service. 
</p><b>Returns:</b></br>A AlphaLocatorConfig object.

</p>

<b>Parameters</b>

<ul>
<li><code>string workerType</code> : </li>
</ul>



</p>

<b>Notes:</b>

<ul>
<li>This connection service is still in Alpha and does not provide an integration with Steam. </li>
</ul>




</td>
    </tr>
</table>




