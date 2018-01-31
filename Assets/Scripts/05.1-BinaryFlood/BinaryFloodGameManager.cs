using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BinaryFloodGameManager : MiniGameManager
{
    public PlaneController t1;
    public PlaneController t2;
    public PlaneController t3;
    public PlaneController t4;

    public TextMesh PText;

    public GameObject Water;

    public GameWinIndicator gameWin;

    public int nNumbersToPlay;
    public float waterSpeed = 0.8f;

    public Text endText;

    bool one;
    bool two;
    bool three;
    bool four;

    int number;
    int[] priorLevels;
    int level;



    float timeLastCorrect;


    protected override void MinigameSpecificStart()
    {
        GameObject scoreManagerGO = GameObject.FindWithTag("ScoreManager");
        if (scoreManagerGO != null)
        {
            scoreManager = scoreManagerGO.GetComponent<BinaryFloodScoreManager>();
            scoreManager.ReadHighscore();
        }

        // Just to not click a panel by accident when starting game
        t1.Activate();
        t2.Activate();
        t3.Activate();
        t4.Activate();

        if (nNumbersToPlay > 15)
        {
            nNumbersToPlay = 15;
            Debug.Log("Maximum number of playable numbers is 15.");
        }

        priorLevels = new int[nNumbersToPlay];

        number = Random.Range(1, 16); //init decimal number
        PText.text = number.ToString();
        priorLevels[0] = number;
        level = 0;
        timeLastCorrect = Time.time;
    }

    void FixedUpdate()
    {
        if (gameStarted && !gameEnded)
        {
            CheckStatus();
            CheckWinningCondition();
            RiseWater();
        }
    }

    void CheckStatus()
    {
        one = t1.getChecking();
        two = t2.getChecking();
        three = t3.getChecking();
        four = t4.getChecking();
    }

    int generateNumber()
    {
        int genNumber;
        int Repeat = 0;
        bool canGenerate = false;
        Repeat = 0;
        genNumber = 0;
        while (!canGenerate)
        {
            genNumber = Random.Range(1, 16);
            for (int i = 0; i < level; i++)
            {
                if (priorLevels[i] == genNumber)
                {
                    Repeat++;
                }
            }
            if (Repeat == 0)
            {
                canGenerate = true;
            }
            else
            {
                Repeat = 0;
            }
        }
        return genNumber;

    }

    void CheckWinningCondition()
    {
        // Go through decimal numbers and check if binary format specified by player is correct
        switch (number)
        {

            case 1:
                if (!one && !two && !three && four)
                {
                    ContinueWithNext();
                }
                break;

            case 2:
                if (!one && !two && three && !four)
                {
                    ContinueWithNext();
                }
                break;

            case 3:
                if (!one && !two && three && four)
                {
                    ContinueWithNext();
                }
                break;

            case 4:
                if (!one && two && !three && !four)
                {
                    ContinueWithNext();
                }
                break;

            case 5:
                if (!one && two && !three && four)
                {
                    ContinueWithNext();
                }
                break;

            case 6:
                if (!one && two && three && !four)
                {
                    ContinueWithNext();
                }
                break;

            case 7:
                if (!one && two && three && four)
                {
                    ContinueWithNext();
                }
                break;

            case 8:
                if (one && !two && !three && !four)
                {
                    ContinueWithNext();
                }
                break;

            case 9:
                if (one && !two && !three && four)
                {
                    ContinueWithNext();
                }
                break;

            case 10:
                if (one && !two && three && !four)
                {
                    ContinueWithNext();
                }
                break;

            case 11:
                if (one && !two && three && four)
                {
                    ContinueWithNext();
                }
                break;

            case 12:
                if (one && two && !three && !four)
                {
                    ContinueWithNext();
                }
                break;

            case 13:
                if (one && two && !three && four)
                {
                    ContinueWithNext();
                }
                break;

            case 14:
                if (one && two && three && !four)
                {
                    ContinueWithNext();
                }
                break;

            case 15:
                if (one && two && three && four)
                {
                    ContinueWithNext();
                }
                break;
        }
    }

    void ContinueWithNext()
    {
        StartCoroutine(correctSolutionAnimation());
        LowerWater();

        if (level < nNumbersToPlay - 1)
        {
            level = level + 1;

            float deltaTime = Time.time - timeLastCorrect;
            int changeScore = Mathf.RoundToInt(Mathf.Max((5.0f - deltaTime) * 20.0f, 0.0f));
            scoreManager.IncreaseScore(changeScore);
            timeLastCorrect = Time.time;

            priorLevels[level] = number;
            number = generateNumber();
            PText.text = number.ToString();
        }
        else
        {
            CheckSuccess();
        }
    }

    void ResetNumbers()
    {
        //Alle Zahlen wieder zu null werden lassen
        t1.reset();
        t2.reset();
        t3.reset();
        t4.reset();
    }

    void RiseWater()
    {
        if (Water.transform.position.y >= 3.8f)
        {
            //nach ca. 20 Sekunden
            SpielVerloren();
        }
        else
        {
            //Water.transform.localScale += new Vector3(0, 0.1F, 0) * Time.deltaTime * waterSpeed;
            Water.transform.position += new Vector3(0, 0.1F, 0) * Time.deltaTime * waterSpeed;
        }
    }

    void LowerWater()
    {
        if (Water.transform.position.y <= 0.6f)
        {
            Water.transform.position = new Vector3(0, 0.04f, 0);
        }
        else
        {
            Water.transform.position -= new Vector3(0, 0.2f, 0);
        }
    }

    void CheckSuccess()
    {
        // Implement something meaningful here...
        SpielGewonnen();
    }

    void SpielGewonnen()
    {
        Debug.Log("Spiel gewonnen!");
        //setze gameOver auf true --> kein Input mehr möglich
        t1.gameOver = true;
        t2.gameOver = true;
        t3.gameOver = true;
        t4.gameOver = true;

        gameWin.setGameWon(true);
        StartCoroutine(WinGameAnimation());
        EndGame();

    }
    void SpielVerloren()
    {
        Debug.Log("Spiel verloren!");
        //setze gameOver auf true --> kein Input mehr möglich
        endText.text = "You were too slow. Z26 got destroyed by the flood.";
        gameWin.setGameWon(false);

        t1.gameOver = true;
        t2.gameOver = true;
        t3.gameOver = true;
        t4.gameOver = true;

        StartCoroutine(LoseGameAnimation());
        EndGame();
    }

    IEnumerator correctSolutionAnimation()
    {
        t1.changeColor();
        t2.changeColor();
        t3.changeColor();
        t4.changeColor();
        yield return new WaitForSeconds(1);
        ResetNumbers();
        t1.changeColorBack();
        t2.changeColorBack();
        t3.changeColorBack();
        t4.changeColorBack();
    }

    IEnumerator WinGameAnimation()
    {
        while (true)
        {
            PText.text = ":)";
            yield return new WaitForSeconds(1);
            PText.text = "(:";
            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator LoseGameAnimation()
    {
        while (true)
        {
            PText.text = ":(";
            yield return new WaitForSeconds(1);
            PText.text = "):";
            yield return new WaitForSeconds(1);
        }
    }
}