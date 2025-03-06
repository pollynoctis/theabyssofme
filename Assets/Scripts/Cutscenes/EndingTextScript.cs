using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndingTextScript : AutomaticTextChange
{
    //šis skripts ir domāts pēdējam teksta objektam scēnā. viņš ļauj automātiski pārslēgt ainu
    [SerializeField] private string sceneToLoad;

    public override void Start()
    {
        //firstText.gameObject.SetActive(true);
        StartCoroutine(DeactivateTextAfterDelay());
    }
    public override IEnumerator DeactivateTextAfterDelay()
    {
        // Wait for the specified duration
        // Deactivate the text object
        yield return new WaitForSeconds(displayDuration);
        firstText.gameObject.SetActive(false);

        SceneManager.LoadScene(sceneToLoad);
    }
    
}
