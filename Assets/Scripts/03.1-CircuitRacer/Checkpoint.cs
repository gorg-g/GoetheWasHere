using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    public GameObject glow;

    public CRScoreManager scrmng;

    public bool passed = false;

    Vector3 checkPos;

    void Start()
    {
      
    }

    private void OnTriggerEnter(Collider other)
    {

        GameObject helper = GameObject.Find("ImageTarget");
        var m = Instantiate(glow, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        m.transform.parent = helper.transform;

        if(passed == false)
        {
            scrmng.AddScore();
        }

        passed = true;
    }
}
