using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviourInGame : MonoBehaviour
{
    public GroundGeneration groundGeneration;

    private GameManager gameManager;
    private AudioManager audioManager;
    private PlayerMovement playerMovement;

    public void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        audioManager = FindObjectOfType<AudioManager>();
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    public void LoadSettingsMenu(GameObject subMenu)
    {
        if (subMenu.activeSelf && gameManager.gameStarted)
        {
            audioManager.PlaySound(audioManager.buttonClick);
            subMenu.SetActive(false);
            groundGeneration.StartBuilding();
        }
        else if (subMenu.activeSelf && !gameManager.gameStarted)
        {
            audioManager.PlaySound(audioManager.buttonClick);
            subMenu.SetActive(false);
        }
        else
        {
            if (!playerMovement.cutLoose)
            {
                audioManager.PlaySound(audioManager.buttonClick);
                subMenu.SetActive(true);
                groundGeneration.CancelGeneration();
            }
        }
    }

    public void LoadMenu()
    {
        audioManager.PlaySound(audioManager.buttonClick);
        audioManager.StopMusic();
        audioManager.PlayMusic(0);
        SceneManager.LoadScene(0);
    }

    public void OnClickStartGame()
    {
        if(!playerMovement.settingsMenu.activeSelf)
        gameManager.StartGame();
    }
}
