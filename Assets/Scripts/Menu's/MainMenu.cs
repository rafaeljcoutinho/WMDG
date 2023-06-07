using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TMP_InputField playerNameInput;
    [SerializeField] private GameObject initialMenu;
    [SerializeField] private Button startGameButton;
    [SerializeField] private Button playGameButton;
    [SerializeField] private Button viewScoreButton;
    [SerializeField] private Button ConfigButton;
    [SerializeField] private Button exitGameButton;

    private void Start()
    {

        startGameButton.onClick.AddListener(StartGame);
        viewScoreButton.onClick.AddListener(ViewScore);
        exitGameButton.onClick.AddListener(ExitGame);
        playGameButton.onClick.AddListener(PlayGame);
        ConfigButton.onClick.AddListener(ConfigGame);

    }

    private void StartGame()
    {
        
        initialMenu.SetActive(false);
        playerNameInput.gameObject.SetActive(true);

    }
    private void PlayGame()
    {
        PlayerData.Instance.SetPlayerName(playerNameInput.text);
        SceneManager.LoadScene("ModeSelector");
    }

    private void ViewScore()
    {
        SceneManager.LoadScene("ScoreScene"); 
    }

    private void ConfigGame()
    {
        SceneManager.LoadScene("ConfigScene");
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}