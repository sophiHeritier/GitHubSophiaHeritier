using UnityEngine;

using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI y Puntuación")]
    public TextMeshProUGUI scoreText;
    public GameObject winPanel;

    private int totalItems;
    private int collectedItems = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Cuenta automáticamente cuántos coleccionables hay en el nivel
        totalItems = GameObject.FindGameObjectsWithTag("Pickup").Length;
        UpdateScoreUI();

        if (winPanel != null)
        {
            winPanel.SetActive(false); // Oculta el panel de victoria al iniciar
        }
    }

    public void AddScore()
    {
        collectedItems++;
        UpdateScoreUI();

        // Condición de victoria al recolectar todos los ítems
        if (collectedItems >= totalItems)
        {
            WinGame();
        }
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Items: " + collectedItems + " / " + totalItems;
        }
    }

    void WinGame()
    {
        if (winPanel != null)
        {
            winPanel.SetActive(true); // Muestra el panel de victoria
        }
        Time.timeScale = 0f; // Pausa el juego opcionalmente
    }
}