using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoSceneChange : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(SecondsToSceneChange());
    }

    private IEnumerator SecondsToSceneChange()
    {
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene("3-LabOne");

    }
}
