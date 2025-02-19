using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public string checkpointName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<SaveSystem>().SaveCheckpoint(checkpointName); //mekle kodu savesystem un saglaba info par checkpoint
        }
    }
}