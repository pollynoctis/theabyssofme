using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InactivityManager : MonoBehaviour
{
    public GameObject inactivityRelatedObject;
    
    public float inactivityTime;
    public float timer = 0f;
    
    // recently deleted !!!! private Vector3 lastMousePosition;
    private void Update()
    {
        //bool mouseMoved = lastMousePosition != Input.mousePosition;
        // recently deleted !!!! lastMousePosition = Input.mousePosition;
        bool isActive = Input.anyKey || /*mouseMoved ||*/ Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;

        if (isActive)
        {
            ResetTimer();
        }
        else
        {
            timer += Time.deltaTime;
            if (timer >= inactivityTime)
            {
                InacitvityRelatedAction();
                ResetTimer();
            }
        }
    }
    private void ResetTimer()
    {
        timer = 0f;
        /*if (inactivityRelatedObject.activeSelf) 
            inactivityRelatedObject.SetActive(false);*/
    }
    protected abstract void InacitvityRelatedAction();
}

