using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class CardsDrawer{

    public static Card[] drawCards(){
        Card[] randomCards = new Card[3];
        Card[] bonusCards;
        Card[] powerUpCards;
        Card[] upgradeCards;
        try
        {
            // Load and deserialize bonus cards
            string bonusCardsJson = LoadJsonFile("./Assets/Scripts/CardsSelector/BonusCards.json");
            bonusCards = JsonConvert.DeserializeObject<Card[]>(bonusCardsJson);

            Debug.Log("bonusCards length: " + (bonusCards != null ? bonusCards.Length : 0));
            
            // Load and deserialize power-up cards
            string powerUpCardsJson = LoadJsonFile("./Assets/Scripts/CardsSelector/PowerUpCards.json");
            powerUpCards = JsonConvert.DeserializeObject<Card[]>(powerUpCardsJson);
            
            Debug.Log("powerUpCards length: " + (powerUpCards != null ? powerUpCards.Length : 0));

            // Load and deserialize upgrade cards
            string upgradeCardsJson = LoadJsonFile("./Assets/Scripts/CardsSelector/UpgradeCards.json");
            upgradeCards = JsonConvert.DeserializeObject<Card[]>(upgradeCardsJson);
            
            Debug.Log("upgradeCards length: " + (upgradeCards != null ? upgradeCards.Length : 0));

            // Generate random indices
            System.Random rand = new System.Random();
            int randomIndexBonus = rand.Next(0, bonusCards.Length);
            int randomIndexPowerUp = rand.Next(0, powerUpCards.Length);
            int randomIndexUpgrade = rand.Next(0, upgradeCards.Length);

            // Assign random cards
            randomCards[0] = bonusCards[randomIndexBonus];
            randomCards[1] = powerUpCards[randomIndexPowerUp];
            randomCards[2] = upgradeCards[randomIndexUpgrade];
        }
        catch (Exception ex)
        {
            Debug.LogError("Error loading and deserializing JSON: " + ex.Message);
            Debug.LogError("Stack trace: " + ex.StackTrace);
            Debug.LogError("Inner exception: " + ex.InnerException);
            Debug.LogError("Source: " + ex.Source);
            
        }

        return randomCards;
    }
    
    private static string LoadJsonFile(string filePath)
    {
        using (StreamReader r = new StreamReader(filePath))
        {
            Debug.Log("Loading JSON file: " + filePath);
            Debug.Log("JSON file contents: " + r.ReadToEnd());
            return r.ReadToEnd();
        }
    }
}