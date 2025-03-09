using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    //Should be in every scene on an empty object without other scripts!!! do not combine with save system
    
    public void OpenMenu()
    {
        SceneManager.LoadScene("1-MainMenu");
    }
    public void OpenIntro()
    {
        SceneManager.LoadScene("2-Intro");
    }

    public void StartGameplay()
    {
        SceneManager.LoadScene("3-LabOne");
    }

    public void TestingLoad()
    {
        SceneManager.LoadScene("4-Testing");
    }

    public void ContinueTestingLoad()
    {
        SceneManager.LoadScene("5-Testing");
    }
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Exit works");
    }
}