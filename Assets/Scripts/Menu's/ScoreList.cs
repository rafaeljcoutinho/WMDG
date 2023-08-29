using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreList : MonoBehaviour
{
    public SaveMethod saveMethod;
    public Transform contentTransform;
    public ScoreController scoreController;

    [SerializeField] private Button backGameButton;

    void Start()
    {
        PopulateScoreList();
        backGameButton.onClick.AddListener(BackToMenu);
    }

    public void PopulateScoreList()
    {
        List<Dictionary<string, int>> scores = saveMethod.LoadScores();
        List<KeyValuePair<string, int>> playerScores = new List<KeyValuePair<string, int>>();

        // Adiciona todos os pares chave-valor na lista playerScores
        foreach (Dictionary<string, int> score in scores)
        {
            foreach (KeyValuePair<string, int> entry in score)
            {
                playerScores.Add(entry);
            }
        }

        // Ordena a lista de pares chave-valor pela pontuação, em ordem decrescente
        playerScores = playerScores.OrderByDescending(x => x.Value).ToList();

        // Adiciona as entradas ordenadas à lista
        for (int index = 0;  index < playerScores.Count; index++) {
            if (index > 14) // Limite de exibição para não estourar
            {
                break;
            }

            var row = Instantiate(scoreController, contentTransform).GetComponent<ScoreController>();
            row.player.text = string.IsNullOrEmpty(playerScores[index].Key) ? "Unknown" : playerScores[index].Key;
            row.score.text = playerScores[index].Value.ToString();
        }
    }

    private void BackToMenu()
    {
        SceneManager.LoadScene("Menu"); 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BackToMenu();
        }
    }
}