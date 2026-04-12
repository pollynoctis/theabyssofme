using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuArrow : MonoBehaviour
{
    [SerializeField] private Transform arrow;
    [SerializeField] private Vector3 positionOffset;
    
    private void Start()
    {
        arrow.gameObject.SetActive(false);
        
        foreach (Button button in FindObjectsOfType<Button>())
        {
            EventTrigger trigger = button.AddComponent<EventTrigger>();
            
            EventTrigger.Entry onPointerEnter = new EventTrigger.Entry();
            onPointerEnter.eventID = EventTriggerType.PointerEnter;
            onPointerEnter.callback.AddListener(delegate { EnableArrow(button.GetComponent<RectTransform>());} );
            trigger.triggers.Add(onPointerEnter);
            
            EventTrigger.Entry onPointerExit = new EventTrigger.Entry();
            onPointerExit.eventID = EventTriggerType.PointerExit;
            onPointerExit.callback.AddListener((arg0 => DisableArrow()));
            trigger.triggers.Add(onPointerExit);
        }
    }

    private void EnableArrow(RectTransform buttonTf)
    {
        arrow.gameObject.SetActive(true);
        Vector3[] buttonCorners = new Vector3[4];
        buttonTf.GetWorldCorners(buttonCorners);
        arrow.position = (buttonCorners[0] + buttonCorners[1]) / 2 + positionOffset;
    }

    private void DisableArrow()
    {
        arrow.gameObject.SetActive(false);
    }
}
