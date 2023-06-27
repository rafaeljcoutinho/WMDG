using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using System;

public class SaveMethod : MonoBehaviour
{
    public List<PlayerScore> playerScores;

    private string GetScoreFilePath()
    {
        string fileName = "playerScores.json";
        return Path.Combine(Application.persistentDataPath, fileName);
    }

    public void SaveScore(PlayerData playerData)
    {
        Debug.Log(GetScoreFilePath());
        playerScores = new List<PlayerScore>();
        var score = new PlayerScore(playerData.PlayerName, playerData.PlayerScore,
                                    playerData.GameMode, DateTime.Now);
        print(score);
        playerScores = LoadScores();
        playerScores.Add(score);
        string json = JsonConvert.SerializeObject(playerScores, Formatting.Indented);
        Debug.Log(json);
        using (StreamWriter streamWriter = new StreamWriter(GetScoreFilePath()))
        {
            
            streamWriter.Write(json);
        }
    }

    public List<PlayerScore> LoadScores()
    {
        string filePath = GetScoreFilePath();
        if (File.Exists(filePath))
        {
            using (StreamReader streamReader = new StreamReader(filePath))
            {
                string json = streamReader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<PlayerScore>>(json);
            }
        }
        else
        {
            // Retorna uma lista vazia se o arquivo não existir
            return new List<PlayerScore>();
        }
    }
}


[System.Serializable]
public class JsonScores
{
    public List<PlayerData> scores;
}