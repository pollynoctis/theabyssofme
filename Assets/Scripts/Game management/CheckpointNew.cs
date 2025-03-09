using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]

public class CheckpointNew : MonoBehaviour
{
    [SerializeField] private string checkpointName;
    private string sceneName;
    private SaveSystem savesSys;
    
    private void Start()
    {
        savesSys = FindObjectOfType<SaveSystem>();
        if (savesSys==null)
        {
            Debug.LogError("save system not linked!");
        }
        Collider2D collider = GetComponent<Collider2D>();
        collider.isTrigger = true;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            savesSys.checkpointPosition = transform.position;
            sceneName = SceneManager.GetActiveScene().name;
            Debug.Log("current scene name is: " + sceneName);
            savesSys.SaveCheckpoint(checkpointName, sceneName);
        }
    }
}