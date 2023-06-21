using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class mainMenu : MonoBehaviour
{
    public void playGame() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void playMulti() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }
    public void option() { 
    
    }

    public void quitGame() {
        Application.Quit();
    }
}
