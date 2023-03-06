using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class Locationfeatch : MonoBehaviour
{
    public float latitude;
    public float longitude;
    public string country ;
    public string city;
    public string region;
    public string timezone;

    void Start()
    {
        StartCoroutine(GetLocation());
    }

    IEnumerator GetLocation()
    {
        WWW www = new WWW("http://ip-api.com/json");
        yield return www;
        if (string.IsNullOrEmpty(www.error))
        {
            string json = www.text;
            LocationData location = JsonUtility.FromJson<LocationData>(json);
             float latitude = location.lat;
             float longitude = location.lon;
             string country = location.country;
             string city = location.city;
             string region = location.region;
             string timezone = location.timezone;


           
        }
        else
        {
            Debug.Log("Error getting location: " + www.error);
        }
    }

    [System.Serializable]
    public class LocationData
    {
        public string country;
        public string region;
        public string city;
        public float lat;
        public float lon;
        public string timezone;
    }
}
