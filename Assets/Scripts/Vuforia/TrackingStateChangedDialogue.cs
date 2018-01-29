using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TrackingStateChangedDialogue : DefaultTrackableEventHandler {

    GameObject DialogueBoxGO;

    protected override void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);

        DialogueBoxGO = GameObject.FindWithTag("DialogueBox");

        if (DialogueBoxGO != null)
        {
            DialogueBoxGO.SetActive(false);
        }
        else
        {
            Debug.Log("Couldn't find Dialogue Box. Did you forget to set the tag?");
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
            ShowDialogueBox();
            OnTrackingFound();

        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NOT_FOUND)
        {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
            HideDialogueBox();
            OnTrackingLost();
        }
        else
        {
            // For combo of previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND
            // Vuforia is starting, but tracking has not been lost or found yet
            // Call OnTrackingLost() to hide the augmentations
            OnTrackingLost();
        }
    }

    void ShowDialogueBox()
    {
        DialogueBoxGO.SetActive(true);
        GameObject.FindWithTag("Scientist").GetComponent<Animator>().SetBool("trackingActive", true);
    }

    void HideDialogueBox()
    {
        DialogueBoxGO.SetActive(false);
        GameObject.FindWithTag("Scientist").GetComponent<Animator>().SetBool("trackingActive", false);
    }
}
