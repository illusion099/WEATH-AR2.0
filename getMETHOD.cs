using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System;
using TMPro;

public class getMETHOD : MonoBehaviour
{
    public Locationfeatch fetch;
    public String longitude;
    public String lattitude;


    public GameObject cubeObject;
     GameObject[] outputObject = new GameObject[6];
     TextMeshPro[] outputArea = new TextMeshPro[6];


    void Start()

    {
        longitude = fetch.longitude.ToString();
        lattitude = fetch.latitude.ToString();

        for (int i = 0; i < 6; i++)
        {
            string c = "output" + i.ToString();
            outputObject[i]= cubeObject.transform.Find(c).gameObject;
            outputArea[i] = outputObject[i].GetComponent<TextMeshPro>();
        }

        GetData();
    }

    void GetData() => StartCoroutine(Getdata_Coroutine());

    IEnumerator Getdata_Coroutine()
    {
        foreach (TextMeshPro g in outputArea)
        {
            g.text = "Loading....";
        }


        string url = string.Format("https://api.openweathermap.org/data/2.5/weather?lat={0}&lon={1}&appid=a9ca6dc51c8d06f0144050b514f694ad",longitude,lattitude);
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
            {
                foreach(TextMeshPro g in outputArea)
                {
                    g.text = request.error;
                }
                
            }
            else
            {
                string json = request.downloadHandler.text;
                WeatherData weatherData = JsonUtility.FromJson<WeatherData>(json);
                float temperature = weatherData.main.temp - 273.15f;
                float feels = weatherData.main.feels_like - 273.15f;
                float windspeed = weatherData.wind.speed;
                int Press = weatherData.main.pressure;
                int humid = weatherData.main.humidity;
                DateTime currentDateTime = DateTime.Now;
                string dateTimeString = currentDateTime.ToString();
                outputArea[0].text = string.Format("Temp {0} °C \n feelslike: {1} °C ", temperature.ToString("0.0"),feels);
                outputArea[1].text = string.Format("WINDSPEED: {0}",windspeed);
                outputArea[2].text = string.Format("PRESSURE: {0}  ",Press);
                outputArea[3].text = string.Format("HUMIDITY:{0}",humid);
                outputArea[5].text = string.Format("DateTime:{0}", dateTimeString);
            }

        }
    }
    [System.Serializable]
    public class WeatherData
    {
        public MainData main;
        public Wind wind;
    }

    [System.Serializable]
    public class MainData
    {
        public float temp;
        public float feels_like;
        public int pressure;
        public int humidity;

    }

    [System.Serializable]
    public class Wind
    {
        public float speed;
    }
    
}
