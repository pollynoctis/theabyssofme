using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

public class GetPlayerUsername : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textToShow;
    private string username = System.Environment.UserName;

    private void Awake()
    {
        textToShow.text = "Hello... " + username + "...";
    }

    void Start()
    {
        
        
        

    }
    
}
