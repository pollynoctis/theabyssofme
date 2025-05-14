using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomDeathText : MonoBehaviour
{
    [SerializeField] private TMP_Text executionerText;

    [TextArea]
    [SerializeField] private string[] possibleLines;

    public void OnEnable()
    {
        if (executionerText == null || possibleLines.Length == 0)
        {
            Debug.LogWarning("DialogueText or possible lines not set.");
            return;
        }

        int randomIndex = Random.Range(0, possibleLines.Length);
        executionerText.text = possibleLines[randomIndex];
    }
}
