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

    private void OnTriggerStay(Collider other)
    {
        ec.speed = 10;
        Debug.Log(ec.speed);

    }
    private void OnTriggerExit(Collider other)
    {
        ec.speed = 1;
        Debug.Log(ec.speed);
    }
}
