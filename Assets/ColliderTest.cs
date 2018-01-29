using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTest : MonoBehaviour {

    public ElectronController ec;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        ec.speed = 10;
    }

    private void OnTriggerExit(Collider other)
    {
        ec.speed = 0.5f;

    }
}
