using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnPress : MonoBehaviour
{
    //es minu, ka šis ir domāts, lai izslēgtu deathscreen
    [SerializeField] private GameObject objectToDisable;
    [SerializeField] private SimpleMovement playerMovement;

    public void DisableObject()
    {
        //Time.timeScale = 1f;
        playerMovement.enabled = true;
        objectToDisable.SetActive(false);
        
    }
}
