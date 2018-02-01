using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    public GameObject glow;
    Vector3 checkPos;
    public bool passed = false;

    void Start()
    {
      
    }

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(glow, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);

        Debug.Log("");

        passed = true;
    }
}
