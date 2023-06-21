using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIt : MonoBehaviour
{

    public GameObject explosionEffect;


    private void Start()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("energyBall"))
        {

            Destroy(gameObject);
            
            
        }

        if (collision.gameObject.CompareTag("Player")) {

            Destroy(gameObject);
            Instantiate(explosionEffect, transform.position, transform.rotation);
            
        }   
    }
}
