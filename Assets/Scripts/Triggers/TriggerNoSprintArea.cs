using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerNoSprintArea : ParentTriggerObject
{
    [SerializeField] private SimpleMovement movement;
    [SerializeField] private GameObject objectToEnable;
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && movement.isRunning)
        {
            print("player is in area and is running");
            StartCoroutine(WaitBeforeDie());
        }
    }

    private IEnumerator WaitBeforeDie()
    {
        yield return new WaitForSeconds(0.7f);
        movement.enabled = false;
        //Time.timeScale = 0f;
        objectToEnable.SetActive(true);
        TextManager.Instance.StopSequence();
    }
}
