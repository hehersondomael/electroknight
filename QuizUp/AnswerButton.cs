using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    public Text answerText;

    private QuizUpQuestionsChoices quizUpQuestionsChoices;
    private QuizUpController quizUpController;

    // Start is called before the first frame update
    void Start()
    {
        quizUpController = FindObjectOfType<QuizUpController>();
    }

    public void Setup(QuizUpQuestionsChoices data, int i)
    {
        quizUpQuestionsChoices = data;
        answerText.text = quizUpQuestionsChoices.choice;
        if (quizUpQuestionsChoices.isCorrect)
            SetCorrectAnswerIndex(i);
    }

    public void SetCorrectAnswerIndex(int i)
    {

    }

    public void HandleClick()
    {
//        quizUpController.AnswerButtonClicked(quizUpQuestionsChoices.isCorrect);
    }
}