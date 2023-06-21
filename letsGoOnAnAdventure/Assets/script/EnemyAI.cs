using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{

    public Transform target;
    public float speed = 200f;
    public float nextWayPointDistance = 3f;

    Path path;
    int currentWayPoint = 0;

    bool reached = false;

    public Seeker seeker;
    public Rigidbody2D rb;

    public Transform dragon;
    public SpriteRenderer sprite;

    public Vector2 spawnPoint;

    public gameMaster gm;
    Vector2 ogXY;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<gameMaster>();
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        sprite = dragon.GetComponent<SpriteRenderer>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

        ogXY = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        InvokeRepeating("updatePath", 0f, .5f);
       
    }

    void updatePath() {
        if (seeker.IsDone()) {
            seeker.StartPath(rb.position, target.position, onPathComplete); //new path
        }
    }

    void onPathComplete(Path p) // check for errors
    {                           // if error reset

        if (!p.error)
        {
            path = p;
            currentWayPoint = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (path == null) return;        //no path

        if (currentWayPoint >= path.vectorPath.Count)   //got over end point
        {
            reached = true;
            return;
        }
        else
        {
            reached = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWayPoint] - rb.position).normalized; 
        Vector2 force = direction * speed * Time.deltaTime;   //how to get to player

      

        if (Vector2.Distance(rb.transform.position, target.transform.position) < 8 ) {  // only go to play if distance is shorter then 8
            rb.AddForce(force);
        }

        else if (Vector2.Distance(rb.transform.position, target.transform.position) > 8)  // go back to original point if > 8
        {
            Vector2 d = (ogXY - rb.position).normalized;
            Vector2 f = d * speed * Time.deltaTime;

            rb.AddForce(f);

            if (Vector2.Distance(rb.transform.position,ogXY) < 1f)  {
                rb.AddForce(new Vector2(0,0));
            }
        }


        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWayPoint]);

        if (distance < nextWayPointDistance)
        {
            currentWayPoint++;
        }

        if (rb.velocity.x > 0.1f)
        {

            sprite.flipX = false;
        }
        else if (rb.velocity.x < -0.1f)
        {
            sprite.flipX = true;
        }
    }
}