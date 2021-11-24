using Photon.Pun;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetNickName : MonoBehaviour
{
    [SerializeField] private GameObject _nameUI;
    [SerializeField] private GameObject _roomUI;
    [SerializeField] private TMP_InputField _nameInput;

    private const string PLAYER_NAME = "PlayerName";

    void Start()
    {
        if (!PlayerPrefs.HasKey(PLAYER_NAME))
        {
            return;
        }

        string playerName = PlayerPrefs.GetString(PLAYER_NAME);
        _nameInput.text = playerName;
    }

    public void SetPlayerName()
    {
        string playerName = _nameInput.text;
        PhotonNetwork.NickName = playerName;
        PlayerPrefs.SetString(PLAYER_NAME, playerName);

         _nameUI.SetActive(false);
        _roomUI.SetActive(true);
    }
}
