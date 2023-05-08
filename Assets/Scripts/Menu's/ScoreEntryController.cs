using TMPro;
using UnityEngine;

public class ScoreEntryController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public void SetScore(string playerName, int playerScore)
    {
        scoreText.text = $"{playerName}: {playerScore}";
    }
}