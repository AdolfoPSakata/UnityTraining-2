using System.Collections.Generic;
using UnityEngine;

public static class AssetsDatabase
{
    public static Dictionary<string, GameObject> prefabsDict { get; private set; }

    public static void Init()
    {
        prefabsDict = CreateDictionary("Prefabs");
        
    }
    private static Dictionary<string, GameObject> CreateDictionary(string path)
    {
        Object[] newArray = { };
        newArray = Resources.LoadAll(path);
        Dictionary<string, GameObject> newDict = new Dictionary<string, GameObject>();
       
        foreach (var go in newArray)
        {
            newDict.Add(go.name, (GameObject)go);
        }

        return newDict;
    }
}
