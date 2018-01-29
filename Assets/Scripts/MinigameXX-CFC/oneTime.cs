using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class oneTime : MonoBehaviour {
	//Enemies
	public GameObject minus;
	public GameObject plus;
	public GameObject fast;
	public GameObject slow;
	public GameObject bigplus;
	public GameObject bigminus;

	GameObject[] collect = new GameObject[11];

	public GameObject parent;

	public Text restartText;
	public Text gameOverText;

	public Button newGame;

	//Spawninfos
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public float minutes;

	private bool gameIsOver;
	private bool restart;

	// Use this for initialization
	void Start () 
    {
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
		while (true) {
			for (int i = 0; i < hazardCount; i++) 
            {
				int rndm = Random.Range (0, 11);
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;

				var m = Instantiate (collect [rndm], spawnPosition, spawnRotation);
				m.transform.parent = GameObject.Find ("enemies").transform;

				yield return new WaitForSeconds (spawnWait);
			}
		}	
	}

	IEnumerator GameOver()
	{
		yield return new WaitForSeconds (minutes * 60);
		Time.timeScale = 0;
		Debug.Log (GetComponent<GameController> ().getScore ());
		Time.timeScale = 0;

		int lala = GetComponent<GameController> ().getScore ();
		if (lala > 0) {
			gameOverText.text = "Your Score: " + lala + "\n\nGood job!";
		} else {
			gameOverText.text = "Your Score: " + lala + "\n\nPlease never play this game again!";
		}

		gameIsOver = true;
		yield return new WaitForSeconds (2);

	}

	public void neustart(){
		
		Scene scene = SceneManager.GetActiveScene ();
		//SceneManager.UnloadSceneAsync (scene.name);
		SceneManager.LoadScene (scene.name);

		gameIsOver = false;
	}



}


