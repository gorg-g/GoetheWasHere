using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MiniGameManager : MonoBehaviour 
{
    public GameObject gameIntroPanel;
    public GameObject gameEndPanel;
    public string minigameName;
    public int CheckLocationInterval;

    public enum Buildings {Humboldt=2, Kirchhoff=3, Helmholtz=4, Zuse=5};
    public Buildings building;

    protected ScoreManager scoreManager;
    private GPS gpsChecker;

    protected bool gameStarted;
    protected bool gameEnded;

    public void Start()
    {
        gameIntroPanel.SetActive(true);
        gameEndPanel.SetActive(false);
        gameStarted = false;
        gameEnded = false;

        gpsChecker = GetComponent<GPS>();
        StartCoroutine(CheckPlayerLocation());
    }

    protected virtual void MinigameSpecificStart()
    {       
    }

    IEnumerator CheckPlayerLocation()
    {
        int previousLocation = 0;
        int consecutiveCounter = 0;

        while (true)
        {
            int playerLocation = gpsChecker.GetClosestBuilding();

            if (playerLocation == previousLocation)
                consecutiveCounter += 1;
            else
                consecutiveCounter = 0;

            previousLocation = playerLocation;

            //switch (playerLocation)
            //{
            //    case (int) Buildings.Humboldt:
            //        // Load Humboldt scene if GPS Location is consecutively Humboldt for long enough
            //        if ((!(building == Buildings.Humboldt)) && consecutiveCounter > 3)
            //        {
            //            print(building);
            //            LoadByIndex(2);
            //        }
                    
            //        break;

            //    case (int) Buildings.Kirchhoff:
            //        // Load Kirchhoff scene if GPS Location is consecutively Humboldt for long enough
            //        if ((!(building == Buildings.Kirchhoff)) && consecutiveCounter > 3)
            //        {
            //            print(building);
            //            LoadByIndex(3);
            //        }
                    
            //        break;

            //    case (int)Buildings.Helmholtz:
            //        // Load Helmholtz scene if GPS Location is consecutively Humboldt for long enough
            //        if ((!(building == Buildings.Helmholtz)) && consecutiveCounter > 3)
            //        {
            //            print(building);
            //            LoadByIndex(4);
            //        }

            //        break;

            //    case (int) Buildings.Zuse:
            //        // Load Zuse scene if GPS Location is consecutively Humboldt for long enough
            //        if ((!(building == Buildings.Zuse)) && consecutiveCounter > 3)
            //        {
            //            print(building);
            //            LoadByIndex(5);
            //        }
                    
            //        break;
            //    case 6:
            //        // Load Test Location
            //        break;
            //    case 0:
            //        // stay in current scene (error in GPS or location not found)
            //        break;
            //}

            yield return new WaitForSeconds(CheckLocationInterval);
        }
    }

    public bool GameHasStarted()
    {
        return gameStarted;
    }

    public bool GameHasEnded()
    {
        return gameEnded;
    }

    public void StartGame()
    {
        gameIntroPanel.SetActive(false);
        StartCoroutine(PrepareGame());

    }
    public void EndGame()
    {
        StartCoroutine(PrepareAftergame());
        scoreManager.WriteHighscore();
    }

    private IEnumerator PrepareGame()
    {
        MinigameSpecificStart();
        yield return new WaitForSeconds(0.5f);
        gameStarted = true;
    }

    private IEnumerator PrepareAftergame()
    {
        yield return new WaitForSeconds(0.5f);
        gameEnded = true;
        gameEndPanel.SetActive(true);
    }

    private void LoadByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

}
