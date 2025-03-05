using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtLeucotome : ItemInteractableInInventory
{
    private PauseMenuToggler menuToggler;
    private void Start()
    {
        
    }

    public override void OnInteract()
    {
        OverlayPuzzleManager puzzleManager = FindObjectOfType<OverlayPuzzleManager>();
        print("Opening Overlay...");
        menuToggler = FindObjectOfType<PauseMenuToggler>();
        menuToggler.ToggleMenu();
        puzzleManager.StartLobotomy();
    }
}
