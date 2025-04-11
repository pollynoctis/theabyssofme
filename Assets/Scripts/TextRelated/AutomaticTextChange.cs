using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using TMPro;


public class AutomaticTextChange : MonoBehaviour
{
    public TextMeshProUGUI firstText;
    [CanBeNull] public TextMeshProUGUI nextText;
    public float displayDuration = 3f;

    public void OnEnable()
    {
        //firstText.gameObject.SetActive(true);
        StartCoroutine(DeactivateTextAfterDelay());
    }
    
    protected virtual IEnumerator DeactivateTextAfterDelay()
    {
        yield return new WaitForSeconds(displayDuration);
        
        firstText.gameObject.SetActive(false);
        if (firstText.gameObject.activeSelf)
        {
            Debug.Log("object active");
        }
        else
        {
            Debug.Log("object inactive");
        }
        nextText?.gameObject.SetActive(true);
    }
}