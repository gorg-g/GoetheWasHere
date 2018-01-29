using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ScoreManager : MonoBehaviour 
{
    public Text scoreText;
    public Text highscoreText;

    protected int scoreCounter;
    protected int highscoreCounter;

    private string minigameName;

	void Start () 
    {
        scoreCounter = 0;
        highscoreCounter = 0;

        GameObject minigameManagerGO = GameObject.FindWithTag("MinigameManager");
        if (minigameManagerGO != null)
        {
            minigameName = minigameManagerGO.GetComponent<MiniGameManager>().minigameName;
            ReadHighscore();
        }
	}
	
	void Update () 
    {
        UpdateScoreText();
	}

    public void UpdateHighScore()
    {
        if (scoreCounter > highscoreCounter)
        {
            highscoreCounter = scoreCounter;
        }
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + scoreCounter;
        highscoreText.text = "Highscore: " + highscoreCounter;
    }

    public void WriteHighscore()
    {
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
