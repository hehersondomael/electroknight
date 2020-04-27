using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ResistController : MonoBehaviour
{
    // This code is set for polishing only after the "atras-abante numero" feature is included on this game.
    public Image resistorPictureDisplay;
    public Text scoreDisplayText;
    public Text timeRemainingDisplay;
    public Text firstDigitButton;
    public Text secondDigitButton;
    public Text thirdDigitButton;
    public Text resistorUnitButton;
    public Text toleranceValueButton;
    public Text passesLeft;
    public Animator resistAnimator;
    public Text finalScore;
    public Text highScore;

    private DataController dataController;
    private ResistData resistData;
    private ResistQuestions[] questionPool;
    private int playerScore;

    private bool isResistActive;
    private char firstDigitIndex;
    private char secondDigitIndex;
    private char thirdDigitIndex;
    private float timeRemaining;
    private int playerPassesLeft;

    private bool currentQuestionIsAnswered;

    public static string[] resistorUnits = {"ohms", "kilohms", "megohms"};
    public static string[] toleranceValues = {"10%", "5%", "2%", "1%"};

    private int resistorUnitIndex;
    private int toleranceValueIndex;

    private int questionCount;

    private System.Random random = new System.Random();
    private static List<ResistQuestions> unansweredQuestions;
    private ResistQuestions currentQuestion;

    private int randomQuestionIndex;
    private int previousRandomQuestionIndex;

    // Start is called before the first frame update
    void Start()
    {
        isResistActive = true;
        playerPassesLeft = 5;
        currentQuestionIsAnswered = true;
        dataController = FindObjectOfType<DataController>();
        resistData = dataController.GetResistData();
        questionPool = resistData.questions;
        timeRemaining = resistData.timeLimitInSeconds;
        UpdateTimeRemainingDisplay();

        previousRandomQuestionIndex = 0;
        ResetButtonContents();
        unansweredQuestions = questionPool.ToList<ResistQuestions>();
        SetCurrentQuestion();
    }

    private void SetCurrentQuestion()
    {

        if (questionCount == questionPool.Length)
            EndRound();
        else
        {
            if (currentQuestionIsAnswered)
            {
                ResetButtonContents();
                randomQuestionIndex = random.Next(0, unansweredQuestions.Count);
            }
            else
                randomQuestionIndex = previousRandomQuestionIndex;

            currentQuestion = unansweredQuestions[randomQuestionIndex];
            resistorPictureDisplay.sprite = currentQuestion.resistorImage;
            previousRandomQuestionIndex = randomQuestionIndex;
        }
    }

    public void ResetButtonContents()
    {
        firstDigitIndex = '0'; 
        secondDigitIndex = '.';
        thirdDigitIndex = '0';
        resistorUnitIndex = 0;
        toleranceValueIndex = 0;
        firstDigitButton.text = firstDigitIndex.ToString();
        secondDigitButton.text = secondDigitIndex.ToString();
        thirdDigitButton.text = thirdDigitIndex.ToString();
        resistorUnitButton.text = resistorUnits[resistorUnitIndex];
        toleranceValueButton.text = toleranceValues[toleranceValueIndex];
    }

    public void OnFirstDigitButtonClick()
    {
	firstDigitIndex++;
	if (firstDigitIndex > '9')
		firstDigitIndex = '0';
        firstDigitButton.text = firstDigitIndex.ToString();
    }

    public void OnFirstDigitButtonClickMinus()
    {
	firstDigitIndex--;
	if (firstDigitIndex < '0')
		firstDigitIndex = '9';
        firstDigitButton.text = firstDigitIndex.ToString();
    }

    public void OnSecondDigitButtonClick()
    {
	secondDigitIndex++;
	if (secondDigitIndex == '/')
		secondDigitIndex = '0';
    if (secondDigitIndex > '9')
            secondDigitIndex = '.';
	secondDigitButton.text = secondDigitIndex.ToString();
    }

    public void OnSecondDigitButtonClickMinus()
    {
        secondDigitIndex--;
        if (secondDigitIndex == '.')
            secondDigitIndex = '9';
        if (secondDigitIndex == '/')
            secondDigitIndex = '.';
        if (secondDigitIndex == '-')
            secondDigitIndex = '9';
        secondDigitButton.text = secondDigitIndex.ToString();
    }

    public void OnThirdDigitButtonClick()
    {
        thirdDigitIndex++;
        if (thirdDigitIndex > '9')
            thirdDigitIndex = '0'; 
        thirdDigitButton.text = thirdDigitIndex.ToString();
    }

    public void OnThirdDigitButtonClickMinus()
    {
        thirdDigitIndex--;
        if (thirdDigitIndex < '0')

            thirdDigitIndex = '9';
        thirdDigitButton.text = thirdDigitIndex.ToString();
    }

    public void OnResistorUnitButtonClick()
    {
        resistorUnitIndex++;
        if (resistorUnitIndex > resistorUnits.Length-1)
            resistorUnitIndex = 0;
        resistorUnitButton.text = resistorUnits[resistorUnitIndex];
    }

    public void OnToleranceValueButtonClick()
    {
        toleranceValueIndex++;
        if (toleranceValueIndex > toleranceValues.Length-1)
            toleranceValueIndex = 0;
        toleranceValueButton.text = toleranceValues[toleranceValueIndex];
    }

    public void OnEnterClick()
    {
        bool resistorUnitChoiceIsCorrect = false;
        bool toleranceValueChoiceIsCorrect = false;


        for (int i = 0; i<resistorUnits.Length; i++)
        {
            if (currentQuestion.resistorUnit.Equals(resistorUnitButton.text, StringComparison.OrdinalIgnoreCase))
            {
                resistorUnitChoiceIsCorrect = true;
                break;
            }
        }

        for (int i = 0; i<toleranceValues.Length; i++)
        {
            if (currentQuestion.toleranceValue == toleranceValueButton.text)
            {
                toleranceValueChoiceIsCorrect = true;
                break;
            }
        }

        for (int i=0; i<currentQuestion.possibleValuesInDigits.Length; i++)
        {
            if (Convert.ToChar(firstDigitIndex) == currentQuestion.possibleValuesInDigits[i][0] &&
                secondDigitIndex == currentQuestion.possibleValuesInDigits[i][1] &&
                Convert.ToChar(thirdDigitIndex) == currentQuestion.possibleValuesInDigits[i][2] &&
                resistorUnitChoiceIsCorrect &&
                toleranceValueChoiceIsCorrect)
            {
                currentQuestionIsAnswered = true;
                break;
            }
            else
            {
                currentQuestionIsAnswered = false;
                continue;
            }
        }

        if (currentQuestionIsAnswered)
        {
            playerScore += resistData.pointsAddedForCorrectAnswer;
            scoreDisplayText.text = playerScore.ToString();
            unansweredQuestions.Remove(currentQuestion);
            questionCount++;
            AudioManager.Instance.PlaySound("Correct");
            SetCurrentQuestion();
        }
        else
        {
            AudioManager.Instance.PlaySound("Wrong");
            resistAnimator.SetTrigger("wrong");
            SetCurrentQuestion();
        }
    }

    public void OnPassClick()
    {
        AudioManager.Instance.PlaySound("Wrong");
        playerPassesLeft--;
        if(playerPassesLeft >= 0)
        {
            passesLeft.text = playerPassesLeft.ToString();
            currentQuestionIsAnswered = true;
            unansweredQuestions.Remove(currentQuestion);
            questionCount++;
        }
        if (playerPassesLeft == 0)
            EndRound();
        else
            SetCurrentQuestion();

    }

    private void EndRound()
    {
        isResistActive = false;
        resistAnimator.SetTrigger("endscreen");
        dataController.SubmitNewHighScoreForResist(playerScore);
        finalScore.text = playerScore.ToString();
        highScore.text = "High Score: " + dataController.GetHighestResistScore().ToString();
        // The minimum winning score for this game shall be 60 points.
    }

    private void UpdateTimeRemainingDisplay()
    {
        timeRemainingDisplay.text = Mathf.Round(timeRemaining).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (isResistActive)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimeRemainingDisplay();
            if (timeRemaining < 0f)
            {
                EndRound();
            }
        }
    }
}
