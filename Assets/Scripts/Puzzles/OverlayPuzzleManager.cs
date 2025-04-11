using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayPuzzleManager : MonoBehaviour
{
    [SerializeField] private GameObject puzzleOverlay;
    [SerializeField] private GameObject player;
    void Start()
    {
        puzzleOverlay.SetActive(false);
    }

    public void StartPuzzle()
    {
        puzzleOverlay.transform.position = player.transform.position;
        puzzleOverlay.SetActive(true);
    }
}
