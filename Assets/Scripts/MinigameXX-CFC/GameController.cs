using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
//using NUnit.Framework.Internal;


using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {


	//Spawn Variables
	public GameObject minus;
	public GameObject plus;
	public GameObject fast;
	public GameObject slow;

	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	//Score Variables
	public Text scoreText;
	public Text restartText;
	public Text gameOverText;

	private bool gameOver;
	private bool restart;
	public Button restartButton;


	public int score;
	void Start(){
	

		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";


		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}


	void Update(){

		if (Input.GetKeyDown (KeyCode.R)) {

			Application.LoadLevel (Application.loadedLevel);

		}
	
	}

	IEnumerator SpawnWaves(){
		//Zeit bevor es losgeht
		yield return new WaitForSeconds (startWait);

		//Spawn der Meteoriten, zeitverzögert, damit sie sich nicht gegenseitig wegficken
		while(true)
		{
			for (int i = 0; i < hazardCount; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (minus, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
			if (gameOver) {

				restartText.text = "Press 'R' to Restart";
				restart = true;
				break;
			}

		}

	}

	public void AddScore (int newScoreValue)
	{
	
		score += newScoreValue;
		UpdateScore ();;

	}


	void UpdateScore()
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

	/*
	public void playButton(){

		Scene scene = SceneManager.GetActiveScene ();
		SceneManager.LoadScene (scene.name);
		restartButton.interactable = false;

	}
	*/

}
