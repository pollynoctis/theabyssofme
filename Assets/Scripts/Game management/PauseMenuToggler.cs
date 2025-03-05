using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuToggler : MonoBehaviour
{
    [SerializeField] private GameObject objectToEnable;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        { 
            objectToEnable.SetActive(!objectToEnable.activeSelf);
        }
    }

    public void ToggleMenu()
    {
        objectToEnable.SetActive(false);
    }
}
