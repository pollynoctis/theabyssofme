using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoSceneChange : MonoBehaviour
{
    [SerializeField] private float timeBeforeSceneCgange;
    [SerializeField] private string sceneToLoad;
    void Start()
    {
        OnSceneStart();
    }
    public IEnumerator ChangeTheScene()
    {
        yield return new WaitForSeconds(timeBeforeSceneCgange);
        SceneManager.LoadScene(sceneToLoad);
    }

    public virtual void OnSceneStart()
    {
        StartCoroutine(ChangeTheScene());
    }
}
