using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject bullet;
    public GameObject player;
    private int x = 0;

    // Start is called before the first frame update


    public void spawnBullets()
    {

        x = Random.Range(3, 6);

        int y = x - 1;


        switch (x)  // shoot between 3-5 bullets
        {

            case 3:
                Instantiate(bullet, transform.position, transform.rotation);
                Instantiate(bullet, new Vector3(transform.position.x + .5f, transform.position.y + .5f, transform.position.z), transform.rotation);
                Instantiate(bullet, new Vector3(transform.position.x + .5f, transform.position.y - .3f, transform.position.z), transform.rotation);
                break;

            case 4:
                Instantiate(bullet, transform.position, transform.rotation);
                Instantiate(bullet, new Vector3(transform.position.x + .5f, transform.position.y + .5f, transform.position.z), transform.rotation);
                Instantiate(bullet, new Vector3(transform.position.x + .5f, transform.position.y - .3f, transform.position.z), transform.rotation);
                Instantiate(bullet, new Vector3(transform.position.x + 1f, transform.position.y - .6f, transform.position.z), transform.rotation);
                break;
            case 5:
                Instantiate(bullet, transform.position, transform.rotation);
                Instantiate(bullet, new Vector3(transform.position.x + .5f, transform.position.y + .5f, transform.position.z), transform.rotation);
                Instantiate(bullet, new Vector3(transform.position.x + .5f, transform.position.y - .3f, transform.position.z), transform.rotation);
                Instantiate(bullet, new Vector3(transform.position.x + 1f, transform.position.y - .6f, transform.position.z), transform.rotation);
                Instantiate(bullet, new Vector3(transform.position.x + 1f, transform.position.y + 1f, transform.position.z), transform.rotation);
                break;


        }

    }

    public void spamshoting() {

        Instantiate(bullet, transform.position, transform.rotation);

    }
}
