using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

	public float speed = 10f;
    public Quaternion rotation = Quaternion.Euler(0, 30, 0);

	void Update()
	{

        //transform.localRotation = Quaternion.identity;
        //transform.Rotate(Vector3.up, speed * Time.deltaTime);
        transform.Rotate(Time.deltaTime, 0, 0);
    }   

}
