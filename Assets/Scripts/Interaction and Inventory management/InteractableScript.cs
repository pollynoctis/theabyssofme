using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class InteractableScript : MonoBehaviour
{
    //parental script visiem interactable objektiem spēlē
    public virtual void Awake()
    {
        gameObject.layer = 6;
    }

    public abstract void OnInteract();
    public abstract void OnFocus();
    public abstract void OnLoseFocus();
    
    
}