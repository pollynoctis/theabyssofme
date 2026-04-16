using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class TriggerObjectText : ParentTriggerObject
{
    //for lines AND sequences AND hints
    [TextArea]
    [SerializeField] protected string[] textLines;
    [SerializeField] private AudioClip[] clipToPlay;
    [SerializeField] protected float textDuration = -1f;
    protected bool playedOnce = false;

    public bool isHint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!playedOnce && other.CompareTag("Player") && !isHint)
        {
            if (clipToPlay.Length > 0)
                TextManager.Instance.ShowTextSequence(textLines, isHint, clipToPlay);
            else 
                TextManager.Instance.ShowTextSequence(textLines, isHint, textDuration);
            playedOnce = true;
        }
    }
}
