using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScarScript : MonoBehaviour
{
    [SerializeField] private DragNDropPuzzleManager puzzleManager;
    [SerializeField] private string requiredTool;
    [SerializeField] private GameObject imageToEnable;
    [SerializeField] private GameObject symptomToEnable;
    
    public void TryCut()
    {
        if (puzzleManager.currentTool == requiredTool)
        {
            ExecuteCut();
            
        }
        else
        {
            //do stewpid sound, camera move and yes
        }
    }

    private void ExecuteCut()
    {
        imageToEnable.SetActive(true);
        symptomToEnable.SetActive(true);
        GetComponent<Button>().enabled = false;
    }
}
