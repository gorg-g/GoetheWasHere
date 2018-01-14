using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

	public float speed;

	private Rigidbody rb;

	public VirtualJoystick joystick;

	public GameObject gc;
	public GameObject sp;
	public GameObject en;

	private Animator anim;

	public int level;


	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		anim = sp.GetComponent <Animator>();
		level = 0;
	}




	void Update () {

		//bool walking = Input.GetKey (KeyCode.W);
		bool walking = true;
		/*
		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.D)) {
			
			anim.SetBool ("walking", walking);


		} else {
			walking = false;
			anim.SetBool ("walking", walking);
		}

		if (Input.GetKeyDown (KeyCode.F)) {

			anim.SetTrigger ("attack");
		*/


		//float x = CrossPlatformInputManager.GetAxis ("Horizontal");
		//float y = CrossPlatformInputManager.GetAxis ("Vertical");
		float x = joystick.Horizontal ();
		float y = joystick.Vertical ();

		Vector3 movement = new Vector3 (x, 0, y);

		rb.velocity = movement * speed;

		if (x != 0 || y != 0) {
			anim.SetBool ("walking", walking);
		} else {
			walking = false;
			anim.SetBool ("walking", walking);

		}




	}


	void FixedUpdate()
		{

			/*
			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical = Input.GetAxis ("Vertical");

			Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical) * speed * Time.deltaTime;

			rb.MovePosition (transform.position + movement);
			*/
		}


	void OnTriggerEnter(Collider other) {

		if (other.tag == "plus") {


			gc.GetComponent<GameController> ().AddScore (10);

		}

		if (other.tag == "minus") {


			gc.GetComponent<GameController> ().AddScore (-5);

		}
			
		if (other.tag == "fast") {
			
			StartCoroutine (BuffTimer (20, 3));
			//showV ();

		}

		if (other.tag == "slow") {

			StartCoroutine (BuffTimer (-10, 1));
			//showV ();

		}

		if (other.tag == "bigplus") {

			gc.GetComponent<GameController> ().AddScore (50);
			//en.GetComponentInChildren<Mover> ().updateSpeed (1); 
			level = level + 1;
			if (level > 7) {
				level = 7;
			}

		}
		if (other.tag == "bigminus") {

			gc.GetComponent<GameController> ().AddScore (-25);
			//en.GetComponentInChildren<Mover> ().updateSpeed (1); 
			level = level - 1;
			if (level < 0) {
				level = 0;
			}
		}
			


	}
	IEnumerator BuffTimer(int x, int bufftime) {
	
		speed += x;
		yield return new WaitForSeconds (bufftime);
		speed = 20;
	}


}
