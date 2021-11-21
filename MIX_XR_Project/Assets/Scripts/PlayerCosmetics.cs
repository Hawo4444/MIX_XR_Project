using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;

public class PlayerCosmetics : MonoBehaviourPunCallbacks
{
    [SerializeField] private List<GameObject> _playerBody;
    [SerializeField] private Transform _hatPosition;

    void Start()
    {
        SetColor();
        SetHat();
    }

    private void SetColor()
    {
        var index = GetIndexOfProperty(ColorCustomizer.HASH_KEY);
        var material = ColorCustomizer.GetOption(index);

        foreach (GameObject part in _playerBody)
        {
            var currentMaterial = (part.GetComponent<Renderer>()).material;
            if (currentMaterial != null)
            {
                Destroy(currentMaterial);
            }

            (part.GetComponent<Renderer>()).material = material;
        }
    }

    private void SetHat()
    {
        var index = GetIndexOfProperty(HatCustomizer.HASH_KEY);
        var selectedHat = HatCustomizer.GetOption(index);

        var spawnedHat = Instantiate(selectedHat, _hatPosition);
        spawnedHat.transform.SetParent(_hatPosition);
    }

    private int GetIndexOfProperty(string key)
    {
        var value = photonView.Owner.CustomProperties[key];

        if (value != null)
        {
            return (int)value;
        }

        return 0;
    }
}
