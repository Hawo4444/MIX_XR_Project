using System.Collections.Generic;
using UnityEngine;

public class PinManager : MonoBehaviour
{
    [SerializeField] private List<Transform> _pinPositions;
    [SerializeField] private GameObject _pin;

    private List<GameObject> _pins;

    public int Tidy(bool isDoubled)
    {
        int score = 0;

        foreach (var pin in _pins)
        {
            if (pin.GetComponent<Pin>().IsDown)
            {
                score++;
                Destroy(pin);
                _pins.Remove(pin);
            }
        }

        return isDoubled ?  score * 2 : score;
    }

    public void Restart()
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

    public int EndTurn(bool isDoubled)
    {
        var score = 10 - _pins.Count;
        Restart();

        return isDoubled ? score * 2 : score;
    }
}
