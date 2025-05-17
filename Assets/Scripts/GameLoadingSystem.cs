using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoadingSystem : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToEnable;
    [SerializeField] private GameObject[] objectsToDisable;
    
    

    private void Start()
    {
        //if (playeyprefs smt) -> foreach objectsToEnable {set active true}
        //if (playeyprefs smt) -> foreach objectsToDisable {set active false}
    }
}
