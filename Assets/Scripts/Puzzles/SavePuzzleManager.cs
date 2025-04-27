using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SavePuzzleManager : MonoBehaviour
{
    //ŠĪ IR VECA VERSIJA! NEIZMANTOT!
    
    
    
    //private string cmdSpamDisabler;
    //[SerializeField] private Text debuggerText;
    
    [SerializeField] private string solutionText;
    [SerializeField] private GameObject triggerToDisable;
    private string savePath;
    private CmdSpam cmdSpam;
    
    void Start()
    {
        PlayerPrefs.DeleteKey("cmdSpamDisabler"); //for testing
        
        cmdSpam = GetComponent<CmdSpam>();
        savePath = Path.Combine(Application.dataPath, "..", "Saves");
        string filePath = Path.Combine(savePath, "save.txt");
        
        if (File.Exists(filePath))
        {
            string saveFileData = File.ReadAllText(filePath);
            if (saveFileData.Contains(solutionText))
            {
                SaveSystem.Instance.LoadCheckpoint();
                if (cmdSpam != null)
                {
                    cmdSpam.enabled = false; 
                }
                gameObject.SetActive(false);
                triggerToDisable.SetActive(false);
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
