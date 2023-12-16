using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Prefab Data/Player", order = 1)]

public class PlayerData : ScriptableObject
{
    public string prefabName;

    public int jumpForce;
    public Sprite head;
    public Sprite body;
    public Sprite wings;
}

