using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance = null;

    public AudioSource menuMusic;
    public AudioSource gameMusic;
    public AudioSource buttonClick;
    public AudioSource collectable1;
    public AudioSource collectable2;
    public AudioSource gameOver;

    private bool musicPlaying = false;

    public void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void Start()
    {
        PlayMusic();
    }

    public void Update()
    {
        menuMusic.volume = PlayerPrefs.GetFloat("MusicVolume");
        gameMusic.volume = PlayerPrefs.GetFloat("MusicVolume");

        // Loop management for menu music
        if (SceneManager.GetActiveScene().buildIndex == 0)
            menuMusic.loop = true;
        else
            menuMusic.loop = false;

        if (!menuMusic.isPlaying && !gameMusic.isPlaying)
            musicPlaying = false;

        if(!musicPlaying && !gameOver.isPlaying)
        {
            PlayMusic();
        }
    }

    public void PlayMusic()
    {
        AudioSource music;

        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                music = menuMusic;
                break;
            case 1:
                music = gameMusic;
                break;
            default:
                music = null;
                break;
        }

        if (!musicPlaying && PlayerPrefs.GetInt("MusicOnOrOff") == 1)
        {
            music.Play();
            musicPlaying = true;
        }
    }

    public void PlayMusic(int sceneId)
    {
        AudioSource music;

        switch (sceneId)
        {
            case 0:
                music = menuMusic;
                break;
            case 1:
                music = gameMusic;
                break;
            default:
                music = null;
                break;
        }

        if (!musicPlaying && PlayerPrefs.GetInt("MusicOnOrOff") == 1)
        {
            music.Play();
            musicPlaying = true;
        }
    }

    public void StopMusic()
    {
        AudioSource music;

        if (menuMusic.isPlaying)
            music = menuMusic;
        else if (gameMusic.isPlaying)
            music = gameMusic;
        else
            music = null;

        if (musicPlaying)
        {
            music.Stop();
            musicPlaying = false;
        }
    }

    public void PlaySound(AudioSource sound)
    {
        if(PlayerPrefs.GetInt("SoundOnOrOff") == 1)
        {
            sound.volume = PlayerPrefs.GetFloat("SoundVolume");
            sound.Play();
        }
    }
}
