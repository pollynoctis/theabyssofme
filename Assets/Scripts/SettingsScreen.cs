using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SettingsScreen : MonoBehaviour
{
    //[SerializeField] private List<GameObject> objectsToDisable;

    [SerializeField] private GameObject settingsOverlay;
    /*when pressed button -> disable list of objects and enable overlay
     when different button pressed, disable overlay and enable list*/
    public void EnableSettings()
    {
        /*foreach (GameObject obj in objectsToDisable)
        {
            obj.SetActive(false);
        }*/
        settingsOverlay.gameObject.SetActive(true);
    }
    public void DisableSettings()
    {
        /*foreach (GameObject obj in objectsToDisable)
        {
            obj.SetActive(true);
        }*/
        settingsOverlay.gameObject.SetActive(false);
    }
}