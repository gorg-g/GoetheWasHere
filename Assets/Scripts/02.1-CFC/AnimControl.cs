using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimControl : MonoBehaviour {

	private Animator anim;
	void Start () {

		anim = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {

		bool walking = Input.GetKey (KeyCode.W);
		anim.SetBool ("walking", walking);

		if (Input.GetKeyDown (KeyCode.A)) {

			anim.SetTrigger ("attack");
		
		}
		
	}
}
