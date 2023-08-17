using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class PauseMenuScript : MonoBehaviour
{
    public TextMeshProUGUI PauseHeader;
    public GameObject pauseMenu;
    public GameObject settingsMenu;
    public GameObject hud;

    public int player;
    public Image backgroundImage;

    public GameObject AkPlayer;

    public GameObject DeaglePlayer;

    public float cameraSensivity;

    public Button MenuButton;
    public Button ResumeButton;
    public Button SettingsButton;

    public AudioMixer audioMixer;

    private float lastTimeScale = 1;
    // Update is called once per frame

    public void Update(){
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0)
            {
                ResumeGame();
            }
            else
            {
                Pause();
            }
        }

    }

    void Pause()
    {
        
        MenuButton.onClick.AddListener(MenuGame);
        ResumeButton.onClick.AddListener(ResumeGame);
        SettingsButton.onClick.AddListener(SettingsGame);
        lastTimeScale = Time.timeScale;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pauseMenu.SetActive(true);
        hud.SetActive(false);
        PauseHeader.gameObject.SetActive(true);
        Debug.Log(AkPlayer.activeSelf);
        if(AkPlayer.activeSelf==true){
            player = 1;
            AkPlayer.GetComponent<Controller>().isPaused = true;
            cameraSensivity = AkPlayer.GetComponentInChildren<Camera>().GetComponent<CameraController>().mouseSensitivity;
            AkPlayer.GetComponentInChildren<Camera>().GetComponent<CameraController>().mouseSensitivity = 0;
        } else if(DeaglePlayer.activeSelf==true){
            player = 2;
            DeaglePlayer.GetComponent<Controller>().isPaused = true;
            cameraSensivity = DeaglePlayer.GetComponentInChildren<Camera>().GetComponent<CameraController>().mouseSensitivity;
            DeaglePlayer.GetComponentInChildren<Camera>().GetComponent<CameraController>().mouseSensitivity = 0;
        }
        AudioListener.pause = true;
        backgroundImage.gameObject.SetActive(true);
    }
    void MenuGame()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }

    void ResumeGame()
    {
        Time.timeScale = lastTimeScale;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(false);
        hud.SetActive(true);
        PauseHeader.gameObject.SetActive(false);
        if(player == 1){
            AkPlayer.GetComponent<Controller>().isPaused = false;
            AkPlayer.GetComponentInChildren<Camera>().GetComponent<CameraController>().mouseSensitivity = cameraSensivity;
        } else if(player == 2){
            DeaglePlayer.GetComponent<Controller>().isPaused = false;
            DeaglePlayer.GetComponentInChildren<Camera>().GetComponent<CameraController>().mouseSensitivity = cameraSensivity;
        }
        AudioListener.pause = false;
        backgroundImage.gameObject.SetActive(false);
    }

    void SettingsGame()
    {
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }
}
