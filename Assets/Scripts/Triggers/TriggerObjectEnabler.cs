using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObjectEnabler : ParentTriggerObject
{
    //script for trigger objects
    [SerializeField] private GameObject objectToEnable;
    private bool playedOnce = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!playedOnce && other.CompareTag("Player"))
        {
            objectToEnable.SetActive(true);
            playedOnce = true;
        }
    }
}
