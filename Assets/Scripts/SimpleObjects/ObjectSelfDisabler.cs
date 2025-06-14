using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelfDisabler : MonoBehaviour
{
    [SerializeField] private float timeBeforeDisable;
    
    void Awake()
    {
        StartCoroutine(WaitBeforeDisable());
    }

    private IEnumerator WaitBeforeDisable()
    {
        yield return new WaitForSeconds(timeBeforeDisable);
        gameObject.SetActive(false);
    }

    
}
