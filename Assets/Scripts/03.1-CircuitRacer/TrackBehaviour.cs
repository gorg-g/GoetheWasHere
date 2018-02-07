using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackBehaviour : MonoBehaviour {

    public ElectronController ec;

    public GameObject startObject;

    Vector3 startingPoint;

    bool inCollider;

    void Start() {

        startingPoint = new Vector3(startObject.transform.position.x, startObject.transform.position.y, startObject.transform.position.z);

    }

    void OnTriggerExit(Collider other)
    {

        StartCoroutine(ResetToOrigin(other));
        //ec.speed = 1f;
        inCollider = false;

    }

    private void OnTriggerStay(Collider other)
    {
        ec.speed = 3f;
        inCollider = true;
    }


    IEnumerator ResetToOrigin(Collider other)
    {
        ec.speed = 1f;
        yield return new WaitForSeconds(2);
        if (inCollider==false)
        {
            other.transform.position = startingPoint;
        }
     

    }

    public void ReseToOrigin(Collider other)
    {
        
    }

    public void ResetToOrigin()
    {
        ec.transform.position = startingPoint;
    }

}

