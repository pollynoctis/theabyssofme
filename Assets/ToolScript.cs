using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cinemachine;
using UnityEngine.UI;
using UnityEngine;

public class ToolScript : MonoBehaviour
{
    [SerializeField] private DragNDropPuzzleManager puzzleManager;
    [SerializeField] private string toolName;
    [SerializeField] private Vector2 toolPosOffset;
    private Transform cursorImage;
    public bool IsAssigned;

    private void Awake()
    {
        cursorImage = transform.GetChild(0);
    }

    public void AssignTool()
    {
        if (IsAssigned)
        {
            DeselectTools();
            return;
        }
        
        puzzleManager.currentTool = toolName;
        IsAssigned = true;

        foreach (ToolScript tool in transform.parent.GetComponentsInChildren<ToolScript>())
        {
            if (tool != this)
                tool.IsAssigned = false;
        }
    }

    public void DeselectTools()
    {
        foreach (ToolScript tool in transform.parent.GetComponentsInChildren<ToolScript>())
        {
            tool.IsAssigned = false;
        }
    }

    private void Update()
    {
        if (IsAssigned)
        {
            Vector3 zeroZPos = Input.mousePosition;
            zeroZPos.z = 0f;
            cursorImage.position = new Vector2(Camera.main.ScreenToWorldPoint(zeroZPos).x, Camera.main.ScreenToWorldPoint(zeroZPos).y) + toolPosOffset;
        }
        else
        {
            cursorImage.position = transform.position;
        }
    }
}
