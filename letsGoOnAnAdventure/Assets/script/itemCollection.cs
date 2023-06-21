using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemCollection : MonoBehaviour
{

    public int collectedCoinsNumber = 0;
    public Text coinText;

    public gameMaster gm;


    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<gameMaster>();

        collectedCoinsNumber = gm.collectedCoinsNumbers; //get saved number for collected coins
        coinText.text = "Collected Coins : " + collectedCoinsNumber + "/15";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("coin")) {
            
            collectedCoinsNumber++;
            coinText.text = "Collected Coins : " + collectedCoinsNumber + "/15"; //update sideQeust text

            
        }
    }

}
