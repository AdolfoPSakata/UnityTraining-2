using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameloopControler : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private ObstacleManager obstacleManager;

    private Action onPlayerDied;

    void Start()
    {
        AssetsDatabase.Init();
        obstacleManager.Init("Obstacle");
        playerManager.Init("Player");
        onPlayerDied += StopGame;
        playerManager.SubscribePlayer(onPlayerDied);
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
