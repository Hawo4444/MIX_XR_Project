using UnityEngine;

[System.Serializable]
public class DefaultRoom
{
    /*public string Name { get { return _name; } }
    public int SceneIndex { get { return _sceneIndex; } }
    public int MaxPlayers { get { return _maxPlayers; } }

    SerializeField] private string _name;
    [SerializeField] private int _sceneIndex;
    [SerializeField] private int _maxPlayers;*/

    [field: SerializeField] public string Name { get; set; }
    [field: SerializeField] public int SceneIndex { get; set; }
    [field: SerializeField] public int MaxPlayers { get; set; }
}
