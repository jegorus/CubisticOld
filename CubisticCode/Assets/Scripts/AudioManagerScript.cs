using UnityEngine;
using UnityEngine.Audio;
using System;
using UnityEngine.UI;

public class AudioManagerScript : MonoBehaviour
{

    public int themeSong = 0;

    public Sound[] sounds;

    public static AudioManagerScript instance;

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        { 
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
         themeSong = 0;
         Play("Theme");
    }

    public void Play(string name)
    {
       Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Can't play the sound");
            return;
        }
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Can't stop the sound");
            return;
        }
        s.source.Stop();
    }

    public void ChangeSong(int value)
    {
        if (themeSong != value)
        {
            themeSong = value;

            if (value == 0)
            {
                Stop("Theme1");
                Play("Theme");
            }
            else
            {
                Stop("Theme");
                Play("Theme1");
            }
        }
    }

    public void ChangeVolume(float newVolume)
    {
        string name = "";
        if (themeSong == 0) name = "Theme";
        if (themeSong == 1) name = "Theme1";


        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Can't change the volume");
            return;
        }
        s.source.volume = newVolume;
    }

    public int GetSong()
    {
        return themeSong;
    }

}
