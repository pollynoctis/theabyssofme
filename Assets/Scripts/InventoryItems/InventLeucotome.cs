using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventLeucotome : ItemInteractableInInventory
{
    private PauseMenuToggler menuToggler;

    public override void OnInteract()
    {
        menuToggler = FindObjectOfType<PauseMenuToggler>();
        menuToggler.ToggleMenu(); //disable inventory visibility
        OverlayPuzzleManager puzzleManager = FindObjectOfType<OverlayPuzzleManager>();
        print("Opening Overlay...");
        puzzleManager.StartPuzzle();
        
    }
}
