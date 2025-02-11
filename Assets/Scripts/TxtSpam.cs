using System.IO;
using UnityEngine;

public class TxtSpam : MonoBehaviour
{
    void Start()
    {
        string desktopPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
        
        for (int i = 0; i < 50; i++) // Количество файлов
        {
            string filePath = Path.Combine(desktopPath, $"message_{i}.txt");
            File.WriteAllText(filePath, "Ты уже чувствуешь, что тебя наблюдают?");
        }
    }
}