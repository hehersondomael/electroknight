using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private bool bgmToggle;
    private bool sfxToggle;

    // Start is called before the first frame update
    void Start()
    {
        bgmToggle = true;
        sfxToggle = true;
    }

    public void ToggleBGM()
    {
        bgmToggle = !bgmToggle;
        Debug.Log(bgmToggle);
    }

    public void ToggleSFX()
    {
        sfxToggle = !sfxToggle;
        Debug.Log(sfxToggle);
    }
}