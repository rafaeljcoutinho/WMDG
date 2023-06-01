using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    public GameObject LoadingScreen;
    public GameObject ModeSelectorCanvas;
    public Slider slider;

    public void LoadScene (int sceneId) {
        StartCoroutine(LoadSceneAsync(sceneId));
    }

    private IEnumerator LoadSceneAsync(int sceneId)
    {
        // Start loading the next scene
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneId);
        LoadingScreen.SetActive(true);
        ModeSelectorCanvas.SetActive(false);

        // Update the progress bar or loading animation based on the loading progress
        while (!asyncLoad.isDone)
        {
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f); // Normalize the progress to 0-1 range
            UpdateLoadingUI(progress);
            yield return null;
        }
    }

    private void UpdateLoadingUI(float progress)
    {
        // Update your loading UI elements here (e.g., progress bar, loading animation)
        slider.value = progress;
    }
}
