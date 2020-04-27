using UnityEngine;
using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour
{
    public GuessItData[] GuessItData;
    public TrueOrFalseData[] TrueOrFalseData;
    public ResistData[] ResistData;
    public QuizUpData[] QuizUpData;
    public PawerData[] PawerData;

    private PlayerProgress playerProgress;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        playerProgress = new PlayerProgress();

        LoadPlayerProgress();

        if (playerProgress.electroKnightLaunched == 0)
            SceneManager.LoadScene("Opening_FirstTime");
        else
            SceneManager.LoadScene("Opening");
    }

    public GuessItData GetGuessItData()
    {
        return GuessItData[0];
    }

    public TrueOrFalseData GetTrueOrFalseData()
    {
        return TrueOrFalseData[0];
    }

    public ResistData GetResistData()
    {
        return ResistData[0];
    }

    public QuizUpData GetQuizUpData()
    {
        return QuizUpData[0];
    }

    public PawerData GetPawerData()
    {
        return PawerData[0];
    }

    private void LoadPlayerProgress()
    {
        if (PlayerPrefs.HasKey("electroKnightLaunched"))
            playerProgress.electroKnightLaunched = PlayerPrefs.GetInt("electroKnightLaunched");
        if (PlayerPrefs.HasKey("guessItLaunched"))
            playerProgress.guessItLaunched = PlayerPrefs.GetInt("guessItLaunched");
        if (PlayerPrefs.HasKey("trueOrFalseLaunched"))
            playerProgress.trueOrFalseLaunched = PlayerPrefs.GetInt("trueOrFalseLaunched");
        if (PlayerPrefs.HasKey("resistLaunched"))
            playerProgress.resistLaunched = PlayerPrefs.GetInt("resistLaunched");
        if (PlayerPrefs.HasKey("quizUpLaunched"))
            playerProgress.quizUpLaunched = PlayerPrefs.GetInt("quizUpLaunched");
        if (PlayerPrefs.HasKey("pawerLaunched"))
            playerProgress.pawerLaunched = PlayerPrefs.GetInt("pawerLaunched");

        if (PlayerPrefs.HasKey("playerName"))
            playerProgress.playerName = PlayerPrefs.GetString("playerName");

        if (PlayerPrefs.HasKey("quizUpHighestScore"))
            playerProgress.quizUpHighestScore = PlayerPrefs.GetInt("quizUpHighestScore");
        if (PlayerPrefs.HasKey("guessItHighestLevel"))
            playerProgress.guessItHighestLevel = PlayerPrefs.GetInt("guessItHighestLevel");
        if (PlayerPrefs.HasKey("trueOrFalseHighestScore"))
            playerProgress.trueOrFalseHighestScore = PlayerPrefs.GetInt("trueOrFalseHighestScore");
        if (PlayerPrefs.HasKey("resistHighestScore"))
            playerProgress.resistHighestScore = PlayerPrefs.GetInt("resistHighestScore");
        if (PlayerPrefs.HasKey("pawerHighestScore"))
            playerProgress.pawerHighestScore = PlayerPrefs.GetInt("pawerHighestScore");
    }

    public void LaunchElectroKnight()
    {
        if (playerProgress.electroKnightLaunched == 0)
        {
            playerProgress.electroKnightLaunched = 1;
            PlayerPrefs.SetInt("electroKnightLaunched", playerProgress.electroKnightLaunched);
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void SetUsername(string username)
    {
        playerProgress.playerName = username;
        PlayerPrefs.SetString("playerName", playerProgress.playerName);
    }

    public void LaunchGuessItDialogue()
    {
        if (playerProgress.guessItLaunched == 0)
        {
            playerProgress.guessItLaunched = 1;
            PlayerPrefs.SetInt("guessItLaunched", playerProgress.guessItLaunched);
            SceneManager.LoadScene("Dialogue_GuessIt");
        }
        else
            SceneManager.LoadScene("Dialogue_GuessIt");
    }

    public void LaunchTrueOrFalseDialogue()
    {
        if (playerProgress.trueOrFalseLaunched == 0)
        {
            playerProgress.trueOrFalseLaunched = 1;
            PlayerPrefs.SetInt("trueOrFalseLaunched", playerProgress.trueOrFalseLaunched);
            SceneManager.LoadScene("Dialogue_TrueOrFalse");
        }
        else
            SceneManager.LoadScene("Dialogue_TrueOrFalse");
    }

    public void LaunchResistDialogue()
    {
        if (playerProgress.resistLaunched == 0)
        {
            playerProgress.resistLaunched = 1;
            PlayerPrefs.SetInt("resistLaunched", playerProgress.resistLaunched);
            SceneManager.LoadScene("Dialogue_Resist");
        }
        else
            SceneManager.LoadScene("Dialogue_Resist");
    }

    public void LaunchQuizUpDialogue()
    {
        if (playerProgress.quizUpLaunched == 0)
        {
            playerProgress.quizUpLaunched = 1;
            PlayerPrefs.SetInt("quizUpLaunched", playerProgress.quizUpLaunched);
            SceneManager.LoadScene("Dialogue_QuizUp");
        }
        else
            SceneManager.LoadScene("Dialogue_QuizUp");
    }

    public void LaunchPawerDialogue()
    {
        if (playerProgress.pawerLaunched == 0)
        {
            playerProgress.pawerLaunched = 1;
            PlayerPrefs.SetInt("pawerLaunched", playerProgress.pawerLaunched);
            SceneManager.LoadScene("Dialogue_Pawer");
        }
        else
            SceneManager.LoadScene("Dialogue_Pawer");
    }

    public void LaunchGuessIt()
    {
        if (playerProgress.guessItLaunched == 0)
        {
            playerProgress.guessItLaunched = 1;
            PlayerPrefs.SetInt("guessItLaunched", playerProgress.guessItLaunched);
            SceneManager.LoadScene("Dialogue_GuessIt");
        }
        else
            SceneManager.LoadScene("Game_GuessIt");
    }

    public void LaunchTrueOrFalse()
    {
        if (playerProgress.trueOrFalseLaunched == 0)
        {
            playerProgress.trueOrFalseLaunched = 1;
            PlayerPrefs.SetInt("trueOrFalseLaunched", playerProgress.trueOrFalseLaunched);
            SceneManager.LoadScene("Dialogue_TrueOrFalse");
        }
        else
            SceneManager.LoadScene("Game_TrueOrFalse");
    }

    public void LaunchResist()
    {
        if (playerProgress.resistLaunched == 0)
        {
            playerProgress.resistLaunched = 1;
            PlayerPrefs.SetInt("resistLaunched", playerProgress.resistLaunched);
            SceneManager.LoadScene("Dialogue_Resist");
        }
        else
            SceneManager.LoadScene("Game_Resist");
    }

    public void LaunchQuizUp()
    {
        if (playerProgress.quizUpLaunched == 0)
        {
            playerProgress.quizUpLaunched = 1;
            PlayerPrefs.SetInt("quizUpLaunched", playerProgress.quizUpLaunched);
            SceneManager.LoadScene("Dialogue_QuizUp");
        }
        else
            SceneManager.LoadScene("Game_QuizUp");
    }

    public void LaunchPawer()
    {
        if (playerProgress.pawerLaunched == 0)
        {
            playerProgress.pawerLaunched = 1;
            PlayerPrefs.SetInt("pawerLaunched", playerProgress.pawerLaunched);
            SceneManager.LoadScene("Dialogue_Pawer");
        }
        else
            SceneManager.LoadScene("Game_Pawer");
    }

    public void SubmitNewHighestLevelReachedForGuessIt(int newLevel)
    {
       if (newLevel > playerProgress.guessItHighestLevel)
       {
            playerProgress.guessItHighestLevel = newLevel;
            PlayerPrefs.SetInt("guessItHighestLevel", playerProgress.guessItHighestLevel);
       }
    }

    public void SubmitNewHighScoreForTrueOrFalse(int newTScore)
    {
        if (newTScore > playerProgress.trueOrFalseHighestScore)
        {
            playerProgress.trueOrFalseHighestScore = newTScore;
        PlayerPrefs.SetInt("trueOrFalseHighestScore", playerProgress.trueOrFalseHighestScore);
        }
    }

    public void SubmitNewHighScoreForResist(int newRScore)
    {
        if (newRScore > playerProgress.resistHighestScore)
        {
            playerProgress.resistHighestScore = newRScore;
            PlayerPrefs.SetInt("resistHighestScore", playerProgress.resistHighestScore);
        }
    }

    public void SubmitNewHighScoreForQuizUp(int newScore)
    {
        if (newScore > playerProgress.quizUpHighestScore)
        {
            playerProgress.quizUpHighestScore = newScore;
            // Save player progress
            PlayerPrefs.SetInt("quizUpHighestScore", playerProgress.quizUpHighestScore);
        }
    }

    public void SubmitNewHighScoreForPawer(int newPScore)
    {
        if (newPScore > playerProgress.pawerHighestScore)
        {
            playerProgress.pawerHighestScore = newPScore;
            PlayerPrefs.SetInt("pawerHighestScore", playerProgress.pawerHighestScore);
        }
    }

    public int GetHighestGuessItLevel()
    {
        return playerProgress.guessItHighestLevel;
    }

    public int GetHighestTrueOrFalseScore()
    {
        return playerProgress.trueOrFalseHighestScore;
    }

    public int GetHighestQuizUpScore()
    {
        return playerProgress.quizUpHighestScore;
    }

    public int GetHighestResistScore()
    {
        return playerProgress.resistHighestScore;
    }

    public int GetHighestPawerScore()
    {
        return playerProgress.pawerHighestScore;
    }

    public string GetPlayerName()
    {
        return playerProgress.playerName;
    }

    public void ResetPlayerProgress()
    {
        playerProgress.electroKnightLaunched = 0;
        PlayerPrefs.SetInt("electroKnightLaunched", playerProgress.electroKnightLaunched);
        playerProgress.guessItHighestLevel = 0;
        PlayerPrefs.SetInt("guessItHighestLevel", playerProgress.guessItHighestLevel);
        playerProgress.trueOrFalseHighestScore = 0;
        PlayerPrefs.SetInt("trueOrFalseHighestScore", playerProgress.trueOrFalseHighestScore);
        playerProgress.resistHighestScore = 0;
        PlayerPrefs.SetInt("quizUpHighestScore", playerProgress.quizUpHighestScore);
        playerProgress.quizUpHighestScore = 0;
        PlayerPrefs.SetInt("resistHighestScore", playerProgress.resistHighestScore);
        playerProgress.pawerHighestScore = 0;
        PlayerPrefs.SetInt("pawerHighestScore", playerProgress.pawerHighestScore);
    }
}