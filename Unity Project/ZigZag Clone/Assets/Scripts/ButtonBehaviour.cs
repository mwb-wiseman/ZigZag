using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour
{
    public MenuSettings menuSettings;

    private AudioManager audioManager;

    public void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void LoadSubMenu(GameObject subMenu)
    {
        audioManager.PlaySound(audioManager.buttonClick);

        if (subMenu.activeSelf)
        {
            subMenu.SetActive(false);
        }
        else
        {
            if (GameObject.FindGameObjectWithTag("SubMenu"))
            {
                GameObject.FindGameObjectWithTag("SubMenu").SetActive(false);
            }
            subMenu.SetActive(true);
        }
    }

    public void LoadGame(string difficulty)
    {
        audioManager.PlaySound(audioManager.buttonClick);

        menuSettings.SetDifficulty(difficulty);
        SceneManager.LoadScene(1);
    }

    public void ToggleSound()
    {
        // 0 = Off, 1 = On
        if (PlayerPrefs.GetInt("SoundOnOrOff") == 1)
        {
            PlayerPrefs.SetInt("SoundOnOrOff", 0);
            menuSettings.soundToggle.isOn = false;
        }
        else
        {
            PlayerPrefs.SetInt("SoundOnOrOff", 1);
            menuSettings.soundToggle.isOn = true;
            audioManager.PlaySound(audioManager.buttonClick);
        }

        // print("SoundOnOrOff = " + PlayerPrefs.GetInt("SoundOnOrOff").ToString());
    }

    public void ToggleMusic()
    {
        audioManager.PlaySound(audioManager.buttonClick);

        // 0 = Off, 1 = On
        if (PlayerPrefs.GetInt("MusicOnOrOff") == 1)
        {
            PlayerPrefs.SetInt("MusicOnOrOff", 0);
            menuSettings.musicToggle.isOn = false;
            audioManager.StopMusic();
        }
        else
        {
            PlayerPrefs.SetInt("MusicOnOrOff", 1);
            menuSettings.musicToggle.isOn = true;
            audioManager.PlayMusic();
        }

        // print("MusicOnOrOff = " + PlayerPrefs.GetInt("MusicOnOrOff").ToString());
    }

    public void QuitGame()
    {
        audioManager.PlaySound(audioManager.buttonClick);

        print("QuitGame() called");
        Application.Quit();
    }
}
