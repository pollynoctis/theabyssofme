using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtKey : ItemInteractableInInventory
{
    private GameObject player;
    private GameObject lockedDoor;
    //private GameObject unlockMessage;
    private PauseMenuToggler menuToggler;

    private void Start()
    {
        player = GameObject.Find("PrototypeMainCharacter");
        lockedDoor = GameObject.Find("Trigger_Door");
        /*unlockMessage = GameObject.Find("KeyUseMessage") ?? GameObject.Find("/KeyUseMessage"); 
        if (unlockMessage == null)
        {
            unlockMessage = GameObject.FindObjectOfType<Canvas>().transform.Find("KeyUseMessage")?.gameObject;
            print(unlockMessage.name);
        }*/
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
            lockedDoor.SetActive(false); 
            //Debug.Log("Door unlocked!");
        }
        else
        {
            //unlockMessage.SetActive(true);
            TextManager.Instance.ShowMessage("KeyUseMessage");
        }
    }
}
