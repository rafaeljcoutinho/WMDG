using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float timerDuration;
    [SerializeField] private TextMeshProUGUI timerTextUI;
    private float timer;

    private void Start()
    {
        timer = timerDuration;
    }

    private void Update()
    {
        timerTextUI.text = timer.ToString("F0");
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            SceneManager.LoadScene("FinishRound");
        }
        
    }



}
