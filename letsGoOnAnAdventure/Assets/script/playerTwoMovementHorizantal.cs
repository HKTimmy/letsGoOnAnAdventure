using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTwoMovementHorizantal : MonoBehaviour
{
    // same as vertical but swap to verticl when j is pressed

    public float speed = 5f;
    public GameObject rotate;

    public SpriteRenderer sprite;
    public BoxCollider2D box;

    public Rigidbody2D rotatebody;
    public SpriteRenderer rotatesprite;
    public BoxCollider2D rotatebox;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        box = GetComponent<BoxCollider2D>();

        rotatebody = rotate.GetComponent<Rigidbody2D>();
        rotatesprite = rotate.GetComponent<SpriteRenderer>();
        rotatebox = rotate.GetComponent<BoxCollider2D>();
    }

    public void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey("w"))
        {
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

        if (Input.GetKeyDown("j"))
        {
            gameObject.SetActive(false);
            rotate.SetActive(true);
            rotatebody.MovePosition(transform.position);

           
        }
    }
}
