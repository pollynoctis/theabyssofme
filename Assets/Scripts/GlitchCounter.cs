using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GlitchCounter : MonoBehaviour
{
    public TMP_Text glitchUIText;
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % 60 == 0)
        {
            UpdateText();
        }
    }
    
    private void UpdateText()
    {
        if (glitchUIText != null)
            glitchUIText.text = "CMDBugs: " + CmdScript.CMDBugsCount + "\nMultiCmd: " + MultiCmd.multipleCMDsCount + "\nCmdSpam: " + CmdSpam.CMDSpamCount + "\nOpenBrowserImage: " + OpenBrowserImage.OpenImageCount + "\nTxtSpam: " + TxtSpam.TxtSpamCount;
    }
}
