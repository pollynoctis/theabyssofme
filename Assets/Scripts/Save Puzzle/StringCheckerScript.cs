using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringCheckerScript : MonoBehaviour
{
    //šis skripts pārbauda, vai txt failā ir nepieciešamais teksts. tā kā mīkla vēl nav gatava, šis ir tikai piemērs
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

    
}
