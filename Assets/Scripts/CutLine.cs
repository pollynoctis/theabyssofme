using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class CutLine : MonoBehaviour
{
    [SerializeField] private XRayPuzzleController controller;
    public bool isCut = false;
    private bool isInside = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Scalpel"))
        {
            isInside = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Scalpel") && isInside && !isCut)
        {
            print("out of collider. reseting...");
            
            controller.ResetProgress();
        }
    }
    public void ConfirmCut()
    {
        if (isInside)
        {
            isCut = true;
            print("line done, great succes!");
        }
    }
}