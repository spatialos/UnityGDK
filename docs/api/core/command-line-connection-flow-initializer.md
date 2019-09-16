
# CommandLineConnectionFlowInitializer Class
<sup>
Namespace: Improbable.Gdk.<a href="{{urlRoot}}/api/core-index">Core</a><br/>
GDK package: Core<br/>
<a href="https://www.github.com/spatialos/gdk-for-unity/blob/88a422dc255ef1d47ee9385f226ca439f31c000b/workers/unity/Packages/io.improbable.gdk.core/Worker/ConnectionHandlers/ConnectionFlowInitializers.cs/#L24">Source</a>
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



<p>Represents an object which can initialize the <a href="{{urlRoot}}/api/core/receptionist-flow">ReceptionistFlow</a>, <a href="{{urlRoot}}/api/core/locator-flow">LocatorFlow</a>, and <a href="{{urlRoot}}/api/core/locator-flow">LocatorFlow</a> connection flows from the command line. </p>



</p>

<b>Inheritance</b>

<code><a href="{{urlRoot}}/api/core/i-connection-flow-initializer">Improbable.Gdk.Core.IConnectionFlowInitializer&lt;ReceptionistFlow&gt;</a></code>
<code><a href="{{urlRoot}}/api/core/i-connection-flow-initializer">Improbable.Gdk.Core.IConnectionFlowInitializer&lt;LocatorFlow&gt;</a></code>










</p>
<hr style="width:100%; border-top-color:#d8d8d8" />
#### Constructors


</p>




<table width="100%">
    <tr>
        <td style="border-right:none"><a id="commandlineconnectionflowinitializer"></a><b>CommandLineConnectionFlowInitializer</b></td>
        <td style="border-left:none; text-align:right"><a href="https://www.github.com/spatialos/gdk-for-unity/blob/88a422dc255ef1d47ee9385f226ca439f31c000b/workers/unity/Packages/io.improbable.gdk.core/Worker/ConnectionHandlers/ConnectionFlowInitializers.cs/#L28">Source</a></td>
    </tr>
    <tr>
        <td colspan="2">
<code> CommandLineConnectionFlowInitializer()</code></p>






</td>
    </tr>
</table>




</p>
<hr style="width:100%; border-top-color:#d8d8d8" />
#### Methods


</p>




<table width="100%">
    <tr>
        <td style="border-right:none"><a id="getconnectionservice"></a><b>GetConnectionService</b></td>
        <td style="border-left:none; text-align:right"><a href="https://www.github.com/spatialos/gdk-for-unity/blob/88a422dc255ef1d47ee9385f226ca439f31c000b/workers/unity/Packages/io.improbable.gdk.core/Worker/ConnectionHandlers/ConnectionFlowInitializers.cs/#L42">Source</a></td>
    </tr>
    <tr>
        <td colspan="2">
<code><a href="{{urlRoot}}/api/core/connection-service">ConnectionService</a> GetConnectionService()</code></p>
Gets the connection service to use based on command line arguments. 
</p><b>Returns:</b></br>The connection service to use.




</td>
    </tr>
</table>


<table width="100%">
    <tr>
        <td style="border-right:none"><a id="initialize-receptionistflow"></a><b>Initialize</b></td>
        <td style="border-left:none; text-align:right"><a href="https://www.github.com/spatialos/gdk-for-unity/blob/88a422dc255ef1d47ee9385f226ca439f31c000b/workers/unity/Packages/io.improbable.gdk.core/Worker/ConnectionHandlers/ConnectionFlowInitializers.cs/#L52">Source</a></td>
    </tr>
    <tr>
        <td colspan="2">
<code>void Initialize(<a href="{{urlRoot}}/api/core/receptionist-flow">ReceptionistFlow</a> receptionist)</code></p>



</p>

<b>Parameters</b>

<ul>
<li><code><a href="{{urlRoot}}/api/core/receptionist-flow">ReceptionistFlow</a> receptionist</code> : </li>
</ul>





</td>
    </tr>
</table>


<table width="100%">
    <tr>
        <td style="border-right:none"><a id="initialize-locatorflow"></a><b>Initialize</b></td>
        <td style="border-left:none; text-align:right"><a href="https://www.github.com/spatialos/gdk-for-unity/blob/88a422dc255ef1d47ee9385f226ca439f31c000b/workers/unity/Packages/io.improbable.gdk.core/Worker/ConnectionHandlers/ConnectionFlowInitializers.cs/#L61">Source</a></td>
    </tr>
    <tr>
        <td colspan="2">
<code>void Initialize(<a href="{{urlRoot}}/api/core/locator-flow">LocatorFlow</a> locator)</code></p>



</p>

<b>Parameters</b>

<ul>
<li><code><a href="{{urlRoot}}/api/core/locator-flow">LocatorFlow</a> locator</code> : </li>
</ul>





</td>
    </tr>
</table>





