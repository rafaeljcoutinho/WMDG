using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI finalScore;
    [SerializeField] private TextMeshProUGUI userName;
    [SerializeField] private TextMeshProUGUI acurracy;
    [SerializeField] private TextMeshProUGUI targetsHit;
    [SerializeField] private TextMeshProUGUI specialTargetsHit;
    [SerializeField] private TextMeshProUGUI ShotsFired;
    [SerializeField] private TextMeshProUGUI allSpecialTargets;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button playAgainButton;
    private void Start()
    {
        finalScore.text = PlayerData.Instance.PlayerScore.ToString();
        userName.text = PlayerData.Instance.PlayerName;
        targetsHit.text = PlayerData.Instance.targetsHit.ToString();
        specialTargetsHit.text = PlayerData.Instance.specialTargetsHit.ToString();
        ShotsFired.text = PlayerData.Instance.shotsFired.ToString();
        allSpecialTargets.text = PlayerData.Instance.allSpecialTargets.ToString();
        acurracy.text = PlayerData.Instance.getAcurrate().ToString()+"%";
        mainMenuButton.onClick.AddListener(MainMenu);
        playAgainButton.onClick.AddListener(PlayAgain);
        PlayerData.Instance.Save();
    }


    public void MainMenu()
    {
        PlayerData.Instance.ResetScore();
        SceneManager.LoadScene("Menu");
    }
    public void PlayAgain()
    {
        PlayerData.Instance.ResetScore();
        SceneManager.LoadScene("WeaponSelector");
    }
}
