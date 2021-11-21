using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Photon.Voice.Unity;
using Photon.Voice.PUN;
using UnityEngine.InputSystem;

public class PushToTalk : MonoBehaviour
{
    [SerializeField] private InputActionReference _voiceChatActivationReference;
    [SerializeField] private Recorder _voiceRecorder;
    [SerializeField] private ParticleSystem _particle;
    private PhotonView _photonView;

    // Start is called before the first frame update
    void Start()
    {
        _photonView = GetComponent<PhotonView>();
        _voiceRecorder.TransmitEnabled = false;
        _voiceChatActivationReference.action.performed += VoiceChatActivate;
        _voiceChatActivationReference.action.canceled += VoiceChatCancel;
        _particle.Stop();
    }

    private void VoiceChatActivate(InputAction.CallbackContext obj)
    {
        if (_photonView.IsMine)
        {
            _particle.Play();
            _voiceRecorder.TransmitEnabled = true;
        }
    }
    
    private void VoiceChatCancel(InputAction.CallbackContext obj)
    {
        if (_photonView.IsMine)
        {
            _particle.Stop();
            _voiceRecorder.TransmitEnabled = false;
        }
    }
}
