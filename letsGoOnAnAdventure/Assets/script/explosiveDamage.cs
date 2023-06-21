using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosiveDamage : MonoBehaviour
{
    public GameObject play;
    public GameObject hp;

    public healthBar hpBar;
    public playerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        play = GameObject.FindGameObjectWithTag("Player");

        hpBar = hp.GetComponent<healthBar>();
        player = play.GetComponent<playerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            hpBar.takeDeathDamage();
            player.Gonzo();
        }
    }
}
