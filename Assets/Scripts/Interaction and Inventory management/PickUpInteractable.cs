using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PickUpInteractable : InteractableScript
{
    //script, ko likt virsū itemam, ko var likt inventory
    [SerializeField] private GameObject pickUp;
    private InventoryManager manager;
    private void Start()
    {
        manager = FindObjectOfType<InventoryManager>();
    }
    public override void OnInteract()
    {
        Debug.Log("interacted");
        manager.AddItem(pickUp);
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
