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

        //Anpassen, dass nur Kinder gesucht werden
        GameObject unlockText = GetChildWithTag("HMenuLockText");
        GameObject lockSym = GetChildWithTag("HMenuLockSym");
        GameObject levelNameText = GetChildWithTag("HMenuLevel");
        GameObject score = GetChildWithTag("HMenuScore");

        if (PlayerPrefs.HasKey(levelName))
        {
            highscore = PlayerPrefs.GetInt(levelName);

            unlockText.SetActive(false);
            lockSym.SetActive(false);
            levelNameText.SetActive(true);
        }
        else
        {
            highscore = 0;

            unlockText.SetActive(true);
            lockSym.SetActive(true);
            levelNameText.SetActive(false);
        }

        Text scoreText = score.GetComponent<Text>();
        scoreText.text = highscore.ToString();
	}

    GameObject GetChildWithTag(string childTag)
    {
        foreach (Transform child in transform)
        {
            if (child.tag == childTag)
            {
                return child.gameObject;
            }
        }
        Debug.LogWarning("Couldn't find any GameObject with that tag. Check tagging again!");
        return null;
    }
}
