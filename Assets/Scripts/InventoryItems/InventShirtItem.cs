using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class InventShirtItem : ItemInteractableInInventory
{
    public override void OnInteract()
    {
        TextManager.Instance.ShowTextSequence(textLines, false, textDuration);
        TextManager.Instance.DisableIsDisplaying();
        
    }
}
