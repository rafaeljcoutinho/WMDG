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

    private float timeScale;

    private void Start()
    {
        timer = timerDuration;
        timeScale = 1f;
    }

    private void Update()
    {
        timerTextUI.text = timer.ToString("F0");
        timer -= Time.deltaTime * timeScale;
        if(timer <= 0)
        {
            SceneManager.LoadScene("FinishRound");
        }
        
    }

    public void AddTime(int t){
        timer += t;
    }

    public void SetTimeScale(float timeScale){
        this.timeScale = timeScale;
    }



}
