using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class CmdScript : MonoBehaviour
{
    void Start()
    {
        RunCmd();
        Debug.Log("cmd is  now opening");
    }

    void RunCmd()
    {
        ProcessStartInfo psi = new ProcessStartInfo
        {
            FileName = "cmd.exe",
            Arguments = "/K echo close your eyes & timeout /T 3 & cls & echo coo-coo!",
            UseShellExecute = true // Включает запуск командной строки
        };

        Process.Start(psi);
    }
}