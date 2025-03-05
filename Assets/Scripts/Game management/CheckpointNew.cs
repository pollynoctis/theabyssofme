using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckpointNew : MonoBehaviour
{
    public string checkpointName;
    public TextMeshProUGUI triggerText;
    public SaveSystemNew savesSys;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            savesSys.checkpointPosition = transform.position;
            triggerText.text = "player entered: " + checkpointName; 
            savesSys.SaveCheckpoint(checkpointName);
        }
    }
}
