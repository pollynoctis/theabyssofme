using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class TriggerSceneChange : AutoSceneChange
{
    public override void OnSceneStart()
    {
        //print("trigger scene change script enabled");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(SecondsToSceneChange());
    }
}
