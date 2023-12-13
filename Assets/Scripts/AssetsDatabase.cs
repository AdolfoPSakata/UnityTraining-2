using System.Collections.Generic;
using UnityEngine;

public class AssetsDatabase : MonoBehaviour
{
    public static Dictionary<string, GameObject> prefabsDict { get; private set; }

    public AssetsDatabase() 
    { 
         InitiateDictionaries();
    }

    private void InitiateDictionaries()
    {
        prefabsDict = CreateDictionary("Prefabs");
        
    }
    private Dictionary<string, GameObject> CreateDictionary(string path)
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
