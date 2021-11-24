using System.Collections.Generic;
using Photon.Realtime;
using UnityEngine;
using Photon.Pun;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject _nameUI;
    private const string ROOM_NAME = "Bowling Area";

    public void ConnectToServer()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Trying to connect to the server...");
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("Successfully connected to the server!");
        PhotonNetwork.JoinLobby();    
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        Debug.Log("Joined the lobby!");
        _nameUI.SetActive(true);
    }

    public void InitializeRoom()
    {
        PhotonNetwork.LoadLevel(1);
        
        var roomOptions = new RoomOptions()
        {
            MaxPlayers = 6,
            IsVisible = true,
            IsOpen = true
        };

        PhotonNetwork.JoinOrCreateRoom(ROOM_NAME, roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined the room!");
        base.OnJoinedRoom();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("A new player joined the room!");
        base.OnPlayerEnteredRoom(newPlayer);
    }
}
