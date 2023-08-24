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
        playerNameInput.Select();
    }

    private void PlayGame()
    {
        PlayerData.Instance.SetPlayerName(playerNameInput.text);
        PlayerData.Instance.tag = "PlayerData";
        SceneManager.LoadScene("WeaponSelector");
    }

    private void ViewScore()
    {
        SceneManager.LoadScene("HighscoreScene"); 
      //SceneManager.LoadScene("ScoreScene"); 
    }

    private void ConfigGame()
    {
        SceneManager.LoadScene("ConfigScene");
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            playerNameInput.gameObject.SetActive(false);
            initialMenu.SetActive(true);
        }
        else if (playerNameInput.isActiveAndEnabled)
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Tab))
            {
                playGameButton.Select();
            }
        }
    }
}