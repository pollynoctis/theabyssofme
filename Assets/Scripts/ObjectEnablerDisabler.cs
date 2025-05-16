using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class ObjectEnablerDisabler : MonoBehaviour
{
    [SerializeField] private GameObject relatedObject;

    public void EnableObject()
    {
        relatedObject.SetActive(true);
    }

    public void DisableObject()
    {
        relatedObject.SetActive(false);
    }
}
