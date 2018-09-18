using System;
using Generated.Playground;
using Improbable.Gdk.Core;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

#region Diagnostic control

#pragma warning disable 649
// ReSharper disable UnassignedReadonlyField
// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

#endregion

namespace Playground
{
    [UpdateInGroup(typeof(SpatialOSUpdateGroup))]
    internal class LocalPlayerInputSync : ComponentSystem
    {
        private struct PlayerInputData
        {
            public readonly int Length;
            [ReadOnly] public ComponentDataArray<LocalInput> LocalInput;
            public ComponentDataArray<PlayerInput.Component> PlayerInput;
            [ReadOnly] public ComponentDataArray<CameraTransform> CameraTransform;
            [ReadOnly] public ComponentDataArray<Authoritative<PlayerInput.Component>> PlayerInputAuthority;
        }

        [Inject] private PlayerInputData playerInputData;

        private const float MinInputChange = 0.01f;

        protected override void OnUpdate()
        {
            for (var i = 0; i < playerInputData.Length; i++)
            {
                var localInput = playerInputData.LocalInput[i];
                var cameraTransform = playerInputData.CameraTransform[i];
                var forward = cameraTransform.Rotation * Vector3.up;
                var right = cameraTransform.Rotation * Vector3.right;
                var input = localInput.LeftStick.x * right + localInput.LeftStick.y * forward;
                var isShiftDown = localInput.Running;

                var oldPlayerInput = playerInputData.PlayerInput[i];

                if (Math.Abs(oldPlayerInput.Horizontal - input.x) > MinInputChange
                    || Math.Abs(oldPlayerInput.Vertical - input.z) > MinInputChange
                    || oldPlayerInput.Running != isShiftDown)
                {
                    var newPlayerInput = new PlayerInput.Component
                    {
                        Horizontal = input.x,
                        Vertical = input.z,
                        Running = isShiftDown
                    };
                    playerInputData.PlayerInput[i] = newPlayerInput;
                }
            }
        }
    }
}
