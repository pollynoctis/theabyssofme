using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpInteractable : InteractableScript
{
    [SerializeField] private Item pickUp;
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
