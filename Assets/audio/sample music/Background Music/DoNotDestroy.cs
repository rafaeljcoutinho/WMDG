using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoNotDestroy : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameMusic");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }

    }
}
