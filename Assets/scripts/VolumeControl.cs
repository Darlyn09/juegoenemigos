using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider volumenSlider; // El nombre puede ser cualquier, pero igual al del Inspector
    public AudioSource audioSource;

    void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("volume", 0.5f);
        volumenSlider.value = savedVolume;
        audioSource.volume = savedVolume;
    }

    public void OnVolumeChange()
    {
        Debug.Log("Volumen cambiado a: " + volumenSlider.value);
        audioSource.volume = volumenSlider.value;
        PlayerPrefs.SetFloat("volume", volumenSlider.value);
    }
}
