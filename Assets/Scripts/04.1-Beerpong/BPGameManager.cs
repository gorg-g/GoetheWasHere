using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPGameManager : MiniGameManager 
{   
    byte nCupsHit;

    protected override void MinigameSpecificStart()
    {
        GameObject scoreManagerGO = GameObject.FindWithTag("ScoreManager");
        if (scoreManagerGO != null)
        {
            scoreManager = scoreManagerGO.GetComponent<BPScoreManager>();
            scoreManager.ReadHighscore();
        }

        GetComponent<AudioSource>().Play();
    }

	// Update is called once per frame
	void Update () 
    {
        if (nCupsHit == 10)
        {
            EndGame();
        }
		
	}

    public void IncreaseCupCount()
    {
        nCupsHit += 1;
    }
}
