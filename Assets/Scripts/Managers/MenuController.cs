using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject optionCanvas;
    [SerializeField] private Button startButton;
    [SerializeField] private Button optionButton;
    [SerializeField] private Button exitButton;
   
    private void Awake()
    {
        PlayerPrefs.SetString("DUCK", "DUCK");
        PlayerPrefs.Save();
        startButton.onClick.AddListener(StartGame);
        optionButton.onClick.AddListener(OpenOption); ;
        exitButton.onClick.AddListener(ExitGame); ;
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OpenOption()
    {
        optionCanvas.SetActive(true);
    }
}
