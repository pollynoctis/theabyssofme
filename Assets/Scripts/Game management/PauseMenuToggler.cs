using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuToggler : MonoBehaviour
{
    [SerializeField] private GameObject objectToEnable;
    //[SerializeField] private GameObject player;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        { 
            objectToEnable.SetActive(!objectToEnable.activeSelf);
            //player.SetActive(!player.activeSelf);
        }
    }

    public void ToggleMenu()
    {
        objectToEnable.SetActive(false);
        //player.SetActive(false);
    }
    
}
