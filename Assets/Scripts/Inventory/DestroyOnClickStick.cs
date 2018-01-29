using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyOnClickStick : MonoBehaviour {

	private GameObject MainCameraHumboldt;
	private GameObject MainCameraKirchhoff;
	private GameObject StickItem;
	private GameObject DialogueBox;
	private GameObject Conversation;
	private Text ConversationText;

	void OnMouseDown(){ 
		Destroy(gameObject);
		MainCameraHumboldt = GameObject.Find ("Inventory");
        MainCameraKirchhoff = GameObject.Find ("InventoryDialogueKirchhoff");
		StickItem = MainCameraHumboldt.FindObject ("Stick Item");
		DialogueBox = MainCameraKirchhoff.FindObject ("DialogueBox");
		DialogueBox.SetActive (true);
		StickItem.SetActive (true);
	}


}
