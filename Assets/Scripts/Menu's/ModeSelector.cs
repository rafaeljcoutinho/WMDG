using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ModeSelector : MonoBehaviour
{
    public Button staticModeButton;
    public Button dynamicModeButton;
    public Button cardModeButton;
    public Button goBackButton;

    private void Start()
    {
        staticModeButton.onClick.AddListener(StaticMode);
        dynamicModeButton.onClick.AddListener(DynamicMode);
        cardModeButton.onClick.AddListener(CardMode);
        goBackButton.onClick.AddListener(GoBack);
    }
    private void StaticMode()
    {
        PlayerData.Instance.SetGameMode("Static");
        SceneManager.LoadScene("GameScene"); // Replace "GameScene" with the actual name of your game scene.
    }

    private void DynamicMode()
    {
        PlayerData.Instance.SetGameMode("Dynamic");

    }

    private void CardMode()
    {
        PlayerData.Instance.SetGameMode("Lucky");

    }

    private void GoBack()
    {
        SceneManager.LoadScene("Menu");
    }
}