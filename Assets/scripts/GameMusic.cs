using UnityEngine;

public class GameMusic : MonoBehaviour
{
    void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("GameVolume", 0.5f);
        GetComponent<AudioSource>().volume = savedVolume;
    }
}