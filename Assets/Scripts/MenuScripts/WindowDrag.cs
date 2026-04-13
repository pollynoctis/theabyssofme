using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WindowDrag : MonoBehaviour
{
    [SerializeField] private Transform targetTf;

    [SerializeField] private float xRange, yRangePositive, yRangeNegative;
    private Vector3 startDragPosition, targetStartPos;
    
    private bool isDragging;
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
        targetStartPos = targetTf.position;
    }

    private void Update()
    {
        if (!isDragging)
            return;
        
        MoveWindow();
    }

    private void MoveWindow()
    {
        Vector3 mouseMovement = cam.ScreenToWorldPoint(Input.mousePosition) - startDragPosition;
        
        targetTf.position += mouseMovement;
        
        startDragPosition = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    public void OnMouseDown()
    {
        startDragPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        isDragging = true;
    }

    public void OnMouseUp()
    {
        isDragging = false;
        
        if (targetTf.localPosition.x > xRange || targetTf.localPosition.x < -xRange)
            ResetPosition();

        if (targetTf.localPosition.y > yRangePositive || targetTf.localPosition.y < yRangeNegative)
            ResetPosition();
    }
    
    private void ResetPosition()
    {
        targetTf.position = targetStartPos;
    }
}
