using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class closeGate_level1 : MonoBehaviour
{
    public GameObject player;

    public TilemapCollider2D collide;
    public TilemapRenderer sprite;

    public GameObject closingGate;

    public GameObject mainCamera;
    public GameObject bossCamera;
    public GameObject finalBoss;
    // Start is called before the first frame update
    void Start()
    {
        sprite = closingGate.GetComponent<TilemapRenderer>();
        collide = closingGate.GetComponent<TilemapCollider2D>();

        sprite.enabled = false;
        collide.enabled = false;

        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))        //collider for setting up boss fight
        {
            sprite.enabled = true;
            collide.enabled = true;

            mainCamera.SetActive(false);

            bossCamera.SetActive(true);

            finalBoss.SetActive(true);
            collide.enabled = false;

            Destroy(gameObject);

        }
    }
}
