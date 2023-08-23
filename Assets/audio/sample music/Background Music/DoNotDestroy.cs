using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoNotDestroy : MonoBehaviour
{
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameMusic");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
        AudioSource[] audioSources = new AudioSource[2];
        audioSources = this.gameObject.GetComponents<AudioSource>(); 
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.enabled = true;
        }
        if (SceneManager.GetActiveScene().name == "GameScene" || SceneManager.GetActiveScene().name == "LuckyModeScene")
        {
            audioSources[0].Stop();
            audioSources[1].Play();
            return;
        }
        audioSources[0].Play();
        audioSources[1].Stop();
    }

    public void Start() {
        
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameMusic");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
        AudioSource[] audioSources = new AudioSource[2];
        audioSources = this.gameObject.GetComponents<AudioSource>(); 
        if (SceneManager.GetActiveScene().name == "GameScene" || SceneManager.GetActiveScene().name == "LuckyModeScene")
        {
            audioSources[0].Stop();
            audioSources[1].Play();
            return;
        }
        audioSources[0].Play();
        audioSources[1].Stop();
    }
}
