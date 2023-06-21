using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class enemyGFX : MonoBehaviour
{

    public AIPath aiPath;
    public SpriteRenderer sprite;
    // Update is called once per frame

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (aiPath.desiredVelocity.x > 0.1f)
        {

            sprite.flipX = false;
        }
        else if (aiPath.desiredVelocity.x < -0.1f) {
            sprite.flipX = true;
        }
    }

}
