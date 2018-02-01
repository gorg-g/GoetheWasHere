using UnityEngine;
using UnityEngine.UI;

public class BinaryFloodScoreManager : ScoreManager
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

    public override void IncreaseScore(int incNPoints)
    {
        scoreCounter += incNPoints;
    }
}
