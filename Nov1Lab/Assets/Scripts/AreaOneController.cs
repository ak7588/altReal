using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AreaOneController : XRSceneController
{
    public Transform xrRigOrigin2;
    public XRSocketInteractor keyCardSocket;
    public XRBaseInteractable keyCard;

    public override void Init() {
        if (PlayerManager.Instance.hasVisited2) {
            keyCardSocket.startingSelectedInteractable = keyCard;
        }
    }

    public override Transform GetXRRigOrigin()
    {
        return PlayerManager.Instance.hasVisited2 ? xrRigOrigin2 : xrRigOrigin;
    }
}
