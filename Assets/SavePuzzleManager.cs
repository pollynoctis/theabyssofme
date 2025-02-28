using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SavePuzzleManager : MonoBehaviour
{
    private string savePath;
    [SerializeField] private Text debuggerText;

    [SerializeField] private string solutionText = "enter the game";
    void Start()
    {
        savePath = Path.Combine(Application.dataPath, "..", "Saves");

        string filePath = Path.Combine(savePath, "save.txt");

        if (File.Exists(filePath))
        {
            string checkpointData = File.ReadAllText(filePath);
            if (File.ReadAllText(filePath).Contains(solutionText))
            {
                SceneManager.LoadScene("LoadingScene");
                
            }
            else
            {
                Application.Quit();
            }
        }
    }

    void Update()
    {
        
    }
}
