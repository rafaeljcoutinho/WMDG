using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class CardsSelector : MonoBehaviour
{
    [SerializeField] private GameObject card1;
    [SerializeField] private GameObject card2;
    [SerializeField] private GameObject card3;

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

    public Update(){
        
    }

}
