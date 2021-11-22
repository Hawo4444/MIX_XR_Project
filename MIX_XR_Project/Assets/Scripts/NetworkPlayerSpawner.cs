using Photon.Pun;
using Photon.Voice.Unity;
using UnityEngine;

public class NetworkPlayerSpawner : MonoBehaviourPunCallbacks
{
    private GameObject _spawnedPlayerPrefab;

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        _spawnedPlayerPrefab = PhotonNetwork.Instantiate("Network Player", transform.position, transform.rotation);
        
        GameObject.Find("Network Voice")
            .GetComponent<PushToTalk>()
            .VoiceRecorder = _spawnedPlayerPrefab.GetComponent<Recorder>();
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(_spawnedPlayerPrefab);
    }
}
