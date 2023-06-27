using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] SaveMethod saveMethod;
    private string playerName;
    private int playerScore;
    private string gameMode;
    public static PlayerData Instance { get; private set; }

    public string PlayerName => playerName;
    public int PlayerScore => playerScore;

    public string GameMode => gameMode;


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

    public PlayerScore GetPlayerScore()
    {
        return new PlayerScore(PlayerName,PlayerScore,gameMode);
    }
    public void SetGameMode(string mode)
    {
        gameMode = mode;
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
