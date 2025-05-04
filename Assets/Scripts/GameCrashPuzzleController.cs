using UnityEngine;
using System;
using System.IO;
using System.Threading;
using System.Collections;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Random = UnityEngine.Random;


public class GameCrashPuzzleController : MonoBehaviour
{
    //_____________errorbox related
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern int MessageBox(IntPtr hWnd, string text, string caption, int type);
    //______________animations, debugging
    //[SerializeField] private TMP_Text debugger;
    [SerializeField] private GameObject animObject;

    public static string solutionText = "Your casket Your casket 30 65 Cemetery";
    //______________instance related
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
        StartGlitchAndAnimation();
        StartCoroutine(WaitBefore(1f));
        
    }
    private void StartGlitchAndAnimation()
    {
        animObject.SetActive(true);    
    }
    private void RewriteSave()
    {
        string savePath = Path.Combine(Application.dataPath, "..", "Saves");
        string savefilePath = Path.Combine(savePath, "save.txt");
        if (File.Exists(savefilePath))
        {
            File.WriteAllText(savefilePath, "[corrupt]\n[ERROR 6C697665]" +
                                            "\nSorry, something went wrong\n" +
                                            "Check 'The Inside' for instructions. "); 
        }
    }
    private void GenerateFilesDesktop()
    {
        //debugger.text = "generating";
        //get the directory
        string desktopPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop), "TheInside");
        if (!Directory.Exists(desktopPath))
        {
            Directory.CreateDirectory(desktopPath);
        }
        //generate txt files
        //file 1
        string generatedFilePath = Path.Combine(desktopPath, "last_breath.txt");
        File.WriteAllText(generatedFilePath, 
                                        "Base64 hides what you seek,\nDecode the chain to see what's unique.\n\n\n" +
                                                "VGhleSBmb2xkZWQgbWUgaW50byBZT1VSIENBU0tFVCwgc2tpbm5lZCBhbmQgcmF3LApGaW5nZXJ" +
                                                "zIHNuYXBwZWQgbGlrZSB0d2lncyBpbiB0aGF3LgpNeSBtb3V0aCBzZXduIHNodXQgd2l0aCBtb2" +
                                                "xkIGFuZCB0aHJlYWQsCkxlZnQgdG8gcm90LCBzdGlsbCB0d2l0Y2hpbmcsIHN0aWxsIGhhbGYtZ" +
                                                "GVhZC4KTXkgc3BpbmUgYmVudCBiYWNrd2FyZCBpbiB5b3VyIHNoYW1lLApBbmQgeW91IHN0aWxs" +
                                                "IGRhcmUgdG8gd2hpc3BlciBteSBuYW1lLg==");
        //file 2
        generatedFilePath = Path.Combine(desktopPath, "rot.txt");
        File.WriteAllText(generatedFilePath,
                                        "Rot47 twists the path you take,\nShift the letters to see what’s at stake." +
                                                "\n\n\nx 4C2H=65 %wx#%* A246D E9C@F89 3:=6 2?5 CFDE[\n}2:=D A66=:?8 @77[ 3" +
                                                "@?6D 8C@F?5 E@ 5FDE]\nx 82DA65 $x)%*\\ux't E:>6D E9C@F89 5:CE 2?5 DA:E[\n" +
                                                "q67@C6 >J =F?8D 82G6 FA — E96J \"&x%]\n#6>6>36C E96D6 ?F>36CD[ 42CG65 :? " +
                                                "D<:? —\n%96J 2C6 E96 >2C<6CD @7 H96C6 J@F 368:?]");
        //file 3
        generatedFilePath = Path.Combine(desktopPath, "hint.txt");
        File.WriteAllText(generatedFilePath, 
                                        "If memory fails, listen to the breathing grave.\nIf sight deceives, bend " +
                                                "the mirror.\nIf you forget yourself, the soil remembers.");
        //generate image
        string sourceImagePath = "Assets/PuzzleMaterials/light_in_the_mirror.png";
        generatedFilePath = Path.Combine(desktopPath, "light_in_the_mirror.png");
        File.Copy(sourceImagePath, generatedFilePath, true);
        //generate audio 
        string sourceAudioPath = "Assets/PuzzleMaterials/hollow_whisper.mp3";
        generatedFilePath = Path.Combine(desktopPath, "hollow_whisper.mp3");
        File.Copy(sourceAudioPath, generatedFilePath, true);
    }
    
    
    private void SpamCmds()
    {
        for (int i = 0; i < 10; i++) // logu daudzums
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/C exit", // logs uzreiz aizveras
                UseShellExecute = true
            };
            Process.Start(psi);
            Thread.Sleep(Random.Range(10, 100));
        }
    }
    public void ShowSystemPopup()
    {
        // type = 0x10 → MB_ICONERROR (покажет иконку ошибки)
        MessageBox(IntPtr.Zero, "Save file corrupted.\nPlease check the game directory.", "Critical Save Error", 0x10);
    }

    private IEnumerator WaitBefore(float seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);
        StartCoroutine(FreezeForSeconds(1f));
    }
    private IEnumerator FreezeForSeconds(float seconds)
    {
        Time.timeScale = 0f; 
        yield return new WaitForSecondsRealtime(seconds); 
        Time.timeScale = 1f;
        RewriteSave();
        GenerateFilesDesktop();
        SpamCmds();
        ShowSystemPopup();
        Application.Quit();
    }
}
