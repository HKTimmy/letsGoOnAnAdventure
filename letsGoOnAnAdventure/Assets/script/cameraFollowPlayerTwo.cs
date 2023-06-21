using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollowPlayerTwo : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerTwo");
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("PlayerTwo");
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
    }
}
