using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;

using PhotonHashtable = ExitGames.Client.Photon.Hashtable;

public abstract class CharacterCustomizer<T> : MonoBehaviour
{
    [SerializeField] protected List<T> _optionsList;
    [SerializeField] private static List<T> OptionsList;
    protected int _currentOption = 0;
    protected PhotonHashtable _hashTable = new PhotonHashtable();

    protected virtual void Start()
    {
        OptionsList = _optionsList;
    }

    public virtual void NextOption()
    {
        _currentOption++;

        if (_currentOption == _optionsList.Count)
        {
            _currentOption = 0;
        }
    }

    public virtual void PreviousOption()
    {
        _currentOption--;

        if (_currentOption < 0)
        {
            _currentOption = _optionsList.Count - 1;
        }
    }

    protected void SetHash(string hashKey)
    {
        if (PhotonNetwork.IsConnected)
        {
            _hashTable[hashKey] = _currentOption;
            PhotonNetwork.LocalPlayer.SetCustomProperties(_hashTable);
        }
    }

    public static T GetOption(int index)
    {
        return OptionsList[index];
    }

    protected abstract void SwitchToSelectedOption();
}
