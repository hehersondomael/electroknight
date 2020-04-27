using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButtonPawer : MonoBehaviour
{
    public Text answerText;

    private PawerQuestionsChoices pawerQuestionsChoices;
    private PawerController pawerController;

    // Start is called before the first frame update
    void Start()
    {
        pawerController = FindObjectOfType<PawerController>();
    }

    public void Setup(PawerQuestionsChoices data)
    {
        pawerQuestionsChoices = data;
        answerText.text = pawerQuestionsChoices.choice;
    }

    public void HandleClick()
    {
        pawerController.AnswerButtonClicked(pawerQuestionsChoices.isCorrect);
    }
}