using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class correct_panel : MonoBehaviour
{
    AudioSource audioData;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void show()
    {
        audioData = GetComponent<AudioSource>();
        audioData.Play();
        Debug.Log("the correct answer audio has been played");
    }
}
