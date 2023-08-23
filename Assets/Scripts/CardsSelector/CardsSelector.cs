using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.InputSystem;

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

    [SerializeField] private Image card1Image;
    [SerializeField] private Image card2Image;
    [SerializeField] private Image card3Image;

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
                Card[] cards = CardsDrawer.drawCards();
                cardsDrawed = true;
                card1Text.text = cards[0].name;
                card2Text.text = cards[1].name;
                card3Text.text = cards[2].name;


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
                
                card1Button.onClick.AddListener(delegate { selectCard(cards[0]); });
                card2Button.onClick.AddListener(delegate { selectCard(cards[1]); });
                card3Button.onClick.AddListener(delegate { selectCard(cards[2]); });
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

    public void selectCard(Card card){
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


        if(card.type == "Bonus" && cardsDrawed == true){
            cardsDrawed = false;
            if(card.name == "More Time"){
                PlayerData.Instance.timer += (int)card.modifier;
            }
            else if(card.name == "Score Multiplier"){
                PlayerData.Instance.scoreMultiplier += card.modifier;
            }
        } else if(card.type == "PowerUp" && cardsDrawed == true){
            cardsDrawed = false;
            if(card.name == "Frozen Grenade"){
                PlayerData.Instance.frozenGrenade = true;
            }else if(card.name == "Explosive Grenade"){
                PlayerData.Instance.explosiveGrenade = true;
            }
        } else if(card.type == "Upgrade" && cardsDrawed == true){
            cardsDrawed = false;
            if(card.name == "Precision"){
                PlayerData.Instance.precision += card.modifier;
            }else if(card.name == "Reload Speed"){
                PlayerData.Instance.reloadSpd += card.modifier;
            }
        }

    }

}
