using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class escMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public gameMaster gm;


    // Update is called once per frame
    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<gameMaster>();

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {

            if (GameIsPaused)
            {
                resume();
            }
            else {
                pause();
            }

        }
    }

    public void resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }


    void pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void loadMenu() {
        gm.lastCheckPointPos = new Vector3(-7, 0, 0);
        gm.changedSpawn = false;
        gm.collectedCoinsNumbers = 0;
        gm.loadMana = 3;
        gm.gameTimer = 0;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

}

    public void quit() {
        Application.Quit();
    }
}
