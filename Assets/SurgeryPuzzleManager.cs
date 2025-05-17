using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNDropPuzzleManager : MonoBehaviour
{
    public string currentTool;

    public void ChangeTool(string tool)
    {
        currentTool = tool;
        
    }
}
