using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class strickPlayer : MonoBehaviour
{
    public GameObject player;
    public playerMovement death;

    public ParticleSystem ps;

    List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();

    // Start is called before the first frame update
    void Start()
    {
        death = player.GetComponent<playerMovement>();
        ps = GetComponent<ParticleSystem>();
    }

    private void OnParticleTrigger()
    {
        int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter); // get the number on particale enter player collider
                                                                                            // in this cause it will only be one
        for (int i = 0; i < numEnter; i++) {
            death.Gonzo();
        } 
    }   
}