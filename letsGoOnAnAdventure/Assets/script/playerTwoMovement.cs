using System;
using System.Collections;
using UnityEngine;

public class playerTwoMovement : MonoBehaviour
{

    public float speed = 5f;
    public GameObject rotate;

    public SpriteRenderer sprite;
    public BoxCollider2D box;

    public Rigidbody2D rotatebody;
    public SpriteRenderer rotatesprite;
    public BoxCollider2D rotatebox;

    public GameObject p1;
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        box = GetComponent<BoxCollider2D>();

        rotatebody = rotate.GetComponent<Rigidbody2D>();
        rotatesprite = rotate.GetComponent<SpriteRenderer>();
        rotatebox = rotate.GetComponent<BoxCollider2D>();

        transform.position = new Vector3(p1.transform.position.x + 2, p1.transform.position.y, p1.transform.position.z);

    }

    public void Update()
    {
        Vector3 pos = transform.position; 

        //use wasd to control
        if (Input.GetKey("w")) {
            pos.y += speed * Time.deltaTime;
        }

        if (Input.GetKey("s"))
        {
            pos.y -= speed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            pos.x -= speed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            pos.x += speed * Time.deltaTime;
        }

        transform.position = pos;

        //change to a rotated 90 degrees obeject
        if (Input.GetKeyDown("j")){
            gameObject.SetActive(false);
            rotate.SetActive(true);
            rotatebody.MovePosition(transform.position);
            
        }
    }
}
