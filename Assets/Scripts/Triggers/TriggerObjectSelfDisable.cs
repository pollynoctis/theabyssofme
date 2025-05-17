using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TriggerObjectSelfDisable : ParentTriggerObject
{
    [SerializeField] private float timeBeforeDisable;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(WaitBeforeDisable());
    }

    private IEnumerator WaitBeforeDisable()
    {
        yield return new WaitForSeconds(timeBeforeDisable);
        gameObject.SetActive(false);
    }
}
