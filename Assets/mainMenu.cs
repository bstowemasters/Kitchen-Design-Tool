using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public void newDesign()
    {
        SceneManager.LoadScene(1);

    }

    public void QuitApp()
    {
        Application.Quit();
        Debug.Log("Quitting Program");
    }
}
