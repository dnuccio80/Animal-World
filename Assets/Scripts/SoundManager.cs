using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance { get; private set; }

    [SerializeField] private AudioClip correctSound;
    [SerializeField] private AudioClip incorrectSound;
    [SerializeField] private OptionsMenu optionsMenu;

    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

        }
        else Destroy(this);

        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        audioSource.volume = PlayerPrefs.GetFloat(Dictionary.SOUND_VOLUME, .2f);
        optionsMenu.OnVolumeChange += OptionsMenu_OnVolumeChange;
    }

    private void OptionsMenu_OnVolumeChange(object sender, System.EventArgs e)
    {
        audioSource.volume = PlayerPrefs.GetFloat(Dictionary.SOUND_VOLUME);
    }

    public void EmitCorrectSound()
    {
        audioSource.clip = correctSound;
        audioSource.Play();
    }

    public void EmitIncorrectSound()
    {
        audioSource.clip = incorrectSound;
        audioSource.Play();
    }
}
