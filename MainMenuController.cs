using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenuController : MonoBehaviour
{
    public Text playerName;
    public TextMeshProUGUI knightMessage;
    public GameObject thunderBg;
    public GameObject thunderSound;
    public Animator thunderMenu;
    public TextMeshProUGUI guessItHighScore;
    public TextMeshProUGUI trueOrFalseHighScore;
    public TextMeshProUGUI resistHighScore;
    public TextMeshProUGUI quizUpHighScore;
    public TextMeshProUGUI pawerHighScore;
    public InputField answerField;

    private DataController dataController;

    // Start is called before the first frame update
    void Start()
    {
        dataController = FindObjectOfType<DataController>();
        StartCoroutine(ThunderBgAnim());
    }

    IEnumerator ThunderBgAnim()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            thunderBg.SetActive(true);
            thunderSound.SetActive(true);
            thunderMenu.SetTrigger("thunder");
            yield return new WaitForSeconds(7F);
            thunderBg.SetActive(false);
            yield return new WaitForSeconds(9);
            thunderSound.SetActive(false);
        }
    }

    public void ResetPlayerProgress()
    {
        dataController.ResetPlayerProgress();
    }

    public void UpdatePlayerName()
    {
        dataController.SetUsername(answerField.text);
    }

    // Update is called once per frame
    void Update()
    {
        knightMessage.text = "Hey, " + dataController.GetPlayerName() + "! Let's defeat those monsters!";

        guessItHighScore.text = "LEVEL " + dataController.GetHighestGuessItLevel().ToString();
        trueOrFalseHighScore.text = dataController.GetHighestTrueOrFalseScore().ToString();
        resistHighScore.text = dataController.GetHighestResistScore().ToString();
        quizUpHighScore.text = dataController.GetHighestQuizUpScore().ToString();
        pawerHighScore.text = dataController.GetHighestPawerScore().ToString();
    }
}