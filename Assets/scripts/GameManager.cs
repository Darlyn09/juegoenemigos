using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject gameOverCanvas;
    public GameObject winCanvas;
    public Text tiempoTexto;
    public Text nombreJugadorTexto;

    private float tiempoTranscurrido;
    private bool jugando = true;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Update()
    {
        if (jugando)
        {
            tiempoTranscurrido += Time.deltaTime;
        }
    }

    public void GameOver(string mensaje)
    {
        Debug.Log("GAME OVER: " + mensaje);
        if (gameOverCanvas != null)
            gameOverCanvas.SetActive(true);
        jugando = false;
    }

    public void LevelComplete()
    {
        Debug.Log("¡Nivel completado!");
        jugando = false;

        // Mostrar canvas de victoria
        if (winCanvas != null)
        {
            winCanvas.SetActive(true);
            if (tiempoTexto != null)
                tiempoTexto.text = $"Tiempo: {tiempoTranscurrido:F2} segundos";

            if (nombreJugadorTexto != null)
                nombreJugadorTexto.text = $"Jugador: {PlayerPrefs.GetString("NombreJugador", "SinNombre")}";
        }

        // Desactivar enemigos
        EnemyAI[] enemigos = FindObjectsOfType<EnemyAI>();
        foreach (var enemigo in enemigos)
        {
            enemigo.enabled = false;
        }

        // Desactivar movimiento del jugador
        PlayerMovement player = FindObjectOfType<PlayerMovement>();
        if (player != null)
            player.enabled = false;
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
