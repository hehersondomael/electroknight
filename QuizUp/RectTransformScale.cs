using UnityEngine;

public class RectTransformScale : MonoBehaviour
{
    public GameObject Choices_Pawer;

    // Start is called before the first frame update
    void Start()
    {
        Choices_Pawer.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
    }
}