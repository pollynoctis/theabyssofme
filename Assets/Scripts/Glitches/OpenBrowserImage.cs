using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBrowserImage : MonoBehaviour
{
    public static int OpenImageCount = 0;
    void Start() 
    {
        OpenImageCount += 1;
        Application.OpenURL("https://www.freepik.com/premium-vector/valentines-day-cute-heart-illustration-heart-kawaii-chibi-vector-drawing-style-heart-cartoon-valenti_36455914.htm"); 
    }

}
