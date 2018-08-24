using Generated.Improbable.Transform;
using Generated.Playground;
using Improbable.Gdk.Core;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

#region Diagnostic control

#pragma warning disable 649
// ReSharper disable UnassignedReadonlyField
// ReSharper disable UnusedMember.Global

#endregion

namespace Playground
{
    [UpdateInGroup(typeof(SpatialOSUpdateGroup))]
    internal class MoveLocalPlayerSystem : ComponentSystem
    {
        public struct Speed : IComponentData
        {
            public float CurrentSpeed;
            public float SpeedSmoothVelocity;
        }

        private struct NewPlayerData
        {
            public readonly int Length;
            public EntityArray Entity;
            [ReadOnly] public ComponentDataArray<SpatialOSPlayerInput> PlayerInput;
            [ReadOnly] public ComponentDataArray<Authoritative<SpatialOSTransform>> TransformAuthority;
            public SubtractiveComponent<Speed> NoSpeed;
        }

        private struct PlayerInputData
        {
            public readonly int Length;
            public ComponentArray<Rigidbody> Rigidbody;
            public ComponentDataArray<Speed> SpeedData;
            [ReadOnly] public ComponentDataArray<SpatialOSPlayerInput> PlayerInput;
            [ReadOnly] public ComponentDataArray<Authoritative<SpatialOSTransform>> TransformAuthority;
        }

        [Inject] private NewPlayerData newPlayerData;
        [Inject] private PlayerInputData playerInputData;

        private const float WalkSpeed = 2;
        private const float RunSpeed = 6;

        private const float TurnSmoothTime = 0.2f;
        private float turnSmoothVelocity;

        private const float SpeedSmoothTime = 0.1f;

        protected override void OnUpdate()
        {
            for (var i = 0; i < newPlayerData.Length; i++)
            {
                var entity = newPlayerData.Entity[i];
                var speed = new Speed
                {
                    CurrentSpeed = 0f,
                    SpeedSmoothVelocity = 0f
                };

                PostUpdateCommands.AddComponent(entity, speed);
            }

            for (var i = 0; i < playerInputData.Length; i++)
            {
                var rigidBody = playerInputData.Rigidbody[i];
                var playerInput = playerInputData.PlayerInput[i];

                var input = new Vector2(playerInput.Horizontal, playerInput.Vertical);
                var inputDir = input.normalized;

                if (inputDir != Vector2.zero)
                {
                    var targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg;
                    rigidBody.transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(
                        rigidBody.transform.eulerAngles.y, targetRotation,
                        ref turnSmoothVelocity, TurnSmoothTime);
                }

                var targetSpeed = (playerInput.Running ? RunSpeed : WalkSpeed) * inputDir.magnitude;
                var speed = playerInputData.SpeedData[i];
                var currentSpeed = speed.CurrentSpeed;
                var speedSmoothVelocity = speed.SpeedSmoothVelocity;

                currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, SpeedSmoothTime);
                playerInputData.SpeedData[i] = new Speed
                {
                    CurrentSpeed = currentSpeed,
                    SpeedSmoothVelocity = speedSmoothVelocity
                };

                rigidBody.transform.Translate(rigidBody.transform.forward * currentSpeed * Time.deltaTime, Space.World);
            }
        }
    }
}
