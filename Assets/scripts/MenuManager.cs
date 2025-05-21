using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public TMP_InputField nameInput;         // Input para el nombre del jugador
    public TMP_Dropdown difficultyDropdown;  // Dropdown para seleccionar dificultad
    public Slider volumeSlider;               // Slider para controlar volumen

    public void StartGame()
    {
       
        PlayerPrefs.SetString("PlayerName", nameInput.text);
        PlayerPrefs.SetInt("GameDifficulty", difficultyDropdown.value); 
        PlayerPrefs.SetFloat("GameVolume", volumeSlider.value);

       
        SceneManager.LoadScene("escenajuego");
    }
}