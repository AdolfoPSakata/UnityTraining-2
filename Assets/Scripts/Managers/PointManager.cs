using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PointManager : MonoBehaviour
{
    [SerializeField] private EventHandler eventHandler;

    [SerializeField] private TMP_Text score;
    [SerializeField] private Image scoreImage;

    public Action OnPlayerAddedPoints;
    public Action OnPlayerDeath;

    int currentPoints = 0;

    public void Setup()
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
        score.text = "SCORE: " + currentPoints.ToString();
    }
}
