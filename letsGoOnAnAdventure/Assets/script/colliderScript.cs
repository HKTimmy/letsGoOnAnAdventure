using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderScript : MonoBehaviour
{

    public GameObject player;
    public playerMovement death;
    private void Start()
    {
        death = player.GetComponent<playerMovement>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) { //fall into the collider then die

            death.Gonzo();
        }
    }
}
