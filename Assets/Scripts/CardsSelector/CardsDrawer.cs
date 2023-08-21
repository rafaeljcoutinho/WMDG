public class CardsDrawer{

    public static Cards[] drawCards{
        Card[] randomCards;

        Card[] bonusCards;
        Card[] powerUpCards;
        Card[] upgradeCards;

        using (StreamReader r = new StreamReader("BonusCards.json"))
        {
            string bonusCardsJson = r.ReadToEnd();  
            bonusCards = JsonConvert.DeserializeObject<Card[]>(bonusCardsJson);          
        }
        using (StreamReader r = new StreamReader("PowerUpCards.json"))
        {
            string powerUpCardsJson = r.ReadToEnd();  
            powerUpCards = JsonConvert.DeserializeObject<Card[]>(powerUpCardsJson);          
        }
        using (StreamReader r = new StreamReader("UpgradeCards.json"))
        {
            string upgradeCardsJson = r.ReadToEnd();  
            upgradeCards = JsonConvert.DeserializeObject<Card[]>(upgradeCardsJson);          
        }

        randomCards = new Card[3];

        randomCards[0] = bonusCards[Random.Range(0, bonusCards.Length)];
        randomCards[1] = powerUpCards[Random.Range(0, powerUpCards.Length)];
        randomCards[2] = upgradeCards[Random.Range(0, upgradeCards.Length)];

        return randomCards;
    }
}