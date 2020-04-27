using UnityEngine;
using UnityEngine.UI;

public class OpeningSceneController : MonoBehaviour
{
    public InputField answerField;

    private DataController dataController;

    // Start is called before the first frame update
    void Start()
    {
        dataController = FindObjectOfType<DataController>();
    }

    public void SetUsernameAndLaunchMainMenu()
    {
        dataController.SetUsername(answerField.text);
        dataController.LaunchElectroKnight();
    }
}