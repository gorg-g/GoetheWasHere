using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadScoreFromPrefs : MonoBehaviour {

    public string levelName;

	// Use this for initialization
	void Start () 
    {
        int highscore;
        if (PlayerPrefs.HasKey(levelName))
            highscore = PlayerPrefs.GetInt(levelName);
        else
            highscore = 0;

        Text scoreText = GetComponent<Text>();
        scoreText.text = highscore.ToString();
	}
}
