using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwapPuzzleManager : MonoBehaviour
{
    [HideInInspector] public Image selectedImage;
    
    [SerializeField] private Image[] images;
    [SerializeField] private Sprite[] correctSpriteOrder;

    public void CheckSolution()
    {
        int i = 0;
        foreach (Image img in images)
        {
            if (img.sprite != correctSpriteOrder[i])
                return;
            i++;
        }
        print("PUZZLE SOLVED!!!1");
    }
}
