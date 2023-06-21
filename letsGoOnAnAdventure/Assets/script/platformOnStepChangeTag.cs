using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformOnStepChangeTag : MonoBehaviour
{


    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.tag = "ground";
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.tag = "board";
        }
    }
}
