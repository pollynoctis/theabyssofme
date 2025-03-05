using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingItemFunctionScript : ItemInteractableInInventory
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public override void OnInteract()
    {
        print("testing item used");
    }
}
