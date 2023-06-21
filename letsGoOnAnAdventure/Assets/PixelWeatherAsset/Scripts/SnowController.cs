﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowController : MonoBehaviour
{
    [Range(0, 1f)]
    public float masterIntensity = 1f;
    [Range(0, 1f)]
    public float snowIntensity = 1f;
    [Range(0, 1f)]
    public float windIntensity = 1f;
    [Range(0, 1f)]
    public float fogIntensity = 1f;
    [Range(0, 7f)]
    public float snowLevel;
    public bool autoUpdate;

    public ParticleSystem snowPart;
    public ParticleSystem windPart;
    public ParticleSystem fogPart;

    private ParticleSystem.EmissionModule snowEmission;
    private ParticleSystem.ForceOverLifetimeModule snowForce;
    private ParticleSystem.ShapeModule snowShape;
    private ParticleSystem.EmissionModule windEmission;
    private ParticleSystem.MainModule windMain;
    private ParticleSystem.EmissionModule lightningEmission;
    private ParticleSystem.MainModule lightningMain;
    private ParticleSystem.EmissionModule fogEmission;
    private Transform snowTransform;

    public Material snowMat;


    public float snowChange;
    public float windChange;
    public float snowLevelChange;
    public float fogChange;


    void Awake()
    {
        snowTransform = snowPart.transform;
        snowEmission = snowPart.emission;
        snowShape = snowPart.shape;
        snowForce = snowPart.forceOverLifetime;
        windEmission = windPart.emission;
        windMain = windPart.main;
        fogEmission = fogPart.emission;
        UpdateAll();
    }

    private void Start()
    {
        randomSnow();

    }
    void Update(){
        if (autoUpdate)
            UpdateAll();
    }

    void UpdateAll(){
        snowEmission.rate = 110f * masterIntensity * snowIntensity;
        snowShape.radius = 30f * Mathf.Clamp(windIntensity, 0.4f, 1f) * masterIntensity;
        snowForce.x = new ParticleSystem.MinMaxCurve(-9f * windIntensity, -3-14f * windIntensity);
        windEmission.rate = 14f * masterIntensity * (windIntensity + fogIntensity);
        windMain.startLifetime = 2f + 6f * (1f - windIntensity);
        windMain.startSpeed = new ParticleSystem.MinMaxCurve(15f * windIntensity, 20 * windIntensity);
        fogEmission.rate = (fogIntensity + (snowIntensity + windIntensity)*0.5f) * masterIntensity;
        snowMat.SetFloat("_SnowLevel", snowLevel);
    }

    public void OnMasterChanged(float value)
    {
        masterIntensity = value;
        UpdateAll();
    }
    public void OnSnowChanged(float value)
    {
        snowIntensity = value;
        UpdateAll();
    }
    public void OnWindChanged(float value)
    {
        windIntensity = value;
        UpdateAll();
    }
    public void OnFogChanged(float value)
    {
        fogIntensity = value;
        UpdateAll();
    }
    public void OnSnowLevelChanged(float value)
    {
        snowLevel = value;
        UpdateAll();
    }

    public void randomSnow() {

        snowChange = Random.Range(0.3f, 1.0f);
        windChange = Random.Range(0.5f, 1.0f);
        snowLevelChange = Random.Range(1f, 7.0f);
        fogChange = Random.Range(0.0f, 1.0f);

        OnMasterChanged(1f);

        OnSnowChanged(snowChange);
        OnWindChanged(windChange);
        OnFogChanged(fogChange);
        OnSnowLevelChanged(snowLevelChange);
    }

    public float getsnowChange() {
        return snowChange;
    }

    public float getwindChange()
    {
        return windChange;
    }

    public float getfogChange()
    {
        return fogChange;
    }

    public float getsnowLevelChange()
    {
        return snowLevelChange;
    }
}
