using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInteractable : InteractableScript
{
    //skripts interactable priekšmetiem, kas netiek pievienoti inventory
    [SerializeField] private GameObject objectToShow;
    public override void OnInteract()
    {
        objectToShow.SetActive(true);
    }

    public override void OnFocus()
    {
        //throw new System.NotImplementedException();
    }

    public override void OnLoseFocus()
    {
        objectToShow.SetActive(false);
    }
}
