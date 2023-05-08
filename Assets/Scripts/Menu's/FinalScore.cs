using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI finalScoreTextUI;
    private void Start()
    {
        finalScoreTextUI.text = PlayerData.Instance.PlayerName.ToString() +  "  " + PlayerData.Instance.PlayerScore.ToString();
        PlayerData.Instance.Save();
    }


    public void MainMenu()
    {
        PlayerData.Instance.ResetScore();
        SceneManager.LoadScene("Menu");
    }
}
