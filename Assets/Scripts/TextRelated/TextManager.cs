using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    private static TextManager instance;
    public static TextManager Instance { get { return instance; } }
    
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        } else {
            instance = this;
        }
    }
    public void ShowMessage(string messageName)
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.name == messageName)
            {
                child.gameObject.SetActive(true);
                return;
            }
        }
        Debug.LogError("teksta objekts neatrasts :)");
    }
}
