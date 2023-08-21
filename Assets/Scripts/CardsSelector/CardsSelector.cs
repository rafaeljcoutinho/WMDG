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

    [SerializeField] private GameObject frozenGranade;
    [SerializeField] private GameObject explosiveGranade;

    public void Update(){
        //imprimir o path local
        Debug.Log(Application.dataPath);
        if (PlayerData.Instance.PlayerScore > 100*scoreMultiplier && PlayerData.Instance.PlayerScore != 0)
        {
            scoreMultiplier++;
            isCardSelected = false;
        }
        if (isCardSelected == false){
            Hud.SetActive(false);
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
            
            lastTimeScale = Time.timeScale;
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            cardSelector.SetActive(true);
                Card[] cards = CardsDrawer.drawCards();
                
                card1Text.text = cards[0].name;
                card2Text.text = cards[1].name;
                card3Text.text = cards[2].name;

                card1Description.text = cards[0].description + " " + (cards[0].modifier * 100) + "%";
                card2Description.text = cards[1].description + " " + (cards[1].modifier * 100) + "%";
                card3Description.text = cards[2].description + " " + (cards[2].modifier * 100) + "%";

                try{
                    card1Image.sprite = Resources.Load<Sprite>(cards[0].image);
                }catch{
                    Debug.Log("Image "+ cards[0].image +" not found");
                }
                try{
                    card2Image.sprite = Resources.Load<Sprite>(cards[1].image);
                }catch{
                    Debug.Log("Image "+ cards[1].image +" not found");
                }
                try{
                    card3Image.sprite = Resources.Load<Sprite>(cards[2].image);
                }catch{
                    Debug.Log("Image "+ cards[2].image +" not found");
                }
                
                card1Button.onClick.AddListener(delegate { selectCard(cards[0]); });
                card2Button.onClick.AddListener(delegate { selectCard(cards[1]); });
                card3Button.onClick.AddListener(delegate { selectCard(cards[2]); });
        }else{
            cardSelector.SetActive(false);
            if (Time.timeScale == 0f){
                Time.timeScale = lastTimeScale;
            }
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
        }
        frozenGranade.SetActive(PlayerData.Instance.frozenGrenade);
        explosiveGranade.SetActive(PlayerData.Instance.explosiveGrenade);
    }

    public void selectCard(Card card){
        Hud.SetActive(true);

        Time.timeScale = lastTimeScale;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cardSelector.SetActive(false);
        isCardSelected = true;


        if(card.type == "Bonus"){
            if(card.name == "Time"){
                PlayerData.Instance.timer += card.modifier;
            }else if(card.name == "Score Multiplier"){
                PlayerData.Instance.scoreMultiplier += card.modifier;
            }
        } else if(card.type == "PowerUp"){
            if(card.name == "Frozen Grenade"){
                PlayerData.Instance.frozenGrenade = true;
            }else if(card.name == "Explosive Grenade"){
                PlayerData.Instance.explosiveGrenade = true;
            }
        } else if(card.type == "Upgrade"){
            if(card.name == "Precision"){
                PlayerData.Instance.precision += card.modifier;
            }else if(card.name == "Reload Speed"){
                PlayerData.Instance.reloadSpd += card.modifier;
            }
        }

       if(player == 1){
            AkPlayer.GetComponent<Controller>().isPaused = false;
            AkPlayer.GetComponentInChildren<Camera>().GetComponent<CameraController>().mouseSensitivity = cameraSensivity;
        } else if(player == 2){
            DeaglePlayer.GetComponent<Controller>().isPaused = false;
            DeaglePlayer.GetComponentInChildren<Camera>().GetComponent<CameraController>().mouseSensitivity = cameraSensivity;
        }

    }

}
