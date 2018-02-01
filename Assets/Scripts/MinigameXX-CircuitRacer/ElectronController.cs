using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronController : MonoBehaviour {

    public float speed;

    public VirtualJoystick joystick;

    private Rigidbody rb;


    void Start () {

        rb = GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	void Update () {

        float x = joystick.Horizontal();
        float y = joystick.Vertical();

        Vector3 movement = new Vector3(x, 0, y);

        rb.velocity = movement * speed;
    }

}
