using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotScript : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Image inspectImage, inspectEye;
    private Item assignedItem;

    public void AssignItem(Item item)
    {
        assignedItem = item;
        GetComponent<Image>().sprite = item.itemSprite;
    }
}
