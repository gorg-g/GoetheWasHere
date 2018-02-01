using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

	public float speed;

    public int level;

    private Rigidbody rb;

	public VirtualJoystick joystick;

	public CFCScoreManager gc;
	public GameObject sp;
	public GameObject en;

	private Animator anim;

    private AudioSource spiderAudio;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		anim = sp.GetComponent <Animator>();
		level = 0;

        spiderAudio = GameObject.FindWithTag("Spider").GetComponent<AudioSource>();
	}

	void Update () {

		bool walking = true;

		float x = joystick.Horizontal ();
		float y = joystick.Vertical ();

		Vector3 movement = new Vector3 (x, 0, y);

		rb.velocity = movement * speed;

		if (x != 0 || y != 0) 
        {
            if (!spiderAudio.isPlaying)
            {
                spiderAudio.Play();
            }

			anim.SetBool ("walking", walking);

		} 
        else 
        {
            if (spiderAudio.isPlaying)
            {
                spiderAudio.Stop();
            }

			walking = false;
			anim.SetBool ("walking", walking);
		}
	}

	void OnTriggerEnter(Collider other) {

		if (other.tag == "plus") {


            gc.IncreaseScore (10);

		}

		if (other.tag == "minus") {
            gc.DecreaseScore (5);
		}
			
		if (other.tag == "fast") {

            //StartCoroutine (BuffTimer (20, 3));
            Buff(5);
		}

		if (other.tag == "slow") {

            //StartCoroutine (BuffTimer (-10, 1));
            Buff(-5);

		}

		if (other.tag == "bigplus") {

            gc.IncreaseScore (50);
			level = level + 1;
			if (level > 7) {
				level = 7;
			}
		}

		if (other.tag == "bigminus") {

            gc.DecreaseScore (25);
			level = level - 1;
			if (level < 0) {
				level = 0;
			}
		}
	}

	IEnumerator BuffTimer(int x, int bufftime) {
        //Obsolet
	
		speed += x;
		yield return new WaitForSeconds (bufftime);
		speed = 20;
	}

    void Buff(int x)
    {
        speed += x;
    }
}
