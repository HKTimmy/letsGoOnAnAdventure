using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energyBall : MonoBehaviour
{

    public Rigidbody2D x;

    private GameObject player;
    private SpriteRenderer playerRender;
    private float direction;

    public GameObject shotEffect;

    public AudioSource fireBallSound;
    // Start is called before the first frame update
    void Start()
    {
        fireBallSound.Play();
        x = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerRender = player.GetComponent<SpriteRenderer>();
        x.GetComponent<Rigidbody2D>().gravityScale = 0.0f;

        decider();
    }

    //Update is called once per frame
    void Update()
    {
        x.velocity = new Vector2(direction, 0);
    }

    private void decider() {

        if (playerRender.flipX)
        {
            direction = -7f;
        }
        else
        {
            direction = 7f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("gameBlocks"))
        {
            Destroy(gameObject);
            Instantiate(shotEffect,transform.position, transform.rotation);
        }

        if (collision.gameObject.CompareTag("board"))
        {
            Destroy(gameObject);
            Instantiate(shotEffect, transform.position, transform.rotation);
        }

        if (collision.gameObject.CompareTag("ground"))
        {
            Destroy(gameObject);
            Instantiate(shotEffect, transform.position, transform.rotation);
        }

        if (collision.gameObject.CompareTag("enemy")) {
            Destroy(gameObject);
            Instantiate(shotEffect, transform.position, transform.rotation);
        }
    }
}

