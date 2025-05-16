using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnInput : MonoBehaviour
{
    [SerializeField] private GameObject objectToDisable;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.anyKey)
        {
            objectToDisable.SetActive(false);
        }
        
    }
}
