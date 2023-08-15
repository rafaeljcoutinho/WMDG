using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PauseMenuScript : MonoBehaviour
{
    public TextMeshProUGUI PauseHeader;
    public GameObject pauseMenu;
    public GameObject settingsMenu;
    public GameObject hud;

    public int player;


    public Button MenuButton;
    public Button ResumeButton;
    public Button SettingsButton;

    private float lastTimeScale = 1;
    // Update is called once per frame

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale != 0)
            {
                MenuButton.onClick.AddListener(MenuGame);
                ResumeButton.onClick.AddListener(ResumeGame);
                SettingsButton.onClick.AddListener(SettingsGame);
                lastTimeScale = Time.timeScale;
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                pauseMenu.SetActive(true);
                hud.SetActive(false);
                PauseHeader.gameObject.SetActive(true);


                // Preciso retirar o cursor do controle da arma e liberar pro menu
            }
            else if (Time.timeScale == 0)
            {
                ResumeGame();
            }
        }
    }
    void MenuGame()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    void ResumeGame()
    {
        Time.timeScale = lastTimeScale;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenu.SetActive(false);
        hud.SetActive(true);
        PauseHeader.gameObject.SetActive(false);
        // Preciso fazer o inverso
    }

    void SettingsGame()
    {
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }
}
