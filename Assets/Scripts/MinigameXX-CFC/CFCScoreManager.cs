using UnityEngine;
using UnityEngine.UI;

public class CFCScoreManager : ScoreManager
{

    //Score Variables
    //public Text scoreText;

 
    private bool gameOver;
    private bool restart;

    public int score;


    void Start()
    {

        gameOver = false;
        restart = false;

        score = 0;
        UpdateLocalScore();

    }



    public void AddScore(int newScoreValue)
    {
        /*
        score += newScoreValue;
        Debug.Log(score);
        */

        scoreCounter += newScoreValue;
        Debug.Log(scoreCounter);
    
        UpdateHighScore();

    }

    void UpdateLocalScore()
    {

        scoreText.text = "Score: " + score;

    }

    public void GameOver()
    {
     
        gameOver = true;
    }

    public int GetScore()
    {

        return score;

    }
}
