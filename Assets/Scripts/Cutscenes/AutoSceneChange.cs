using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoSceneChange : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private GameObject fadeOutScreen;
    [SerializeField] private float timeBeforeFadeOut = 3f;
    [SerializeField] private float timeBeforeSceneCgange;
    
    void Start()
    {
        OnSceneStart();
    }
    
    public IEnumerator SecondsToSceneChange()
    {
        yield return new WaitForSeconds(timeBeforeFadeOut);
        fadeOutScreen.SetActive(true);
        StartCoroutine(ChangeTheScene());
    }
    
    public IEnumerator ChangeTheScene()
    {
        yield return new WaitForSeconds(timeBeforeSceneCgange);
        SceneManager.LoadScene(sceneToLoad);
    }
    
    public virtual void OnSceneStart()
    {
        StartCoroutine(SecondsToSceneChange());
    }
}
