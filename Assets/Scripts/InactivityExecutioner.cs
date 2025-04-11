using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InactivityExecutioner : InactivityManager
{
    protected override void InacitvityRelatedAction()
    {
        inactivityRelatedObject.SetActive(true);
        
    }
}



