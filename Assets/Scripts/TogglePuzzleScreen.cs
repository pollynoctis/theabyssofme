using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePuzzleScreen : MonoBehaviour
{
    [SerializeField] private bool enabledOnPositionOne;
    [SerializeField] private GameObject buttonToEnable;
    [SerializeField] private Animator anim;
    
    public void ToggleScreenPosition()
    {
        anim.SetBool("position", !anim.GetBool("position"));
        if (enabledOnPositionOne)
        {
            gameObject.SetActive(false);
        }
        else
        {
            buttonToEnable.SetActive(true); }
    }
}
