using TMPro;
using UnityEngine;

public class KeyboardKey : MonoBehaviour
{
    [SerializeField] private TMP_InputField _nickName;
    
    public void KeyPressed(GameObject key)
    {
        _nickName.text += key.name.ToUpper();
    }
}
