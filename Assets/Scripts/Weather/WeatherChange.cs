using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using LitJson;

public class WeatherChange : MonoBehaviour {
    private int actualWeather;

    [SerializeField] //GameObject rainMaker;
    DigitalRuby.RainMaker.RainScript2D rainMaker;
    private void Start() {
        StartCoroutine(GetWeather());
    }

    private void WeatherChanger() {
        if (actualWeather >= 200 && actualWeather < 300)
        {
            //tormenta
            rainMaker.RainIntensity += 1;
        }
        else if (actualWeather >= 300 && actualWeather < 400)
        {
            //llovizna
            rainMaker.RainIntensity += 0.2f;
        }
        else if (actualWeather >= 400 && actualWeather < 500)
        {
            //lluvia
            rainMaker.RainIntensity += 0.55f;
        }
        else if (actualWeather >= 500 && actualWeather < 600)
        {
            //lluvia
            rainMaker.RainIntensity += 0.7f;
        }
        else if (actualWeather >= 700 && actualWeather < 800)
        {
            //niebla
            rainMaker.RainIntensity += 0.1f;
        }
        else if (actualWeather > 800)
        {
            //Nubes
            rainMaker.RainIntensity += 0.1f;
        }
        else if (actualWeather == 800)
        {
            //ClearSky
            rainMaker.gameObject.SetActive(false);
        }
    }

    IEnumerator GetWeather() {
        UnityWebRequest www = UnityWebRequest.Get("https://api.openweathermap.org/data/2.5/weather?q=bogota&appid=db35d87f275c32099d5477ede90c26f8");
        yield return www.SendWebRequest();

        if(www.result != UnityWebRequest.Result.Success){
            Debug.Log(www.error);
        }
        else {
            //Debug.Log(www.downloadHandler.text);
            JsonData jsonData = JsonMapper.ToObject(www.downloadHandler.text);
            actualWeather = (int)jsonData["weather"][0]["id"];
        }

        Debug.Log(actualWeather);
        WeatherChanger();
        StopCoroutine(GetWeather());
    }
}
