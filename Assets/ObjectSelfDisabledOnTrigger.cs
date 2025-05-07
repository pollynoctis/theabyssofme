using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ObjectSelfDisabledOnTrigger : MonoBehaviour
{
    [SerializeField] private float timeBeforeDisable;
    private void Reset()
    {
        var collider = GetComponent<BoxCollider2D>();
        collider.isTrigger = true;
    }
    
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
