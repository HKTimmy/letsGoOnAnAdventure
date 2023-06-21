using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class scalePlayervelocity : MonoBehaviour
{
    public GameObject player;
    public playerMovement scale;
    public GameObject snow;
    private void Start()
    {
        scale = player.GetComponent<playerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            snow.SetActive(false);
        }
    }

}
