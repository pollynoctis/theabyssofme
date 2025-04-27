using System.Diagnostics;
using UnityEngine;

public class CmdScript : MonoBehaviour
{
    public static int CMDBugsCount = 0;
    void Start()
    {
        RunCmd();
        print("cmd is  now opening");
    }

    void RunCmd()
    {
        CMDBugsCount += 1;
        
        ProcessStartInfo psi = new ProcessStartInfo
        {
            FileName = "cmd.exe",
            Arguments = "/K echo close your eyes & timeout /T 3 & cls & echo coo-coo!",
            UseShellExecute = true // Включает запуск командной строки
            
        };

        Process.Start(psi);
    }
}