using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerProgress : MonoBehaviour 
{
    public int PlayerProgressedUntilScene;

	// Use this for initialization
	void Start () 
    {
        if (PlayerPrefs.HasKey("Progress"))
        {
            PlayerProgressedUntilScene = PlayerPrefs.GetInt("Progress");
        }
        else
        {
            PlayerProgressedUntilScene = 1;
        }
	}

    public void StartNewGame()
    {
        PlayerPrefs.DeleteAll();
        PlayerProgressedUntilScene = 1;
        PlayerPrefs.SetInt("Progress", PlayerProgressedUntilScene);
        SceneManager.LoadScene(PlayerProgressedUntilScene);
    }

    public void ResumeGame()
    {
        SceneManager.LoadScene(PlayerProgressedUntilScene);
    }
}
