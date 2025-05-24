using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPressCounter : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private int maxPressCount;
    private int currentPressCount;

    public void OnButtonPress()
    {
        currentPressCount++;
        print("button pressed: " + currentPressCount);
        if (currentPressCount > maxPressCount)
        {
            print("max count reached");
            GetComponent<Button> ().interactable = false;
            print("button action disabled");
            
        }
    }
}
