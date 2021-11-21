using System.Collections.Generic;
using UnityEngine;

public sealed class ColorCustomizer : CharacterCustomizer<Material>
{
    [SerializeField] private List<GameObject> _playerBody;
    public const string HASH_KEY = "color";


    protected override void Start()
    {
        base.Start();
        SwitchToSelectedOption();
    }

    public override void NextOption()
    {
        base.NextOption();

        SwitchToSelectedOption();
    }

    public override void PreviousOption()
    {
        base.PreviousOption();

        SwitchToSelectedOption();
    }

    protected override void SwitchToSelectedOption()
    {
        foreach (GameObject part in _playerBody)
        {
            var currentMaterial = (part.GetComponent<Renderer>()).material;
            if (currentMaterial != null)
            {
                Destroy(currentMaterial);
            }

            (part.GetComponent<Renderer>()).material = _optionsList[_currentOption];
        }

        SetHash(HASH_KEY);
    }
}
