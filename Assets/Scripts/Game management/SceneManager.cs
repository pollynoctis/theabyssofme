using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    //Should be in every scene on an empty object without other scripts!!! do not combine with save system
    
    public void OpenMenu()
    { SceneManager.LoadScene("1-MainMenu"); }
    public void OpenIntro()
    { SceneManager.LoadScene("2-Intro"); }
    public void StartGameplay()
    { SceneManager.LoadScene("3-LabOne"); }
    public void BeforeHandCut()
    { SceneManager.LoadScene("4-BeforeHands"); }
    public void HandCutting()
    { SceneManager.LoadScene("5-HandCut"); }
    public void LabTwo()
    { SceneManager.LoadScene("6-LabTwo"); }
    public void Surgery()
    { SceneManager.LoadScene("7-Surgery"); }
    public void AfterSurgery()
    { SceneManager.LoadScene("8-AfterSurgery"); }
    public void LabThree()
    { SceneManager.LoadScene("9-LabThree"); }
    public void FakeScene()
    { SceneManager.LoadScene("10-FakeScene"); }
    public void LabThreeAfterCrash()
    { SceneManager.LoadScene("11-CEMETERYs"); }
    
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Exit works");
    }
}