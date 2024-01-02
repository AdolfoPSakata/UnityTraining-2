using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionControler : MonoBehaviour
{
    [SerializeField] private GameObject optionCanvas;

    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;
    [SerializeField] private Button returnButton;

    [SerializeField] private Slider audioSlider;
    [SerializeField] private Image audioImage;
    [SerializeField] private Image duckImage;
    [SerializeField] private Image foodImage;
    
    [SerializeField] private AudioMixer masterVolume;

    [SerializeField] private TMP_Text strokeForce;

    private int index = 0;
    private float currentVolume = 0f;
    private string currentDuck = "";
    const string DUCK_KEY = "DUCK";
    const string INDEX_KEY = "INDEX";
    const string VOLUME_KEY = "VOLUME";
    private void Awake()
    {
        ReadScriptables.SetupOptions();

        index = PlayerPrefs.GetInt(INDEX_KEY, 0);
        audioSlider.onValueChanged.AddListener(delegate { SliderControl(); });
        leftButton.onClick.AddListener(delegate { DuckPagination(false); });
        rightButton.onClick.AddListener(delegate { DuckPagination(true); });
        returnButton.onClick.AddListener(Close);
        SetSlider();
    }

    private void Start()
    {
        currentVolume = PlayerPrefs.GetFloat(VOLUME_KEY);
        masterVolume.SetFloat("volume", Mathf.Log10(currentVolume) * 100);
    }

    public void Close()
    {
        SavePreferences();
        optionCanvas.SetActive(false);
    }

    private int ChangeIndex(bool isAdding)
    {
        if (isAdding)
            index++;
        else
            index--;

        if (index >= ReadScriptables.GetPlayerDataLenght())
            return index = 0;
        else if (index <= 0)
            return index = ReadScriptables.GetPlayerDataLenght() - 1;
        else
            return index;
    }

    public void DuckPagination(bool isAdding)
    {
        index = ChangeIndex(isAdding);

        PlayerData currentData = ReadScriptables.GetPlayerData(index);
        currentDuck = currentData.prefabName;
        duckImage.sprite = currentData.body;
        foodImage.sprite = currentData.body;
        strokeForce.text = currentData.jumpForce.ToString();
    }

    public void SliderControl()
    {
        float sliderValue = audioSlider.value;
        masterVolume.SetFloat("volume", Mathf.Log10(sliderValue) * 100);
    }

    public void SetSlider()
    {
        audioSlider.value = currentVolume;
    }
    
    private void SavePreferences()
    {
        PlayerPrefs.SetString(DUCK_KEY, currentDuck);
        PlayerPrefs.SetFloat(VOLUME_KEY, audioSlider.value);
        PlayerPrefs.SetFloat(INDEX_KEY, index);
        PlayerPrefs.Save();
    }
}

