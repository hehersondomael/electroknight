using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wrong_panel : MonoBehaviour
{
    AudioSource audioData;
    CanvasGroup canvasGroup = null;

    // Start is called before the first frame update
    void Start()
    {

 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Hide()
    {
        canvasGroup.alpha = 0f; //this makes everything transparent
        canvasGroup.blocksRaycasts = false; //this prevents the UI element to receive input events
    }

    public void Show()
    {
        //shows the dialog, then plays a sound
        audioData = GetComponent<AudioSource>();
        audioData.Play();
        Debug.Log("the wrong answer audio has been played");

    } 
}