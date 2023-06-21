using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.EventSystems.EventTrigger;

public class dontLoadCoin : MonoBehaviour
{

    public SpriteRenderer sprite;
    public BoxCollider2D box;
    private static dontLoadCoin instance;
    // Start is called before the first frame update

    public gameMaster gm;

    void Start()
    {

        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<gameMaster>();
        sprite = GetComponent<SpriteRenderer>();
        box = GetComponent<BoxCollider2D>();

        if (transform.position.x > gm.lastCheckPointPos.x) //destroy if checkpoint past the coin location
        {
            sprite.enabled = true;
            box.enabled = true;
            
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            sprite.enabled = false;
            box.enabled = false;
        }
    }
}
