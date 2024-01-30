using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Food", menuName = "Prefab Data/Food", order = 3)]
public class FoodData : ScriptableObject
{
    public string prefabName;

    public Sprite food;
}
