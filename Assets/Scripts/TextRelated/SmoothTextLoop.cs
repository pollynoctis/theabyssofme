using System.Collections;
using TMPro;
using UnityEngine;

public class SmoothTextLoop : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TextGameObject;
    [SerializeField] private float secondsPerLettter = 0.03f;
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
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) 
            || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.E))
        {
            return;
        }
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
            yield return new WaitForSeconds(secondsPerLettter); //laiks katram burtam
        }
    }
}