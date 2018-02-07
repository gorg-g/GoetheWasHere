using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZuseWinningCondition : MonoBehaviour 
{
    public GameObject WinDialogue;
    public GameObject LoseDialogue;
    public GameObject ProgressGame;

    public void Start()
    {
        GameWinIndicator gameWinIndicator = GameObject.FindWithTag("GameWinIndicator").GetComponent<GameWinIndicator>();
        bool gameWon = gameWinIndicator.getGameWon();
        Destroy(GameObject.FindWithTag("GameWinIndicator"));

        if (gameWon)
        {
            WinDialogue.SetActive(true);
            ProgressGame.SetActive(true);
            GameObject.FindWithTag("Scientist").GetComponent<SetWinningCondition>().SetWinningState(true);
        }
        else
        {
            LoseDialogue.SetActive(true);
            GameObject.FindWithTag("Scientist").GetComponent<SetWinningCondition>().SetWinningState(false);
        }
    }
}
