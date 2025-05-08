using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public abstract class TriggerObject : MonoBehaviour
{
    //this is parent script for all trigger scripts
    private void Reset()
    {
        var collider = GetComponent<BoxCollider2D>();
        collider.isTrigger = true;
    }
    
}
