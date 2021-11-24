using UnityEngine.XR.Interaction.Toolkit;
using Photon.Pun;

public class XRGrabNetworkInteractable : XRGrabInteractable
{
    private PhotonView _photonView;

    void Start()
    {
        _photonView = GetComponent<PhotonView>();   
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (args.interactor.gameObject.name == "RightHand Teleport Controller")
            return;

        _photonView.RequestOwnership();
        base.OnSelectEntered(args);
    }
}
