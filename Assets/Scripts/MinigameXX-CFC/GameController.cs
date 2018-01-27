using UnityEngine;
using UnityEngine.UI;

public class GameController : ScoreManager {

	//Score Variables
	//public Text scoreText;
	public Text restartText;
	public Text gameOverText;

	private bool gameOver;
	private bool restart;

	public int score;


	void Start(){
	
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";

		score = 0;
		UpdateLocalScore ();

	}

	void Update(){


	}

	public void AddScore (int newScoreValue)
	{
        /*
        score += newScoreValue;
        Debug.Log(score);
        */
        
        scoreCounter += newScoreValue;
        Debug.Log(scoreCounter);
        UpdateScoreText();

        UpdateHighScore();

        

    }

	void UpdateLocalScore()
	{
	
		scoreText.text = "Score: " + score; 
	
	}

	public void GameOver()
	{
		gameOverText.text = "Good job!";
		gameOver = true;
	}

	public int getScore(){
	
		return score;

	}
}
