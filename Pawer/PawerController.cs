using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PawerController : MonoBehaviour
{
    public Text questionTextDisplay;
    public Text timeRemainingDisplay;
    public Text currentScoreDisplay;
    public GameObject heart1Display;
    public GameObject heart2Display;
    public GameObject heart3Display;
    public GameObject heart4Display;
    public GameObject heart5Display;
    public Text triviaTitleDisplay;
    public TextMeshProUGUI triviaDisplay;

    public Text finalScoreDisplay;
    public Text highScoreDisplay;
    public Text winOrLoseMessageDisplay;
    public Text bossMessageDisplay; 

    public SimpleObjectPool answerButtonObjectPool;
    public Transform answerButtonParent;

    public Button backButton;

    public Animator pawerAnimator;
    public Animator endAnimator;

    private DataController dataController;
    private PawerData pawerData;
    private PawerQuestions[] questionPool;

    private int healthCount;
    private bool isPawerActive;
    private int playerScore;
    private float timeRemaining;
    private int questionCount;

    private List<GameObject> answerButtonGameObjects = new List<GameObject>();

    private System.Random random = new System.Random();
    private PawerQuestions currentQuestion;

    private static List<PawerQuestions> unansweredQuestions;

    // Start is called before the first frame update
    void Start()
    {
        dataController = FindObjectOfType<DataController>();
        pawerData = dataController.GetPawerData();

        questionPool = pawerData.questions;
        unansweredQuestions = questionPool.ToList<PawerQuestions>();

        isPawerActive = true;
        questionCount = 0;
        playerScore = 0;
        healthCount = 5;

        timeRemaining = pawerData.timeLimitInSeconds;
        UpdateTimeRemainingDisplay();
    
        SetCurrentQuestion();

        // Play Sound Sample
        // AudioManager.Instance.PlaySound("GameMusic");
    }

    private void SetCurrentQuestion()
    {
        if (questionCount == questionPool.Length || healthCount == 0)
            EndRound();
        else
        {
            RemoveAnswerButtons();
            int randomQuestionIndex = random.Next(0, unansweredQuestions.Count);
            currentQuestion = unansweredQuestions[randomQuestionIndex];

            questionTextDisplay.text = currentQuestion.question;

            for (int i=0; i<currentQuestion.choices.Length; i++)
            {
                GameObject answerButtonGameObject = answerButtonObjectPool.GetObject();
                answerButtonGameObject.transform.SetParent(answerButtonParent);
                answerButtonGameObjects.Add(answerButtonGameObject);
                AnswerButtonPawer answerButtonPawer = answerButtonGameObject.GetComponent<AnswerButtonPawer>();
                answerButtonPawer.Setup(currentQuestion.choices[i]);
            }
            unansweredQuestions.Remove(currentQuestion);
        }
    }

    private void RemoveAnswerButtons()
    {
        while (answerButtonGameObjects.Count > 0)
        {
            answerButtonObjectPool.ReturnObject(answerButtonGameObjects[0]);
            answerButtonGameObjects.RemoveAt(0);
        }
    }

    public void AnswerButtonClicked(bool isCorrect)
    {
        if (isCorrect)
        {
            playerScore += pawerData.pointsAddedForCorrectAnswer;
            pawerAnimator.SetTrigger("opentrivia");
            isPawerActive = false;
            triviaTitleDisplay.text = currentQuestion.question;
            triviaDisplay.text = currentQuestion.trivia;
            AudioManager.Instance.PlaySound("Correct");
            currentScoreDisplay.text = playerScore.ToString();
        }
        else
        {
            // Animation Play Sample
            // GameObject.Find("WrongPanel").GetComponent<Animator>().Play("WrongAnswer");
            healthCount--;
            AudioManager.Instance.PlaySound("Wrong");
            pawerAnimator.SetTrigger("wrongpawer");
            ContinueButtonClicked();
        }

    }
    public void ContinueButtonClicked()
    {
        if (questionPool.Length > questionCount || healthCount != 0)
        {
            isPawerActive = true;
            questionCount++;
            SetCurrentQuestion();
        }
        else
            EndRound();
    }

public void EndRound()
    {
        backButton.interactable = false;

        if (healthCount == 0)
            heart1Display.gameObject.SetActive(false);

        isPawerActive = false;

        dataController.SubmitNewHighScoreForPawer(playerScore);
        endAnimator.SetTrigger("endscreen");
        if (playerScore >= pawerData.minimumWinningScore)
        {
            winOrLoseMessageDisplay.text = "YOU WIN!!";
            // Change Color Sample
            // winOrLoseMessageDisplay.color = new Color(56.0f / 255.0f, 214.0f / 255.0f, 199.0f / 255.0f);

            bossMessageDisplay.text = "HOW CAN THISssSSsSs HAPPEN?!? \n \n NooOOOoo....";
            AudioManager.Instance.PlaySound("PWin");
            AudioManager.Instance.PlaySound("Win");
        }
        else
        {
            winOrLoseMessageDisplay.text = "YOU LOSE!!";
            bossMessageDisplay.text = "Mwahahahaha.. \n \n You can't beat me! hiSssSSs..";
            AudioManager.Instance.PlaySound("PLose");
        }
        finalScoreDisplay.text = playerScore.ToString();
        highScoreDisplay.text = "High Score: " + dataController.GetHighestPawerScore().ToString();

        // Audio Manager Stop Sound Sample
        // AudioManager.Instance.StopSound("GameMusic");
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
                heart4Display.gameObject.SetActive(true);
                heart3Display.gameObject.SetActive(true);
                heart2Display.gameObject.SetActive(true);
                heart1Display.gameObject.SetActive(true);
                break;
            case 3:
                heart5Display.gameObject.SetActive(false);
                heart4Display.gameObject.SetActive(false);
                heart3Display.gameObject.SetActive(true);
                heart2Display.gameObject.SetActive(true);
                heart1Display.gameObject.SetActive(true);
                break;
            case 2:
                heart5Display.gameObject.SetActive(false);
                heart4Display.gameObject.SetActive(false);
                heart3Display.gameObject.SetActive(false);
                heart2Display.gameObject.SetActive(true);
                heart1Display.gameObject.SetActive(true);
                break;
            case 1:
                heart5Display.gameObject.SetActive(false);
                heart4Display.gameObject.SetActive(false);
                heart3Display.gameObject.SetActive(false);
                heart2Display.gameObject.SetActive(false);
                heart1Display.gameObject.SetActive(true);
                break;
            case 0:
                heart5Display.gameObject.SetActive(false);
                heart4Display.gameObject.SetActive(false);
                heart3Display.gameObject.SetActive(false);
                heart2Display.gameObject.SetActive(false);
                heart1Display.gameObject.SetActive(false);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPawerActive)
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