using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
	
	private Rigidbody rb;
    public float speed;
	public GameObject plr;



	void Start()
	{

		//Debug.Log ("ESBEWEGTSICHESBEGETSICH");
		plr = GameObject.FindWithTag ("Player");
	}

	void Update()
	{
		
		updateSpeed ();
		transform.Translate (Vector3.back*speed*Time.deltaTime);

	}





	public void updateSpeed(){
        
        //Updated GlobalGameSpeed

		if (plr.GetComponent<PlayerController> ().level == 0) {
			speed = 10;

		} else if (plr.GetComponent<PlayerController> ().level == 1) {

			speed = 15;

		} else if (plr.GetComponent<PlayerController> ().level == 2) {
			speed = 20;

		} else if (plr.GetComponent<PlayerController> ().level == 3) {
			speed = 30;

		} else if (plr.GetComponent<PlayerController> ().level == 4) {
			speed = 40;
		}
		else if (plr.GetComponent<PlayerController> ().level  == 5) {
				speed = 50;

		}
		else if (plr.GetComponent<PlayerController> ().level  == 6) {
			speed = 60;

		}
		else if (plr.GetComponent<PlayerController> ().level  == 7) {
			speed = 70;
		}
	}


}
