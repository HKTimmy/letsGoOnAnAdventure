using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bossBullet : MonoBehaviour
{

    public GameObject player;
    public Transform target;

    public healthBar hpbar;
    public playerMovement death;

    public Rigidbody2D rb;
    public BoxCollider2D box;

    

    public Vector3 bullet1 = new Vector3(265,6,0);
    public Vector3 bullet2 = new Vector3(265.5f, 6.5f, 0);
    public Vector3 bullet3 = new Vector3(265.5f, 5.7f, 0);
    public Vector3 bullet4 = new Vector3(266f, 5.4f, 0);
    public Vector3 bullet5 = new Vector3(266f, 7f, 0);

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        hpbar = GameObject.FindGameObjectWithTag("hp").GetComponent<healthBar>();
        death = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>();


        
        //match which bullet it is and has a different rotation
        if (transform.position == bullet1)
        transform.right = target.position - transform.position;


        if (transform.position == bullet2)
            transform.right = target.position - transform.position + new Vector3(-10,0,0);


        if (transform.position == bullet3)
            transform.right = target.position - transform.position + new Vector3(5, 0, 0);


        if (transform.position == bullet4)
            transform.right = target.position - transform.position + new Vector3(10, 0, 0); 


        if (transform.position == bullet5)
            transform.right = target.position - transform.position + new Vector3(-20, 0, 0); 
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddRelativeForce(new Vector2(.5f,0)); //move bullet straight base of direction facing
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("bossBullet"))
            Destroy(gameObject);

        if (collision.gameObject.CompareTag("Player")){  //-1 hp if bullet hit

            hpbar.takeDamage();
            if (hpbar.currentHealth == 0) {
                death.Gonzo();
            }
        }
    }
}
