using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TriggerObjectEnablerTimerRepeat : MonoBehaviour
{
    [SerializeField] private GameObject objectToEnable;
    [SerializeField] private float waitingTime;
    private void Start()
    {
        objectToEnable.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("player here");
        if (other.CompareTag("Player"))
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
    }
}
