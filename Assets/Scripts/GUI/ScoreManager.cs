using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour 
{
    public Text scoreText;
    public Text highscoreText;

    protected int scoreCounter;
    protected int highscoreCounter;

    protected string minigameName;

	void Update () 
    {
        UpdateScoreText();
	}

    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + scoreCounter;

        highscoreText.text = "Highscore: " + highscoreCounter;
    }

    public void WriteHighscore()
    {
        if (scoreCounter > highscoreCounter)
            highscoreCounter = scoreCounter;
        
        PlayerPrefs.SetInt(minigameName, highscoreCounter);
    }

    public void ReadHighscore()
    {
        if (PlayerPrefs.HasKey(minigameName))
        {
            highscoreCounter = PlayerPrefs.GetInt(minigameName);
        }
        else
        {
            highscoreCounter = 0;
        }
    }
}
