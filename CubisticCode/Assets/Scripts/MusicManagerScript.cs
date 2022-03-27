using UnityEngine;
using UnityEngine.UI;

public class MusicManagerScript : MonoBehaviour
{
    public Slider VolumeSlider;
    public Dropdown SongDropdown;

    private void Start()
    {
        VolumeSlider.normalizedValue = PlayerPrefs.GetFloat("VolumeSlider", 0.4f);
        SongDropdown.value = FindObjectOfType<AudioManagerScript>().GetSong();
    }

    public void VolumeChanger(float newVol)
    {
        PlayerPrefs.SetFloat("VolumeSlider", newVol);
        FindObjectOfType<AudioManagerScript>().ChangeVolume(newVol);
    }

    public void SongChanger(int val)
    {
        FindObjectOfType<AudioManagerScript>().ChangeSong(val);
        FindObjectOfType<AudioManagerScript>().ChangeVolume(PlayerPrefs.GetFloat("VolumeSlider", 0.4f));
    }
}

