using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    public GameObject boden;

    private bool OnCollisionEnter(Collision collision)
    {
        return true;

    }
}
