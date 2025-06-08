using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitBeforeDisable : MonoBehaviour
{
    [SerializeField] private float timeBeforeDisable;
    [SerializeField] private GameObject[] objectsToDisable;
    [SerializeField] private GameObject[] objectsToEnable;
    void Update()
    {
        timeBeforeDisable -= Time.deltaTime;
        if (timeBeforeDisable <= 0f) 
        {
            TextManager.Instance.StopSequence();
            foreach (GameObject obj in objectsToEnable)
            {
                obj.SetActive(true);
            }
            foreach (GameObject obj in objectsToDisable)
            {
                obj.SetActive(false);
            }
        }
    }
}
