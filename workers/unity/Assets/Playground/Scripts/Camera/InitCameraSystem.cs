using Generated.Playground;
using Improbable.Gdk.Core;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Playground
{
    [UpdateInGroup(typeof(SpatialOSUpdateGroup))]
    public class InitCameraSystem : SpatialOSSystem
    {
        public struct Data
        {
            public readonly int Length;
            public EntityArray Entites;
            [ReadOnly] public ComponentDataArray<Authoritative<SpatialOSPlayerInput>> PlayerInput;
            [ReadOnly] public ComponentArray<AuthoritiesChanged<SpatialOSPlayerInput>> PlayerInputAuthority;
        }

        [Inject] private Data data;

        protected override void OnUpdate()
        {
            for (var i = 0; i < data.Length; i++)
            {
                var camera = Camera.main;
                PostUpdateCommands.AddComponent(data.Entites[i], CameraComponentDefaults.Input);
                PostUpdateCommands.AddComponent(data.Entites[i], CameraComponentDefaults.Transform);

                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}
