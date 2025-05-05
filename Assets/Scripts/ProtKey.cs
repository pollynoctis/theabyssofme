using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtKey : ItemInteractableInInventory
{
    private GameObject player;
    private GameObject lockedDoor;
    private GameObject houseOverlay;
    //private GameObject unlockMessage;
    private PauseMenuToggler menuToggler;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        houseOverlay = GameObject.Find("HouseOverlay");
        lockedDoor = GameObject.Find("HouseDoor");

        /*unlockMessage = GameObject.Find("KeyUseMessage") ?? GameObject.Find("/KeyUseMessage");
        if (unlockMessage == null)
        {
            unlockMessage = GameObject.FindObjectOfType<Canvas>().transform.Find("KeyUseMessage")?.gameObject;
            print(unlockMessage.name);
        }*/ //veca versija, lai parādās message
    }

    public override void OnInteract()
    {
        print("key interacted");
        menuToggler = FindObjectOfType<PauseMenuToggler>();
        menuToggler.ToggleMenu(); //disable inventory visibility
        
        Collider2D playerCollider = player.GetComponent<Collider2D>();
        Collider2D doorCollider = lockedDoor.GetComponent<Collider2D>();
        if (playerCollider.IsTouching(doorCollider))
        {
            houseOverlay.SetActive(false); 
            //Debug.Log("House unlocked!");
        }
        else
        {
            //unlockMessage.SetActive(true);
            TextManager.Instance.ShowMessage("KeyUseMessage");
        }
    }
}
