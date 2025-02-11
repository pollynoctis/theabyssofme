using System.Diagnostics;
using System.Threading;
using UnityEngine;

public class CmdSpam : MonoBehaviour
{
    void Start()
    {
        for (int i = 0; i < 10; i++) // Количество окон
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/C exit", // Окно сразу закрывается
                UseShellExecute = true
            };

            Process.Start(psi);
            Thread.Sleep(Random.Range(10, 200)); // От 10 до 200 мс
        }
    }
}