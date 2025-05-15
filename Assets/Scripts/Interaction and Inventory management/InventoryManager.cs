using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> items;
    public InventorySlotScript inventorySlot;
    [SerializeField] private Transform inventory;
    
    void Start()
    {
        UpdateInventory();
    }

    public void AddItem(GameObject item)
    {
        items.Add(item);

        UpdateInventory();
    }

    public void RemoveItem(GameObject item)
    {
        items.Remove(item);

        UpdateInventory();
    }

    public void UpdateInventory()
    {   
        foreach(Transform child in inventory)
        {
            Destroy(child.gameObject);
        }
        //instantiate slots
        foreach(GameObject item in items)
        {
            GameObject newSlot = Instantiate(inventorySlot.gameObject, inventory);
            
            newSlot.GetComponent<InventorySlotScript>().AssignItem(item);
            newSlot.transform.position = Vector3.zero;
            item.transform.position = new Vector3(0, 0, 0);
        }
    }
    
    
}
