using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    private BPGameManager gameManager;
    private BPPlayerController player;

    // Use this for initialization
    void Start()
    {
        GameObject gameManagerGO = GameObject.FindWithTag("MinigameManager");
        if (gameManagerGO != null)
        {
            gameManager = gameManagerGO.GetComponent<BPGameManager>();
        }
        else
        {
            Debug.Log("Couldn't find MinigameManager. Did you forget the tag?");
        }

        player = GetComponent<BPPlayerController>();
    }

    void Update()
    {
        if (gameManager.GameHasStarted() && !gameManager.GameHasEnded())
        {
            if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                if (Input.touchCount > 0)
                {
                    Touch thisTouch = Input.GetTouch(0);

                    if (thisTouch.phase == TouchPhase.Ended || thisTouch.phase == TouchPhase.Canceled)
                    {
                        // Throw ball
                        player.Throw();
                    }
                    else
                    {
                        // Move Player
                        Vector3 touchPosition = thisTouch.position;
                        player.Move(touchPosition);
                    }

                }
                else
                {
                    // check whether ball has to be respawned
                    player.CheckMovement();
                }
            }

            // This is only for debugging purposes and not important for the actual iOS Game
            else if (Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.OSXPlayer ||
        Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
            {

                // Mouse Button pressed down
                if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0))
                {
                    // Move Player to new position
                    Vector3 clickPosition = Input.mousePosition;
                    player.Move(clickPosition);
                }
                else
                {
                    // Release of Mouse Button
                    if (Input.GetMouseButtonUp(0))
                    {
                        // Throw Ball
                        player.Throw();
                    }
                    // Not pressed down and not previously released
                    else
                    {
                        // check whether ball has to be respawned
                        player.CheckMovement();
                    }
                }
            }
        }
    }
}