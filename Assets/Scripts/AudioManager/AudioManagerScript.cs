using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    public static AudioManagerScript instance;

    public Sound[] backgroundMusicSounds, soundEffectsSounds;
    public AudioSource bgmSource, sfxSource;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayBGM("MainMenuBGM");
    }

    public void PlayBGM(string soundName)
    {
        Sound s = Array.Find(backgroundMusicSounds, x => x.soundName == soundName);

        if (s == null)
        {
            Debug.Log("BGM Sound is invalid.");
        }
        else
        {
            bgmSource.clip = s.soundClip;
            bgmSource.Play();
        }
    }


    public void PlaySFX(string soundName)
    {
        Sound s = Array.Find(backgroundMusicSounds, x => x.soundName == soundName);

        if (s == null)
        {
            Debug.Log("SFX Sound is invalid.");
        }
        else
        {
            sfxSource.PlayOneShot(s.soundClip);

        }
    }


}
