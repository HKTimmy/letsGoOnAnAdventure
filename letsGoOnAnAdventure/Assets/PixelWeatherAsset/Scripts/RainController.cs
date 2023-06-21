using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RainController : MonoBehaviour
{
    [Range(0, 1f)]
    public float masterIntensity = 1f;
    [Range(0, 1f)]
    public float rainIntensity = 1f;
    [Range(0, 1f)]
    public float windIntensity = 1f;
    [Range(0, 1f)]
    public float fogIntensity = 1f;
    [Range(0, 1f)]
    public float lightningIntensity = 1f;
    public bool autoUpdate;

    public ParticleSystem rainPart;
    public ParticleSystem windPart;
    public ParticleSystem lightningPart;
    public ParticleSystem fogPart;

    private ParticleSystem.EmissionModule rainEmission;
    private ParticleSystem.ForceOverLifetimeModule rainForce;
    private ParticleSystem.EmissionModule windEmission;
    private ParticleSystem.MainModule windMain;
    private ParticleSystem.EmissionModule lightningEmission;
    private ParticleSystem.MainModule lightningMain;
    private ParticleSystem.EmissionModule fogEmission;


    public float rainChange;
    public float windChange;
    public float lightingChange;
    public float fogChange;


    void Awake()
    {
        rainEmission = rainPart.emission;
        rainForce = rainPart.forceOverLifetime;
        windEmission = windPart.emission;
        windMain = windPart.main;
        lightningEmission = lightningPart.emission;
        lightningMain = lightningPart.main;
        fogEmission = fogPart.emission;
        UpdateAll();
    }

    private void Start()
    {
        randomRain();
    }

    void Update()
    {
        if (autoUpdate)
            UpdateAll();
    }

    void UpdateAll() {
        rainEmission.rate = 200f * masterIntensity * rainIntensity;
        rainForce.x = new ParticleSystem.MinMaxCurve(-25f * windIntensity * masterIntensity, (-3 - 30f * windIntensity) * masterIntensity);
        windEmission.rate = 5f * masterIntensity * (windIntensity + fogIntensity);
        windMain.startLifetime = 2f + 5f * (1f - windIntensity);
        windMain.startSpeed = new ParticleSystem.MinMaxCurve(15f * windIntensity, 25 * windIntensity);
        fogEmission.rate = (1f + (rainIntensity + windIntensity) * 0.5f) * fogIntensity * masterIntensity;
        if (rainIntensity * masterIntensity < 0.7f)
            lightningEmission.rate = 0;
        else
            lightningEmission.rate = lightningIntensity * masterIntensity * 0.4f;

    }

    public void OnMasterChanged(float value)
    {
        masterIntensity = value;
        UpdateAll();
    }
    public void OnRainChanged(float value)
    {
        rainIntensity = value;
        UpdateAll();
    }
    public void OnWindChanged(float value)
    {
        windIntensity = value;
        UpdateAll();
    }
    public void OnLightningChanged(float value)
    {
        lightningIntensity = value;
        UpdateAll();
    }
    public void OnFogChanged(float value)
    {
        fogIntensity = value;
        UpdateAll();
    }

    public void randomRain(){ // randomize component of rain particle everyTime

        rainChange = Random.Range(0.3f, 1.0f);
        windChange = Random.Range(0.0f, 1.0f);
        lightingChange = Random.Range(0.0f, 1.0f);
        fogChange = Random.Range(0.0f, 1.0f);

        if (lightingChange <= 0.5)
        {
            OnMasterChanged(1f);
            OnRainChanged(rainChange);
            OnWindChanged(windChange);
            OnFogChanged(fogChange);
            OnLightningChanged(lightingChange);
        }

        if (lightingChange >= 0.5)  // need more wind for lightning to show on map significantly
        {
            OnMasterChanged(1f);
            OnRainChanged(1f);
            OnWindChanged(1f);
            OnFogChanged(1f); 
            OnLightningChanged(lightingChange);
        }
    }

    public float getrainChange() {
        return rainChange;
    }

    public float getwindChange()
    {
        return windChange;
    }

    public float gefogChange()
    {
        return fogChange;
    }


}
