using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventKey : ItemInteractableInInventory
{
    [SerializeField] private GameObject key;
    private InventoryManager inventManager;
    private GameObject player;
    private GameObject lockedDoor;
    private GameObject houseOverlay;
    private PauseMenuToggler menuToggler;
    

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        houseOverlay = GameObject.Find("HouseOverlay");
        lockedDoor = GameObject.Find("HouseDoor");
    }

    public override void OnInteract()
    {
        Collider2D playerCollider = player.GetComponent<Collider2D>();
        Collider2D doorCollider = lockedDoor.GetComponent<Collider2D>();
        inventManager = FindObjectOfType<InventoryManager>();
        
        if (playerCollider.IsTouching(doorCollider))
        {
            houseOverlay.SetActive(false);
            inventManager.ClearAll();
        }
        else
        {
            TextManager.Instance.ShowTextSequence(textLines, isHint, textDuration); //isHint instead of false
            TextManager.Instance.DisableIsDisplaying();
        }
        menuToggler = FindObjectOfType<PauseMenuToggler>();
        menuToggler.ToggleMenu();
        player.GetComponent<SimpleMovement>().enabled = true;
    }
}
