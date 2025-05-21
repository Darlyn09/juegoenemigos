using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonSalir : MonoBehaviour
{
    public void VolverAlMenu()
    {
        SceneManager.LoadScene("MenuScene"); // Reemplaza "Menu" con el nombre exacto de tu escena de menú
    }
}
