using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collide : MonoBehaviour {

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag ("Cup")) 
        {
            other.gameObject.transform.parent.gameObject.SetActive(false);
            other.gameObject.SetActive (false);
        }
    }
}
