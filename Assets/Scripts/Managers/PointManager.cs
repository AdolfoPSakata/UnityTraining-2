using System;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    [SerializeField] private EventHandler eventHandler;

    public Action OnPlayerAddedPoints;
    public Action OnPlayerDeath;

    int currentPoints = 0;

    public void Init()
    {
        OnPlayerAddedPoints = AddPoint;
        eventHandler.AddEventToDict("OnPlayerAddedPoints", OnPlayerAddedPoints);
        eventHandler.SubscribeToEvent("OnPlayerAddedPoints", "OnAddedPoints");
        OnPlayerDeath = Stop;
        eventHandler.AddEventToDict("OnPlayerDeath", OnPlayerDeath);
        eventHandler.SubscribeToEvent("OnPlayerDeath", "OnDied");
    }

    private void Stop()
    {
        eventHandler.UnsubscribeToEvent("OnPlayerAddedPoints", "OnAddedPoints");
        eventHandler.UnsubscribeToEvent("OnPlayerDeath", "OnDied");
    }

    private void AddPoint()
    {
        currentPoints++;
        print(currentPoints);
    }
}
