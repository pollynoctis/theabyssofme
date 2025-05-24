using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeText : MonoBehaviour
{
    //for lines AND sequences AND hints
    [TextArea]
    [SerializeField] protected string[] textLines;
    [SerializeField] protected float textDuration = -1f;
    protected bool playedOnce;

    public bool isHint;

    public void SetText()
    {
        TextManager.Instance.ShowTextSequence(textLines, isHint, textDuration);
        playedOnce = true;
    }
}
