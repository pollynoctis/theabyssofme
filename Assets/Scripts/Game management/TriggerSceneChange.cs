using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class TriggerSceneChange : AutoSceneChange
{
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(ChangeTheScene());
    }

    public override void OnSceneStart()
    {
        //do nothing
    }
}
