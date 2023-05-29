using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour
{
    public bool resume;
    public void returnToMenu()
    {
        if (!resume)
        {
            // Delete all cabinets
        }
        else
        {
            // Resume Scene (Do Nothing)
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    //Test function to enable resume on page load

    //public void enableResume()
    //{
    //    Scene scene = SceneManager.GetSceneAt(0);
    //    GameObject[] sceneObjects = scene.GetRootGameObjects();
    //    foreach (GameObject obj in sceneObjects)
    //    {
    //        if (obj.CompareTag("resumeBtn")) 
    //        {
    //            obj.SetActive(true);
    //        }
    //    }
    //}

    public void QuitApp()
    {
        Application.Quit();
        Debug.Log("Quitting Program");
    }
}
