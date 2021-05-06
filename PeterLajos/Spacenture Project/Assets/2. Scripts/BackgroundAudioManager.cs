using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public class BackgroundAudioManager : MonoBehaviour
{
    private int selectSound;
    private float soundPitch;
    private float timer;
    private float time;

    public Sound[] sounds;

    public static BackgroundAudioManager instance;

    private void Start()
    {
        // Play the sound called Theme
        Play("Theme");
    }

    private void Awake()
    {
        // This part helps so the sound is not breaking and starting again when changing between scenes
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

        // Search for the called sound in the array
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play (string name)
    {
        timer += Time.deltaTime;

        // Find the sound and make it "s"
        Sound s = Array.Find(sounds, sound => sound.name == name);

        // If there is something spelled wrongly, say this in log
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        // Play the sound
        s.source.Play();
    }
}
