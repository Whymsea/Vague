using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    public GameObject settingsPanel;
    public Button settingsButton;
    public Slider musicVolumeSlider;
    public Slider videoSoundVolumeSlider;
    public Toggle showQuizToggle;

    // Ajoutez cette ligne pour la gestion de l'affichage des quiz
    public static bool showQuizzes = true;

    private bool isSettingsVisible = false;

    void Start()
    {
        settingsPanel.SetActive(false);
        settingsButton.onClick.AddListener(ToggleSettingsPanel);
        musicVolumeSlider.onValueChanged.AddListener(AdjustMusicVolume);
        videoSoundVolumeSlider.onValueChanged.AddListener(AdjustVideoSoundVolume);
        showQuizToggle.onValueChanged.AddListener(ToggleShowQuizzes);

        // Initialisation des valeurs par défaut
        musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f) * 100f;
        videoSoundVolumeSlider.value = PlayerPrefs.GetFloat("VideoSoundVolume", 1f) * 100f;
    }

    void ToggleSettingsPanel()
    {
        isSettingsVisible = !isSettingsVisible;
        settingsPanel.SetActive(isSettingsVisible);
    }

    void AdjustMusicVolume(float volume)
    {
        float normalizedVolume = volume / 100f;
        AudioListener.volume = normalizedVolume;
        PlayerPrefs.SetFloat("MusicVolume", normalizedVolume);
    }

    void AdjustVideoSoundVolume(float volume)
    {
        // Mettez ici la logique pour ajuster le volume du son de la vidéo
        // Par exemple, si vous utilisez VideoPlayer avec un AudioSource :
        // videoPlayer.GetComponent<AudioSource>().volume = volume / 100f;
        PlayerPrefs.SetFloat("VideoSoundVolume", volume / 100f);
    }

    // Ajoutez cette méthode pour gérer le changement de valeur du Toggle
    void ToggleShowQuizzes(bool value)
    {
        showQuizzes = value;
    }
}
