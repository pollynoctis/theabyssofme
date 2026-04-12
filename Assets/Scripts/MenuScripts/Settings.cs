using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private TMP_Text screenModeText;
    private bool fullscreen;
    [SerializeField] private AudioMixer mainMixer;
    [SerializeField] private Slider volumeSlider;

    private void Start()
    {   // set fullscreen bool to initial game setting
        fullscreen = Screen.fullScreenMode switch
        {
            FullScreenMode.FullScreenWindow => true,
            FullScreenMode.Windowed => false,
            _ => fullscreen
        };
        
        InitializeSettings();
    }

    private void InitializeSettings()
    {
        screenModeText.text = fullscreen ? "Fullscreen" : "Windowed";
        mainMixer.SetFloat("MasterVolume", Mathf.Log10(volumeSlider.value) * 20);
    }

    public void ToggleFullscreen()
    {
        fullscreen = !fullscreen;
        Screen.fullScreenMode = fullscreen ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;
        InitializeSettings();
    }

    public void SetVolume(float volume)
    {
        mainMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
    }
}
