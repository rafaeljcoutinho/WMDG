using TMPro;
using UnityEngine;

public class ScoreEntryController : MonoBehaviour
{
    /*
    public Canvas lineScoreEntry;
    public TextMeshProUGUI[] myComps;

    public void SetScore(string playerName, int playerScore)
    {
        lineScoreEntry = GetComponent<Canvas>();
        if (lineScoreEntry != null )
        {
            myComps = GetComponentsInChildren<TextMeshProUGUI>();
            myComps[0].text = playerName;
            myComps[1].text = $"{playerScore}";
        }
    }
    */

    public TextMeshProUGUI scoreText;

    public void SetScore(string playerName, int playerScore)
    {
        scoreText.text = $"{playerName}: {playerScore}";
    }
}