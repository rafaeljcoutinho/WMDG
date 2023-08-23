using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] SaveMethod saveMethod;
    private string playerName;
    private int playerScore;
    public static PlayerData Instance { get; private set; }

    public string PlayerName => playerName;
    public int PlayerScore => playerScore;

    public int targetsHit = 0;
    public int normalTargetsHit = 0;
    public int specialTargetsHit = 0;
    public int allSpecialTargets = 0;
    public int shotsFired = 0;
    public float accuracy = 0;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        this.gameObject.tag = "PlayerData";
        GameObject[] objs = GameObject.FindGameObjectsWithTag("PlayerData");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }


        DontDestroyOnLoad(gameObject);
    }

    public void SetPlayerName(string name)
    {
        playerName = name;
    }

    public void AddPlayerScore(float value)
    {
        playerScore += (int)value;
    }
    public void ResetScore()
    {
        playerScore = 0;
        targetsHit = 0;
        normalTargetsHit = 0;
        specialTargetsHit = 0;
        allSpecialTargets = 0;
        shotsFired = 0;
        accuracy = 0;
    }

    public void Save()
    {
        saveMethod.SaveScore(this);
        ResetScore();
    }

    public float getAcurrate()
    {
        try{
            accuracy = (((float)targetsHit) / ((float)shotsFired))*10000f;
            accuracy = (float)Mathf.Round(accuracy);
            accuracy = accuracy / 100f;
        } catch (System.DivideByZeroException e){
            return 0;
        }
        return accuracy;
    }

}
