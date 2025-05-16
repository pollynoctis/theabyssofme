using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using TMPro;


public class AutomaticTextChange : MonoBehaviour
{
    [CanBeNull] public TextMeshProUGUI currentText;
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
        currentText?.gameObject.SetActive(false);
        nextText?.gameObject.SetActive(true);
    }
}