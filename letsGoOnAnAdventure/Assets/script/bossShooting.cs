using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
//using UnityEditor.Tilemaps;
using UnityEngine;
//using UnityEngine.Tilemaps;

public class bossShooting : MonoBehaviour
{


    public Animator decider;
    public SpriteRenderer sprite;
    public GameObject Spawner;
    public bulletSpawner spawn;

    public float timer = 7f;

    public int bossHealth = 3;
    int countShotTime = 0;

    

    public GameObject barrier;

    public float countDOwnSpamShotTimer = 5f;
    public float spamShotTimer = 4f;



    public GameObject pathOne;
    public GameObject pathTwo;
    public GameObject pathThree;
    public GameObject rejectCollider;

    public GameObject bossCamera;
    public GameObject mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        decider = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        spawn = Spawner.GetComponent<bulletSpawner>();


        sprite.flipX = true;

        barrier.SetActive(false);         //make sure non of these future stuff shows
        pathOne.SetActive(false);
        pathTwo.SetActive(false);
        pathThree.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        updateAnimation();

        if (countShotTime >= 5) {                                    //every 5 times normal bullets

            barrier.SetActive(true);                                 // 1 ultra spam bullet
            if (countDOwnSpamShotTimer > 0)
            {
                countDOwnSpamShotTimer -= Time.deltaTime;
            }
            else {

                if (spamShotTimer > 0) {
                    spawn.spamshoting();
                    spamShotTimer -= Time.deltaTime;
                }
                else
                {
                    countShotTime = 0;
                    timer = 20f;
                    spamShotTimer = 5f;
                    countDOwnSpamShotTimer = 5f;
                }
            }

        }

        spawnPath();
    }


    public void spawnPath() {                        //paths for the head


        if (timer <=16 && timer>=15) {

            if (bossHealth == 1)
            {
                pathOne.SetActive(true);
            }

            if (bossHealth == 2)
            {
                pathTwo.SetActive(true);
            }
            if (bossHealth == 3)
            {
                pathThree.SetActive(true);
            }

        }
    }

    public void updateAnimation() {
        if (countShotTime <= 5)
        {
            if (timer > 0)
            {
                if (timer < 4)
                {
                    decider.SetInteger("switch", 0);
                }
                timer -= Time.deltaTime;
            }
            else
            {

                decider.SetInteger("switch", 1);

                spawn.spawnBullets();
                countShotTime++;

                timer = 5f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("energyBall")) {                            //reset for another wave
            bossHealth--;
            pathOne.SetActive(false);
            pathTwo.SetActive(false);
            pathThree.SetActive(false);
            barrier.SetActive(false);
            rejectCollider.SetActive(false);
            

            
            timer = 5f;
        }
        if (bossHealth == 0)
        {
            Destroy(gameObject);
            bossCamera.SetActive(false);
            mainCamera.SetActive(true);
        }

    }
}