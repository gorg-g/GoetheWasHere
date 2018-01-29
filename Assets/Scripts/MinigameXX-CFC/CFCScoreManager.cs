using UnityEngine;
using UnityEngine.UI;

public class CFCScoreManager : ScoreManager
{
    void Start()
    {
        GameObject minigameManagerGO = GameObject.FindWithTag("MinigameManager");
        if (minigameManagerGO != null)
        {
            minigameName = minigameManagerGO.GetComponent<MiniGameManager>().minigameName;
        }

        ReadHighscore();
    }

    public void IncreaseScore(int incNPoints)
    {
        scoreCounter += incNPoints;    
    }

    public void DecreaseScore(int decNPoints)
    {
        scoreCounter -= decNPoints;

        if (scoreCounter < 0)
            scoreCounter = 0;
    }
}
