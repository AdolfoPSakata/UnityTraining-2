using UnityEngine;

[CreateAssetMenu(fileName = "Obstacle", menuName = "Prefab Data/Obstacle", order = 2)]
public class ObstacleData : ScriptableObject
{
    public string prefabName;
    
    public float speed;
    public Sprite spriteDown;
    public Sprite spriteUp;
}
