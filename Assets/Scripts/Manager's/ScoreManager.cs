using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreTextUI;
    
    public void ResetScore()
    {
        PlayerData.Instance.ResetScore();
        scoreTextUI.text = PlayerData.Instance.PlayerScore.ToString();
    }


    public void AddScore(float value)
    {
        PlayerData.Instance.AddPlayerScore(value);
        scoreTextUI.text = PlayerData.Instance.PlayerScore.ToString();
    }

}
