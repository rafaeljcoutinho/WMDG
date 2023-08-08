using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


public class WeaponSelector : MonoBehaviour
{
    [SerializeField] private Animator cameraAnimator;
    public static WeaponSelector Instance { get; private set; }
    [SerializeField] private TextMeshProUGUI weaponName;
    [SerializeField] private Button playGameButton;
    [SerializeField] private Button goBackButton;
    [SerializeField] private Button changeWeapon;
    
    private string selectedWeapon = "Ak";
    public string SelectedWeapon => selectedWeapon;

     private void Awake()
    {
        cameraAnimator.SetInteger("Anim", -1);
            Instance = this;
    }

    void Start() {
        weaponName.text = selectedWeapon;
        playGameButton.onClick.AddListener(PlayGame);
        goBackButton.onClick.AddListener(GoBack);
        changeWeapon.onClick.AddListener(ChangeWeapon);
    }

    void ChangeWeapon() {
        if (selectedWeapon == "Ak") {
            cameraAnimator.SetInteger("Anim", 1);
            selectedWeapon = "Deagle";
        } else if (selectedWeapon == "Deagle") {
            cameraAnimator.SetInteger("Anim", 0);
            selectedWeapon = "Ak";
        }
        weaponName.text = selectedWeapon;
    }


    private void PlayGame()
    {
        SceneManager.LoadScene("ModeSelector");
    }

    private void GoBack()
    {
        SceneManager.LoadScene("Menu");
    }

}
