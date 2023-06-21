using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class weatherSystem : MonoBehaviour
{

    public GameObject snow;
    public GameObject rain;
    public GameObject snow2;
    public GameObject rain2;
    public GameObject snow3;
    public GameObject rain3;


    int whichWeatherDecider;
    int secoundWeatherDecider;

    public float masterChange = 1;

    public GameObject player;
    public playerMovement scale;
    private gameMaster gm;

    // Start is called before the first frame update
    void Start() {

        scale = player.GetComponent<playerMovement>();

        snow.SetActive(false);
        rain.SetActive(false);

        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<gameMaster>();


        randomWeather();
        randomSecoundWeather();

        if (gm.lastCheckPointPos.x > snow.transform.position.x) {
            snow.SetActive(false);
        }
        if (gm.lastCheckPointPos.x > snow2.transform.position.x)
        {
            snow2.SetActive(false);
        }
        if (gm.lastCheckPointPos.x > snow3.transform.position.x)
        {
            snow3.SetActive(false);
        }
        if (gm.lastCheckPointPos.x > rain.transform.position.x)
        {
            rain.SetActive(false);
        }
        if (gm.lastCheckPointPos.x > rain2.transform.position.x)
        {
            rain.SetActive(false);
        }
        if (gm.lastCheckPointPos.x > rain3.transform.position.x)
        {
            rain.SetActive(false);
        }
    }


    //randomize weather

    void randomWeather() {


        whichWeatherDecider = Random.Range(0, 3);


        switch (whichWeatherDecider) {

            case 0:
                snow.SetActive(false);
                rain.SetActive(false);
                snow2.SetActive(false);
                rain2.SetActive(false);
                break;

            case 1:
                snow.SetActive(true);
                snow2.SetActive(true);
                rain.SetActive(false);
                rain2.SetActive(false);
                break;

            case 2:
                snow.SetActive(false);
                snow2.SetActive(false);
                rain.SetActive(true);
                rain2.SetActive(true);
                break;
        }




    }

    //randomiz\e secound part of outdoor weather
    void randomSecoundWeather()
    {

        secoundWeatherDecider = Random.Range(0, 3);

        switch (whichWeatherDecider)
        {

            case 0:
                snow.SetActive(false);
                rain.SetActive(false);

                break;

            case 1:
                snow.SetActive(true);
                rain.SetActive(false);
                break;

            case 2:
                snow.SetActive(false);
                rain.SetActive(true);
                break;
        }
    }
}
