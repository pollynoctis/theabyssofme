using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventCorpse : ItemInteractableInInventory
{
    public override void OnInteract()
    {
        GameCrashPuzzleController.Instance.StartCrash();
        print("game crash begins");
    }
}
