using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ReadScriptables : MonoBehaviour
{
    private static Dictionary<string, ScriptableObject> scriptableDict;
    const string SCRIPTABLE_PATH = "ScriptableObjects/";
    const string PLAYERS_PATH = "Players";
    const string OBSTACLES_PATH = "Obstacles";
    private static string[] pathArray = { PLAYERS_PATH, OBSTACLES_PATH };
    public static void Init()
    {
        scriptableDict = CreateScriptableDataDict();
    }
    private static Dictionary<string, ScriptableObject> CreateScriptableDataDict()
    {
        Dictionary<string, ScriptableObject> newDict = new Dictionary<string, ScriptableObject>();

        foreach (var path in pathArray)
        {
            Object[] newArray = { };
            newArray = Resources.LoadAll(SCRIPTABLE_PATH + path);

            foreach (var so in newArray)
            {
                newDict.Add(so.name, (ScriptableObject)so);
            }
        }

        return newDict;
    }

    public static ScriptableObject GetScriptableObject(string key)
    {


        return scriptableDict[key];
    }

    public static ScriptableObject GetScriptableObject(int index)
    {
        KeyValuePair<string, ScriptableObject> keyValuePair = scriptableDict.ElementAt(index);
        return keyValuePair.Value;
    }

    public static int GetScriptablesCount()
    {
        return scriptableDict.Count;
    }
}
