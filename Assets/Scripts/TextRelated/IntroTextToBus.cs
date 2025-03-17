using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroTextToBus : AutomaticTextChange
{
    [SerializeField] private GameObject toEnable;
    [SerializeField] private GameObject toDisable;
    
    
    public override IEnumerator DeactivateTextAfterDelay()
    {
        yield return new WaitForSeconds(displayDuration);
        firstText.gameObject.SetActive(false);
        nextText?.gameObject.SetActive(true);
        toDisable.SetActive(false);
        toEnable.SetActive(true);
    }
}
