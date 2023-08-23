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

    private float timeScale;

    private void Start()
    {
        PlayerData.Instance.timer = timerDuration;
        timeScale = 1f;
    }

    private void Update()
    {
        timerTextUI.text = PlayerData.Instance.timer.ToString("F0");
        PlayerData.Instance.timer -= Time.deltaTime * timeScale;
        if(PlayerData.Instance.timer <= 0)
        {
            SceneManager.LoadScene("FinishRound");
        }
        
    }

    public void AddTime(int t){
        PlayerData.Instance.timer += t;
    }

    public void SetTimeScale(float timeScale){
        this.timeScale = timeScale;
    }



}
