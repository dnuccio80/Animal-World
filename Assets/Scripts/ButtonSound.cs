using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    [SerializeField] private OptionsMenu optionsMenu;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        optionsMenu.OnVolumeChange += OptionsMenu_OnVolumeChange;    
        audioSource.volume = PlayerPrefs.GetFloat(Dictionary.SOUND_VOLUME, 0.2f);
    }

    private void OptionsMenu_OnVolumeChange(object sender, System.EventArgs e)
    {
        UpdateVolume();
    }

    public void EmitSound()
    {
        audioSource.PlayOneShot(audioSource.clip);
    }

    private void UpdateVolume()
    {
        audioSource.volume = PlayerPrefs.GetFloat(Dictionary.SOUND_VOLUME, 0.2f);
    }


}
