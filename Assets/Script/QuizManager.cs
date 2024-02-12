using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public GameObject QuizRacine;
    public TextMeshProUGUI questionText;
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;

    public Question[] questions = new Question[]
    {
        new Question("Question 1 : Quel est la particularité du Bogue ?", "Gros ventre", "Gros yeux", "Couleur unique", "Prédateur des Merlan", 2, 0),
        new Question("Question 2 : Combien de bandes brune dispose le Serran", "8", "6", "10", "3", 1, 1),
        new Question("Question 3 : Dans quelle mer/océan trouve-t-on le plus souvent des serran ", "Méditerranée", "Mer noire", "Atlantique", "Pacifique", 1, 2),
        new Question("Question 4 : Quel est le surnom de la Anthias ? ", "Le Poisson chat", "La Castagnole rouge", "Le Poisson marteau", "Le merlan éclairé", 2, 3),
        new Question("Question 5 : Quelle couleur si particulière caractérise une Anthias ?", "Gris", "Bleu", "Rose", "Vert", 3, 4),
        new Question("Question 6 : Combien de bras possède une étoile de mer épineuse ?", "10", "6", "8", "2", 1, 5),
    };

    public int currentQuestionIndex = 0;
    public VideoManager videoManager;
    public static bool showQuizzes = true;

    private void Start()
    {
        if (videoManager == null)
        {
            Debug.LogError("VideoManager reference not assigned. Please assign the VideoManager in the Unity Inspector.");
            return;
        }
        AddButtonEventListeners();
        DisplayQuestion();
    }

    private void AddButtonEventListeners()
    {
        button1.onClick.AddListener(() => Answer(0));
        button2.onClick.AddListener(() => Answer(1));
        button3.onClick.AddListener(() => Answer(2));
        button4.onClick.AddListener(() => Answer(3));
    }

    public void StartQuiz()
    {
        currentQuestionIndex = 0;
        DisplayQuestionForVideo(videoManager.GetCurrentVideoIndex());
    }

    public void Answer(int choiceIndex)
    {
        Question currentQuestion = questions[currentQuestionIndex];
        currentQuestion.userAnswer = choiceIndex;
        currentQuestion.isCorrect = (currentQuestion.userAnswer == currentQuestion.correctChoice);
        UpdateButtonColor(choiceIndex, currentQuestion.isCorrect);
        currentQuestionIndex++;
        if (currentQuestionIndex < questions.Length)
        {
            StartCoroutine(DisplayNextQuestion());
        }
        else
        {
            if (AreAllQuestionsAnsweredForCurrentVideo())
            {
                StartCoroutine(MoveToNextVideo());
            }
            else
            {
                Debug.Log("Quiz terminé !");
            }
        }
    }

    private void UpdateButtonColor(int choiceIndex, bool isCorrect)
    {
        Button selectedButton = null;
        switch (choiceIndex)
        {
            case 0:
                selectedButton = button1;
                break;
            case 1:
                selectedButton = button2;
                break;
            case 2:
                selectedButton = button3;
                break;
            case 3:
                selectedButton = button4;
                break;
        }

        if (selectedButton != null)
        {
            selectedButton.GetComponent<Image>().color = isCorrect ? Color.green : Color.red;
        }
    }

    private IEnumerator MoveToNextVideo()
    {
        yield return new WaitForSeconds(3f);
        videoManager.NextVideo();
    }

    private bool AreAllQuestionsAnsweredForCurrentVideo()
    {
        int currentVideoIndex = questions[currentQuestionIndex - 1].videoIndex;
        return questions.Where(q => q.videoIndex == currentVideoIndex).All(q => q.userAnswer != -1);
    }

    private IEnumerator DisplayNextQuestion()
    {
        yield return new WaitForSeconds(2f);
        DisplayQuestion();
    }

    private void DisplayQuestion(Question questionToDisplay = null)
    {
        ResetButtonColors();
        button1.GetComponent<Image>().color = Color.white;
        button2.GetComponent<Image>().color = Color.white;
        button3.GetComponent<Image>().color = Color.white;
        button4.GetComponent<Image>().color = Color.white;

        if (questionToDisplay == null)
        {
            questionToDisplay = questions[currentQuestionIndex];
        }

        button1.GetComponentInChildren<TextMeshProUGUI>().text = questionToDisplay.choice1;
        button2.GetComponentInChildren<TextMeshProUGUI>().text = questionToDisplay.choice2;
        button3.GetComponentInChildren<TextMeshProUGUI>().text = questionToDisplay.choice3;
        button4.GetComponentInChildren<TextMeshProUGUI>().text = questionToDisplay.choice4;

        questionText.text = questionToDisplay.question;
    }

    public void DisplayQuestionForVideo(int videoIndex)
    {
        foreach (var q in questions)
        {
            if (q.videoIndex == videoIndex)
            {
                DisplayQuestion(q);
                break;
            }
        }
    }

    void ResetButtonColors()
    {
        button1.GetComponent<Image>().color = Color.white;
        button2.GetComponent<Image>().color = Color.white;
        button3.GetComponent<Image>().color = Color.white;
        button4.GetComponent<Image>().color = Color.white;
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
        public bool isCorrect;

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
