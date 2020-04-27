using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectTransformScalePawerChoices : MonoBehaviour
{
    public GameObject Choices_Pawer;

    // Start is called before the first frame update
    void Start()
    {
        Choices_Pawer.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {

    }
}