using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI finalScoreTextUI;

    private int score;
    private void Start()
    {
        score = ScoreManager.Instance.Score;
        finalScoreTextUI.text = score.ToString();
    }


    public void MainMenu()
    {
        ScoreManager.Instance.ResetScore();
        SceneManager.LoadScene("Menu");
    }
}
