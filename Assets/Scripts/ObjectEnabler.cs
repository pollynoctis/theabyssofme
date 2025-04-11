using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ObjectEnabler : MonoBehaviour
{
    //script for trigger objects
    [SerializeField] private GameObject objectToEnable;
    private bool playedOnce = false;
    private void Reset()
    {
        var collider = GetComponent<BoxCollider2D>();
        collider.isTrigger = true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!playedOnce && other.CompareTag("Player"))
        {
            objectToEnable.SetActive(true);
            playedOnce = true;
        }
    }
}
