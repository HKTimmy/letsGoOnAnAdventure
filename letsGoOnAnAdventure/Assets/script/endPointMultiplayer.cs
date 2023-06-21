using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endPointMultiplayer : MonoBehaviour
{

    public Animator check;
    // Start is called before the first frame update
    void Start()
    {
        check = GetComponent<Animator>();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            check.SetTrigger("check");
        }

    }

    public void loadAnotherScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}