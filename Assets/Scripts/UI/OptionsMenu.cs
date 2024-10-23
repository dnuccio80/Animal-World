using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{

    public event EventHandler OnVolumeChange;
    public event EventHandler OnPanelHide;

    [SerializeField] private Button soundVolumeButton;
    [SerializeField] private Button musicVolumeButton;
    [SerializeField] private Button backButton;
    [SerializeField] private TextMeshProUGUI soundVolumeText;
    [SerializeField] private TextMeshProUGUI musicVolumeText;

    private float soundVolume;
    private float musicVolume;

    private void Awake()
    {
        soundVolumeButton.onClick.AddListener(() =>
        {
            IncrementSoundVolume();
        });

        musicVolumeButton.onClick.AddListener(() =>
        {
            IncrementMusicVolume();

        });

        backButton.onClick.AddListener(() =>
        {
            Hide();
        });
    }

    private void Start()
    {
        soundVolume = PlayerPrefs.GetFloat(Dictionary.SOUND_VOLUME, .3f);
        musicVolume = PlayerPrefs.GetFloat(Dictionary.MUSIC_VOLUME, .6f);
        UpdateVisual();
        Hide();

    }

    public void Show()
    {
        gameObject.SetActive(true);
        transform.SetAsLastSibling();
        soundVolumeButton.Select();
    }

    private void Hide()
    {
        gameObject.SetActive(false);
        OnPanelHide?.Invoke(this, EventArgs.Empty);
    }

    public void IncrementSoundVolume()
    {
        soundVolume += .1f;
        if (soundVolume > 1f) { soundVolume = 0f; }
        UpdateVisual();
    }

    public void IncrementMusicVolume()
    {
        musicVolume += .1f;
        if (musicVolume > 1f) { musicVolume = 0f; }
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        float multiplier = 10;
        soundVolumeText.text = "Sound Volume: " + Mathf.RoundToInt(soundVolume * multiplier);
        musicVolumeText.text = "Music Volume: " + Mathf.RoundToInt(musicVolume * multiplier);
        SaveVolumeData();
    }

    private void SaveVolumeData()
    {
        PlayerPrefs.SetFloat(Dictionary.SOUND_VOLUME, soundVolume);
        PlayerPrefs.SetFloat(Dictionary.MUSIC_VOLUME, musicVolume);
        OnVolumeChange?.Invoke(this, EventArgs.Empty);
    }

}
