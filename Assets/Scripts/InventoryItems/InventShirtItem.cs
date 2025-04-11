using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventShirtItem : ItemInteractableInInventory
{
    public override void OnInteract()
    {
        
        TextManager.Instance.ShowMessage("It stinks.");
    }
}
