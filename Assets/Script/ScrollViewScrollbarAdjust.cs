using UnityEngine;
using UnityEngine.UI;

public class ScrollViewScrollbarAdjust : MonoBehaviour
{
    public ScrollRect scrollRect;
    public RectTransform content;

    void Start()
    {
        Debug.Log("Start method called");
        // Réinitialiser la taille de la barre de défilement verticale au début
        AdjustScrollbar();
    }

    void Update()
    {
        Debug.Log("Update method called");
        // Ajuster la taille de la barre de défilement verticale à chaque mise à jour (si nécessaire)
        AdjustScrollbar();
    }

        void AdjustScrollbar()
    {
        if (scrollRect.verticalScrollbar)
        {
            // Calculer le ratio entre la taille du contenu et la taille de la viewport
            float contentHeight = content.rect.height;
            float viewportHeight = scrollRect.viewport.rect.height;

            // Calculer la taille souhaitée de la barre de défilement
            float desiredScrollbarSize = 0.20f;

            // Calculer la taille de la barre de défilement en fonction de la taille du contenu et de la taille de la viewport
            float verticalScrollbarSize = Mathf.Clamp(desiredScrollbarSize * (viewportHeight / contentHeight), 0f, 1f);

            // Ajuster la taille de la barre de défilement verticale en fonction du ratio calculé
            scrollRect.verticalScrollbar.size = verticalScrollbarSize;
        }
    }
}

