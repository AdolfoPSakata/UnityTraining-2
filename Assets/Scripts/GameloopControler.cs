using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameloopControler : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private ObstacleManager obstacleManager;
    [SerializeField] private PointManager pointManager;
    [SerializeField] private EventHandler eventHandler;
    private Action OnPlayerDied;

    void Start()
    {
        AssetsDatabase.Init();
        eventHandler.Init();
        playerManager.Init("Player");
        obstacleManager.Init("Obstacle");
        pointManager.Init();
        OnPlayerDied = StopGame;
        eventHandler.AddEventToDict("OnPlayerDied", OnPlayerDied);
        eventHandler.SubscribeToEvent("OnPlayerDied", "OnDied");
    }

    private void StopGame()
    {
        //eventHandler.UnsubscribeToEvent("OnPlayerDied", "OnDied");
        //eventHandler.RemoveEventToDict("OnDied");
        //eventHandler.RemoveEventToDict("OnPlayerDied");
        
        obstacleManager.DisableAll();
        ResetGame();
    }

    private void ResetGame()
    {
        //TODO: SceneLoader needed
        SceneManager.LoadScene(0);
    }
}
