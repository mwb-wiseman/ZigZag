using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GroundGeneration groundGeneration;
    public GameObject gameStartCanvas;
    public bool gameStarted;

    public void StartGame()
    {
        gameStarted = true;
        gameStartCanvas.SetActive(false);
        groundGeneration.StartBuilding();
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
