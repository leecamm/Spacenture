using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundsForAssets: MonoBehaviour
{
    public AudioClip[] sounds;
    public AudioSource soundSource;

    private int selectSound;
    private float selectPitch;
    private float timer;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        // Pitch randomization
        selectPitch = Random.Range(0.5f, 1.5f);
        selectSound = Random.Range(0, sounds.Length);
        time = Random.Range(2.5f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > time)
        {
            //play sound
            soundSource.clip = sounds[selectSound];
            soundSource.pitch = selectPitch;
            soundSource.Play();

            //recalculate
            timer = 0;
            selectPitch = Random.Range(0.5f, 1.5f);
            selectSound = Random.Range(0, sounds.Length);
            time = Random.Range(2.5f, 5f);
        }
    }
}
