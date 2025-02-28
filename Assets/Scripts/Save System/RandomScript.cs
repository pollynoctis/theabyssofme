using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomScript : MonoBehaviour
{
    public string testString = "sdkfhkshdfPOOPkfshdkfhgsdf";
    public string testStringTwo = "jahsdbjasdkjahskfj";
    void Start()
    {
        if (testString.Contains("POOP"))
        {
            print("Stinks!");
        }

        if (testStringTwo.Contains("VAGINA"))
        {
            print("penis");   
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
