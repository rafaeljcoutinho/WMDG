using UnityEngine;

public class CardsDrawer{

    public static Card[] drawCards(){
        Card[] randomCards = new Card[3];

        Random.InitState(System.DateTime.Now.Millisecond);

        // Generate random indices
        int randomIndexBonus = Random.Range(0, 2);
        int randomIndexPowerUp = Random.Range(0, 2);
        int randomIndexUpgrade = Random.Range(0, 2);

        Debug.Log("Random Index Bonus: " + randomIndexBonus);
        Debug.Log("Random Index PowerUp: " + randomIndexPowerUp);
        Debug.Log("Random Index Upgrade: " + randomIndexUpgrade);

        // Assign random cards
        randomCards[0] = CardFactory.CreateCard("Bonus", randomIndexBonus);
        randomCards[1] = CardFactory.CreateCard("PowerUp", randomIndexPowerUp);
        randomCards[2] = CardFactory.CreateCard("Upgrade", randomIndexUpgrade);

        return randomCards;
    }
}