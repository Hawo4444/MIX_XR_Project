using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerCosmetics : MonoBehaviourPunCallbacks
{
    [SerializeField] private List<GameObject> _playerBody;
    [SerializeField] private Transform _hatPosition;

    private XRRig _rig;
    private PhotonView _photonView;

    private const string RIGHT_HAND_PATH = "Camera Offset/Right Hand/RightHand Controller/Right Hand Presence";
    private const string RIGHT_HAND_MATERIAL_PATH = "hands:hands_geom/hands:Rhand";
    private const string LEFT_HAND_PATH = "Camera Offset/Left Hand/LeftHand Controller/Left Hand Presence";
    private const string LEFT_HAND_MATERIAL_PATH = "hands:hands_geom/hands:Lhand";

    void Start()
    {
        _photonView = GetComponent<PhotonView>();

        _rig = FindObjectOfType<XRRig>();
        AddRigModelToPlayerBodyList(RIGHT_HAND_PATH, RIGHT_HAND_MATERIAL_PATH, _rig);
        AddRigModelToPlayerBodyList(LEFT_HAND_PATH, LEFT_HAND_MATERIAL_PATH, _rig);

        SetColor();
        SetHat();
    }

    private void AddRigModelToPlayerBodyList(string modelPath, string materialPath, XRRig rig)
    {
        var handModel = rig.transform.Find(modelPath)?
            .GetComponent<HandPresence>().GetSpawnedHandModel()?.transform.Find(materialPath).gameObject;

        if(handModel != null && _photonView.IsMine)
            _playerBody.Add(handModel);
    }

    private void SetColor()
    {
        var index = GetIndexOfProperty(ColorCustomizer.HASH_KEY);
        var material = ColorCustomizer.GetOption(index);

        foreach (var part in _playerBody)
        {
            var currentMaterial = (part.GetComponent<Renderer>()).material;
            if (currentMaterial != null)
            {
                Destroy(currentMaterial);
            }

            part.GetComponent<Renderer>().material = material;
        }
    }

    private void SetHat()
    {
        var index = GetIndexOfProperty(HatCustomizer.HASH_KEY);
        var selectedHat = HatCustomizer.GetOption(index);

        var spawnedHat = Instantiate(selectedHat, _hatPosition);
        spawnedHat.transform.SetParent(_hatPosition);
    }

    private int GetIndexOfProperty(string key)
    {
        var value = photonView.Owner.CustomProperties[key];

        if (value != null)
        {
            return (int)value;
        }

        return 0;
    }
}
