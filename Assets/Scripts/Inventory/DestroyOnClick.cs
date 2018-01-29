using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnClick : MonoBehaviour {

	public GameObject item;
	public GameObject text;

	void OnMouseDown(){
		Destroy(gameObject);
		item.SetActive (true);
		text.SetActive (true);
	}


}
