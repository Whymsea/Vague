using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingManager : MonoBehaviour
{
    public GameObject settingsPanel;
    public GameObject quizPanel; 
    public Button parameterIcon;
    public Toggle showQuizToggle;
    public TextMeshProUGUI toggleTextMeshPro;
    public QuizManager quizManager;
    public VideoManager videoManager; // Ajoutez une référence au VideoManager
    public static bool showQuizzes = true;
    private bool isSettingsVisible = false;

    [SerializeField] Slider volumeSlider;

    public void ChangeVolume()
    {
        float normalizedVolume = volumeSlider.value / 100f;
        AudioListener.volume = normalizedVolume;
        Save();
        Debug.Log("Volume changed to: " + normalizedVolume);
    }

    private void Start()
    {
        settingsPanel.SetActive(false);
        quizPanel.SetActive(showQuizzes);
        parameterIcon.onClick.AddListener(OnParameterIconClicked);
        showQuizToggle.onValueChanged.AddListener(ShowHideQuizzes);
        showQuizToggle.isOn = true;

        Load();

        // Ajoutez une vérification pour s'assurer que videoManager est correctement attribué
        if (videoManager == null)
        {
            Debug.LogError("VideoManager reference not assigned. Please assign the VideoManager in the Unity Inspector.");
        }
    }

    void OnParameterIconClicked()
    {
        ToggleSettingsPanel();
    }

    void ToggleSettingsPanel()
    {
        isSettingsVisible = !isSettingsVisible;
        settingsPanel.SetActive(isSettingsVisible);
    }

    void ShowHideQuizzes(bool show)
    {
        showQuizzes = show;
        quizPanel.SetActive(show);

        if (toggleTextMeshPro != null)
        {
            toggleTextMeshPro.text = show ? "On" : "Off";
        }
        else
        {
            Debug.LogError("TextMeshProUGUI non assigné. Veuillez assigner le TextMeshProUGUI dans l'éditeur Unity.");
        }

        Color toggleBackgroundColor = show ? Color.white : Color.gray;
        showQuizToggle.GetComponent<Image>().color = toggleBackgroundColor;
        Debug.Log("Afficher les quiz : " + show);
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume", 100f); // Ajoutez une valeur par défaut si aucune valeur n'est trouvée
        ChangeVolume(); // Appliquez le volume au chargement
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}
