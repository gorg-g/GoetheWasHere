using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnClick : MonoBehaviour {

	public GameObject item;
	public GameObject text;
    public AudioSource pickupSound;

	void OnMouseDown(){
        pickupSound.Play();
		Destroy(gameObject);
		item.SetActive (true);
		text.SetActive (true);
	}


}
