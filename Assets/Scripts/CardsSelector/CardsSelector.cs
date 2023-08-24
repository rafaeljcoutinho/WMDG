using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using System;

public class CardsSelector : MonoBehaviour
{
    [SerializeField] private GameObject Hud;

    [SerializeField] private GameObject AkPlayer;
    [SerializeField] private GameObject DeaglePlayer;

    private int player;
    private float cameraSensivity;

    [SerializeField] private GameObject cardSelector;

    [SerializeField] private Button card1Button;
    [SerializeField] private Button card2Button;
    [SerializeField] private Button card3Button;

    [SerializeField] private TextMeshProUGUI card1Text;
    [SerializeField] private TextMeshProUGUI card2Text;
    [SerializeField] private TextMeshProUGUI card3Text;

    [SerializeField] private TextMeshProUGUI card1Description;
    [SerializeField] private TextMeshProUGUI card2Description;
    [SerializeField] private TextMeshProUGUI card3Description;

    private int card1Id;
    private int card2Id;
    private int card3Id;

    private string card1Type;
    private string card2Type;
    private string card3Type;

    private float card1Modifier;
    private float card2Modifier;
    private float card3Modifier;

    [SerializeField] private bool isCardSelected=true;

    private float lastTimeScale;

    private int scoreMultiplier = 1;
    private bool cardsDrawed;
    private int  lastscore = 0;

    [SerializeField] private GameObject frozenGranade;
    [SerializeField] private GameObject explosiveGranade;

    [SerializeField] private Image More_Time;
    [SerializeField] private Image Score_Multiplier;

    [SerializeField] private Image Frozen_Grenade;
    [SerializeField] private Image Explosive_Grenade;

    [SerializeField] private Image Precision;
    [SerializeField] private Image Reload_Speed;

    public void Update(){
        if(Time.timeScale != 0){
            if (PlayerData.Instance.PlayerScore > 100*scoreMultiplier+lastscore && PlayerData.Instance.PlayerScore != 0)
            {
                lastscore = 100*scoreMultiplier+lastscore;
                scoreMultiplier++;
                isCardSelected = false;
            }
            if (isCardSelected == false){
                if( cardsDrawed == false){
                Hud.SetActive(false);
                if(AkPlayer.activeSelf==true){
                    player = 1;
                    if (cameraSensivity != 0){
                        cameraSensivity = AkPlayer.GetComponentInChildren<Camera>().GetComponent<CameraController>().mouseSensitivity;
                    }
                    AkPlayer.GetComponentInChildren<Camera>().GetComponent<CameraController>().mouseSensitivity = 0;
                    AkPlayer.GetComponent<Controller>().isPaused = true;
                } else if(DeaglePlayer.activeSelf==true){
                    player = 2;
                    if (cameraSensivity != 0){
                        cameraSensivity = DeaglePlayer.GetComponentInChildren<Camera>().GetComponent<CameraController>().mouseSensitivity;
                    }
                    DeaglePlayer.GetComponentInChildren<Camera>().GetComponent<CameraController>().mouseSensitivity = 0;
                    DeaglePlayer.GetComponent<Controller>().isPaused = true;
                }
                lastTimeScale = Time.timeScale;
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                cardSelector.SetActive(true);
                cardsDrawed = true;
                Card[] cards = CardsDrawer.drawCards();
                
                card1Text.text = cards[0].name;
                card2Text.text = cards[1].name;
                card3Text.text = cards[2].name;

                card1Id = cards[0].id;
                card2Id = cards[1].id;
                card3Id = cards[2].id;

                card1Type = cards[0].type;
                card2Type = cards[1].type;
                card3Type = cards[2].type;

                card1Modifier = cards[0].modifier;
                card2Modifier = cards[1].modifier;
                card3Modifier = cards[2].modifier;

                if (cards[0].name != "More Time")
                    card1Description.text = cards[0].description + " " + cards[0].modifier + " times ";
                else
                    card1Description.text = cards[0].description + " " + cards[0].modifier + "s";
                card2Description.text = cards[1].description;
                card3Description.text = cards[2].description + " " + (cards[2].modifier * 100) + "%";

                if (cards[0].name == "More Time"){
                    More_Time.gameObject.SetActive(true);
                    Score_Multiplier.gameObject.SetActive(false);
                }
                else if (cards[0].name == "Score Multiplier"){
                    More_Time.gameObject.SetActive(false);
                    Score_Multiplier.gameObject.SetActive(true);

                }
                if ( cards[1].name == "Frozen Grenade"){
                    Frozen_Grenade.gameObject.SetActive(true);
                    Explosive_Grenade.gameObject.SetActive(false);
                }
                else if (cards[1].name == "Explosive Grenade"){
                    Frozen_Grenade.gameObject.SetActive(false);
                    Explosive_Grenade.gameObject.SetActive(true);
                }
                if (cards[2].name == "Precision"){
                    Precision.gameObject.SetActive(true);
                    Reload_Speed.gameObject.SetActive(false);
                }
                else if (cards[2].name == "Reload Speed"){
                    Precision.gameObject.SetActive(false);
                    Reload_Speed.gameObject.SetActive(true);
                }
                
                card1Button.onClick.AddListener(delegate { selectCard(card1Id,card1Type); });
                card2Button.onClick.AddListener(delegate { selectCard(card2Id,card2Type); });
                card3Button.onClick.AddListener(delegate { selectCard(card3Id,card3Type); });
                }
            }else{
                cardSelector.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

                if(Input.GetKeyDown(KeyCode.F) && PlayerData.Instance.frozenGrenade == true){
                    PlayerData.Instance.frozenGrenade = false;
                    frozenGranade.SetActive(false);
                    TargetController.Instance.Frozen(10f);

                }
                if(Input.GetKeyDown(KeyCode.E) && PlayerData.Instance.explosiveGrenade == true){
                    PlayerData.Instance.explosiveGrenade = false;
                    explosiveGranade.SetActive(false);
                    TargetController.Instance.Explode();
                }
                frozenGranade.SetActive(PlayerData.Instance.frozenGrenade);
                explosiveGranade.SetActive(PlayerData.Instance.explosiveGrenade);
            }   
        }
    }

    public void selectCard(int id, string type){
        float defaultCameraSensivity = 300f;
        GameObject gameConfig = GameObject.Find("GameConfig");
        if (PlayerData.Instance.isPaused == true){
            gameConfig.GetComponent<PauseMenuScript>().lastTimeScale = lastTimeScale;
            if (cameraSensivity != 0){
                gameConfig.GetComponent<PauseMenuScript>().cameraSensivity = cameraSensivity;
            } else{
                    gameConfig.GetComponent<PauseMenuScript>().cameraSensivity = defaultCameraSensivity;
            }
        }else{
            Hud.SetActive(true);
            Time.timeScale = lastTimeScale;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            if(player == 1){
                    AkPlayer.GetComponent<Controller>().isPaused = false;
                    if (cameraSensivity != 0){
                        AkPlayer.GetComponentInChildren<Camera>().GetComponent<CameraController>().mouseSensitivity = cameraSensivity;
                    } else {
                        AkPlayer.GetComponentInChildren<Camera>().GetComponent<CameraController>().mouseSensitivity = defaultCameraSensivity;
                    }
                } else if(player == 2){
                    DeaglePlayer.GetComponent<Controller>().isPaused = false;
                    if (cameraSensivity != 0){
                        DeaglePlayer.GetComponentInChildren<Camera>().GetComponent<CameraController>().mouseSensitivity = cameraSensivity;
                    } else {
                        DeaglePlayer.GetComponentInChildren<Camera>().GetComponent<CameraController>().mouseSensitivity = defaultCameraSensivity;
                    }
                }

        }
        More_Time.gameObject.SetActive(false);
        Score_Multiplier.gameObject.SetActive(false);
        Frozen_Grenade.gameObject.SetActive(false);
        Explosive_Grenade.gameObject.SetActive(false);
        Precision.gameObject.SetActive(false);
        Reload_Speed.gameObject.SetActive(false);


        cardSelector.SetActive(false);
        isCardSelected = true;
        if(type.Equals("Bonus")){
            if(id == 0){
                PlayerData.Instance.timer += (int)card1Modifier;
            }
            if(id == 1){
                PlayerData.Instance.scoreMultiplier += card1Modifier;
            }
        } else if(type.Equals("Upgrade")){
            if(id == 0){
                PlayerData.Instance.precision += card3Modifier;
            }
            if(id == 1){
                PlayerData.Instance.reloadSpd += card3Modifier;
            }
        }
        if(type.Equals("PowerUp")){
            if(id == 0){
                Debug.Log("Frozen Grenade");
                PlayerData.Instance.frozenGrenade = true;
            }
            if(id == 1){
                PlayerData.Instance.explosiveGrenade = true;
            }
        }
        cardsDrawed = false;
        cleanButtons();

    }

    private void cleanButtons()
    {
        card1Button.onClick.RemoveAllListeners();
        card1Description.text = "";
        card1Text.text = "";
        card1Modifier = 0;
        card1Id = 0;
        card1Type = "";
        card2Button.onClick.RemoveAllListeners();
        card2Description.text = "";
        card2Text.text = "";
        card2Modifier = 0;
        card2Id = 0;
        card2Type = "";
        card3Button.onClick.RemoveAllListeners();
        card3Description.text = "";
        card3Text.text = "";
        card3Modifier = 0;
        card3Id = 0;
        card3Type = "";
    }
}
