using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemActionScript : MonoBehaviour
{
    public virtual void Awake()
    {
        gameObject.layer = 6;
    }

    public abstract void OnInteract();

}
