using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddUpScores : MonoBehaviour {
    
   	void Update () 
    {
        Text totalScoretext = GetComponent<Text>();

        GameObject[] scores = GameObject.FindGameObjectsWithTag("HMenuScore");

        int totalscore = 0;

        foreach (GameObject score in scores)
        {
            Text scoreText = score.GetComponent<Text>();
            totalscore += int.Parse(scoreText.text);
        }

        totalScoretext.text = totalscore.ToString();
	}
}
