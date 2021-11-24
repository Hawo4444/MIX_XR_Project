using Photon.Pun;
using TMPro;
using UnityEngine;

public class PlayerNickName : MonoBehaviourPun
{
    [SerializeField] private TMP_Text _nameText;

    void Start()
    {
        if (!photonView.IsMine)
        {
            _nameText.text = photonView.Owner.NickName;
        }
    }
}
