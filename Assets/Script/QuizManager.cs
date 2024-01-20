using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class QuizManager : MonoBehaviour
{
    public GameObject QuizRacine;
    public Text questionText;
    public XRGrabInteractable button1;
    public XRGrabInteractable button2;
    public XRGrabInteractable button3;
    public XRGrabInteractable button4;

    public MeshRenderer button1Renderer;
    public MeshRenderer button2Renderer;
    public MeshRenderer button3Renderer;
    public MeshRenderer button4Renderer;

    public Text button1Text;
    public Text button2Text;
    public Text button3Text;
    public Text button4Text;

    public Question[] questions = new Question[]
    {
        new Question("Question 1 : Quelle est la couleur d'un bar commun ?", "Bleu", "Rouge", "Vert", "Jaune", 2, 0),
        new Question("Question 2 : Quelle est la longueur d'un poulet ?", "1m50", "3m10", "1m75", "1m25", 1, 1),
        // Associez chaque question à une vidéo spécifique...
    };

    public int currentQuestionIndex = 0;

    public VideoManager videoManager;

    private void Start()
    {
        // Assurez-vous que videoManager est correctement attribué dans l'inspecteur Unity
        if (videoManager == null)
        {
            Debug.LogError("VideoManager reference not assigned. Please assign the VideoManager in the Unity Inspector.");
            return;
        }

        // Assurez-vous que les MeshRenderer des boutons sont correctement attribués dans l'inspecteur Unity
        if (button1Renderer == null || button2Renderer == null || button3Renderer == null || button4Renderer == null)
        {
            Debug.LogError("MeshRenderer references not assigned. Please assign MeshRenderers for all buttons in the Unity Inspector.");
            return;
        }

        DisplayQuestion();
    }

    public void StartQuiz()
    {
        // Assurez-vous que la variable currentVideoIndex est initialisée ou a une valeur appropriée
        // Vous pouvez initialiser la variable ici ou à un autre endroit selon vos besoins.
        currentQuestionIndex = 0;

        // Votre logique pour démarrer le quiz ici
        DisplayQuestionForVideo(videoManager.GetCurrentVideoIndex());
    }

    public void Answer(int choiceIndex)
    {
        Question currentQuestion = questions[currentQuestionIndex];
        currentQuestion.userAnswer = choiceIndex;

        // Vérifier si la réponse de l'utilisateur est correcte
        currentQuestion.isCorrect = (currentQuestion.userAnswer == currentQuestion.correctChoice);

        // Mettre à jour la couleur des boutons en fonction de la réponse
        UpdateButtonColors();

        currentQuestionIndex++;

        if (currentQuestionIndex < questions.Length)
        {
            // Afficher la prochaine question après un court délai
            StartCoroutine(DisplayNextQuestion());
        }
        else
        {
            // Vérifier si toutes les questions pour la vidéo actuelle ont été répondues
            if (AreAllQuestionsAnsweredForCurrentVideo())
            {
                // Passer à la vidéo suivante après un court délai
                StartCoroutine(MoveToNextVideo());
            }
            else
            {
                // Ajoutez ici la logique à exécuter lorsque toutes les questions ont été répondues
                Debug.Log("Quiz terminé !");
            }
        }
    }

    private void UpdateButtonColors()
    {
        Question currentQuestion = questions[currentQuestionIndex];

        // Changer la couleur des boutons en fonction de la réponse de l'utilisateur
        button1Renderer.material.color = (currentQuestion.userAnswer == 0) ? GetButtonColor(currentQuestion) : Color.white;
        button2Renderer.material.color = (currentQuestion.userAnswer == 1) ? GetButtonColor(currentQuestion) : Color.white;
        button3Renderer.material.color = (currentQuestion.userAnswer == 2) ? GetButtonColor(currentQuestion) : Color.white;
        button4Renderer.material.color = (currentQuestion.userAnswer == 3) ? GetButtonColor(currentQuestion) : Color.white;
    }

    private Color GetButtonColor(Question question)
    {
        // Retourner la couleur appropriée en fonction de la correction de la réponse
        return question.isCorrect ? Color.green : Color.red;
    }

    private IEnumerator MoveToNextVideo()
    {
        // Attendre quelques secondes avant de passer à la vidéo suivante
        yield return new WaitForSeconds(3f);

        // Passer à la vidéo suivante en appelant la fonction de VideoManager
        videoManager.NextVideo();
    }

    private bool AreAllQuestionsAnsweredForCurrentVideo()
    {
        // Vérifier si toutes les questions pour la vidéo actuelle ont été répondues
        int currentVideoIndex = questions[currentQuestionIndex - 1].videoIndex;
        return questions.Where(q => q.videoIndex == currentVideoIndex).All(q => q.userAnswer != -1);
    }

    private IEnumerator DisplayNextQuestion()
    {
        // Attendre quelques secondes avant d'afficher la prochaine question
        yield return new WaitForSeconds(2f);

        // Afficher la prochaine question
        DisplayQuestion();
    }

    private void DisplayQuestion(Question questionToDisplay = null)
    {
        // Réinitialiser la couleur des boutons
        ResetButtonColors();

        // Utilisez le paramètre de la méthode plutôt que la variable locale
        button1Text.text = questionToDisplay.choice1;
        button2Text.text = questionToDisplay.choice2;
        button3Text.text = questionToDisplay.choice3;
        button4Text.text = questionToDisplay.choice4;

        questionText.text = questionToDisplay.question;
    }

    public void DisplayQuestionForVideo(int videoIndex)
    {
        // Recherchez la question associée à la vidéo actuelle
        foreach (var q in questions)
        {
            if (q.videoIndex == videoIndex)
            {
                // Affichez la question trouvée
                DisplayQuestion(q);
                break;
            }
        }
    }

    void ResetButtonColors()
    {
        ChangeButtonColor(button1Renderer, Color.white);
        ChangeButtonColor(button2Renderer, Color.white);
        ChangeButtonColor(button3Renderer, Color.white);
        ChangeButtonColor(button4Renderer, Color.white);
    }

    void ChangeButtonColor(MeshRenderer buttonRenderer, Color color)
    {
        if (buttonRenderer != null)
        {
            buttonRenderer.material.color = color;
        }
        else
        {
            Debug.LogError("Le bouton n'a pas de composant MeshRenderer attaché.");
        }
    }

    [System.Serializable]
    public class Question
    {
        public string question;
        public string choice1;
        public string choice2;
        public string choice3;
        public string choice4;
        public int correctChoice;
        public int videoIndex;
        public int userAnswer = -1;
        public bool isCorrect;  // Nouvelle propriété pour indiquer si la réponse est correcte

        public Question(string question, string choice1, string choice2, string choice3, string choice4, int correctChoice, int videoIndex)
        {
            this.question = question;
            this.choice1 = choice1;
            this.choice2 = choice2;
            this.choice3 = choice3;
            this.choice4 = choice4;
            this.correctChoice = correctChoice;
            this.videoIndex = videoIndex;
        }
    }
}
