using System.IO;
using UnityEngine;
using TMPro;

public class SaveSystem : MonoBehaviour
{
    private string savePath;
    public TextMeshProUGUI debugText;

    void Start()
    {
        debugText.text = "game started";
        // Путь к папке с сохранениями (в папке "Documents" или "Application.persistentDataPath")
        // savePath = Path.Combine(Application.persistentDataPath, "SaveData"); // cels uz vietu, kur klabajas faili
        string folderPath = Path.Combine(Application.dataPath, "..", "Saves");
        savePath = Path.Combine(folderPath, "save.txt");
        
        // Создаём папку, если её нет
        if (!Directory.Exists(savePath)) //parbauda, vai ir mape
        {
            Directory.CreateDirectory(savePath); // veido mapi
            debugText.text = "directory created";
        }

        // Создаём файл, если он не существует
        string filePath = Path.Combine(savePath, "save.txt");
        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "Checkpoint: Start"); // Начальное значение
        }
        // Загружаем последнее сохранение
        LoadCheckpoint();
    }

    public void SaveCheckpoint(string checkpointName)
    {
        string filePath = Path.Combine(savePath, "save.txt");
        File.WriteAllText(filePath, "Checkpoint: " + checkpointName);
        Debug.Log("Сохранено: " + checkpointName);
        debugText.text = "saved at: " + checkpointName;
        

    }

    public string LoadCheckpoint()
    {
        string filePath = Path.Combine(savePath, "save.txt");
        if (File.Exists(filePath))
        {
            string data = File.ReadAllText(filePath);
            Debug.Log("Загружено: " + data);
            debugText.text = "loaded: " + data;
            return data.Replace("Checkpoint: ", ""); // Возвращаем только имя чекпоинта
        }
        return "Start"; // Если файл пустой
    }
}