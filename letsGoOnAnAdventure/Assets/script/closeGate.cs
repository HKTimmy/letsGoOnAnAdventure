using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class closeGate : MonoBehaviour
{

    public GameObject player;

    public TilemapCollider2D collide;
    public TilemapRenderer sprite;

    public GameObject closingGate;

    public GameObject mainCamera;
    public GameObject p2Camera;
    public GameObject bossCamera;

    public GameObject p2v;
    public GameObject p2h;

    public GameObject finalBoss;
    // Start is called before the first frame update
    void Start()
    {
        sprite = closingGate.GetComponent<TilemapRenderer>();
        collide = closingGate.GetComponent<TilemapCollider2D>();

        sprite.enabled = false;
        collide.enabled = false;

        finalBoss.SetActive(false);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))        //collider for setting up boss fight
        {
            sprite.enabled = true;
            collide.enabled = true;

            mainCamera.SetActive(false);
            p2Camera.SetActive(false);
            bossCamera.SetActive(true);
            p2v.SetActive(false);
            p2h.SetActive(false);
            collide.enabled = false;
            finalBoss.SetActive(true);
            Destroy(gameObject);
        }
    }
}
