using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    public static bool pauseEnabled = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(pauseEnabled)
            {
                resume();
            } else
            {
                pause();
            }
        }

    }

    public void resume()
    {
        pauseEnabled = false;
        pauseMenuUI.SetActive(false);
    }

    private void pause()
    {
        pauseEnabled = true;
        pauseMenuUI.SetActive(true);
    }

    public void quit()
    {
        Application.Quit();
    }

}
