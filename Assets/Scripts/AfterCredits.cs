using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing; // добавь ссылку на System.Drawing.dll
using Microsoft.Win32;

public class AfterCredits : MonoBehaviour
{
    const int SPI_SETDESKWALLPAPER = 20;
    const int SPIF_UPDATEINIFILE = 0x01;
    const int SPIF_SENDWININICHANGE = 0x02;
    
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

    public void EndGame()
    {
        //change wpp
        //check for wpp engine and start bat if yes
        // quit
        Application.Quit();
    }
}
