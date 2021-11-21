using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class TeleportController : MonoBehaviour
{
    [SerializeField] private GameObject _controllerGameObject;
    [SerializeField] private GameObject _teleportationGameObject;

    [SerializeField] private InputActionReference _teleportActivationReference;

    [SerializeField] private UnityEvent _onTeleportActivate;
    [SerializeField] private UnityEvent _onTeleportCancel;

    private void Start()
    {
        _teleportActivationReference.action.performed += TeleportModeActivate;
        _teleportActivationReference.action.canceled += TeleportModeCancel; 
    }

    private void TeleportModeActivate(InputAction.CallbackContext obj) => _onTeleportActivate.Invoke();

    private void TeleportModeCancel(InputAction.CallbackContext obj)
    {
        Invoke("DeactivateTeleporter", .1f);
    }

    private void DeactivateTeleporter() => _onTeleportCancel.Invoke();

}
