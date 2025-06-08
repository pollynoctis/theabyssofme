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

    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip finishSound;

    public void CheckSolution()
    {
        int i = 0;
        foreach (Image img in images)
        {
            if (img.sprite != correctSpriteOrder[i])
                return;
            i++;
        }
        source.PlayOneShot(finishSound);
        print("PUZZLE SOLVED!!!1");
        
    }
}
