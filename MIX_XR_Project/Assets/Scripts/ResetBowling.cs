using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ResetBowling : MonoBehaviour
{
    [SerializeField] private List<Transform> _pinPositions;
    [SerializeField] private GameObject _pin;
    [SerializeField] private List<GameObject> _pins;
    [SerializeField] private GameObject _ball;
    [SerializeField] private Transform _ballTransform;

    [SerializeField] private InputActionReference _resetBowlingReference;

    private void Start()
    {
        _resetBowlingReference.action.performed += Reset;
    }

    public void Reset(InputAction.CallbackContext obj)
    {
        ResetBall();
        ResetPins();
    }

    private void ResetBall()
    {
        Destroy(_ball);
        Instantiate(_ball, _ballTransform);
    }

    private void ResetPins()
    {
        foreach (var pin in _pins)
        {
            if (pin != null)
            {
                Destroy(pin);
                _pins.Remove(pin);
            }
        }

        foreach (var pinPosition in _pinPositions)
        {
            var newPin = Instantiate(_pin, pinPosition);
            _pins.Add(newPin);
        }
    }
}
