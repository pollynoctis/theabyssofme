using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtLeucotome : ItemInteractable
{
    
    private void Start()
    {
        
    }

    public override void OnInteract()
    {
        OverlayPuzzleManager puzzleManager = FindObjectOfType<OverlayPuzzleManager>();
        print("Opening Overlay...");
        puzzleManager.StartLobotomy();
    }
}
