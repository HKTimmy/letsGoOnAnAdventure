using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sneaky : MonoBehaviour
{

    public GameObject dragon;
    public GameObject player;

    public SpriteRenderer sprite;
    public CircleCollider2D circle;

    public gameMaster gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<gameMaster>();
        sprite = dragon.GetComponent<SpriteRenderer>();
        

        sprite.enabled = false;
        circle.enabled = false;

        if (transform.position.x < gm.lastCheckPointPos.x)
        {
            Destroy(gameObject);

        }
        }

    // Update is called once per frame
    void Update()
    {


            if (Vector2.Distance(player.transform.position, dragon.transform.position) < 4) //show up is short distance
            {
                sprite.enabled = true;
                circle.enabled = true;
            }
        
    }
}
