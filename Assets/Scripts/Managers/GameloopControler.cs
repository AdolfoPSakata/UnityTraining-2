using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameloopControler : MonoBehaviour
{
    [Header("Managers")]
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private ObstacleManager obstacleManager;
    [SerializeField] private PointManager pointManager;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private WallMovement wallManager;
    [SerializeField] private ItensManager itensManager;
    [SerializeField] private EventHandler eventHandler;

    [Header("UI")]
    [SerializeField] private const int COUNTDOWN_TIME = 3;

    [SerializeField] private GameObject countdownCanvas;
    [SerializeField] private TMP_Text countdown;

    [SerializeField] private GameObject endGameCanvas;
    [SerializeField] private Button leavebutton;
    [SerializeField] private Button restartButton;

    private Action OnPlayerDied;
    private Coroutine start;

    private void Awake()
    {
        start = StartCoroutine(StartGame());
    }

    private IEnumerator StartGame()
    {
        InitManager();
        SubscribeToEvents();
        InitUI();
        for (int i = COUNTDOWN_TIME; i > 0; i--)
        {
            countdown.text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        countdownCanvas.SetActive(false);
        playerManager.Init();
        obstacleManager.Init();
        inputManager.Init();
        itensManager.Init();
    }
    private void StopGame()
    {
        wallManager.DisableAll();
        endGameCanvas.SetActive(true);
        obstacleManager.DisableAll();
    }
    
    private void ResetGame()
    {
        SceneManager.LoadScene(1);
    }

    private void LeaveGame()
    {
        SceneManager.LoadScene(0);
    }

    private void InitManager()
    {
        AssetsDatabase.Setup();
        ReadScriptables.Setup();
        ReadScriptables.SetupFoods();
        eventHandler.Setup();
        playerManager.Setup("Player_Base");
        obstacleManager.Setup("Obstacle_Base");
        itensManager.Setup("Food_Base");
        pointManager.Setup();
        inputManager.Setup();
    }

    private void SubscribeToEvents()
    {
        OnPlayerDied = StopGame;
        eventHandler.AddEventToDict("OnPlayerDied", OnPlayerDied);
        eventHandler.SubscribeToEvent("OnPlayerDied", "OnDied");
    }

    private void InitUI()
    {
        countdownCanvas.SetActive(true);
        endGameCanvas.SetActive(false);
        leavebutton.onClick.AddListener(LeaveGame);
        restartButton.onClick.AddListener(ResetGame);
    }
}
