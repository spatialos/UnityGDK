
# WorldCommandSenderSubscriptionManager Class
<sup>
Namespace: Improbable.Gdk.<a href="{{urlRoot}}/api/core-index">Core</a><br/>
GDK package: Core<br/>
<a href="https://www.github.com/spatialos/gdk-for-unity/blob/51790202/workers/unity/Packages/io.improbable.gdk.core/Subscriptions/StandardSubscriptionManagers/WorldCommands.cs/#L11">Source</a>
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
<li><a href="#overrides">Overrides</a>
</ul></nav>



</p>

<b>Inheritance</b>

<code><a href="{{urlRoot}}/api/subscriptions/subscription-manager">Improbable.Gdk.Subscriptions.SubscriptionManager&lt;WorldCommandSender&gt;</a></code>










</p>
<hr style="width:100%; border-top-color:#d8d8d8" />
#### Constructors


</p>




<table width="100%">
    <tr>
        <td style="border-right:none"><a id="worldcommandsendersubscriptionmanager-world"></a><b>WorldCommandSenderSubscriptionManager</b></td>
        <td style="border-left:none; text-align:right"><a href="https://www.github.com/spatialos/gdk-for-unity/blob/51790202/workers/unity/Packages/io.improbable.gdk.core/Subscriptions/StandardSubscriptionManagers/WorldCommands.cs/#L20">Source</a></td>
    </tr>
    <tr>
        <td colspan="2">
<code> WorldCommandSenderSubscriptionManager(World world)</code></p>



</p>

<b>Parameters</b>

<ul>
<li><code>World world</code> : </li>
</ul>





</td>
    </tr>
</table>





</p>
<hr style="width:100%; border-top-color:#d8d8d8" />
#### Overrides


</p>




<table width="100%">
    <tr>
        <td style="border-right:none"><a id="subscribe-entityid"></a><b>Subscribe</b></td>
        <td style="border-left:none; text-align:right"><a href="https://www.github.com/spatialos/gdk-for-unity/blob/51790202/workers/unity/Packages/io.improbable.gdk.core/Subscriptions/StandardSubscriptionManagers/WorldCommands.cs/#L57">Source</a></td>
    </tr>
    <tr>
        <td colspan="2">
<code>override <a href="{{urlRoot}}/api/subscriptions/subscription">Subscription</a>&lt;<a href="{{urlRoot}}/api/core/world-command-sender">WorldCommandSender</a>&gt; Subscribe(<a href="{{urlRoot}}/api/core/entity-id">EntityId</a> entityId)</code></p>



</p>

<b>Parameters</b>

<ul>
<li><code><a href="{{urlRoot}}/api/core/entity-id">EntityId</a> entityId</code> : </li>
</ul>





</td>
    </tr>
</table>


<table width="100%">
    <tr>
        <td style="border-right:none"><a id="cancel-isubscription"></a><b>Cancel</b></td>
        <td style="border-left:none; text-align:right"><a href="https://www.github.com/spatialos/gdk-for-unity/blob/51790202/workers/unity/Packages/io.improbable.gdk.core/Subscriptions/StandardSubscriptionManagers/WorldCommands.cs/#L81">Source</a></td>
    </tr>
    <tr>
        <td colspan="2">
<code>override void Cancel(<a href="{{urlRoot}}/api/subscriptions/i-subscription">ISubscription</a> subscription)</code></p>



</p>

<b>Parameters</b>

<ul>
<li><code><a href="{{urlRoot}}/api/subscriptions/i-subscription">ISubscription</a> subscription</code> : </li>
</ul>





</td>
    </tr>
</table>


<table width="100%">
    <tr>
        <td style="border-right:none"><a id="resetvalue-isubscription"></a><b>ResetValue</b></td>
        <td style="border-left:none; text-align:right"><a href="https://www.github.com/spatialos/gdk-for-unity/blob/51790202/workers/unity/Packages/io.improbable.gdk.core/Subscriptions/StandardSubscriptionManagers/WorldCommands.cs/#L97">Source</a></td>
    </tr>
    <tr>
        <td colspan="2">
<code>override void ResetValue(<a href="{{urlRoot}}/api/subscriptions/i-subscription">ISubscription</a> subscription)</code></p>



</p>

<b>Parameters</b>

<ul>
<li><code><a href="{{urlRoot}}/api/subscriptions/i-subscription">ISubscription</a> subscription</code> : </li>
</ul>





</td>
    </tr>
</table>




