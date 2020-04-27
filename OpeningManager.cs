using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(OpeningSceneDelay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator OpeningSceneDelay()
    {
        yield return new WaitForSeconds(5.2F);
        SceneManager.LoadScene("MainMenu");
    }
}
