using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ObjectEnabler : MonoBehaviour
{
    [SerializeField] private GameObject objectToEnable;
    private bool playedOnce = false;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!playedOnce)
        {
            objectToEnable.SetActive(true);
            playedOnce = true;
        }
        
        
        
    }
}
