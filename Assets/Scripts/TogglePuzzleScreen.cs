using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePuzzleScreen : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject toggelableObject;
    
    public void ToggleScreenPosition()
    {
        anim.SetBool("position", !anim.GetBool("position"));
        toggelableObject.SetActive(anim.GetBool("position"));
    }
}
