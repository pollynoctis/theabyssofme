using UnityEngine;
using System.IO;

[RequireComponent(typeof(BoxCollider2D))]
public class TriggerZone : MonoBehaviour
{
    [SerializeField] private GameObject objectToActivate;
    private string puzzleEnabledKey = "PuzzleEnabled";
    
    private string savePath;
    private string filePath;
    private void Start()
    {
        savePath = Path.Combine(Application.dataPath, "..", "Saves"); 
        filePath = Path.Combine(savePath, "save.txt"); 
        //PlayerPrefs.DeleteKey("puzzleEnableKey"); //izdzēš to key, vajadzīgs testēšanai. IZŅEMT GALVENAJĀ BUILD!
        
        Collider2D collider = GetComponent<Collider2D>();
        collider.isTrigger = true;
        
        
        /*if (PlayerPrefs.GetInt(puzzleEnabledKey, 0) == 1)
        {
            objectToActivate.SetActive(true);
        }
        else
        {
            objectToActivate.SetActive(false);
        }*/
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            print("player entered puzzle trigger");

            objectToActivate.SetActive(true);
            
            if (File.Exists(filePath))
            {
                
                File.WriteAllText(filePath, "check your desktop"); 
            }
            
            PlayerPrefs.SetInt(puzzleEnabledKey, 1); 
            PlayerPrefs.Save(); 
        }
    }
}