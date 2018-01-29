using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;

public class PlayerControllerLegac : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;
	public Text areaText;

	private Rigidbody rb;
	private int count;
	private double distance;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		distance = 0.015;
		SetCountText ();
		winText.text = "";
		areaText.text = "";
	}

	void Update ()
	{
		SetAreaText ();
	}

	void FixedUpdate ()
	{
		float moveVertical = Input.GetAxis ("Vertical");
		float moveHorizontal = Input.GetAxis ("Horizontal");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("easter"))
		{
			other.gameObject.SetActive (false);
			count++;
			SetCountText ();
		}
	}

	void SetCountText ()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 12) 
		{
			winText.text = "You Win!";
		}
	}

	void SetAreaText ()
	{
		if (Haversinecalculate (50.682356, 10.932279) <= distance) {
			areaText.text = "You're in the right area bro"; 
		} 
		else 
		{
			areaText.text = "You're in the wrong area bro";
		}
	}

	double Haversinecalculate(double lat2, double lon2) {
		var R = 6372.8; // In kilometers
		double lat1 = Input.location.lastData.latitude;
		double lon1 = Input.location.lastData.longitude;
		var dLat = toRadians(lat2 - lat1);
		var dLon = toRadians(lon2 - lon1);
		lat1 = toRadians(lat1);
		lat2 = toRadians(lat2);

		var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(lat1) * Math.Cos(lat2);
		return R * 2 * Math.Asin(Math.Sqrt(a));
	}

	double toRadians(double angle) {
		return Math.PI * angle / 180.0;
	}

}