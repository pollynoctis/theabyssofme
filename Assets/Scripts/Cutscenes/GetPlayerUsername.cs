using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

public class GetPlayerUsername : MonoBehaviour
{
    [SerializeField] private TMP_Text textToShow;
    [TextArea]
    [SerializeField] private string textForUsername;
    private string username = System.Environment.UserName;

    private void Awake()
    {
        textToShow.text = textForUsername + username + "...";
    }

    
    
}
