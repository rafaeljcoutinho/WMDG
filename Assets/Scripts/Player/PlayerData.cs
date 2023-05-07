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


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void SetPlayerName(string name)
    {
        playerName = name;
    }

    public void AddPlayerScore(int value)
    {
        playerScore += value;
    }
    public void ResetScore()
    {
        playerScore = 0;
    }

    public void Save()
    {
        saveMethod.SaveScore(this);
    }
    
}
