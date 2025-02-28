using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ItemInteractable : MonoBehaviour
{
    public Sprite itemSprite;
    
    public virtual void Awake()
    {
        gameObject.layer = 6;
    }

    public abstract void OnInteract();
}
