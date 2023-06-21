using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovmentBetween2Points : MonoBehaviour
{
    public GameObject startPoint;
    public GameObject endPoint;

    int x = 0;

    private float speed = 2f;

    // Update is called once per frame
    void Update()
    {
        decider();

        if (x == 1) {
            transform.position = Vector2.MoveTowards(transform.position, endPoint.transform.position, Time.deltaTime * speed);
        }

        if (x == 0) {
            transform.position = Vector2.MoveTowards(transform.position, startPoint.transform.position, Time.deltaTime * speed);
        }
    }

    void decider() {
        if (Vector2.Distance(transform.position, startPoint.transform.position) < .1f)
        {
            x = 1;
            
        }

        if (Vector2.Distance(endPoint.transform.position, transform.position) < .1f)
        {
            x = 0;
        }

    }
}   
