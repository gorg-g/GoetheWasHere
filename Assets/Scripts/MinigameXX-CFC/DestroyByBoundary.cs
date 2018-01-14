using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour {

	public GameObject pl;

	void OnTriggerExit(Collider other)
	{
		
		//Destroy everything that leaves the trigger

		if (other.tag == "Player") {
			pl.transform.position = new Vector3 (0,0,0);
			return;
		} 
		if (other.tag == "MainCamera") {
			
			return;
		}
		Destroy (other.gameObject);
		//Erstelle 
	}

}
