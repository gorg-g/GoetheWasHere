using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour 
{
    public PlayerProgress progress;
    public GameObject StartGameDecisionPanel;
    public GameObject MainMenuPanel;

	public void startGame()
    {
        if (progress.PlayerProgressedUntilScene==1)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            StartGameDecisionPanel.SetActive(true);
            MainMenuPanel.SetActive(false);
        }
    }
}
