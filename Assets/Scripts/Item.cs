using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New PuzzleItem", menuName = "Puzzle Object")]
public class Item : ScriptableObject
{
    [Header("Parameters:")]
    public string objectName;
    public Sprite itemSprite;
    public ItemActionScript actionScript;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void UseItem()
    {
        
    }
}
