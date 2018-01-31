using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPScoreManager : ScoreManager 
{
    void Start()
    {
        GameObject minigameManagerGO = GameObject.FindWithTag("MinigameManager");
        if (minigameManagerGO != null)
        {
            minigameName = minigameManagerGO.GetComponent<BPGameManager>().minigameName;
        }

        ReadHighscore();
    }

    public void IncreaseScore(float tSinceLastHit)
    {
        int score = Mathf.RoundToInt(Mathf.Clamp((60.0f - tSinceLastHit), 0.0f, 60.0f));
        scoreCounter += score;
    }
}
