using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayPuzzleManager : MonoBehaviour
{
    [SerializeField] private GameObject lobotomyOverlay;
    void Start()
    {
        lobotomyOverlay.SetActive(false);
    }

    void Update()
    {
        
    }

    public void StartLobotomy()
    {
        lobotomyOverlay.SetActive(true);
    }
}
