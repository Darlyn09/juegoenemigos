using UnityEngine;
using TMPro;

public class GameUIManager : MonoBehaviour
{
    public TMP_Text infoText; // Arrastra aquí el texto PlayerInfoText desde el Inspector

    void Start()
    {
        // Cargar los datos guardados
        string playerName = PlayerPrefs.GetString("PlayerName", "Sin nombre");
        int difficulty = PlayerPrefs.GetInt("GameDifficulty", 0);

        string dificultadTexto = "Fácil";
        switch (difficulty)
        {
            case 1: dificultadTexto = "Media"; break;
            case 2: dificultadTexto = "Difícil"; break;
        }

        // Mostrar en pantalla
        infoText.text = "Nombre: " + playerName + " | Dificultad: " + dificultadTexto;
    }
}
