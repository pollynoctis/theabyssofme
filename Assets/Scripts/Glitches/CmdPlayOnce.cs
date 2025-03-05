using System.Diagnostics;
using System.Threading;
using UnityEngine;

public class CmdPlayOnce : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.DeleteKey("CmdEffectPlayed"); // izdzēst player pref info. šis ir testēšanai
        if (PlayerPrefs.GetInt("CmdEffectPlayed", 0) == 0) // pārbauda, vai agrāk cmd parādījās
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

            PlayerPrefs.SetInt("CmdEffectPlayed", 1); // pieraksta, ka cmd tika izmests
            PlayerPrefs.Save(); 
        }
    }
}