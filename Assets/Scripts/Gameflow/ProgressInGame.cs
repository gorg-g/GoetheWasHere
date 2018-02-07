using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgressInGame : MonoBehaviour 
{
    public void Start()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("Progress", sceneIndex);
    }

}
