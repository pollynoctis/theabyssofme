using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoSceneChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SecondsToSceneChange());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator SecondsToSceneChange()
    {
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene("3-LabOne");

    }
}
