using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObjectEnablerTimer : ParentTriggerObject
{
    [SerializeField] private GameObject objectToEnable;
    [SerializeField] private float waitingTime;
    private bool playedOnce;
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("player here");
        if (!playedOnce && other.CompareTag("Player"))
        {
            print("enabling buttons?");
            StartCoroutine(WaitForEnable());
        }
    }

    private IEnumerator WaitForEnable()
    {
        yield return new WaitForSeconds(waitingTime);
        print("coroutine done");
        objectToEnable.SetActive(true);
        playedOnce = true;
    }
}
