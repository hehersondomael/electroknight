using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class OpeningDialogue : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public float typingSpeed;
    private int index;

    public GameObject continueButton;
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        StartCoroutine(Type());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

    
    IEnumerator Type()
    {
        yield return new WaitForSeconds(3.8F);
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
            AudioManager.Instance.PlaySound("OpeningTypeSound");
        }
        continueButton.SetActive(true);
    }

    public void PressStartGame(string scenename)
    {
        //pressAnywhereText.text = "LOADING...";
        SceneManager.LoadScene(scenename);
    }
}
