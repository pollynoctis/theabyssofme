using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayPuzzleManager : MonoBehaviour
{
    [SerializeField] private GameObject puzzleOverlay;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject objectToDisable;
    void Start()
    {
        puzzleOverlay.SetActive(false);
    }

    public void StartPuzzle()
    {
        objectToDisable.SetActive(false);
        puzzleOverlay.transform.position = player.transform.position;
        puzzleOverlay.SetActive(true);
    }
}
