using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenUI : MonoBehaviour
{
    // Start is called before the first frame update
    public void backToMainMenu() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}
