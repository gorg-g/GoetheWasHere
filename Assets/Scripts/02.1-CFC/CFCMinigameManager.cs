using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CFCMinigameManager : MiniGameManager {
	//Enemies
	public GameObject minus;
	public GameObject plus;
	public GameObject fast;
	public GameObject slow;
	public GameObject bigplus;
	public GameObject bigminus;

	GameObject[] collect = new GameObject[11];

	//Spawninfos
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public float minutes;

	private bool gameIsOver;

	// Use this for initialization
	protected override void MinigameSpecificStart () 
    {
        GameObject scoreManagerGO = GameObject.FindWithTag("ScoreManager");
        if (scoreManagerGO != null)
        {
            scoreManager = scoreManagerGO.GetComponent<CFCScoreManager>();
            scoreManager.ReadHighscore();
        }

        GetComponent<AudioSource>().Play();

   		collect [0] = plus;
		collect [1] = plus;
		collect [2] = plus;
		collect [3] = plus;
		collect [4] = plus;
		collect [5] = minus;
		collect [6] = minus;
		collect [7] = slow;
		collect [8] = fast;
		collect [9] = bigplus;
		collect [10] = bigminus;

		StartCoroutine (SpawnWaves ());
		StartCoroutine (GameOver ());
	}
	
	IEnumerator SpawnWaves()
    {
		//Zeit bevor es losgeht
		yield return new WaitForSeconds (startWait);

		//Spawn der Meteoriten, zeitverzögert, damit sie sich nicht gegenseitig wegficken
        while (!gameEnded) 
        {
			for (int i = 0; i < hazardCount; i++) 
            {
				int rndm = Random.Range (0, 11);
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				
                GameObject helper = GameObject.Find ("enemies");

                if (helper != null)
                {
                    if (helper.activeSelf)
                    {
                        var m = Instantiate(collect[rndm], spawnPosition, spawnRotation);
                        m.transform.parent = helper.transform;

                        if (collect[rndm] == fast || collect[rndm] == slow)
                        {
                            m.transform.Rotate(new Vector3(0, 0, 90));
                        }
                    }
                }

                yield return new WaitForSeconds (spawnWait);
			}
		}
	}

	IEnumerator GameOver()
	{
		yield return new WaitForSeconds (minutes * 60);

        GameObject.FindWithTag("enemy").SetActive(false);
        EndGame();
	}
}