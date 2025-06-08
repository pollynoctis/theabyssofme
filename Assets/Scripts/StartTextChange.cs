using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTextChange : MonoBehaviour
{
    [SerializeField] private ChangeText textChanger;

    private void Awake()
    {
        textChanger = GetComponent<ChangeText>();
        textChanger.SetText();
    }
}
