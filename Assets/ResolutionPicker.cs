using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionPicker : MonoBehaviour
{
    Dropdown resolutionDropdown;
    List<Resolution> commonResolutions = new List<Resolution>
    {
        new Resolution { width = 1920, height = 1080 },
        new Resolution { width = 1600, height = 900 },
        new Resolution { width = 1366, height = 768 },
        new Resolution { width = 1280, height = 720 }
    };

    void Start()
    {
        resolutionDropdown = GetComponent<Dropdown>();
        resolutionDropdown.ClearOptions(); // Ensure it's empty

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        Resolution currentRes = new Resolution { width = Screen.width, height = Screen.height };

        for (int i = 0; i < commonResolutions.Count; i++)
        {
            Resolution res = commonResolutions[i];
            string option = res.width + " x " + res.height;
            options.Add(option);

            if (res.width == currentRes.width && res.height == currentRes.height)
                currentResolutionIndex = i;
        }

        resolutionDropdown.AddOptions(options); // Add the new resolution options
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        resolutionDropdown.onValueChanged.AddListener(SetResolution);
    }

    void SetResolution(int index)
    {
        Resolution res = commonResolutions[index];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }
}
