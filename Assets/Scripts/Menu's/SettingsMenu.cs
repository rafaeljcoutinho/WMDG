using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using static TMPro.TMP_Dropdown;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public Button goBackButton;
    public TMP_Dropdown resolutionDropdown;
    public TMP_Dropdown graphicsDropdown;
    public TMP_Dropdown screenModeDropdown;
    public AudioMixer audioMixer;
    public Slider volumeSlider;

    private Resolution[] resolutions;
    private List<OptionData> resolution_names;
    private List<string> graphics;
    private List<OptionData> graphic_names;
    private void Start()
    {   
        resolution_names = new List<OptionData>();
        int currentResolution = 0;
        graphics = new List<string>();

        resolutionDropdown.ClearOptions();
        resolutions = Screen.resolutions;
        foreach (Resolution res in resolutions)
        {
            resolution_names.Add(new OptionData(res.ToString()));
            if(Screen.currentResolution.Equals(res))
            {
                currentResolution = resolutions.ToList().IndexOf(res);
            }
        }
        resolutionDropdown.AddOptions(resolution_names);
        resolutionDropdown.value = currentResolution;

        graphicsDropdown.ClearOptions();
        graphics = QualitySettings.names.ToList();
        graphic_names = new List<OptionData>();
        int graphicSelected = 0;
        foreach (string graphic in graphics)
        {
            graphic_names.Add(new OptionData(graphic));
            Debug.Log(graphic+"\r\n"+QualitySettings.GetQualityLevel());
            if(graphic.Equals(QualitySettings.names[QualitySettings.GetQualityLevel()]))
            {
                graphicSelected = graphics.IndexOf(graphic);
            }
        }
        graphicsDropdown.AddOptions(graphic_names);
        graphicsDropdown.value = graphicSelected;

        screenModeDropdown.ClearOptions();
        screenModeDropdown.AddOptions(new List<OptionData>(){
            new OptionData("Windowed"),
            new OptionData("Borderless"),
            new OptionData("Fullscreen")
            });
        switch(Screen.fullScreenMode)
        {
            case FullScreenMode.Windowed:
                screenModeDropdown.value = 0;
                break;
            case FullScreenMode.FullScreenWindow:
                screenModeDropdown.value = 1;
                break;
            case FullScreenMode.ExclusiveFullScreen:
                screenModeDropdown.value = 2;
                break;
        }

        goBackButton.onClick.AddListener(GoBack);
        resolutionDropdown.onValueChanged.AddListener(delegate { SetResolution();});
        graphicsDropdown.onValueChanged.AddListener(delegate { SetGraphicsSettings();});
        screenModeDropdown.onValueChanged.AddListener(delegate { SetScreenMode();});
        volumeSlider.value = audioMixer.GetFloat("volume", out float volume) ? volume : 0;
        Debug.Log("Volume = " + audioMixer.GetFloat("volume", out volume));
        Debug.Log("Volume = " + volume);
    }

    private void GoBack()
    {
        SceneManager.LoadScene("Menu");
    }

    private void SetResolution(){
        Resolution res = resolutions[resolutionDropdown.value];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }

    private void SetGraphicsSettings(){
        Debug.Log("Graphics changed = " + graphicsDropdown.value);
        QualitySettings.SetQualityLevel(graphicsDropdown.value);
    }

    private void SetScreenMode(){ 
        switch(screenModeDropdown.value)
        {
            case 0:
                Screen.fullScreenMode = FullScreenMode.Windowed;
                break;
            case 1:
                Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
                break;
            case 2:
                Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
                break;
        }
    }

    public void SetVolume(float volume){
        Debug.Log("Setting volume = " + volume);
        audioMixer.SetFloat("volume", volume);
    }
} 
