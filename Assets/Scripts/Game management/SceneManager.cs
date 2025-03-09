using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
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
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Exit works");
    }
}