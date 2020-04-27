using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GuessItController : MonoBehaviour
{
    public Image guessPictureDisplay;
    public InputField answerField;
    public Text currentLevelDisplay;
    public Text finalLevelReachedDisplay;
    public Animator wrongAnswerAnimator;
    public Animator gameOverAnimator;
    public Text highestLevelReachedDisplay;
    public Text bossMessageDisplay;

    private DataController dataController;
    private GuessItData guessItData;
    private GuessItQuestions[] questionPool;

    private bool isGuessItActive;
    private int questionCount;

    private System.Random random = new System.Random();
    private GuessItQuestions currentQuestion;

    private static List<GuessItQuestions> unansweredQuestions;

    // Start is called before the first frame update
    void Start()
    {
        dataController = FindObjectOfType<DataController>();
        guessItData = dataController.GetGuessItData();

        questionPool = guessItData.questions;
        unansweredQuestions = questionPool.ToList<GuessItQuestions>();

        isGuessItActive = true;
        questionCount = 0;

        SetCurrentQuestion();
    }

    private void SetCurrentQuestion()
    {
        if (questionCount == questionPool.Length)
            EndRound();
        else
        {
            int randomQuestionIndex = random.Next(0, unansweredQuestions.Count);
            currentQuestion = unansweredQuestions[randomQuestionIndex];
            currentLevelDisplay.text = "LEVEL " + (questionCount + 1);
            guessPictureDisplay.sprite = currentQuestion.symbolImage;
            answerField.text = "";
        }
    }

    public void EnterButtonClicked()
    {
        bool isInputAnswerCorrect = false;
        for (int i = 0; i < currentQuestion.possibleAnswers.Length; i++)
        {
            if (currentQuestion.possibleAnswers[i].Equals(answerField.text, StringComparison.OrdinalIgnoreCase))
            {
                isInputAnswerCorrect = true;
                break;
            }
        }

        if (isInputAnswerCorrect)
        {
            AudioManager.Instance.PlaySound("LevelUp");
            questionCount++;
            unansweredQuestions.Remove(currentQuestion);

            if (questionPool.Length > questionCount)
                SetCurrentQuestion();
            else
                EndRound();
        }
        else
        {
            AudioManager.Instance.PlaySound("Wrong");
            wrongAnswerAnimator.SetTrigger("wrong");
            answerField.text = "";
        }
    }

    public void GiveUpButtonClicked()
    {
        isGuessItActive = false;

        dataController.SubmitNewHighestLevelReachedForGuessIt(questionCount);

        AudioManager.Instance.PlaySound("GILose");
        gameOverAnimator.SetTrigger("endscreen");

        finalLevelReachedDisplay.text = questionCount.ToString();

        highestLevelReachedDisplay.text = "Highest Level Reached: " + dataController.GetHighestGuessItLevel().ToString();
        bossMessageDisplay.text = "You won't reach the end mwahaahaha..";
    }

    public void EndRound()
    {
        isGuessItActive = false;

        dataController.SubmitNewHighestLevelReachedForGuessIt(questionCount);
 
        AudioManager.Instance.PlaySound("GIWin");
        AudioManager.Instance.PlaySound("Win");
        gameOverAnimator.SetTrigger("endscreen");

        finalLevelReachedDisplay.text = questionCount.ToString();

        highestLevelReachedDisplay.text = "Highest Level Reached: " + dataController.GetHighestGuessItLevel().ToString();
        bossMessageDisplay.text = "NoOOoooOo..I am dead";
    }
}