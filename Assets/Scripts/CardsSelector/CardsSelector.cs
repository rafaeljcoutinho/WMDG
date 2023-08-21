using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.InputSystem;

public class CardsSelector : MonoBehaviour
{
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

    [SerializeField] private TextMeshProUGUI card1Type;
    [SerializeField] private TextMeshProUGUI card2Type;
    [SerializeField] private TextMeshProUGUI card3Type;

    [SerializeField] private TextMeshProUGUI card1Modifier;
    [SerializeField] private TextMeshProUGUI card2Modifier;
    [SerializeField] private TextMeshProUGUI card3Modifier;

    [SerializeField] private Image card1Image;
    [SerializeField] private Image card2Image;
    [SerializeField] private Image card3Image;

    [SerializeField] private bool isCardSelected=true;

    private float lastTimeScale;

    private int scoreMultiplier = 1;

    public void Update(){
        //imprimir o path local
        Debug.Log(Application.dataPath);
        if (PlayerData.Instance.PlayerScore > 100*scoreMultiplier && PlayerData.Instance.PlayerScore != 0)
        {
            scoreMultiplier++;
            isCardSelected = false;
        }
        if (isCardSelected == false){

            
            lastTimeScale = Time.timeScale;
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            cardSelector.SetActive(true);
            Card[] cards = CardsDrawer.drawCards();
            
            card1Text.text = cards[0].name;
            card2Text.text = cards[1].name;
            card3Text.text = cards[2].name;

            card1Description.text = cards[0].description;
            card2Description.text = cards[1].description;
            card3Description.text = cards[2].description;

            card1Type.text = cards[0].type;
            card2Type.text = cards[1].type;
            card3Type.text = cards[2].type;

            card1Modifier.text = cards[0].modifier;
            card2Modifier.text = cards[1].modifier;
            card3Modifier.text = cards[2].modifier;

            card1Image.sprite = Resources.Load<Sprite>(cards[0].image);
            card2Image.sprite = Resources.Load<Sprite>(cards[1].image);
            card3Image.sprite = Resources.Load<Sprite>(cards[2].image);

            
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
                TargetController.Instance.Frozen(10f);

            }
            if(Input.GetKeyDown(KeyCode.E) && PlayerData.Instance.explosiveGrenade == true){
                PlayerData.Instance.explosiveGrenade = false;
                TargetController.Instance.Explode();
            }
        }
    }

    public void selectCard(Card card){
        
        Time.timeScale = lastTimeScale;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cardSelector.SetActive(false);
        isCardSelected = true;

        if(card.type == "Bonus"){
            if(card.name == "Time"){
                PlayerData.Instance.timer += int.Parse(card.modifier);
            }else if(card.name == "Score Multiplier"){
                PlayerData.Instance.scoreMultiplier = int.Parse(card.modifier);
            }
        } else if(card.type == "PowerUp"){
            if(card.name == "Frozen Grenade"){
                PlayerData.Instance.frozenGrenade = true;
            }else if(card.name == "Explosive Grenade"){
                PlayerData.Instance.explosiveGrenade = true;
            }
        } else if(card.type == "Upgrade"){
            if(card.name == "Precision"){
                PlayerData.Instance.precision += float.Parse(card.modifier);
            }else if(card.name == "Reload Speed"){
                PlayerData.Instance.reloadSpd += float.Parse(card.modifier);
            }
        }
    }

}
