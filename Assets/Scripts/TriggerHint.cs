using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHint : TriggerObjectText
{
    [SerializeField] private float hintTime = 30f;
    
    
    //variable for hint related action, not pressing smth

    private void Reset()
    {
        isHint = true;
    }

    //сделать эту часть дочерним скриптом!!!!!!!!
    private void OnTriggerStay2D(Collider2D other)
    {
        if (!playedOnce && other.CompareTag("Player"))
        {
            hintTime -= Time.deltaTime;
            if (hintTime <= 0f) //добавить часть из инактивити мэнэджер, чтобы показывать текст, если игрок не нажимает правильные кнопки
            {
                TextManager.Instance.ShowTextSequence(textLines, isHint, textDuration);
                playedOnce = true; 
            }
        }
    }
}
