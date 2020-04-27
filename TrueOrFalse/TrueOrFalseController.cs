using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TrueOrFalseController : MonoBehaviour
{
    public TextMeshProUGUI questionTextDisplay;
    public Text timeRemainingDisplay;
    public Text currentScoreDisplay;
    public GameObject heart1Display;
    public GameObject heart2Display;
    public GameObject heart3Display;
    public GameObject heart4Display;
    public GameObject heart5Display;
    public Text answerIsTrueText;
    public Text answerIsFalseText;
    public GameObject trueCover;
    public GameObject falseCover;
    public Animator gameOverAnimator;
    public Text finalScoreDisplay;
    public Text highScoreDisplay;
    public Text winOrLoseMessageDisplay;
    public Text bossMessageDisplay;

    private DataController dataController;
    private TrueOrFalseData trueOrFalseData;
    private TrueOrFalseQuestions[] questionPool;

    private int healthCount;
    private bool isTrueOrFalseActive;
    private int playerScore;
    private float timeRemaining;
    private int questionCount;
    private float timeTransitionBetweenQuestions;

    private System.Random random = new System.Random();
    private TrueOrFalseQuestions currentQuestion;

    private static List<TrueOrFalseQuestions> unansweredQuestions;

    // Start is called before the first frame update
    void Start()
    {
        dataController = FindObjectOfType<DataController>();
        trueOrFalseData = dataController.GetTrueOrFalseData();

        questionPool = trueOrFalseData.questions;
        unansweredQuestions = questionPool.ToList<TrueOrFalseQuestions>();

        isTrueOrFalseActive = true;
        timeTransitionBetweenQuestions = 1f;
        questionCount = 0;
        playerScore = 0;
        healthCount = 5;

        timeRemaining = trueOrFalseData.timeLimitInSeconds;
        UpdateTimeRemainingDisplay();

        trueCover.SetActive(false);
        falseCover.SetActive(false);

        SetCurrentQuestion();
    }

    private void SetCurrentQuestion()
    {
        trueCover.SetActive(false);
        falseCover.SetActive(false);

        if (questionCount == questionPool.Length)
            EndRound();
        else
        {
            int randomQuestionIndex = random.Next(0, unansweredQuestions.Count);
            currentQuestion = unansweredQuestions[randomQuestionIndex];

            questionTextDisplay.text = currentQuestion.statement;
            unansweredQuestions.Remove(currentQuestion);

            if (currentQuestion.isTrue)
            {
                answerIsTrueText.text = "CORRECT";
                answerIsTrueText.color = new Color32(70, 195, 32, 255);
                answerIsFalseText.text = "WRONG";
                answerIsFalseText.color = new Color32(245, 36, 36, 255);
            }
            else
            {
                answerIsFalseText.text = "CORRECT";
                answerIsFalseText.color = new Color32(70, 195, 32, 255);
                answerIsTrueText.text = "WRONG";
                answerIsTrueText.color = new Color32(245, 36, 36, 255);
            }
        }
    }

    public void TapTrueButton()
    {
        falseCover.SetActive(true);

        if (currentQuestion.isTrue)
        {
            playerScore += trueOrFalseData.pointsAddedForCorrectAnswer;
            AudioManager.Instance.PlaySound("Correct");
        }
        else
        {
            healthCount--;
            AudioManager.Instance.PlaySound("Wrong");
        }

        currentScoreDisplay.text = playerScore.ToString();

        questionCount++;
        if (questionPool.Length > questionCount)
            StartCoroutine(TransitionToNextQuestion());
        else
            EndRound();
    }

    public void TapFalseButton()
    {
        trueCover.SetActive(true);

        if (!currentQuestion.isTrue)
        {
            playerScore += trueOrFalseData.pointsAddedForCorrectAnswer;
            AudioManager.Instance.PlaySound("Correct");
        }
        else
        {
            healthCount--;
            AudioManager.Instance.PlaySound("Wrong");
        }
 
        currentScoreDisplay.text = playerScore.ToString();

        questionCount++;
        if (questionPool.Length > questionCount)
            StartCoroutine(TransitionToNextQuestion());
        else
            EndRound();
    }

    IEnumerator TransitionToNextQuestion()
    {
        yield return new WaitForSeconds(timeTransitionBetweenQuestions);
        SetCurrentQuestion();
    }

    public void EndRound()
    {
        isTrueOrFalseActive = false;
        dataController.SubmitNewHighScoreForTrueOrFalse(playerScore);
        gameOverAnimator.SetTrigger("endscreen");

        if (playerScore >= trueOrFalseData.minimumWinningScore)
        {
            winOrLoseMessageDisplay.text = "YOU WIN!!";
            winOrLoseMessageDisplay.color = new Color(56.0f / 255.0f, 214.0f / 255.0f, 199.0f / 255.0f);
            bossMessageDisplay.text = "HOW CAN THISssSSsSs HAPPEN?!? \n \n NooOOOoo....";
            AudioManager.Instance.PlaySound("TFWin");
            AudioManager.Instance.PlaySound("Win");
        }
        else
        {
            winOrLoseMessageDisplay.text = "YOU LOSE!!";
            winOrLoseMessageDisplay.color = new Color(89.0f / 255.0f, 237.0f / 255.0f, 243.0f / 255.0f);
            bossMessageDisplay.text = "Mwahahahaha.. \n \n You can't beat me! hiSssSSs..";
            AudioManager.Instance.PlaySound("TFLose");
        }
        finalScoreDisplay.text = playerScore.ToString();
        highScoreDisplay.text = "High Score: " + dataController.GetHighestTrueOrFalseScore().ToString();
    }

    private void UpdateTimeRemainingDisplay()
    {
        timeRemainingDisplay.text = Mathf.Round(timeRemaining).ToString();
    }

    private void CountHealth()
    {
        switch (healthCount)
        {
            case 4:
                heart5Display.gameObject.SetActive(false);
                break;
            case 3:
                heart4Display.gameObject.SetActive(false);
                break;
            case 2:
                heart3Display.gameObject.SetActive(false);
                break;
            case 1:
                heart2Display.gameObject.SetActive(false);
                break;
            case 0:
                heart1Display.gameObject.SetActive(false);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isTrueOrFalseActive)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimeRemainingDisplay();
            if (timeRemaining <= 0f)
                EndRound();

            CountHealth();
            if (healthCount == 0)
                EndRound();
        }
    }
}