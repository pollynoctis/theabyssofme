using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private List<Item> items;
    public InventorySlotScript inventorySlot;
    [SerializeField] private Transform inventory;
    void Start()
    {
        UpdateInventory();
    }

    void Update()
    {
        
    }
    public void AddItem(Item item)
    {
        items.Add(item);

        UpdateInventory();
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);

        UpdateInventory();
    }

    public void UpdateInventory()
    {   //clear inventory
        foreach(Transform child in inventory)
        {
            Destroy(child.gameObject);
        }
        //instantiate slots
        foreach(Item item in items)
        {
            GameObject newSlot = Instantiate(inventorySlot.gameObject, inventory);
            newSlot.GetComponent<InventorySlotScript>().AssignItem(item);
            newSlot.transform.position = Vector3.zero;
        }
    }
}
