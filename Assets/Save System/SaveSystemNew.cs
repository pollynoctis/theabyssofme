using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;


public class SaveSystemNew : MonoBehaviour
{
   
    private string savePath;
    public TextMeshProUGUI debugTextOne;
    public TextMeshProUGUI debugTextTwo;
    public TextMeshProUGUI debugTextThree;
    public GameObject player;
    public Vector2 checkpointPosition; 
    void Start()
    {
        player = GameObject.Find("PlayerSquare");
        if (player == null)
        {
            Debug.LogError("player not found");
        }
        else
        {
            Debug.Log("player found");
        }
        debugTextOne.text = "game started";
        savePath = Path.Combine(Application.dataPath, "..", "Saves");
        if (!Directory.Exists(savePath))
        {
            Directory.CreateDirectory(savePath);
            debugTextTwo.text = "directory created";
            string filePath = Path.Combine(savePath, "save.txt");
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "Start"); 
            }
        }
        LoadCheckpoint();
    }
    
    public void SaveCheckpoint(string checkpointName)
    {
        //debugging part
        debugTextOne.text = "Saving checkpoint: " + checkpointName;
        Debug.Log("saving checkpoint: " + checkpointName);
        Debug.Log(checkpointPosition);
        
        //actual coding part
        string filePath = Path.Combine(savePath, "save.txt");
        File.WriteAllText(filePath, checkpointName + " " + checkpointPosition.x + " " + checkpointPosition.y);
    }
    public string LoadCheckpoint()
    {
        string filePath = Path.Combine(savePath, "save.txt");
        if (File.Exists(filePath))
        {
            
            string checkpointData = File.ReadAllText(filePath);
            Debug.Log("Loaded: " + checkpointData);
            debugTextThree.text = "(load checkpoint void) game loaded" + checkpointData;
            Debug.Log(checkpointPosition);
            string[] kuku = checkpointData.Split(" ");
            LoadPlayerPosition(new Vector2(float.Parse(kuku[1]), float.Parse(kuku[2])));
        }
        return "Start";
    }
    public void LoadPlayerPosition(Vector2 pos)
    {
        //player.transform.position = checkpointPosition;
        player.transform.position = pos;
    }
    
}
