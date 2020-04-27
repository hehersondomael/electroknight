using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public float typingSpeed;
    private int index;

    public Text pressAnywhereText;

    public GameObject dialoguePanel;
    public GameObject platform;
    public GameObject continueButton;
    public GameObject continueButtonBlink;
    public GameObject knightFace;
    public GameObject villainFace;
    public GameObject villainBody;
    public GameObject knightBody;
    public GameObject knightName;
    public GameObject villainName;
    public GameObject startGame;
    public GameObject thunder;
    public GameObject clickToSkip;

    public Animator thunderAnim;

    // Start is called before the first frame update
    void Start()
    {
        dialoguePanel.SetActive(false);
        villainBody.SetActive(false);
        thunderAnim.SetTrigger("thunder");

        StartCoroutine(VillainAppear());

        if(index == 0)
        {
            knightFace.SetActive(false);
            villainFace.SetActive(true);
            knightName.SetActive(false);
            villainName.SetActive(true);
            startGame.SetActive(false);
            continueButtonBlink.SetActive(false);
        }
        StartCoroutine(Type());
    }

    // Update is called once per frame
    void Update()
    {
        if(textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
            continueButtonBlink.SetActive(true);
        }

    }

    public void NextSentence()
    {
        continueButton.SetActive(false);
        continueButtonBlink.SetActive(false);

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            if(index == 0 || index == 2)
            {
                knightFace.SetActive(false);
                villainFace.SetActive(true);
                knightName.SetActive(false);
                villainName.SetActive(true);
            }
            else if (index == 1 || index == 3)
            {
                knightFace.SetActive(true);
                villainFace.SetActive(false);
                knightName.SetActive(true);
                villainName.SetActive(false);
            }
            else if (index == 4)
            {
                thunder.SetActive(true);
                thunderAnim.SetTrigger("thunder");
                dialoguePanel.SetActive(false);
                StartCoroutine(VillainDisappear());
                clickToSkip.SetActive(false);
            }
            StartCoroutine(Type());
        }
        
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
            continueButtonBlink.SetActive(false);
        }
    }

    public void StartGame(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

    IEnumerator VillainAppear()
    {
        yield return new WaitForSeconds(.9F);
        dialoguePanel.SetActive(true);
        villainBody.SetActive(true);
        AudioManager.Instance.PlaySound("Thunder");

    }

    IEnumerator VillainDisappear()
    {
        yield return new WaitForSeconds(.1F);
        AudioManager.Instance.PlaySound("Thunder");
        yield return new WaitForSeconds(.9F);
        //dialoguePanel.SetActive(false);
        villainBody.SetActive(false);
        knightBody.SetActive(false);
        startGame.SetActive(true);
        knightFace.SetActive(false);
        villainFace.SetActive(false);
        knightName.SetActive(false);
        villainName.SetActive(false);
        platform.SetActive(false);

    }

    IEnumerator Type()
    {
        if (index == 0)
        {
            yield return new WaitForSeconds(1.5F);
            thunder.SetActive(false);
        }


        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
            AudioManager.Instance.PlaySound("TypingSound");
        }
    }
    IEnumerator LaughDelay()
    {
        yield return new WaitForSeconds(1.5F);
    }

    public void PressStartGame(string scenename)
    {
        pressAnywhereText.text = "LOADING...";
        LaughDelay();
        SceneManager.LoadScene(scenename);
    }
}
