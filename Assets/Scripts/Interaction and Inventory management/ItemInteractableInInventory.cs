using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public abstract class ItemInteractableInInventory : MonoBehaviour
{
    //potentially change to ObjectWithInventoryText 
    //šis skripts ir domāts objektiem, kuriem parādās teksts, kad uz tiem uzspiež inventory
    public Sprite itemSprite;
    [TextArea]
    [CanBeNull][SerializeField] protected string[] textLines;
    [SerializeField] protected float textDuration = 2f;
    [SerializeField] protected bool isHint; //maybe delete
    public virtual void Awake()
    {
        gameObject.layer = 6;
    }
    public abstract void OnInteract();

}
