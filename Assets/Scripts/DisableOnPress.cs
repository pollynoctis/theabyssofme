using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnPress : MonoBehaviour
{
    //es minu, ka šis ir domāts, lai izslēgtu deathscreen
    [SerializeField] private GameObject objectToDisable;
    [SerializeField] private SimpleMovement movement;

    public void DisableObject()
    {
        //Time.timeScale = 1f;
        movement.enabled = true;
        objectToDisable.SetActive(false);
        
    }
}
