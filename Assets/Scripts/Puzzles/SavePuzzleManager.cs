using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SavePuzzleManager : MonoBehaviour
{
    //private string cmdSpamDisabler;
    //[SerializeField] private Text debuggerText;
    
    [SerializeField] private string solutionText;
    private string savePath;
    private CmdSpam cmdSpam;
    
    void Start()
    {
        cmdSpam = GetComponent<CmdSpam>();
        //PlayerPrefs.DeleteKey("cmdSpamDisabler");
        
        savePath = Path.Combine(Application.dataPath, "..", "Saves");
        string filePath = Path.Combine(savePath, "save.txt");

        if (File.Exists(filePath))
        {
            string checkpointData = File.ReadAllText(filePath);
            if (File.ReadAllText(filePath).Contains(solutionText))
            {
                SaveSystem.Instance.LoadCheckpoint();
                if (cmdSpam != null)
                {
                    cmdSpam.enabled = false; 
                }
            }
            else
            {
                if (cmdSpam != null)
                {
                    cmdSpam.enabled = true; 
                }
                Application.Quit();
            }
        }
    }
}
