using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetWinningCondition : MonoBehaviour {

    public bool playerWon;

	void Start () 
    {
        GetComponent<Animator>().SetBool("gameWon", playerWon);
	}

    public void SetWinningState (bool winningState)
    {
        playerWon = winningState;
        GetComponent<Animator>().SetBool("gameWon", playerWon);
    }
}
