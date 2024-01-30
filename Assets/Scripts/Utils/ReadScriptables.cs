using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ReadScriptables : MonoBehaviour
{
    private static Dictionary<string, ScriptableObject> scriptableDict;
    private static Object[] playerDataArray = { };
    private static Object[] foodDataArray = { };

    const string SCRIPTABLE_PATH = "ScriptableObjects/";
    const string PLAYERS_PATH = "Players";
    const string OBSTACLES_PATH = "Obstacles";
    const string FOOD_PATH = "Food";
    private static string[] pathArray = { PLAYERS_PATH, OBSTACLES_PATH, FOOD_PATH };
    public static void Setup()
    {
        scriptableDict = CreateScriptableDataDict();
    }

    public static void SetupOptions()
    {
        playerDataArray = CreateSingleScriptableDataArray("Players");
    }

    public static void SetupFoods()
    {
        foodDataArray = CreateSingleScriptableDataArray("Food");
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

    private static Object[] CreateSingleScriptableDataArray(string path)
    {
        playerDataArray = Resources.LoadAll(SCRIPTABLE_PATH + path);
        return playerDataArray;
    }

    private static ScriptableObject CastScriptable(Object[] array, int index)
    {
        return (ScriptableObject)array[index];
    }

    public static PlayerData GetPlayerData(int index)
    {
        return (PlayerData)CastScriptable(playerDataArray, index);
    }

    public static FoodData GetFoodData(int index)
    {
        return (FoodData)CastScriptable(foodDataArray, index);
    }

    public static int GetPlayerDataLenght()
    {
        return playerDataArray.Length;
    }

    public static int GetFoodDataLenght()
    {
        return foodDataArray.Length;
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
