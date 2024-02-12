using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Ajoutez cette directive pour utiliser TextMeshProUGUI

public class SettingManager : MonoBehaviour
{
    public GameObject settingsPanel;
    public GameObject quizPanel; 
    public Button parameterIcon;
    public Toggle showQuizToggle;
    public QuizManager quizManager;
    public static bool showQuizzes = true;
    private bool isSettingsVisible = false;

    public TextMeshProUGUI toggleTextMeshPro; // Ajoutez une variable pour stocker la référence à TextMeshProUGUI

    private void Start()
    {
        settingsPanel.SetActive(false);
        quizPanel.SetActive(showQuizzes);
        parameterIcon.onClick.AddListener(OnParameterIconClicked);
        showQuizToggle.onValueChanged.AddListener(ShowHideQuizzes);
        showQuizToggle.isOn = true;
    }

    void OnParameterIconClicked()
    {
        ToggleSettingsPanel();
    }

    void ToggleSettingsPanel()
    {
        isSettingsVisible = !isSettingsVisible;
        settingsPanel.SetActive(isSettingsVisible);
        Debug.Log("Settings Panel visibility changed to: " + isSettingsVisible);
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
}
