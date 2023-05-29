using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR;

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

    public void loadVRView()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        StartCoroutine(SwitchToVR());
    }
    IEnumerator SwitchToVR()
    {
        XRSettings.LoadDeviceByName("WindowsMR");
        yield return null;
        XRSettings.enabled = true;
    }

    public void QuitApp()
    {
        Application.Quit();
        Debug.Log("Quitting Program");
    }
}
