using System.Collections;
using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class SaveSystem : MonoBehaviour
{
    public Vector2 checkpointPosition;
    [CanBeNull] private GameObject player;
    private string savePath;
    private string filePath;
    
    private static SaveSystem _instance;
    public static SaveSystem Instance { get { return _instance; } }
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
    void Start()
    {
        savePath = Path.Combine(Application.dataPath, "..", "Saves");
    
        string flagPath = Path.Combine(savePath, "crash.flag");

        if (File.Exists(flagPath))
        {
            Debug.Log("Crash flag detected. Triggering corrupted save logic.");
            HandleCorruptedSave(); // отдельный метод, см. ниже
        }
        else
        {
            // обычная логика
            player = GameObject.FindWithTag("Player");
            if (player == null)
            {
                Debug.LogError("player not found");
            }

            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
                string filePath = Path.Combine(savePath, "save.txt");
                if (!File.Exists(filePath))
                {
                    File.WriteAllText(filePath, "Clean");
                }
            }
        }
    }
    
    public void SaveCheckpoint(string checkpointName, string sceneName)
    {
        string filePath = Path.Combine(savePath, "save.txt");
        File.WriteAllText(filePath, checkpointName + " " + checkpointPosition.x + " " + checkpointPosition.y + " " + sceneName);
    }
    
    public void LoadCheckpoint()
    {
        StartCoroutine(LoadSceneAndSetPosition());
    }
    private IEnumerator LoadSceneAndSetPosition()
    {
        string filePath = Path.Combine(savePath, "save.txt");
        if (File.Exists(filePath))
        {
            string checkpointData = File.ReadAllText(filePath);
            string[] positionFromText = checkpointData.Split(" ");
            string sceneToLoad = positionFromText[3];
            
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
            yield return new WaitForSeconds(0.1f); 
            
            player = GameObject.FindWithTag("Player");
            if (player == null)
            {
                Debug.LogError("Player not found after scene load!");
                yield break;
            }
            checkpointPosition = new Vector2(float.Parse(positionFromText[1]), float.Parse(positionFromText[2]));
            player.transform.position = checkpointPosition;
        }
    }
    
    public void ClearSaveData()
    {
        string filePath = Path.Combine(savePath, "save.txt");
        File.WriteAllText(filePath, "Clean");
        //clear all player prefs as well
    }

    private void HandleCorruptedSave()
    {
        string filePath = Path.Combine(savePath, "save.txt");
        string saveContent = File.ReadAllText(filePath);

        if (saveContent.Contains(GameCrashPuzzleController.solutionText.ToLower()) || saveContent.Contains(GameCrashPuzzleController.solutionTextTwo.ToLower()))
        {
            SceneManager.LoadScene("Cemetery");
        }
        else
        {
            // Запускай фальшивую сцену, глитчи или снова вылет
            SceneManager.LoadScene("FakeScene");
            GameCrashPuzzleController.Instance.SpamTxt();
        }
    }

    
    
    
}
