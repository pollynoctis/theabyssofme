using System.Collections;
using TMPro;
using UnityEngine;

public class SmoothTextLoop : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TextGameObject;
    [SerializeField] private float textSpeed = 0.03f;
    private string text;
    private bool isSkipping;
    
    void OnEnable() //was awake
    {
        isSkipping = false;
        text = TextGameObject.text;
        TextGameObject.text = "";
        StartCoroutine(TextCoroutine());
    }
    void Update()
    {
        if (Input.anyKeyDown) 
        {
            isSkipping = true;
        }
    }
    IEnumerator TextCoroutine()
    {
        foreach (char abc in text)
        {
            if (isSkipping)
            {
                TextGameObject.text = text;
                yield break;
            }
            TextGameObject.text += abc;
            yield return new WaitForSeconds(textSpeed); //laiks katram burtam
        }
    }
}