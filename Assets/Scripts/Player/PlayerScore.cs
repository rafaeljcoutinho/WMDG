using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public string name { get; set; }
    public int score { get; set; }
    public string gameMode { get; set; }
    public DateTime date { get; set; }

    public PlayerScore(string name, int score, string gameMode, DateTime date)
    {
        this.name = name;
        this.score = score;
        this.gameMode = gameMode;
        this.date = date;
    }

    public PlayerScore(string name, int score, string gameMode)
    {
        this.name = name;
        this.score = score;
        this.gameMode = gameMode;
    }
    public PlayerScore()
    {
    }
}
