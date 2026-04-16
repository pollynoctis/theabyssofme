using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SwapPuzzleManager : MonoBehaviour
{
    [HideInInspector] public Image selectedImage;
    
    [SerializeField] private Image[] images;
    [SerializeField] private Sprite[] correctSpriteOrder;

    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip finishSound;

    [SerializeField] private float secondsToWait;
    public void CheckSolution()
    {
        int i = 0;
        foreach (Image img in images)
        {
            if (img.sprite != correctSpriteOrder[i])
                return;
            i++;
        }
        source.PlayOneShot(finishSound);
        print("PUZZLE SOLVED!!!1");
        StartCoroutine(WaitBeforeSceneLoad());
    }
    private IEnumerator WaitBeforeSceneLoad()
    {
        yield return new WaitForSeconds(secondsToWait);
        SceneManager.LoadScene("8-AfterSurgery");
    }
}
