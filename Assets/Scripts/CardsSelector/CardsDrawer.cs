using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class CardsDrawer{

    public static Card[] drawCards(){
        Card[] randomCards = new Card[3];
        List<Card> bonusCards;
        List<Card> powerUpCards;
        List<Card> upgradeCards;

        Root bonusCardsRoot;
        Root powerUpCardsRoot;
        Root upgradeCardsRoot;

        // Deserialize JSON files
        bonusCardsRoot = JsonConvert.DeserializeObject<Root>(LoadJsonFile("Assets/Scripts/CardsSelector/BonusCards.json"));
        powerUpCardsRoot = JsonConvert.DeserializeObject<Root>(LoadJsonFile("Assets/Scripts/CardsSelector/PowerUpCards.json"));
        upgradeCardsRoot = JsonConvert.DeserializeObject<Root>(LoadJsonFile("Assets/Scripts/CardsSelector/UpgradeCards.json"));

        // Assign cards to lists
        bonusCards = bonusCardsRoot.Cards;
        powerUpCards = powerUpCardsRoot.Cards;
        upgradeCards = upgradeCardsRoot.Cards;


        // Generate random indices
        System.Random rand = new System.Random();
        int randomIndexBonus = rand.Next(0, bonusCards.Count-1);
        int randomIndexPowerUp = rand.Next(0, powerUpCards.Count-1);
        int randomIndexUpgrade = rand.Next(0, upgradeCards.Count-1);

        // Assign random cards
        randomCards[0] = bonusCards[randomIndexBonus];
        randomCards[1] = powerUpCards[randomIndexPowerUp];
        randomCards[2] = upgradeCards[randomIndexUpgrade];

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