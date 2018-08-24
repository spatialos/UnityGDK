using Generated.Playground;
using Improbable.Gdk.Core.GameObjectRepresentation;
using Improbable.Worker;
using Improbable.Worker.Core;
using UnityEngine;

namespace Playground.MonoBehaviours
{
    public class ToggleRotationCommandSender : MonoBehaviour
    {
        [Require] private SpinnerRotation.Requirables.Reader reader;
        [Require] private SpinnerRotation.Requirables.CommandRequestSender requestSender;
        private EntityId ownEntityId;

        private void OnEnable()
        {
            if (reader != null) // TODO UTY-791: Needed until prefab preprocessing is implemented, remove as part of UTY-791
            {
                ownEntityId = GetComponent<SpatialOSComponent>().SpatialEntityId;
            }
        }

        private void Update()
        {
            if (reader.Authority != Authority.NotAuthoritative)
            {
                // Perform sending logic only on non-authoritative workers.
                return;
            }
            if (Input.GetKeyDown(KeyCode.T))
            {
                requestSender.SendSpinnerToggleRotationRequest(ownEntityId, new Void());
            }
        }
    }
}
