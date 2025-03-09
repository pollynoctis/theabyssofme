using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class SaveSystem : MonoBehaviour
{
    private string savePath;
    //public string sceneName; //should be empty
    public GameObject player;
    public Vector2 checkpointPosition;

    private string filePath;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        player = GameObject.Find("PrototypeMainCharacter");
        if (player == null)
        {
            Debug.LogError("player not found");
        }
        else
        {
            Debug.Log("player found");
        }
        
        savePath = Path.Combine(Application.dataPath, "..", "Saves");
        if (!Directory.Exists(savePath))
        {
            Directory.CreateDirectory(savePath);
            
            string filePath = Path.Combine(savePath, "save.txt");
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "first load"); 
            }
        }
        LoadCheckpoint();
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

            // Загружаем сцену и ждем её полной загрузки
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);
            while (!asyncLoad.isDone)
            {
                yield return null;
            }

            // Ждём пока объект игрока загрузится
            yield return new WaitForSeconds(0.1f); // небольшая задержка для безопасности

            // Находим игрока заново, так как он может быть уничтожен при смене сцены
            player = GameObject.FindWithTag("Player");
            if (player == null)
            {
                Debug.LogError("Player not found after scene load!");
                yield break;
            }

            // Устанавливаем позицию игрока
            checkpointPosition = new Vector2(float.Parse(positionFromText[1]), float.Parse(positionFromText[2]));
            player.transform.position = checkpointPosition;
            Debug.Log($"Player loaded at {checkpointPosition}");
        }
    }

    private void LoadPlayerPosition(Vector2 pos)
    {
        player.transform.position = pos;
    }

    public void ClearSaveData()
    {
        File.WriteAllText(filePath, "   ");
    }
}
