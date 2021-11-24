using TMPro;
using UnityEngine;

public class KeyboardDeleteKey : MonoBehaviour
{
    [SerializeField] private TMP_InputField _nickName;

    public void KeyPressed()
    {
        var currentName = _nickName.text;

        if (currentName.Length > 0)
        {
            _nickName.text = currentName.Remove(currentName.Length - 1);
        }
    }
}
