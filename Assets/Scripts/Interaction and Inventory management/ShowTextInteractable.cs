using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTextInteractable : InteractableScript
{
    [TextArea]
    [SerializeField] protected string[] textLines;
    public override void OnInteract()
    {
        TextManager.Instance.ShowTextSequence(textLines, false, 500f);
    }

    public override void OnFocus()
    {
        //throw new System.NotImplementedException();
    }

    public override void OnLoseFocus()
    {
        TextManager.Instance.StopSequence();
        
    }
}
