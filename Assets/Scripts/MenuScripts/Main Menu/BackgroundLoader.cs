using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackgroundLoader : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private GameObject mainMenuScreen;

    [SerializeField] private Slider progressBar;



    public void loadNewDesignBtn(string scene)
    {
        mainMenuScreen.SetActive(false);
        loadingScreen.SetActive(true);

        StartCoroutine(loadNewDesign(scene));
    }

    IEnumerator loadNewDesign(string scene)
    {
        AsyncOperation loadingProcess = SceneManager.LoadSceneAsync(scene);
        while (!loadingProcess.isDone)
        {
            float progress = Mathf.Clamp01(loadingProcess.progress / 0.9f);
            progressBar.value = progress;
            yield return null;
        }
    }
}
