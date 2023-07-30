using UnityEngine;
using UnityEngine.UI;

public class AmmoDisplay : MonoBehaviour
{
    [SerializeField] private WeaponManager weaponManager;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private RectTransform aimPoint;
    
    [SerializeField] private float circleRadius = 50f; // Raio do círculo que as bolinhas formarão

    private RectTransform[] bullets;
    private int maxBullets;

    private void Start()
    {
        maxBullets = weaponManager.AmmoCapaicty;
        // Inicializa o array de bolinhas
        bullets = new RectTransform[maxBullets];

        // Cria as bolinhas no início do jogo
        CreateBullets();
    }

    private void Update()
    {
        // Atualiza a quantidade de balas exibidas sempre que o jogador atirar
        UpdateBullets();
    }

    private void CreateBullets()
    {
        // Verifica se o objeto da mira foi configurado corretamente
        if (aimPoint == null)
        {
            Debug.LogError("O objeto da mira não foi atribuído no Inspector!");
            return;
        }

        for (int i = 0; i < maxBullets; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform); // Cria a bolinha como filho do objeto AmmoDisplay
            bullets[i] = bullet.GetComponent<RectTransform>();

            // Posiciona cada bolinha ao redor do ponto da mira formando um círculo
            float angle = i * (360f / maxBullets);
            Vector2 offset = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)) * circleRadius;
            bullet.GetComponent<RectTransform>().anchoredPosition = aimPoint.anchoredPosition + offset;
        }
    }

    private void UpdateBullets()
    {
        int currentBullets = weaponManager.CurrentAmmo; // Obtém a quantidade atual de balas do script de controle de arma

        for (int i = 0; i < maxBullets; i++)
        {
            if (i < currentBullets)
            {
                bullets[i].gameObject.SetActive(true); // Ativa as bolinhas correspondentes à quantidade de balas disponíveis
            }
            else
            {
                bullets[i].gameObject.SetActive(false); // Desativa as bolinhas restantes (não há mais balas disponíveis)
            }
        }
    }
}
