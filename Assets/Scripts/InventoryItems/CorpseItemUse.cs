using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorpseItemUse : ItemInteractableInInventory
{
    public override void OnInteract()
    {
        print("corpse used");
    }
}
