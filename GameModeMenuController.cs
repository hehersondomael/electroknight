using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameModeMenuController : MonoBehaviour
{
    public Text resistInstruction;
    public Text quizUpInstruction;
    public Text pawerInstruction;

    public GameObject resistPlayButton;
    public GameObject resistWatchDialogueSceneButton;
    public GameObject resistViewCheatSheetButton;
    public GameObject quizUpPlayButton;
    public GameObject quizUpWatchDialogueSceneButton;
    public GameObject pawerPlayButton;
    public GameObject pawerWatchDialogueSceneButton;

    public GameObject coverResist;
    public GameObject coverQuizUp;
    public GameObject coverPawer;

    public Button resistUnlockButton;

    public GameObject resistUnlockPopup;
    public GameObject mysticUnlockPopup;

    //    public GameObject pawerUnlockPopup;
    //    public GameObject finishedGamePopup;

    public GameObject guessItCover;
    public GameObject trueOrFalseCover;
    public GameObject resistCover;
    public GameObject quizUpCover;
    public GameObject pawerCover;

    private DataController dataController;
    private PlayerProgress playerProgress;
    private TrueOrFalseData trueOrFalseData;
    private ResistData resistData;
    private QuizUpData quizUpData;
    private PawerData pawerData;

    void Start()
    {
        dataController = FindObjectOfType<DataController>();
        trueOrFalseData = dataController.GetTrueOrFalseData();
        resistData = dataController.GetResistData();
        quizUpData = dataController.GetQuizUpData();
        quizUpData = dataController.GetQuizUpData();
        pawerData = dataController.GetPawerData();
    }

    public void StartQuizUp()
    {
        dataController.LaunchQuizUp();
    }

    public void StartTrueOrFalse()
    {
        dataController.LaunchTrueOrFalse();
    }

    public void StartGuessIt()
    {
        dataController.LaunchGuessIt();
    }

    public void StartResist()
    {
        dataController.LaunchResist();
    }

    public void StartPawer()
    {
        dataController.LaunchPawer();
    }

    public void WatchQuizUpDialogue()
    {
        dataController.LaunchQuizUpDialogue();
    }

    public void WatchTrueOrFalseDialogue()
    {
        dataController.LaunchTrueOrFalseDialogue();
    }

    public void WatchGuessItDialogue()
    {
        dataController.LaunchGuessItDialogue();
    }

    public void WatchResistDialogue()
    {
        dataController.LaunchResistDialogue();
    }

    public void WatchPawerDialogue()
    {
        dataController.LaunchPawerDialogue();
    }

    public void OnClickGuessIt()
    {
        guessItCover.SetActive(false);
        trueOrFalseCover.SetActive(true);
        resistCover.SetActive(true);
        quizUpCover.SetActive(true);
        pawerCover.SetActive(true);
    }

    public void OnClickTrueOrFalse()
    {
        guessItCover.SetActive(true);
        trueOrFalseCover.SetActive(false);
        resistCover.SetActive(true);
        quizUpCover.SetActive(true);
        pawerCover.SetActive(true);
    }

    public void OnClickResist()
    {
        guessItCover.SetActive(true);
        trueOrFalseCover.SetActive(true);
        resistCover.SetActive(false);
        quizUpCover.SetActive(true);
        pawerCover.SetActive(true);
    }


    public void OnClickQuizUp()
    {
        guessItCover.SetActive(true);
        trueOrFalseCover.SetActive(true);
        resistCover.SetActive(true);
        quizUpCover.SetActive(false);
        pawerCover.SetActive(true);
    }


    public void OnClickPawer()
    {
        guessItCover.SetActive(true);
        trueOrFalseCover.SetActive(true);
        resistCover.SetActive(true);
        quizUpCover.SetActive(true);
        pawerCover.SetActive(false);
    }

    public void OnXButtonClick()
    {
        guessItCover.SetActive(false);
        trueOrFalseCover.SetActive(false);
        resistCover.SetActive(false);
        quizUpCover.SetActive(false);
        pawerCover.SetActive(false);
    }

    void Update()
    {

        /*
        if (dataController.GetHighestTrueOrFalseScore() >= trueOrFalseData.minimumWinningScore)
        {
            //resistMinimumScoreReached += 1;
            //if(resistMinimumScoreReached == 1)
            //resistUnlockPopup.SetActive(true);
            coverResist.SetActive(false);
        }
        else
            coverResist.SetActive(true);

        if (dataController.GetHighestResistScore() >= resistData.minimumWinningScore)
        {
            //resistUnlockPopup.SetActive(true);
            coverQuizUp.SetActive(false);
        }
        else
            coverQuizUp.SetActive(true);

        if (dataController.GetHighestPlayerScore() >= quizUpData.minimumWinningScore)
        {
            //pawerUnlockPopup.SetActive(true);
            coverPawer.SetActive(false);
        }
        else
            coverPawer.SetActive(true);
        */
    }
    
}