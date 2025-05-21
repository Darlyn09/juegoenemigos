using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public float tiempoRestante = 15f;
    public TMP_Text timerText;
    public GameObject gameOverPanel;
    public GameObject winPanel;
    public TMP_Text tiempoUsadoText; // ← NUEVO

    private bool isGameOver = false;

    void Update()
    {
        if (isGameOver) return;

        tiempoRestante -= Time.deltaTime;
        timerText.text = "Tiempo: " + Mathf.CeilToInt(tiempoRestante).ToString();

        if (tiempoRestante <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
    }

    public void Ganaste()
    {
        isGameOver = true;
        Time.timeScale = 0f;
        winPanel.SetActive(true);

        // Calcular tiempo usado
        float tiempoUsado = 15f - tiempoRestante;
        tiempoUsado = Mathf.Clamp(tiempoUsado, 0, 999); // Evitar negativos

        if (tiempoUsadoText != null)
            tiempoUsadoText.text = "Tiempo usado: " + Mathf.CeilToInt(tiempoUsado).ToString() + " segundos";
    }

    public void Volver()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuScene");
    }
}
