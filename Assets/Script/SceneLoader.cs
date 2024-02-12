using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneLoader : MonoBehaviour
{
    public Button changeSceneButton; // Référence au bouton dans l'éditeur Unity

     void Start()
    {
        // Ajoutez un écouteur d'événements pour le clic sur le bouton
        changeSceneButton.onClick.AddListener(ChangeToScene);
    }

    // Méthode appelée lorsque le bouton est cliqué
    private void ChangeToScene()
    {
        // Charge la scène spécifiée par son nom
        SceneManager.LoadScene("Sae 501 LOOM");
    }
}
