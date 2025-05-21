using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed = 3f;
    public Transform player;
    private Vector3 startPosition;

    private int hits = 0;
    private float originalSpeed;

    // Prefab del sistema de partículas para el efecto al tocar al jugador
    public GameObject hitParticlePrefab;

    // Componente de audio para reproducir sonido al tocar al jugador
    private AudioSource audioSource;

    void Start()
    {
        originalSpeed = speed;
        startPosition = transform.position;

        // Buscar al jugador si no está asignado
        if (player == null)
            player = GameObject.FindWithTag("Player").transform;

        // Cambiar velocidad según la dificultad
        int difficulty = PlayerPrefs.GetInt("GameDifficulty", 0); // 0: fácil, 1: medio, 2: difícil
        float multiplier = 1f;
        if (difficulty == 1) multiplier = 2f;      // Medio
        else if (difficulty == 2) multiplier = 3f; // Difícil

        speed *= multiplier;
        originalSpeed = speed; // Guardamos el nuevo originalSpeed

        // Obtener componente AudioSource
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (player == null) return;

        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
        transform.LookAt(player);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Instanciar partículas
            if (hitParticlePrefab != null)
            {
                Instantiate(hitParticlePrefab, transform.position, Quaternion.identity);
            }

            // Reproducir sonido si hay un AudioSource
            if (audioSource != null)
            {
                audioSource.Play();
            }

            hits++;
            Debug.Log("Enemy hit player. Hits: " + hits);

            if (hits == 1)
            {
                StartCoroutine(SlowDownTemporarily());
            }
            else if (hits >= 2)
            {
                Debug.Log("Game Over triggered by: " + gameObject.name);
                GameManager.instance.GameOver("Perdiste por un kamikaze 😵");
                Destroy(gameObject);
            }
        }
    }

    IEnumerator SlowDownTemporarily()
    {
        speed *= 0.5f;
        Debug.Log("Enemy slowed to: " + speed);
        yield return new WaitForSeconds(3f);
        speed = originalSpeed;
        Debug.Log("Enemy speed restored: " + speed);
    }
}
