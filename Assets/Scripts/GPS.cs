using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class GPS : MonoBehaviour {

	public static GPS Instance { set; get; }

	public float latitudePlayer;
	public float longitudePlayer;
	public float latitudeBuilding;
	public float longitudeBuilding;
	public Text GPSText;
	public Text areaText;

    //	1 = Humbolt
    //	2 = Kirchhoff
    //	3 = Zuse
    //	4 = Helmholtz
	public int building;

	private double distance;

	private void Start(){
		Instance = this;
		DontDestroyOnLoad (gameObject);
		StartCoroutine (StartLocationSevice());
		areaText.text = "";
		latitudeBuilding = (float)setLatitude (building);
		longitudeBuilding = (float)setLongitude (building);
		distance = setDistance (building);	
		}

	private IEnumerator StartLocationSevice() {
		if (!Input.location.isEnabledByUser) {
			Debug.Log ("User has not enabled GPS");
			yield break;
		}

		Input.location.Start ();
		int maxWait = 20;
		while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0) {
			yield return new WaitForSeconds (1);
			maxWait--;
		}

		if (maxWait <= 0) {
			Debug.Log ("Timed out");
			yield break;
		}

		if (Input.location.status == LocationServiceStatus.Failed) {
			Debug.Log ("Failed to determine location");
			yield break;
		}

		latitudePlayer = Input.location.lastData.latitude;
		longitudePlayer = Input.location.lastData.longitude;

		yield break;
	}

	private void Update(){
		latitudePlayer = Input.location.lastData.latitude;
		longitudePlayer = Input.location.lastData.longitude;
		GPSText.text = "Lat:" + GPS.Instance.latitudePlayer.ToString() + "  Lon:" + GPS.Instance.longitudePlayer.ToString() + " distance:" + Haversinecalculate (latitudeBuilding,longitudeBuilding).ToString("0.####");
		SetAreaText();
	}

	void SetAreaText ()
	{
		if (Haversinecalculate (latitudeBuilding,longitudeBuilding) <= distance) {
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
		
	float setLatitude(int building) {
		if (building == 1) {
			return (float)50.682902;
		} else if (building == 2) {
			return (float)50.683041;
		} else if (building == 3) {
			return (float)50.681779;
		} else if (building == 4) {
			return (float)50.681811;
		} else {
			Debug.Log ("Wrong building");
			return 0;
		}

	}

	float setLongitude(int building) {
		if (building == 1) {
			return (float)10.937878;
		} else if (building == 2) {
			return (float)10.939464;
		} else if (building == 3) {
			return (float)10.940955;
		} else if (building == 4) {
			return (float)10.938900;
		} else {
			Debug.Log ("Wrong building");
			return 0;
		}

	}

	double setDistance(int building) {
		if (building == 1) {
			return 0.04;
		} else if (building == 2) {
			return 0.068;
		} else if (building == 3) {
			return 0.106;
		} else if (building == 4) {
			return 0.045;
		} else {
			Debug.Log ("Wrong building");
			return 0;
		}

	}

}
