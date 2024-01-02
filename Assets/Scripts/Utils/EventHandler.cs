using System;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour, ISubscriber
{

    private Dictionary<string, Action> actionDict;
    public void Setup()
    {
        actionDict = new Dictionary<string, Action>();
    }

    //TODO: create a class for actions with names
    public void SendAction(string key)
    {
        if (actionDict[key] != null)
        {
            actionDict[key].DynamicInvoke();
        }
    }
    public void SubscribeToEvent(string subscriber, string target)
    {
         actionDict[target] += actionDict[subscriber];
    }
    public void UnsubscribeToEvent(string subscriber, string target)
    {
        actionDict[target] -= actionDict[subscriber];
    }

    public Action GetEvent(string key)
    {
        return actionDict[key];
    }

    public void AddEventToDict(string key, Action action)
    {
        if (!actionDict.ContainsKey(key))
            actionDict.Add(key, action);
        else
        { 
            actionDict[key] = null;
            actionDict[key] = action;
        }
    }

    public void RemoveEventToDict(string key)
    {
        if (actionDict.ContainsKey(key))
            actionDict.Remove(key);
    }
}
