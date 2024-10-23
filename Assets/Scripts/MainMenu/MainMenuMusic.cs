using UnityEngine;

public class MainMenuMusic : MonoBehaviour
{

    [SerializeField] private OptionsMenu optionsMenu;

    private AudioSource musicSource;

    private void Awake()
    {
        musicSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        musicSource.volume = PlayerPrefs.GetFloat(Dictionary.MUSIC_VOLUME, .2f);
        optionsMenu.OnVolumeChange += OptionsMenu_OnVolumeChange;
    }

    private void OptionsMenu_OnVolumeChange(object sender, System.EventArgs e)
    {
        musicSource.volume = PlayerPrefs.GetFloat(Dictionary.MUSIC_VOLUME, .2f);
    }
}
