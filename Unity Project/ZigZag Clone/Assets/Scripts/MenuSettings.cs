using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSettings : MonoBehaviour
{
    public Slider soundSlider;
    public Slider musicSlider;
    public Toggle soundToggle;
    public Toggle musicToggle;

    public void Awake()
    {
        if (!PlayerPrefs.HasKey("SoundOnOrOff"))
        {
            // if no PlayerPrefs setting, set sound default as on at 50% volume
            PlayerPrefs.SetInt("SoundOnOrOff", 1);
            SetSoundVolume(0.5f);
        }
            
        if (!PlayerPrefs.HasKey("MusicOnOrOff"))
        {
            // if no PlayerPrefs setting, set music default as on at 50% volume
            PlayerPrefs.SetInt("MusicOnOrOff", 1);
            SetMusicVolume(0.5f);
        }
    }

    public void Start()
    {
        soundToggle.SetIsOnWithoutNotify(Convert.ToBoolean(PlayerPrefs.GetInt("SoundOnOrOff")));
        soundSlider.value = PlayerPrefs.GetFloat("SoundVolume");

        musicToggle.SetIsOnWithoutNotify(Convert.ToBoolean(PlayerPrefs.GetInt("MusicOnOrOff")));
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
    }

    public void Update()
    {
        SetSoundVolume(soundSlider.value);
        SetMusicVolume(musicSlider.value);
    }

    public void SetSoundVolume(float volume)
    {
        PlayerPrefs.SetFloat("SoundVolume", volume);
    }

    public void SetMusicVolume(float volume)
    {
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void SetDifficulty(string difficulty)
    {
        float difficultyModifier = 1f;

        switch (difficulty)
        {
            case "Cakewalk":
                difficultyModifier = 0.75f;
                break;
            case "Spacewalk":
                difficultyModifier = 1f;
                break;
            case "Death_March":
                difficultyModifier = 1.5f;
                break;
            default:
                break;
        }

        PlayerPrefs.SetFloat("Difficulty", difficultyModifier);
    }
}
