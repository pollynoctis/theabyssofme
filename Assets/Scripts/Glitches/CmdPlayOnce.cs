using System.Diagnostics;
using System.Threading;
using UnityEngine;

public class CmdPlayOnce : MonoBehaviour
{
    void Start()
    {
        //PlayerPrefs.DeleteKey("CmdEffectPlayed"); // Сбросить настройку
        if (PlayerPrefs.GetInt("CmdEffectPlayed", 0) == 0) // Проверка, был ли эффект ранее
        {
            for (int i = 0; i < 2; i++) 
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = "/C exit", 
                    UseShellExecute = true
                };
                Process.Start(psi);
                Thread.Sleep(Random.Range(10, 120));  
            }

            PlayerPrefs.SetInt("CmdEffectPlayed", 1); // Запоминаем, что эффект был
            PlayerPrefs.Save(); 
        }
    }
}