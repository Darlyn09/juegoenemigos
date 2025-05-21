using UnityEngine;
using TMPro;

public class GameUIManager : MonoBehaviour
{
    public TMP_Text infoText; // Arrastra aqu� el texto PlayerInfoText desde el Inspector

    void Start()
    {
        // Cargar los datos guardados
        string playerName = PlayerPrefs.GetString("PlayerName", "Sin nombre");
        int difficulty = PlayerPrefs.GetInt("GameDifficulty", 0);

        string dificultadTexto = "F�cil";
        switch (difficulty)
        {
            case 1: dificultadTexto = "Media"; break;
            case 2: dificultadTexto = "Dif�cil"; break;
        }

        // Mostrar en pantalla
        infoText.text = "Nombre: " + playerName + " | Dificultad: " + dificultadTexto;
    }
}
