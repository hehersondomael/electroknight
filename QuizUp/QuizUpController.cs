using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class QuizUpController : MonoBehaviour
{
    public Text questionTextDisplay;
    public Text timeRemainingDisplay;
    public Text currentScoreDisplay;
    public GameObject heart1Display;
    public GameObject heart2Display;
    public GameObject heart3Display;
    public GameObject heart4Display;
    public GameObject heart5Display;

    public Text finalScoreDisplay;
    public Text highScoreDisplay;
    public Text winOrLoseMessageDisplay;
    public Text bossMessageDisplay;

    public SimpleObjectPool answerButtonObjectPool;
    public Transform answerButtonParent;

    public Animator correctAnswerAnimator;
    public Animator wrongAnswerAnimator;
    public Animator gameOverAnimator;

    public Button choiceA;
    public Button choiceB;
    public Button choiceC;
    public Button choiceD;

    public Text choice1;
    public Text choice2;
    public Text choice3;
    public Text choice4;

    private DataController dataController;
    private QuizUpData quizUpData;
    private QuizUpQuestions[] questionPool;

    private int healthCount;
    private bool isQuizUpActive;
    private int playerScore;
    private float timeRemaining;
    private int questionCount;

    private List<GameObject> answerButtonGameObjects = new List<GameObject>();

    private System.Random random = new System.Random();
    private QuizUpQuestions currentQuestion;
    
    private static List<QuizUpQuestions> unansweredQuestions;


    private QuizUpQuestionsChoices quizUpQuestionsChoices;


    // Start is called before the first frame update
    void Start()
    {
        dataController = FindObjectOfType<DataController>();
        quizUpData = dataController.GetQuizUpData();

        questionPool = quizUpData.questions;
        unansweredQuestions = questionPool.ToList<QuizUpQuestions>();

        isQuizUpActive = true;
        questionCount = 0;
        playerScore = 0;
        healthCount = 5;

        timeRemaining = quizUpData.timeLimitInSeconds;
        UpdateTimeRemainingDisplay();

        choiceA.enabled = true;
        choiceB.enabled = true;
        choiceC.enabled = true;
        choiceD.enabled = true;

        SetCurrentQuestion();

        // Play Sound Sample
        // AudioManager.Instance.PlaySound("GameMusic");
    }

    private void SetCurrentQuestion()
    {
        choiceA.enabled = true;
        choiceB.enabled = true;
        choiceC.enabled = true;
        choiceD.enabled = true;
        if (questionCount == questionPool.Length || healthCount == 0)
            EndRound();
        else
        {


            int randomQuestionIndex = random.Next(0, unansweredQuestions.Count);
            currentQuestion = unansweredQuestions[randomQuestionIndex];

            questionTextDisplay.text = currentQuestion.question;
            /*
            RemoveAnswerButtons();
            for (int i = 0; i < currentQuestion.choices.Length; i++)
            {
                GameObject answerButtonGameObject = answerButtonObjectPool.GetObject();
                answerButtonGameObject.transform.SetParent(answerButtonParent);
                answerButtonGameObjects.Add(answerButtonGameObject);
                AnswerButton answerButton = answerButtonGameObject.GetComponent<AnswerButton>();
                answerButton.Setup(currentQuestion.choices[i]);
            }
            */
            unansweredQuestions.Remove(currentQuestion);

            choice1.text = currentQuestion.choices[0].choice.ToString();
            choice2.text = currentQuestion.choices[1].choice.ToString();
            choice3.text = currentQuestion.choices[2].choice.ToString();
            choice4.text = currentQuestion.choices[3].choice.ToString();
        }
    }

    /*
    private void RemoveAnswerButtons()
    {
        while (answerButtonGameObjects.Count > 0)
        {
            answerButtonObjectPool.ReturnObject(answerButtonGameObjects[0]);
            answerButtonGameObjects.RemoveAt(0);
        }
    }
    */

    public void Button1Clicked()
    {
        choiceA.enabled = true;
        choiceB.enabled = false;
        choiceC.enabled = false;
        choiceD.enabled = false;

        if (currentQuestion.choices[0].isCorrect)
        {
            playerScore += quizUpData.pointsAddedForCorrectAnswer;
            AudioManager.Instance.PlaySound("Correct");
            correctAnswerAnimator.SetTrigger("correct");
            currentScoreDisplay.text = playerScore.ToString();
        }
        else
        {
            healthCount--;
            AudioManager.Instance.PlaySound("Wrong");
            wrongAnswerAnimator.SetTrigger("wrong");
        }


        if (questionPool.Length > questionCount || healthCount != 0)
        {
            questionCount++;
            SetCurrentQuestion();
        }
        else
            EndRound();
    }

    public void Button2Clicked()
    {
        choiceA.enabled = false;
        choiceB.enabled = true;
        choiceC.enabled = false;
        choiceD.enabled = false;
        if (currentQuestion.choices[1].isCorrect)
        {
            playerScore += quizUpData.pointsAddedForCorrectAnswer;
            AudioManager.Instance.PlaySound("Correct");
            correctAnswerAnimator.SetTrigger("correct");
            currentScoreDisplay.text = playerScore.ToString();
        }
        else
        {
            healthCount--;
            AudioManager.Instance.PlaySound("Wrong");
            wrongAnswerAnimator.SetTrigger("wrong");
        }

        if (questionPool.Length > questionCount || healthCount != 0)
        {
            questionCount++;
            SetCurrentQuestion();
        }
        else
            EndRound();
    }

    public void Button3Clicked()
    {
        choiceA.enabled = false;
        choiceB.enabled = false;
        choiceC.enabled = true;
        choiceD.enabled = false;
        if (currentQuestion.choices[2].isCorrect)
        {
            playerScore += quizUpData.pointsAddedForCorrectAnswer;
            AudioManager.Instance.PlaySound("Correct");
            correctAnswerAnimator.SetTrigger("correct");
            currentScoreDisplay.text = playerScore.ToString();
        }
        else
        {
            healthCount--;
            AudioManager.Instance.PlaySound("Wrong");
            wrongAnswerAnimator.SetTrigger("wrong");
        }


        if (questionPool.Length > questionCount || healthCount != 0)
        {
            questionCount++;
            SetCurrentQuestion();
        }
        else
            EndRound();
    }

    public void Button4Clicked()
    {
        choiceA.enabled = false;
        choiceB.enabled = false;
        choiceC.enabled = false;
        choiceD.enabled = true;
        if (currentQuestion.choices[3].isCorrect)
        {
            playerScore += quizUpData.pointsAddedForCorrectAnswer;
            AudioManager.Instance.PlaySound("Correct");
            correctAnswerAnimator.SetTrigger("correct");
            currentScoreDisplay.text = playerScore.ToString();
        }
        else
        {
            healthCount--;
            AudioManager.Instance.PlaySound("Wrong");
            wrongAnswerAnimator.SetTrigger("wrong");
        }


        if (questionPool.Length > questionCount || healthCount != 0)
        {
            questionCount++;
            SetCurrentQuestion();
        }
        else
            EndRound();
    }

    /*
        public void AnswerButtonClicked(bool isCorrect)
        {
            if (currentQuestion.choices[0].isCorrect)
            {
                playerScore += quizUpData.pointsAddedForCorrectAnswer;
                AudioManager.Instance.PlaySound("Correct");
                correctAnswerAnimator.SetTrigger("correct");
                currentScoreDisplay.text = playerScore.ToString();
            }
            else
            {
                // Animation Play Sample
                // GameObject.Find("WrongPanel").GetComponent<Animator>().Play("WrongAnswer");
                healthCount--;
                AudioManager.Instance.PlaySound("Wrong");
                wrongAnswerAnimator.SetTrigger("wrong");
            }

            if (questionPool.Length > questionCount || healthCount != 0)
            {
                questionCount++;
                SetCurrentQuestion();
            }
            else
                EndRound();
        }
    */

    public void EndRound()
    {
        if (healthCount == 0)
            heart1Display.gameObject.SetActive(false);

        isQuizUpActive = false;
        dataController.SubmitNewHighScoreForQuizUp(playerScore);
        gameOverAnimator.SetTrigger("endscreen");

        if (playerScore >= quizUpData.minimumWinningScore)
        {
            winOrLoseMessageDisplay.text = "YOU WIN!!";
            winOrLoseMessageDisplay.color = new Color(56.0f / 255.0f, 214.0f / 255.0f, 199.0f / 255.0f);
            bossMessageDisplay.text = "HOW CAN THISssSSsSs HAPPEN?!? \n \n NooOOOoo....";
            AudioManager.Instance.PlaySound("QUWin");
            AudioManager.Instance.PlaySound("Win");
        }
        else
        {
            winOrLoseMessageDisplay.text = "YOU LOSE!!";
            winOrLoseMessageDisplay.color = new Color(200.0f / 255.0f, 53.0f / 255.0f, 43.0f / 255.0f);
            bossMessageDisplay.text = "Mwahahahaha.. \n \n You can't beat me! hiSssSSs..";
            AudioManager.Instance.PlaySound("QULose");
        }
        finalScoreDisplay.text = playerScore.ToString();
        highScoreDisplay.text = "High Score: " + dataController.GetHighestQuizUpScore().ToString();

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
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isQuizUpActive)
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