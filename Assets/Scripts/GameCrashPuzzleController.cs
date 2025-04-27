using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using System.IO;
using TMPro;
using System.Threading;


public class GameCrashPuzzleController : MonoBehaviour
{
    [SerializeField] private TMP_Text debugger; 
    private string savePath;
    
    
    
    
    private static GameCrashPuzzleController _instance;
    public static GameCrashPuzzleController Instance { get { return _instance; } }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void StartCrash()
    {
        print("crash started");
        RewriteSave();
        GenerateFilesDesktop();
        SpamCmds();
    }
    /*
     отключение игры - игра фризует
     врубаются разные эффекты
     генерируются файлы на рабочем столе
     файл сохранения становится пустым
     менеджер паззла - загрузка доп сцены
     менеджер паззла - загрузка текста и тд
     вылет игры
     */


    private void RewriteSave()
    {
        savePath = Path.Combine(Application.dataPath, "..", "Saves");
        string filePath = Path.Combine(savePath, "save.txt");
        if (File.Exists(filePath))
        {
            File.WriteAllText(filePath, "[corrupt]\n[ERROR 6C697665]\nSorry, something went wrong\n" +
                                        "Check 'The Inside' for instructions. " +
                                        "\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n" +
                                        "I am already inside you."); 
        }
    }

    private void GenerateFilesDesktop()
    {
        debugger.text = "generating";
        string desktopPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop), "TheInside");
        if (!Directory.Exists(desktopPath))
        {
            Directory.CreateDirectory(desktopPath);
        }
        string txtFilePath = Path.Combine(desktopPath, "fragment_1.txt");
        File.WriteAllText(txtFilePath, 
            "Base64 hides what you seek,\nDecode the chain to see what's unique.\n\n\n" +
            "SSB3b2tlIHVuZGVyIGdsb3ZlZCBoYW5kcywKQnJlYXRoIGNydXNoZWQsClNraW4gc3BsaXQgYnkgc2lsZW50IHByYXllcnMuCk5vIGZpZ2h0IOKAlCBqdXN0IG1lYXQg4oCUClJvdHRpbmcsIHdhcm0sIGZvcmdvdHRlbi4=");
        txtFilePath = Path.Combine(desktopPath, "fragment_2.txt");
        File.WriteAllText(txtFilePath,
            "Rot47 twists the path you take,\nShift the letters to see what’s at stake.\n\n\n" +
            "%96J 3FC:65 >J G@:46 :? D@7E D@:=[\n%66E9 8C:?5:?8 5FDE[\n}2:=D 4=2H:?8 9@==@H 8C@F?5]\nx 3=65 2 >2A 24C@DD E96:C =2F89E6C[\n{67E 369:?5 2E %wx#%* A246D 62DE[ $x)%*\\ux't ?@CE9]");

        string sourceImagePath = "Assets/Visuals/main_menu.png";
        string destImagePath = Path.Combine(desktopPath, "main_menu.png");
        File.Copy(sourceImagePath, destImagePath, true);

    }
    
    private IEnumerator FreezeForSeconds(float seconds)
    {
        Time.timeScale = 0f; 
        yield return new WaitForSecondsRealtime(seconds); 
        Time.timeScale = 1f;
    }

    private void StartGlitchAndAnimation()
    {
        
    }

    private void ExitGame()
    {
        
    }

    private void SpamCmds()
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
            Thread.Sleep(Random.Range(10, 100));
        }

        ProcessStartInfo anotherpsi = new ProcessStartInfo()
        {
            FileName = "cmd.exe",
            Arguments = "/T:04 /K echo [Critical Save Error] & echo Save file corrupted. & echo Check the game directory.",
            UseShellExecute = true

        };
        Process.Start(anotherpsi);
        Application.Quit();
    }

    private void PasteImage()
    {
        
    }

    
}
