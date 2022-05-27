using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public Text currentScoreText;
    public Text highScoreText;

    private int currentScore;

    private void Awake()
    {
        highScoreText.text = GetHighScore().ToString();
    }

    public void UpdateCurrentScore()
    {
        currentScore++;
        currentScoreText.text = currentScore.ToString();

        if(currentScore > GetHighScore())
        {
            switch (PlayerPrefs.GetFloat("Difficulty"))
            {
                case 0.75f:
                    PlayerPrefs.SetInt("CakewalkScore", currentScore);
                    break;
                case 1f:
                    PlayerPrefs.SetInt("SpacewalkScore", currentScore);
                    break;
                case 1.5f:
                    PlayerPrefs.SetInt("Death_MarchScore", currentScore);
                    break;
                default:
                    break;
            }
            highScoreText.text = currentScore.ToString();
        }
    }

    public int GetHighScore()
    {
        int i;

        switch (PlayerPrefs.GetFloat("Difficulty"))
        {
            case 0.75f:
                i = PlayerPrefs.GetInt("CakewalkScore");
                break;
            case 1f:
                i = PlayerPrefs.GetInt("SpacewalkScore");
                
                break;
            case 1.5f:
                i = PlayerPrefs.GetInt("Death_MarchScore");
                break;
            default:
                i = 0;
                break;
        }

        return i;
    }
}
