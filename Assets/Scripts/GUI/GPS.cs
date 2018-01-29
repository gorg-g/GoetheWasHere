using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class GPS : MonoBehaviour
{

    public static GPS Instance { set; get; }

    float latitudePlayer;
    float longitudePlayer;

    //  0 = Unknown Location (=game stays where it is)
    //	2 = Humbolt
    //	3 = Kirchhoff
    //	4 = Helmholtz
    //  5 = Zuse
    //  6 = Test Location
    int playerIsInBuildingNo;

    bool LocationServiceActive;

    public int GetClosestBuilding()
    {
        if (LocationServiceActive)
        {
            latitudePlayer = Input.location.lastData.latitude;
            longitudePlayer = Input.location.lastData.longitude;

            double HumboldtDistance = Haversinecalculate(latitudePlayer, longitudePlayer,
                                                         getLatitude(2), getLongitude(2));
            double KirchhoffDistance = Haversinecalculate(latitudePlayer, longitudePlayer,
                                             getLatitude(3), getLongitude(3));
            double HelmholtzDistance = Haversinecalculate(latitudePlayer, longitudePlayer,
                                             getLatitude(4), getLongitude(4));
            double ZuseDistance = Haversinecalculate(latitudePlayer, longitudePlayer,
                                 getLatitude(5), getLongitude(5));
            
            double[] distances = { HumboldtDistance, KirchhoffDistance, HelmholtzDistance, ZuseDistance };

            // find smallest distance
            int pos = 0;
            for (int i = 0; i < distances.Length; i++)
            {
                if (distances[i] < distances[pos])
                    pos = i;
            }

            return pos + 2; //Array starts at 0, buildings start at 2
        }

        return 0;
    }

    void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        StartCoroutine(StartLocationSevice());
    }

    IEnumerator StartLocationSevice()
    {
        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("User has not enabled GPS");
            LocationServiceActive = false;
            yield break;
        }

        Input.location.Start(5, 5);
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if (maxWait <= 0)
        {
            Debug.Log("Timed out");
            LocationServiceActive = false;
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Failed to determine location");
            LocationServiceActive = false;
            yield break;
        }

        LocationServiceActive = true;
        Debug.Log("LocationService activated");

        yield break;
    }

    double Haversinecalculate(double lat1, double lon1, double lat2, double lon2)
    {
        var R = 6372.8; // In kilometers
        var dLat = toRadians(lat2 - lat1);
        var dLon = toRadians(lon2 - lon1);
        lat1 = toRadians(lat1);
        lat2 = toRadians(lat2);

        var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(lat1) * Math.Cos(lat2);
        return R * 2 * Math.Asin(Math.Sqrt(a));
    }

    double toRadians(double angle)
    {
        return Math.PI * angle / 180.0;
    }

    double getLatitude(int buildingID)
    {
        switch (buildingID)
        {
            case 2:
                return 50.682902;
            case 3:
                return 50.683041;
            case 4:
                return 50.681811;
            case 5:
                return 50.681779;
            case 6:
                return 50.683355;
            default:
                Debug.Log("Building doesn't exist.");
                return 0.0;
        }
    }

    double getLongitude(int buildingID)
    {
        switch (buildingID)
        {
            case 2:
                return 10.937878;
            case 3:
                return 10.939464;
            case 4:
                return 10.938900;
            case 5:
                return 10.940955;
            case 6:
                return 10.915169;
            default:
                Debug.Log("Building doesn't exist.");
                return 0.0;
        }
    }

    double getDistance(int buildingID)
    {
        switch (buildingID)
        {
            case 2:
                return 0.04;
            case 3:
                return 0.068;
            case 4:
                return 0.045;
            case 5:
                return 0.106;
            case 6:
                return 0.1;
            default:
                Debug.Log("Building doesn't exist.");
                return 0.0;
        }
    }

}
