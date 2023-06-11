using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class ScoreList : MonoBehaviour
{
    public SaveMethod saveMethod;

    public GameObject panel;
    public Button backGameButton;
    public Button StaticScoreButton;
    public Button DynamicScoreButton;
    public Button LuckyScoreButton;
    private string ActivatedButton;
    private List<PlayerScore> scores;
    private List<PlayerScore> selectedScores;


    void Start()
    {
        SelectStaticMode();
        scores = saveMethod.LoadScores();
        StaticScoreButton.onClick.AddListener(SelectStaticMode);
        DynamicScoreButton.onClick.AddListener(SelectDynamicMode);
        LuckyScoreButton.onClick.AddListener(SelectLuckyMode);
    }
    private List<PlayerScore> FilterScores(List<PlayerScore> scores)
    {
        List<PlayerScore> filteredList = new List<PlayerScore>();
        print(scores);
        foreach (PlayerScore score in scores)
        {
            if (score.gameMode == ActivatedButton)
            {
                filteredList.Add(score);
            }
        }
        filteredList = (List<PlayerScore>)(from score in filteredList
                       orderby score.score ascending
                       select score);
        print(filteredList);
        return filteredList;
    }

    private void SelectStaticMode()
    {
        ActivatedButton = "Static";
        SwitchActivesButtons();
        selectedScores = FilterScores(scores);
    }

    private void SelectDynamicMode()
    {
        ActivatedButton = "Dynamic";
        SwitchActivesButtons();
        saveMethod.LoadScores();
        selectedScores = FilterScores(scores);
    }

    private void SelectLuckyMode()
    {
        ActivatedButton = "Lucky";
        SwitchActivesButtons();
        saveMethod.LoadScores();
        selectedScores = FilterScores(scores);
    }

    private void SwitchActivesButtons()
    {
        switch (ActivatedButton)
        {
            case "Static":
                StaticScoreButton.image.color = new Color(0, 0, 0, 0.8f);
                DynamicScoreButton.image.color = new Color(0, 0, 0, 0.5f);
                LuckyScoreButton.image.color = new Color(0, 0, 0, 0.5f);
                break;
            case "Dynamic":
                StaticScoreButton.image.color = new Color(0, 0, 0, 0.5f);
                DynamicScoreButton.image.color = new Color(0, 0, 0, 0.8f);
                LuckyScoreButton.image.color = new Color(0, 0, 0, 0.5f);
                break;
            case "Lucky":
                StaticScoreButton.image.color = new Color(0, 0, 0, 0.5f);
                DynamicScoreButton.image.color = new Color(0, 0, 0, 0.5f);
                LuckyScoreButton.image.color = new Color(0, 0, 0, 0.8f);
                break;
        }
    }

    private void BackToMenu()
    {
        SceneManager.LoadScene("Menu"); 
    }
}