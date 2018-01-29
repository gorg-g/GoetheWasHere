using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TrackingStateChangedMinigame : DefaultTrackableEventHandler {

    GameObject DialogueBoxGO;
    GameObject HighscoreGO;
    GameObject MiniGameManagerGO;

    protected override void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);

        DialogueBoxGO = GameObject.FindWithTag("DialogueBox");
        HighscoreGO = GameObject.FindWithTag("ScoreManager");
        MiniGameManagerGO = GameObject.FindWithTag("MinigameManager");

        if (DialogueBoxGO != null)
        {
            DialogueBoxGO.SetActive(false);
        }
        else
        {
            Debug.Log("Couldn't find Dialogue Box. Did you forget to set the tag?");
        }

        if (HighscoreGO != null)
        {
            HighscoreGO.SetActive(false);
        }
        else
        {
            Debug.Log("Couldn't find Highscore. Did you forget to set the tag?");
        }

        if (MiniGameManagerGO == null)
        {
            Debug.Log("Couldn't find MinigameManager. Did you forget to set the tag?");
        }
    }

    public override void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
            ShowGame();
            OnTrackingFound();

        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NOT_FOUND)
        {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
            HideGame();
            OnTrackingLost();
        }
        else
        {
            // For combo of previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND
            // Vuforia is starting, but tracking has not been lost or found yet
            // Call OnTrackingLost() to hide the augmentations;
            OnTrackingLost();
        }
    }

    void ShowGame()
    {
        if(!MiniGameManagerGO.GetComponent<MiniGameManager>().GameHasStarted())
            DialogueBoxGO.SetActive(true);
        
        HighscoreGO.SetActive(true);
    }

    void HideGame()
    {
        DialogueBoxGO.SetActive(false);
        HighscoreGO.SetActive(false);
    }
}
