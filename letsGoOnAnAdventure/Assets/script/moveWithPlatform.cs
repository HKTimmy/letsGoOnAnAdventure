using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveWithPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision) {  //changes tag is player can jump on it
        if (collision.gameObject.tag == "Player") {
            collision.gameObject.transform.SetParent(transform);
            gameObject.tag = "ground";
        }
    }

    private void OnCollisionExit2D (Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.SetParent(null); //set back to platform
            gameObject.tag = "board";
        }
    }
    
}
