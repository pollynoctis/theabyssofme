using System.Diagnostics;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;
using System.Linq;


public class BatFileRunner : MonoBehaviour
{
    public void CheckWallpaperEngine()
    {
        if (IsWallpaperEngineRunning())
        {
            Debug.Log("Wallpaper Engine обнаружен — запускаем бат-файл.");
            RunPopupAndKillWallpaper();
        }
        else
        {
            Debug.Log("Wallpaper Engine не запущен.");
        }
    }

    private bool IsWallpaperEngineRunning()
    {
        try
        {
            var targetNames = new string[]
            {
                "Wallpaper32.exe",
                "Wallpaper64.exe",
                "wallpaper32.exe",
                "wallpaper64.exe",
                "WallpaperEngine.exe"
            };

            foreach (Process p in Process.GetProcesses())
            {
                try
                {
                    string exeName = Path.GetFileName(p.MainModule.FileName);
                    if (targetNames.Contains(exeName))
                    {
                        return true;
                    }
                }
                catch
                {
                    // Некоторые системные процессы не дают доступ к MainModule — игнорируем
                }
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("Ошибка при проверке процессов: " + e.Message);
        }

        return false;
    }

    public void RunPopupAndKillWallpaper()
    {
        string batPath = Path.Combine(Application.dataPath, "temp_popup.bat");

        // Содержимое bat-файла с самоуничтожением
        string batContent = "@echo off\n" +
                            "powershell -NoProfile -Command \"Add-Type -AssemblyName PresentationFramework; " +
                            "[System.Windows.MessageBox]::Show('Wallpaper Engine crashed. Please turn it off.', 'Critical Error', 'OK', 'Error')\"\n" +
                            "taskkill /f /im Wallpaper32.exe >nul 2>&1\n" +
                            "taskkill /f /im Wallpaper64.exe >nul 2>&1\n" +
                            "taskkill /f /im WallpaperEngine.exe >nul 2>&1\n" +
                            "timeout /t 2 >nul\n" +
                            "del \"%~f0\" & exit\n"; // Удаление самого себя

        // Создаем файл
        File.WriteAllText(batPath, batContent);

        // Запускаем bat-файл
        ProcessStartInfo psi = new ProcessStartInfo
        {
            FileName = batPath,
            CreateNoWindow = true,
            UseShellExecute = true,
            Verb = "runas" // Запуск от имени администратора
        };

        try
        {
            Process.Start(psi);
        }
        catch (System.Exception e)
        {
            //Debug.LogError("Не удалось запустить BAT файл: " + e.Message);
        }
    }
}