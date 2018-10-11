﻿using Improbable.Gdk.Core;
using Improbable.Gdk.Mobile;
using Playground;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbstractMobileClientWorker : MobileWorkerConnector
{
    [SerializeField] private GameObject ConnectionPanel;
    [SerializeField] private GameObject Level;

    private GameObject levelInstance;
    private bool connected;
    private InputField ipAddressInput;
    private Button connectButton;
    private Text errorMessage;

    protected string IpAddress => ipAddressInput != null ? ipAddressInput.text : null;

    public void Awake()
    {
        ipAddressInput = ConnectionPanel.transform.Find("ConnectInput").GetComponent<InputField>();
        connectButton = ConnectionPanel.transform.Find("ConnectButton").GetComponent<Button>();
        errorMessage = ConnectionPanel.transform.Find("ConnectionError").GetComponent<Text>();

        ipAddressInput.text = PlayerPrefs.GetString("cachedIp");
        connectButton.onClick.AddListener(Connect);
    }

    public async void Connect()
    {
        errorMessage.text = "";
        await Connect(WorkerUtils.UnityClient, new ForwardingDispatcher()).ConfigureAwait(false);
    }

    protected override void HandleWorkerConnectionEstablished()
    {
        WorkerUtils.AddClientSystems(Worker.World);
        if (Level == null)
        {
            return;
        }

        levelInstance = Instantiate(Level, transform);
        levelInstance.transform.SetParent(null);

        connected = true;
        ConnectionPanel.SetActive(false);

        PlayerPrefs.SetString("cachedIp", input.text);
        PlayerPrefs.Save();
    }

    protected override void HandleWorkerConnectionFailure()
    {
        errorMessage.text = "Connection failure. Please check the IP address";
    }

    protected string GetIpFromField()
    {
        return input.text;
    }

    public override void Dispose()
    {
        if (levelInstance != null)
        {
            Destroy(levelInstance);
        }

        if (connected)
        {
            Destroy(this);
        }

        Worker?.Dispose();
        Worker = null;
    }
}
