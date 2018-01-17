using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collide : MonoBehaviour 
{
    private BPScoreManager scoreManager;
    private BPGameManager gameManager;

    private float tSinceLastHit;

    void Start()
    {
        tSinceLastHit = 0.0f;

        GameObject scoreManagerGO = GameObject.FindWithTag("ScoreManager");
        if (scoreManagerGO != null)
        {
            scoreManager = scoreManagerGO.GetComponent<BPScoreManager>();
        }

        GameObject gameManagerGO = GameObject.FindWithTag("MinigameManager");
        if (gameManagerGO != null)
        {
            gameManager = gameManagerGO.GetComponent<BPGameManager>();
        }  
    }

    void Update()
    {
        tSinceLastHit += Time.deltaTime;
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag ("Cup")) 
        {
            scoreManager.IncreaseScore(tSinceLastHit);
            tSinceLastHit = 0.0f;

            gameManager.nCupsHit += 1;

            other.gameObject.transform.parent.gameObject.SetActive(false);
            other.gameObject.SetActive (false);

            scoreManager.WriteHighscore();
        }
    }
}
