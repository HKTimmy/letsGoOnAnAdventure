using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPoint : MonoBehaviour
{

    public Animator check;

    private gameMaster gm;

    public AudioSource checkPointSound;
    public int x = 0;
    public manaBar mb;
    public GameObject player;
    public itemCollection items;
    // Start is called before the first frame update
    void Start()
    {
        check = GetComponent<Animator>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<gameMaster>();
        items = player.GetComponent<itemCollection>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player"){
            if (x == 0) { //only play the music once
                checkPointSound.Play();
                x++;
            }
            check.SetTrigger("active");
            check.SetTrigger("activated");

            //saving all the details to game master
            gm.lastCheckPointPos = transform.position;
            gm.changedSpawn = true;
            gm.loadMana = mb.currentMana;
            gm.collectedCoinsNumbers = items.collectedCoinsNumber;
        }
        

    }
}
