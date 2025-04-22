using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

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
                                        "Check 'The Inside' for instructions. \n \n \n \n \n \n \n \n \n \n \n " +
                                        "\n \n \n \n \n \n \n \n \n \n \n \nI am already inside you."); 
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

        string txtFilePath = Path.Combine(desktopPath, "body_frag.txt");

        File.WriteAllText(txtFilePath, 
            "Your hands were cold when you picked it up.\n" +
            "But that was not the first time.\n\n" +
            "X: -21.4\nZ: 3.2\nY: [ROT13] -> avprf5.rk\n");
    }

    
    private IEnumerator FreezeForSeconds(float seconds)
    {
        Time.timeScale = 0f; 
        yield return new WaitForSecondsRealtime(seconds); 
        Time.timeScale = 1f;
    }

    
}
