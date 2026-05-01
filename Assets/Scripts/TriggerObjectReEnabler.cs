using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObjectReEnabler : ParentTriggerObject
{
    //script for trigger objects
    [SerializeField] private GameObject objectToEnable;
    
    private void Start()
    {
        objectToEnable.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!objectToEnable.activeSelf && other.CompareTag("Player"))
        {
            objectToEnable.SetActive(true);
        }
    }
}
