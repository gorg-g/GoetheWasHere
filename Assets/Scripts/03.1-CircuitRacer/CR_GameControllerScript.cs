using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CR_GameControllerScript : MiniGameManager {

    public Checkpoint check1;
    public Checkpoint check2;
    public Checkpoint check3;
    public Checkpoint check4;
    public Checkpoint check5;
    public Checkpoint check6;
    public Checkpoint check8;
    public Checkpoint check9;
    public Checkpoint check10;
    public Checkpoint check11;
    public Checkpoint check12;
    public Checkpoint check13;

 
    public TrackBehaviour tb;

    public CRScoreManager scoremng;


    public int score;

    private bool spielVorbei = false;
  
    void Start () {

        Time.timeScale = 0;

    }
	

	void Update () {

        if(spielVorbei == false)
        {
            CheckStatus();
        }
        
		
	}

    protected override void MinigameSpecificStart()
    {
        Time.timeScale = 1;
        GetComponent<AudioSource>().Play();
    }

    void CheckStatus()
    {
        if(check1.passed && check2.passed && check3.passed && check4.passed && check5.passed && check6.passed  && check8.passed && check9.passed && check10.passed && check11.passed && check12.passed && check13.passed)
        {
            StartCoroutine(Gewonnen());
        }
    }

    IEnumerator Gewonnen()
    {
        
        spielVorbei = true;
        Debug.Log("Gewonnen!");
        scoremng.SetScore();

        //scrtxt.text = "Score: " + score;
        yield return new WaitForSeconds(2);
        tb.ResetToOrigin();
        EndGame();

        //btn.gameObject.SetActive(true);
        //scrtxt.gameObject.SetActive(true);

        //yield return new WaitForSeconds(2);

        Time.timeScale = 0;

    }


    public void RestartGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
