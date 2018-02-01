using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyOnClickCrown : MonoBehaviour {

	private GameObject MainCameraHumboldt;
	private GameObject MainCameraZuse;
	private GameObject CrownItem;
	private GameObject DialogueBox;
	private GameObject Conversation;
	private Text ConversationText;

    public AudioSource pickupSound;

	void OnMouseDown(){ 
        pickupSound.Play();
		Destroy(gameObject);
		MainCameraHumboldt = GameObject.Find ("Inventory");
        MainCameraZuse = GameObject.Find ("InventoryZuseDialogue");
		CrownItem = MainCameraHumboldt.FindObject ("Crown Item");
		DialogueBox = MainCameraZuse.FindObject ("DialogueBox");
		DialogueBox.SetActive (true);
		CrownItem.SetActive (true);
	}
}
