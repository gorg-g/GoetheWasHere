using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWinIndicator : MonoBehaviour 
{
    private bool gameWon;

	// Use this for initialization
	void Start () 
    {
        DontDestroyOnLoad(gameObject);
	}

    public void setGameWon(bool success)
    {
        gameWon = success;
    }

    public bool getGameWon()
    {
        return gameWon;
    }
}
