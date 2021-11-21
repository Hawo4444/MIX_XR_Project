using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Photon.Pun;
using UnityEngine.XR;

public class NetworkPlayer : MonoBehaviour
{
    [SerializeField] private Transform _head;
    [SerializeField] private Transform _body;
    [SerializeField] private Transform _leftHand;
    [SerializeField] private Transform _rightHand;

    [SerializeField] private Animator _leftHandAnimator;
    [SerializeField] private Animator _rightHandAnimator;

    private PhotonView _photonView;

    private Transform _headRig;
    private Transform _leftHandRig;
    private Transform _rightHandRig;

    // Start is called before the first frame update
    void Start()
    {
        _photonView = GetComponent<PhotonView>();

        var rig = FindObjectOfType<XRRig>();
        _headRig = rig.transform.Find("Camera Offset/Main Camera");
        _leftHandRig = rig.transform.Find("Camera Offset/Left Hand");
        _rightHandRig = rig.transform.Find("Camera Offset/Right Hand");

        if (_headRig == null) { Debug.Log("head is null"); }
        if (_leftHandRig == null) { Debug.Log("hand is null"); }

        if (_photonView.IsMine)
        {
            foreach (var renderer in GetComponentsInChildren<Renderer>())
            {
                renderer.enabled = false;
            }
        }    
    }

    // Update is called once per frame
    void Update()
    {
        if (_photonView.IsMine)
        {
            MapPosition(_head, _headRig);
            MapPosition(_leftHand, _leftHandRig);
            MapPosition(_rightHand, _rightHandRig);
            _body.position = GetBodyPosition();

            UpdateHandAnimation(InputDevices.GetDeviceAtXRNode(XRNode.LeftHand), _leftHandAnimator);
            UpdateHandAnimation(InputDevices.GetDeviceAtXRNode(XRNode.RightHand), _rightHandAnimator);
        }
    }

    void UpdateHandAnimation(InputDevice targetDevice, Animator handAnimator)
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handAnimator.SetFloat("Trigger", triggerValue);
        }
        else
        {
            handAnimator.SetFloat("Trigger", 0);
        }

        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            handAnimator.SetFloat("Grip", 0);
        }
    }

    void MapPosition(Transform target, Transform rigTransform)
    {
        target.position = rigTransform.position;
        target.rotation = rigTransform.rotation;
    }

    private Vector3 GetBodyPosition()
    {
        return new Vector3(_headRig.position.x, _headRig.position.y - 0.5f, _headRig.position.z);
    }
}
