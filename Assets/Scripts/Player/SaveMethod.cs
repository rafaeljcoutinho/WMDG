using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
public class SaveMethod : MonoBehaviour
{
    public List<Dictionary<string , int>> playerScores;

    private string GetScoreFilePath()
    {
        string fileName = "playerScores.json";
        return Path.Combine(Application.persistentDataPath, fileName);
    }

    public void SaveScore(PlayerData playerData)
    {
        Debug.Log(GetScoreFilePath());
        playerScores = new List<Dictionary<string, int>>();
        playerScores = LoadScores();
        var test = new Dictionary<string, int>();
        test.Add(playerData.PlayerName, playerData.PlayerScore);
        playerScores.Add(test);
        string json = JsonConvert.SerializeObject(playerScores);
        Debug.Log(json);
        using (StreamWriter streamWriter = new StreamWriter(GetScoreFilePath()))
        {
            
            streamWriter.Write(json);
        }
    }

    public List<Dictionary<string, int>> LoadScores()
    {
        string filePath = GetScoreFilePath();
        if (File.Exists(filePath))
        {
            using (StreamReader streamReader = new StreamReader(filePath))
            {
                string json = streamReader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Dictionary<string, int>>>(json);
            }
        }
        else
        {
            // Retorna uma lista vazia se o arquivo não existir
            return new List<Dictionary<string, int>>();
        }
    }
}


[System.Serializable]
public class JsonScores
{
    public List<PlayerData> scores;
}