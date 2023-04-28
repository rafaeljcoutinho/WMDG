using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button startGameButton;
    public Button viewScoreButton;
    public Button exitGameButton;

    private void Start()
    {
        startGameButton.onClick.AddListener(StartGame);
        viewScoreButton.onClick.AddListener(ViewScore);
        exitGameButton.onClick.AddListener(ExitGame);
    }

    private void StartGame()
    {
        SceneManager.LoadScene("ModeSelector"); // Replace "ModeSelector" with the actual name of your game scene.
    }

    private void ViewScore()
    {
        SceneManager.LoadScene("ScoreScene"); // Replace "ScoreScene" with the actual name of your score scene.
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}