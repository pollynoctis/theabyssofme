using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Checkpoint : ParentTriggerObject
{
    [SerializeField] private string checkpointName;
    [SerializeField] private TMP_Text savingText;
    private string sceneName;
    private SaveSystem savesSys;
    private void Start()
    {
        savesSys = FindObjectOfType<SaveSystem>();
        if (savesSys==null)
        {
            Debug.LogError("save system not linked!");
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            savesSys.checkpointPosition = transform.position;
            sceneName = SceneManager.GetActiveScene().name;
            //Debug.Log("current scene name is: " + sceneName);
            savesSys.SaveCheckpoint(checkpointName, sceneName);
            savingText.gameObject.SetActive(true);
            StartCoroutine(DisableSaving());
        }
    }
    private IEnumerator DisableSaving()
    {
        yield return new WaitForSeconds(2f);
        savingText.gameObject.SetActive(false);
    }
}