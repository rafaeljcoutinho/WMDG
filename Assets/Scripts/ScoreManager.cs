using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreTextUI;
    private static int score;
    public static ScoreManager Instance;

    public int Score => score;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
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
