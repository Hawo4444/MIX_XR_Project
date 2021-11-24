using UnityEngine;
using Photon.Pun;
using Photon.Voice.Unity;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PushToTalk : MonoBehaviour
{
    [SerializeField] private InputActionReference _voiceChatActivationReference;
    [SerializeField] private Image _speakerImage;

    private Recorder _voiceRecorder;
    private PhotonView _photonView;

    private void Start()
    {
        _voiceRecorder = GameObject.Find("Network Voice Manager").GetComponent<Recorder>();
        _photonView = GetComponent<PhotonView>();

        _voiceRecorder.TransmitEnabled = false;
        _speakerImage.enabled = false;

        _voiceChatActivationReference.action.performed += VoiceChatActivate;
        _voiceChatActivationReference.action.canceled += VoiceChatCancel;
    }

    private void VoiceChatActivate(InputAction.CallbackContext obj)
    {
        if (_photonView.IsMine)
        {
            _voiceRecorder.TransmitEnabled = true;
            _speakerImage.enabled = true;
        }
    }
    
    private void VoiceChatCancel(InputAction.CallbackContext obj)
    {
        if (_photonView.IsMine)
        {
            _voiceRecorder.TransmitEnabled = false;
            _speakerImage.enabled = false;
        }
    }
}
