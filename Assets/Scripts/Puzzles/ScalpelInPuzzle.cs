using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalpelInPuzzle : MonoBehaviour
{
    [SerializeField] private float shakeStrength = 0.05f;
    [SerializeField] private Transform hitPoint;
    [SerializeField] private float hitRadius = 0.1f;
    [SerializeField] private XRayPuzzleController controller;
    [SerializeField] private CutLine cutLine;
    
    private bool isDragging = false;
    private void Update()
    {
        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            float shakeX = Random.Range(-shakeStrength, shakeStrength);
            float shakeY = Random.Range(-shakeStrength, shakeStrength);
            transform.position = mousePosition + new Vector3(shakeX, shakeY, 0);
        }
    }
    private void OnMouseDown()
    {
        isDragging = true;
    }
    private void OnMouseUp()
    {
        isDragging = false;
        CheckHit();
    }
    private void CheckHit()
    {
        
    }
}