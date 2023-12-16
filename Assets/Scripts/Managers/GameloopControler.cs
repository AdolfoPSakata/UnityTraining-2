using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameloopControler : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private ObstacleManager obstacleManager;
    [SerializeField] private PointManager pointManager;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private EventHandler eventHandler;
    private Action OnPlayerDied;

    void Start()
    {
        AssetsDatabase.Init();
        ReadScriptables.Init();

        eventHandler.Init();
        playerManager.Init("Player_Base");
        obstacleManager.Init("Obstacle_Base");
        pointManager.Init();
        inputManager.Init();
        OnPlayerDied = StopGame;
        eventHandler.AddEventToDict("OnPlayerDied", OnPlayerDied);
        eventHandler.SubscribeToEvent("OnPlayerDied", "OnDied");
    }

    private void StopGame()
    {
        obstacleManager.DisableAll();
        ResetGame();
    }

    private void ResetGame()
    {
        //TODO: SceneLoader needed
        SceneManager.LoadScene(0);
    }
}
