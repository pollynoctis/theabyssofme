using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpInteractable : InteractableScript
{
    //script, ko likt virsū itemam, ko var likt inventory
    [SerializeField] private GameObject pickUp;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip pickUpSound;
    private InventoryManager manager;
    private void Start()
    {
        manager = FindObjectOfType<InventoryManager>();
    }
    public override void OnInteract()
    {
        //Debug.Log("interacted");
        manager.AddItem(pickUp); 
        source.PlayOneShot(pickUpSound);
        Destroy(gameObject);
        
    }
    public override void OnFocus()
    {
        //throw new System.NotImplementedException();
    }

    public override void OnLoseFocus()
    {
        //throw new System.NotImplementedException();
    }
    
}
