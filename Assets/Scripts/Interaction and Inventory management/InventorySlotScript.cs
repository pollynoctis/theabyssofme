using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
// ReSharper disable All

public class InventorySlotScript : MonoBehaviour
{
    private GameObject assignedItem;

    public void AssignItem(GameObject item)
    {
        assignedItem = Instantiate(item, Vector3.zero, Quaternion.identity, transform);
        GetComponent<Image>().sprite = assignedItem.GetComponent<ItemInteractableInInventory>().itemSprite;
        GetComponent<Image>().color = new Color(193f/255f, 193f/255f, 193f/255f);
        
        //GetComponent<Image>().sprite = item.itemSprite;
    }

    public void UseItem()
    {
        if (assignedItem==null)
        {
            return;
        }
        assignedItem.GetComponent<ItemInteractableInInventory>().OnInteract();
        
    }
}
