using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class TriggerObjectText : MonoBehaviour
{
    //for lines AND sequences AND hints
    [TextArea]
    [SerializeField] protected string[] textLines;
    [SerializeField] protected float textDuration = -1f;
    protected bool playedOnce = false;

    public bool isHint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!playedOnce && other.CompareTag("Player") && !isHint)
        {
            TextManager.Instance.ShowTextSequence(textLines, isHint, textDuration);
            playedOnce = true;
        }
    }
}
