using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayPuzzleManager : MonoBehaviour
{
    [SerializeField] private GameObject lobotomyOverlay;
    [SerializeField] private GameObject player;
    void Start()
    {
        lobotomyOverlay.SetActive(false);
    }

    public void StartLobotomy()
    {
        lobotomyOverlay.transform.position = player.transform.position;
        lobotomyOverlay.SetActive(true);
    }
}
