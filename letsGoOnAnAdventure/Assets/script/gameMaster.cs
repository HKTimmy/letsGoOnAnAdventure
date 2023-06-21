using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameMaster : MonoBehaviour
{


    private static gameMaster instance;



    // 5 key variables that need to be saved after crossing a check point
    public Vector3 lastCheckPointPos = new Vector3(-7,0,0);
    public bool changedSpawn = false;
    //coin number
    public int collectedCoinsNumbers = 0;
    public int loadMana = 3;
    public float gameTimer = 0;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        gameTimer += Time.deltaTime;
    }
}
