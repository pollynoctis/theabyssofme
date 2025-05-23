using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingItemFunctionScript : ItemInteractableInInventory
{
   

    public override void OnInteract()
    {
        print("testing item used");
    }
}
