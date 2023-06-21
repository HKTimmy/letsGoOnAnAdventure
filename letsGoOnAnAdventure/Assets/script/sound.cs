using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour
{
    public AudioSource explosionSound;
    // Start is called before the first frame update
    void Start()
    {
        explosionSound.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}