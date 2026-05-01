using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventCorpse : ItemInteractableInInventory
{
    public override void OnInteract()
    {
        print("waiting for game crash");
        GameCrashPuzzleController.Instance.StartCrash();
        print("game crash begins");
    }
}
