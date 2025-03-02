using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Smoothtext : MonoBehaviour
{
    public Text TextGameObject;
    private string text;
    
    void Start()
    {
        text = TextGameObject.text;
        TextGameObject.text = "";
        StartCoroutine(TextCorutine());
    }

    IEnumerator TextCorutine()
    {
        foreach (char abc in text)
        {
            TextGameObject.text += abc;
            yield return new WaitForSeconds(0.03f); //time for each letter
        }
    }
    
}