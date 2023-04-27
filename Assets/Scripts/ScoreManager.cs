using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreTextUI;
    private static int score;

    public void ResetScore()
    {
        score = 0;
        scoreTextUI.text = score.ToString();
    }


    public void AddScore(int value)
    {
        score += value;
        scoreTextUI.text = score.ToString();
    }

}
