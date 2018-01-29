using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TrackingStateChangedMinigame : DefaultTrackableEventHandler {

    GameObject HideableGUI;

    protected override void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);

        HideableGUI = GameObject.FindWithTag("HideableGUI");

        if (HideableGUI != null)
        {
            HideableGUI.SetActive(false);
        }
        else
        {
            Debug.Log("Couldn't find HideableGUI. Did you forget to set the tag?");
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
        HideableGUI.SetActive(true);
    }

    void HideGame()
    {
        HideableGUI.SetActive(false);
    }
}
