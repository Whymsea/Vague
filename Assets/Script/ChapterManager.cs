using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChapterManager : MonoBehaviour
{
    public GameObject chapterPanel;
    public Button[] chapterButtons;
    public Button parameterIcon;
    public VideoManager videoManager; // Ajoutez une référence au VideoManager

    private bool isChapterPanelVisible = false;

    void Start()
    {
        chapterPanel.SetActive(false);

        // Attach event handlers to the chapter buttons
        for (int i = 0; i < chapterButtons.Length; i++)
        {
            int chapterIndex = i; // To capture the correct index in the lambda expression
            chapterButtons[i].onClick.AddListener(() => OnChapterButtonSelected(chapterIndex));
        }

        // Add a handler for the onClick event of the parameterIcon
        parameterIcon.onClick.AddListener(OnParameterIconClicked);
    }

    void OnChapterButtonSelected(int chapterIndex)
    {
        // Example: Log the selected chapter index
        Debug.Log("Selected Chapter: " + chapterIndex);

        // Charger la vidéo correspondante en utilisant le VideoManager
        if (videoManager != null)
        {
            videoManager.LoadVideoByIndex(chapterIndex);
        }
        else
        {
            Debug.LogError("VideoManager reference not assigned. Please assign the VideoManager in the Unity Inspector.");
        }
    }

    void OnParameterIconClicked()
    {
        ToggleChapterPanel();
    }

    void ToggleChapterPanel()
    {
        isChapterPanelVisible = !isChapterPanelVisible;
        chapterPanel.SetActive(isChapterPanelVisible);
    }
}
