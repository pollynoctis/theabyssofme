using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalpelInPuzzle : MonoBehaviour
{
    [SerializeField] private Transform hitPoint;
    [SerializeField] private float hitRadius = 0.1f;
    private bool isDragging = false;
    private void Update()
    {
        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            transform.position = mousePosition;
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
