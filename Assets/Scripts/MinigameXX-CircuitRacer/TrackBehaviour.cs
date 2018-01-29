using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackBehaviour : MonoBehaviour {

    public ElectronController ec;

    public GameObject startObject;

    Vector3 startingPoint;

    bool inCollider;

	void Start () {

        startingPoint = new Vector3(startObject.transform.position.x, startObject.transform.position.y, startObject.transform.position.z);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter(Collider other)
    {
        ec.speed = 3;
        inCollider = true;
    }

    private void OnTriggerExit(Collider other)
    {
        
        inCollider = false;
        StartCoroutine(ResetToOrigin(other));
        
    }

    IEnumerator ResetToOrigin(Collider other)
    {
        ec.speed = 0.5f;
        yield return new WaitForSeconds(1);
        if (!inCollider)
        {
            other.transform.position = startingPoint;
        }
        ec.speed = 3;
        
    }

}
