using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
public class settingsMenu : MonoBehaviour
{


    public AudioMixer mainVol;
    public TMP_Dropdown resolutionOptsDD;
    Resolution[] resolutionList;

    private void Start()
    {
        resolutionList = Screen.resolutions;// Sets list to store available screen resolutions.
        resolutionOptsDD.ClearOptions();    // Clear any prev saved resolutions so new ones can be fetched.

        List <string> availableResOpts = new List<string>();    // Stores new resolutions available

        int currResIdx = 0;

        for (int i = 0; i < resolutionList.Length; i++) {       // Iterated through available resoltions.
            string opt = resolutionList[i].width + " x " + resolutionList[i].height;    // Checks placeholder text to retrieve resolutions
            availableResOpts.Add(opt);                          // Adds the current option to list.

            if (resolutionList[i].width == Screen.currentResolution.width && resolutionList[i].height == Screen.currentResolution.height)   // Check for both resolutions equal to current res.
            {
                currResIdx = i; // Sets the index to the current resolution.
            }

        }

        resolutionOptsDD.AddOptions(availableResOpts);          // Adds the option to the dropdown menu.
        resolutionOptsDD.value = currResIdx;                    // Selects option from drop down.
        resolutionOptsDD.RefreshShownValue();                   // Displays new resolution.

    }

    public void setNewResolution(int resIdx)
    {
        Resolution resolutionToSet = resolutionList[resIdx];
        Screen.SetResolution(resolutionToSet.width, resolutionToSet.height, Screen.fullScreen);
    }

    public void setVol(float volume)
    {
        mainVol.SetFloat("MainVolume", volume);
    }

    public void enableFullScreen(bool isEnabled)
    {
        Screen.fullScreen = isEnabled;
    }

    public void setQualityPreset(int presetIdx)
    {
        QualitySettings.SetQualityLevel(presetIdx);
    }
}
