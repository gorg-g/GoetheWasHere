using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MiniGameManager : MonoBehaviour 
{
    public GameObject gameIntroPanel;
    public GameObject gameEndPanel;
    public string minigameName;

    private BPScoreManager scoreManager; 

    protected bool gameStarted;
    protected bool gameEnded;

    public void Start()
    {
        gameIntroPanel.SetActive(true);
        gameEndPanel.SetActive(false);
        gameStarted = false;
        gameEnded = false;

        GameObject scoreManagerGO = GameObject.FindWithTag("ScoreManager");
        if (scoreManagerGO != null)
        {
            scoreManager = scoreManagerGO.GetComponent<BPScoreManager>();
            scoreManager.ReadHighscore();
        }
    }

    public bool GameHasStarted()
    {
        return gameStarted;
    }

    public bool GameHasEnded()
    {
        return gameEnded;
    }

    public void StartGame()
    {
        gameIntroPanel.SetActive(false);
        StartCoroutine(PrepareGame());

    }
    public void EndGame()
    {
        StartCoroutine(PrepareAftergame());
        scoreManager.WriteHighscore();
    }

    private IEnumerator PrepareGame()
    {
        yield return new WaitForSeconds(0.5f);
        gameStarted = true;
    }

    private IEnumerator PrepareAftergame()
    {
        yield return new WaitForSeconds(0.5f);
        gameEnded = true;
        gameEndPanel.SetActive(true);
    }

}
