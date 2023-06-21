using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class manaPotion : MonoBehaviour
{
    public manaBar manabar;
    public GameObject effect;
    public SpriteRenderer sprite;
    public BoxCollider2D box;

    private static manaPotion instance;

    public gameMaster gm;
    public GameObject energy;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<gameMaster>();

        sprite = GetComponent<SpriteRenderer>();
        box = GetComponent<BoxCollider2D>();

        if (transform.position.x > gm.lastCheckPointPos.x) //check if its behind player or not so they cant come back for it
        {
            sprite.enabled = true;
            box.enabled = true;
            energy.SetActive(true);
        }
        else {
            Destroy(gameObject);  // destroy if pass
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            sprite.enabled = false;
            box.enabled = false;
            energy.SetActive(false);
            Instantiate(effect, transform.position, transform.rotation); //spawn partical effect
        }

        manabar.SetMana(manabar.currentMana + 1); //add mana
        if (manabar.currentMana > 3)
        {
            manabar.currentMana = 3;
        }
    }
}
