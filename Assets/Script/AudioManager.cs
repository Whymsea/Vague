using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using TMPro;
public class AudioManager : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Référence au VideoPlayer pour couper le son
    public Toggle musicToggle; // Toggle pour activer/désactiver la musique
    public Toggle soundToggle; // Toggle pour activer/désactiver les effets sonores

    private bool isAudioEnabled = true; // Variable pour suivre l'état du son
    private AudioSource[] allAudioSources;

    private void Start()
    {
        allAudioSources = FindObjectsOfType<AudioSource>(); // Trouver tous les AudioSources dans la scène
        UpdateAudio();

        // Ajoutez des écouteurs pour détecter les changements d'état des toggles
        if (musicToggle != null)
        {
            musicToggle.onValueChanged.AddListener(ToggleMusic);
        }

        if (soundToggle != null)
        {
            soundToggle.onValueChanged.AddListener(ToggleSound);
        }
    }

    void ToggleMusic(bool enableMusic)
    {
        // Mettre à jour l'état de la musique et appeler la méthode UpdateAudio pour appliquer les changements
        isAudioEnabled = enableMusic;
        UpdateAudio();
    }

    void ToggleSound(bool enableSound)
    {
        // Mettre à jour l'état des effets sonores et appeler la méthode UpdateAudio pour appliquer les changements
        isAudioEnabled = enableSound;
        UpdateAudio();
    }

    private void UpdateAudio()
    {
        if (videoPlayer != null)
        {
            // Mettre à jour le volume du VideoPlayer en fonction de l'état du son
            videoPlayer.SetDirectAudioVolume(0, isAudioEnabled ? 1f : 0f);
        }

        // Parcourir tous les AudioSources dans la scène et activer ou désactiver en fonction de isAudioEnabled
        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.enabled = isAudioEnabled;
        }
    }
}
