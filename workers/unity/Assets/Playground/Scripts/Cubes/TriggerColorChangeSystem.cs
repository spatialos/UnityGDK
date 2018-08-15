using System;
using Generated.Playground;
using Improbable.Gdk.Core;
using Improbable.Gdk.TransformSynchronization;
using Unity.Collections;
using Unity.Entities;

namespace Playground
{
    [UpdateInGroup(typeof(SpatialOSUpdateGroup))]
    public class TriggerColorChangeSystem : ComponentSystem
    {
        private struct CubeColorData
        {
            public readonly int Length;
            [ReadOnly] public ComponentDataArray<CubeColor.EventSender.ChangeColor> EventSenders;
        }

        [Inject] private CubeColorData cubeColorData;

        private Array colorValues;

        protected override void OnCreateManager(int capacity)
        {
            base.OnCreateManager(capacity);

            colorValues = Enum.GetValues(typeof(Color));
        }

        protected override void OnUpdate()
        {
            if (World.GetExistingManager<TickSystem>().GlobalTick % 100 != 0)
            {
                return;
            }

            var newColor = (Generated.Playground.Color) colorValues.GetValue(new Random().Next(colorValues.Length));

            for (var i = 0; i < cubeColorData.Length; i++)
            {
                var colorData = new Generated.Playground.ColorData
                {
                    Color = newColor
                };

                cubeColorData.EventSenders[i].Events.Add(colorData);
            }
        }
    }
}
