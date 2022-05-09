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
            PlayerPrefs.SetInt("Highscore", currentScore);
            highScoreText.text = currentScore.ToString();
        }
    }

    public int GetHighScore()
    {
        int i = PlayerPrefs.GetInt("Highscore");
        return i;
    }
}
