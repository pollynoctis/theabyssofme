using System.Diagnostics;
using UnityEngine;

public class MultiCmd : MonoBehaviour
{
    void Start()
    {
        OpenCmdWindow("can you hear it?", 7, "it's coming...");
        OpenCmdWindow("watch behind you", 5, "too late...");
        OpenCmdWindow("close your eyes", 3, "coo-coo!");
        
    }

    void OpenCmdWindow(string firstMessage, int delay, string secondMessage)
    {
        ProcessStartInfo psi = new ProcessStartInfo
        {
            FileName = "cmd.exe",
            Arguments = $"/K echo {firstMessage} & timeout /T {delay} & cls & echo {secondMessage}",
            UseShellExecute = true
        };

        Process.Start(psi);
    }
}