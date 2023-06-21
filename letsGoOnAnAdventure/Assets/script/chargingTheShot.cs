using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chargingTheShot : MonoBehaviour
{
    public GameObject shot;
    private GameObject player;
    private SpriteRenderer playerRender;
    private SpriteRenderer render;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRender = player.GetComponent<SpriteRenderer>();
        render = shot.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);

        if (Input.GetKeyUp("x")) {  //charging animation
            Destroy(gameObject);

            if (playerRender.flipX)
            {
                render.flipX = true;
                Instantiate(shot, new Vector2(transform.position.x - 1, transform.position.y), transform.rotation);
            }
            else {
                render.flipX = false;
                Instantiate(shot, new Vector2(transform.position.x + 1, transform.position.y), transform.rotation);
            }
        }
        
    }
}
