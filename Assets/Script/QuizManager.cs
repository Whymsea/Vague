using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuizManager : MonoBehaviour
{
   public Text questionText;
    public Text resultText;

    private int devScore;
    private int creaScore;
    private int comScore;
    public Image questionImage;
    private int currentQuestionIndex = 0;
    public Sprite[] questionSprites;
    public Button button1;
    public Button button2;
    public Button button3;

    private Question[] questions = new Question[]
    {
        new Question("Question 1 : Quelle est votre couleur préférée ?", "Bleu", "Rouge", "Vert", 1, 1, 1, new int[] { 0 }),
        new Question("Question 2 : Quel langage de programmation préférez-vous ?", "C#", "Python", "JavaScript", 1, 1, 1, new int[] { 1 }),
        // Ajoutez d'autres questions ici...
    };

    private void Start()
    {
        questionSprites = new Sprite[] { /* Ajoutez vos sprites ici */ };
        DisplayQuestion();
    }

    public void AnswerChoice1()
    {
        Answer(0);
    }

    public void AnswerChoice2()
    {
        Answer(1);
    }

    public void AnswerChoice3()
    {
        Answer(2);
    }

    private void Answer(int choiceIndex)
    {
        devScore += questions[currentQuestionIndex].devPoints[choiceIndex];
        creaScore += questions[currentQuestionIndex].creaPoints[choiceIndex];
        comScore += questions[currentQuestionIndex].comPoints[choiceIndex];

        currentQuestionIndex++;

        if (currentQuestionIndex < questions.Length)
        {
            DisplayQuestion();
        }
        else
        {
            DisplayResult();
        }
    }

    private void DisplayQuestion()
    {
        if (currentQuestionIndex < questions.Length)
        {
            button1.GetComponentInChildren<Text>().text = questions[currentQuestionIndex].choice1;
            button2.GetComponentInChildren<Text>().text = questions[currentQuestionIndex].choice2;
            button3.GetComponentInChildren<Text>().text = questions[currentQuestionIndex].choice3;

            button1.GetComponentInChildren<Text>().gameObject.SetActive(true);
            button2.GetComponentInChildren<Text>().gameObject.SetActive(true);
            button3.GetComponentInChildren<Text>().gameObject.SetActive(true);

            questionText.text = questions[currentQuestionIndex].question;

            Sprite[] questionImages = questions[currentQuestionIndex].GetQuestionImages(questionSprites);

            if (questionImages.Length > 0)
            {
                questionImage.sprite = questionImages[0];
                questionImage.gameObject.SetActive(true);
            }
            else
            {
                Debug.LogError("Aucune image trouvée pour la question " + currentQuestionIndex);
                questionImage.gameObject.SetActive(false);
            }
        }
        else
        {
            button1.GetComponentInChildren<Text>().gameObject.SetActive(false);
            button2.GetComponentInChildren<Text>().gameObject.SetActive(false);
            button3.GetComponentInChildren<Text>().gameObject.SetActive(false);

            questionImage.gameObject.SetActive(false);

            questionText.text = "";
        }
    }

    private void DisplayResult()
    {
        string resultMessage = "Résultats :\n\n";

        if (devScore > creaScore && devScore > comScore)
        {
            resultMessage += "Vous êtes orienté développement!";
        }
        else if (creaScore > devScore && creaScore > comScore)
        {
            resultMessage += "Vous êtes orienté créativité!";
        }
        else if (comScore > devScore && comScore > creaScore)
        {
            resultMessage += "Vous êtes orienté communication!";
        }
        else
        {
            resultMessage += "Vous avez des compétences équilibrées!\n 10201 !";
        }

        resultText.text = resultMessage;
    }

    [System.Serializable]
    public class Question
    {
        public string question;
        public string choice1;
        public string choice2;
        public string choice3;

        public int[] devPoints;
        public int[] creaPoints;
        public int[] comPoints;

        private int[] questionImageIndices;

        public Question(string question, string choice1, string choice2, string choice3, int devPoints1, int creaPoints1, int comPoints1, int[] questionImageIndices)
        {
            this.question = question;
            this.choice1 = choice1;
            this.choice2 = choice2;
            this.choice3 = choice3;

            this.devPoints = new int[] { devPoints1, devPoints1, devPoints1 };
            this.creaPoints = new int[] { creaPoints1, creaPoints1, creaPoints1 };
            this.comPoints = new int[] { comPoints1, comPoints1, comPoints1 };

            this.questionImageIndices = questionImageIndices;
        }

        public Sprite[] GetQuestionImages(Sprite[] questionSprites)
        {
            List<Sprite> images = new List<Sprite>();

            foreach (int index in questionImageIndices)
            {
                if (index >= 0 && index < questionSprites.Length)
                {
                    images.Add(questionSprites[index]);
                }
                else
                {
                    Debug.LogError("Invalid index for question image.");
                }
            }

            return images.ToArray();
        }
    }
}
