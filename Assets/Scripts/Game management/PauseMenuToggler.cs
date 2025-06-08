using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuToggler : MonoBehaviour
{
    [SerializeField] private GameObject objectToEnable;
    [SerializeField] private SimpleMovement playerMovement;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        { 
            objectToEnable.SetActive(!objectToEnable.activeSelf);
            playerMovement.enabled = !playerMovement.enabled;
        }
    }

    public void ToggleMenu()
    {
        objectToEnable.SetActive(false);
    }
}
