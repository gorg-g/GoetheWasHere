using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CR_GameControllerScript : MonoBehaviour {

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

    public Button btn;
    public Button strt;

    public Text scrtxt;
 
    public TrackBehaviour tb;


    public int score;

    private bool spielVorbei = false;
  
    void Start () {

        Time.timeScale = 0;
        btn.gameObject.SetActive(false);
        scrtxt.gameObject.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {

        if(spielVorbei == false)
        {
            CheckStatus();
        }
        
		
	}
    
     public void StartGame()
    {
        strt.gameObject.SetActive(false);
        Time.timeScale = 1;
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
        score = CalculateScore();
        Debug.Log(score);
        scrtxt.text = "Score: " + score;
        yield return new WaitForSeconds(2);
        tb.ResetToOrigin();

        btn.gameObject.SetActive(true);
        scrtxt.gameObject.SetActive(true);

        //yield return new WaitForSeconds(2);
      
        Time.timeScale = 0;

    }
    private int CalculateScore()
    {
        int s = Mathf.RoundToInt(500 - Time.time);
        if (s <= 0)
        {
            return 0;
        }
        else return s;
    }

    public void RestartGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
