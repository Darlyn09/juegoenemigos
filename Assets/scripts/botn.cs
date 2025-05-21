using UnityEngine;
using UnityEngine.SceneManagement;

public class botn : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("escenajuego");
    }
}