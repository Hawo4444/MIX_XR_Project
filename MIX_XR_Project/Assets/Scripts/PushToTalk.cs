using UnityEngine;
using Photon.Pun;
using Photon.Voice.Unity;
using UnityEngine.InputSystem;

public class PushToTalk : MonoBehaviour
{
    [SerializeField] private InputActionReference _voiceChatActivationReference;
    private Recorder _voiceRecorder;
    public Recorder VoiceRecorder 
    { 
        get { return _voiceRecorder; }
        set 
        {
            _voiceRecorder = value;
            _voiceRecorder.TransmitEnabled = false; 
        } 
    }

    private PhotonView _photonView;

    private void Start()
    {
        _photonView = GetComponent<PhotonView>();
        //VoiceRecorder.TransmitEnabled = false;
        _voiceChatActivationReference.action.performed += VoiceChatActivate;
        _voiceChatActivationReference.action.canceled += VoiceChatCancel;
    }

    private void VoiceChatActivate(InputAction.CallbackContext obj)
    {
        if (_photonView.IsMine)
        {
            _voiceRecorder.TransmitEnabled = true;
        }
    }
    
    private void VoiceChatCancel(InputAction.CallbackContext obj)
    {
        if (_photonView.IsMine)
        {
            _voiceRecorder.TransmitEnabled = false;
        }
    }
}
