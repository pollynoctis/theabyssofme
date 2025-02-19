using UnityEngine;

public class PlayerSpawnNew : MonoBehaviour
{
    public Transform[] checkpoints; // Массив точек появления
    public SaveSystemNew savesSys;


    void Start()
    {
        string savedCheckpoint = savesSys.LoadCheckpoint();
        //string savedCheckpoint = FindObjectOfType<SaveSystem>().LoadCheckpoint();

        foreach (Transform checkpoint in checkpoints)
        {
            if (checkpoint.name == savedCheckpoint)
            {
                transform.position = checkpoint.position;
                transform.rotation = checkpoint.rotation;
                break;
            }
        }
    }
}