using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyOnClickHand : MonoBehaviour {

	private GameObject MainCameraHumboldt;
	private GameObject MainCameraHelmholtz;
	private GameObject FistItem;
	private GameObject DialogueBox;
	private GameObject Conversation;
	private Text ConversationText;

    public AudioSource pickupSound;

	void OnMouseDown()
    {
        pickupSound.Play();
		Destroy(gameObject);
		MainCameraHumboldt = GameObject.Find ("Inventory");
        MainCameraHelmholtz = GameObject.Find ("InventoryHelmholtzDialogue");
		FistItem = MainCameraHumboldt.FindObject ("Fist Item");
		DialogueBox = MainCameraHelmholtz.FindObject ("DialogueBox");
		DialogueBox.SetActive (true);
		FistItem.SetActive (true);
	}
}
