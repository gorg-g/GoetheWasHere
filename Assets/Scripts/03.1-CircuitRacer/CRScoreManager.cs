using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRScoreManager : ScoreManager{



	void Start () {

        GameObject minigameManagerGO = GameObject.FindWithTag("MinigameManager");
        if (minigameManagerGO != null)
        {
            minigameName = minigameManagerGO.GetComponent<MiniGameManager>().minigameName;
        }

        ReadHighscore();

    }

    public void IncreaseScore()
    {
        
    }

    public void SetScore()
    {
        scoreCounter += CalculateScore();
        Debug.Log(scoreCounter);
        WriteHighscore();
    }

    public void AddScore()
    {
        scoreCounter += 10;
        WriteHighscore();
    }

    private int CalculateScore()
    {
        int s = Mathf.RoundToInt(500 - Time.time);
        if (s <= 0)
        {
            return 0;
        }
        else return s;
    }
}
