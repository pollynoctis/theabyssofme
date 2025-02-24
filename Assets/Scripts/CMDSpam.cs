using System.Diagnostics;
using System.Threading;
using UnityEngine;

public class CmdSpam : MonoBehaviour
{
    void Start()
    {
        for (int i = 0; i < 2; i++) // logu daudzums
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/C exit", // logs uzreiz aizveras
                UseShellExecute = true
            };
            Process.Start(psi);
            Thread.Sleep(Random.Range(10, 200)); // laika range no 10 līdz 200 ms
        }
    }
}