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

    // Variable pour indiquer si les quiz doivent être affichés
    public static bool showQuizzes = true;

    private bool isSettingsVisible = false;

    void Start()
    {
        settingsPanel.SetActive(false);
        settingsButton.onClick.AddListener(ToggleSettingsPanel);
        musicVolumeSlider.onValueChanged.AddListener(AdjustMusicVolume);
        videoSoundVolumeSlider.onValueChanged.AddListener(AdjustVideoSoundVolume);
        showQuizToggle.onValueChanged.AddListener(ShowHideQuizzes);

        // Initialisation des valeurs par défaut (vous pouvez ajuster selon vos besoins)
        musicVolumeSlider.value = AudioListener.volume * 100f;
        videoSoundVolumeSlider.value = 100f;
        showQuizToggle.isOn = true;
    }

    void ToggleSettingsPanel()
    {
        isSettingsVisible = !isSettingsVisible;
        settingsPanel.SetActive(isSettingsVisible);
    }

    void AdjustMusicVolume(float volume)
    {
        // Convertir le pourcentage du slider en une valeur entre 0 et 1 pour AudioListener.volume
        float normalizedVolume = volume / 100f;
        AudioListener.volume = normalizedVolume;

        // Vous pouvez également stocker la valeur dans un gestionnaire de préférences ou l'utiliser ailleurs selon vos besoins
        PlayerPrefs.SetFloat("MusicVolume", normalizedVolume);
    }

    void AdjustVideoSoundVolume(float volume)
    {
        // Convertir le pourcentage du slider en une valeur entre 0 et 1
        float normalizedVolume = volume / 100f;

        // Par exemple, si vous utilisez VideoPlayer :
        // videoPlayer.GetComponent<AudioSource>().volume = normalizedVolume;

        // Vous pouvez également stocker la valeur dans un gestionnaire de préférences ou l'utiliser ailleurs selon vos besoins
        PlayerPrefs.SetFloat("VideoSoundVolume", normalizedVolume);
    }

    void ShowHideQuizzes(bool show)
    {
        Debug.Log("Afficher les quiz : " + show);
        // Mettez à jour la variable showQuizzes en fonction de la valeur du toggle
        showQuizzes = show;
    }
}
