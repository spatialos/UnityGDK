using Improbable.Gdk.Core;
using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_ANDROID
using Improbable.Gdk.Android;

#endif

namespace Playground
{
    [UpdateBefore(typeof(ConnectClientSystem))]
    [UpdateBefore(typeof(SpatialOSUpdateGroup))]
    internal class ConnectButtonClickSystem : ComponentSystem
    {
        private struct Data
        {
            public readonly int Length;
            public EntityArray Entity;
            public ComponentDataArray<WorkerEntityTag> DenotesWorker;
        }

        private InputField connectParam;
        private Button connectButton;
        private bool clicked;
        private WorkerBase worker;
        private Text error;

        [Inject] private Data data;

        protected override void OnCreateManager(int capacity)
        {
            base.OnCreateManager(capacity);
            worker = WorkerRegistry.GetWorkerForWorld(World);
            connectParam = GameObject.Find("ConnectParam").GetComponent<InputField>();
            connectButton = GameObject.Find("ConnectButton").GetComponent<Button>();
            connectButton.onClick.AddListener(IsClicked);
            error = GameObject.Find("ConnectionError").GetComponent<Text>();
            if (!Application.isMobilePlatform)
            {
                connectParam.gameObject.SetActive(false);
            }
        }

        protected override void OnUpdate()
        {
            for (var i = 0; i < data.Length; i++)
            {
                if (!clicked)
                {
                    continue;
                }

                PostUpdateCommands.AddComponent(data.Entity[i], new ConnectButtonClicked());
                connectButton.gameObject.SetActive(false);
                error.text = "";
                clicked = false;
            }
        }

        private void IsClicked()
        {
            clicked = true;
#if UNITY_ANDROID
            if (Application.isMobilePlatform)
            {
                if (DeviceInfo.IsAndroidStudioEmulator() && GetInputString().Equals(""))
                {
                    worker.ConnectionConfig = ReceptionistConfig.CreateConnectionConfigForAndroidEmulator();
                }
                else
                {
                    SetConnectionParameters(GetInputString());
                }
            }
#endif
        }

        private string GetInputString()
        {
            return connectParam.text;
        }

        private void SetConnectionParameters(string param)
        {
            if (IsIpAddress(param))
            {
                worker.ConnectionConfig = ReceptionistConfig.CreateConnectionConfigForPhysicalAndroid(param);
            }

            // TODO: UTY-558 else -> cloud connection
        }

        private static bool IsIpAddress(string param)
        {
            return param.Split('.').Length == 4;
        }
    }
}
