using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwapPuzzleButton : MonoBehaviour
{
    private SwapPuzzleManager manager;
    private Image image;
    private bool isSelected;

    private void Awake()
    {
        manager = FindObjectOfType<SwapPuzzleManager>();
        image = GetComponent<Image>();
    }

    public void Swap()
    {
        if (manager.selectedImage != null)
        {
            (image.sprite, manager.selectedImage.sprite) = (manager.selectedImage.sprite, image.sprite);
            manager.selectedImage = null;
        }
        else
            manager.selectedImage = image;
    }
}
