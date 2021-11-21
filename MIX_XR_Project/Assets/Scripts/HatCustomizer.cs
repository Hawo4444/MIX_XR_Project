using UnityEngine;

public sealed class HatCustomizer : CharacterCustomizer<GameObject>
{
    [SerializeField] private Transform _hatPosition;
    private GameObject _hat;
    public const string HASH_KEY = "hat";

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
        if (_hat != null)
        {
            Destroy(_hat);
        }

        _hat = Instantiate(_optionsList[_currentOption], _hatPosition);

        SetHash(HASH_KEY);
    }
}
