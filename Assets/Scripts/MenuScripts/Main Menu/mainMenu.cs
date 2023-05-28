using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public void newDesign()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);   // Loads New Design Scene (next scene)

    }

    public void QuitApp()
    {
        Application.Quit();
        Debug.Log("Quitting Program");
    }
}
