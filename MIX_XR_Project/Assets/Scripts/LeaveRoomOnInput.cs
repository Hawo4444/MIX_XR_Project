using UnityEngine.XR;
using Photon.Pun;
using UnityEngine.XR.Interaction.Toolkit;

public class LeaveRoomOnInput : MonoBehaviourPunCallbacks
{
    private InputHelpers.Button _inputHelpers;
    private XRNode _controller;

    private void Start()
    {
        _inputHelpers = InputHelpers.Button.MenuButton;
        _controller = XRNode.LeftHand;
    }

    void Update()
    {
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(_controller), _inputHelpers, out bool isPressed);

        if (isPressed)
        {
            PhotonNetwork.Disconnect();
            PhotonNetwork.LoadLevel(0);
        }
    }
}