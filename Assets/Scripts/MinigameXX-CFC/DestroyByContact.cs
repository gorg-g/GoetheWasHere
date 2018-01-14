using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestroyByContact : MonoBehaviour {


	//Effekt beim Einsammeln
	//public GameObject effekt;
	public GameObject gc;
	public GameObject pl;


	void OnTriggerEnter(Collider other) {

		//GameObject collided nicht mit Boundary
		if (other.tag == "Boundary") {
			return;
		}
		//Erstelle eine Instanz des effektes
		//Instantiate(effekt,transform.position, transform.rotation);


		//zerstöre angegriffenes gameObject
		Destroy (gameObject); 


		//zerstöre ankommendes gameObject
		//Destroy (other.gameObject);


	}
}
