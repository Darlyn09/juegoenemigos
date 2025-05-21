using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private bool reached = false;
    public GameTimer gameTimer; // ← Asigna este en el Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (reached) return;

        if (other.CompareTag("Player"))
        {
            reached = true;
            gameTimer.Ganaste();
           // FindObjectOfType<GameTimer>().TerminarJuego(); // ← Detiene el temporizador
        }
    }
}
