using UnityEngine;
using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing; // добавь ссылку на System.Drawing.dll
using Microsoft.Win32;

public class SetUserWallpaper : MonoBehaviour
{
    const int SPI_SETDESKWALLPAPER = 20;
    const int SPIF_UPDATEINIFILE = 0x01;
    const int SPIF_SENDWININICHANGE = 0x02;

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

    /// <summary>
    /// Устанавливает изображение из Resources как обои.
    /// </summary>
    /// <param name="resourceImageName">Имя картинки в Resources (без расширения)</param>
    public static void SetWallpaper(string resourceImageName)
    {
        Texture2D texture = Resources.Load<Texture2D>(resourceImageName);
        if (texture == null)
        {
            Debug.LogError($"[WallpaperSetter] Изображение '{resourceImageName}' не найдено в Resources.");
            return;
        }

        byte[] imageBytes = texture.EncodeToPNG(); // или .EncodeToJPG()

        string tempImagePath = Path.Combine(Path.GetTempPath(), "wallpaper.bmp");

        // Конвертация PNG → BMP через System.Drawing
        using (MemoryStream pngStream = new MemoryStream(imageBytes))
        using (System.Drawing.Image image = System.Drawing.Image.FromStream(pngStream))
        {
            image.Save(tempImagePath, System.Drawing.Imaging.ImageFormat.Bmp);
        }

        // Установка обоев через WinAPI
        SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, tempImagePath, SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
        Debug.Log($"[WallpaperSetter] Обои установлены: {tempImagePath}");
    }

    public void SettTheWallpaper()
    {
        //WallpaperSetter.SetWallpaper("wallpaper"); // если файл называется "wallpaper.png"
    }
}
