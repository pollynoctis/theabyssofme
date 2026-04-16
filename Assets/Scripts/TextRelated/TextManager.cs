using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    [Header("Text Objects")]
    [SerializeField] private TMP_Text bottomTextObject;
    [SerializeField] private TMP_Text upperTextObject;
    [SerializeField] private AudioSource voiceSource;
    [SerializeField] private float defaultDuration = 3f;
    
    private Queue<(string, float)> textQueue = new ();
    private Queue<(string, AudioClip)> textAndVoiceQueue = new ();
    public bool isDisplaying = false;
    
    private static TextManager instance;
    public static TextManager Instance { get { return instance; } }
    private void Awake() 
    {
        if (instance != null && instance != this)
        {Destroy(this.gameObject);}
        else 
        {instance = this;}
        
        bottomTextObject.gameObject.SetActive(false);
        upperTextObject.gameObject.SetActive(false);
    }
    
    public void ShowTextSequence(IEnumerable<string> lines, bool isHint, AudioClip[] voiceLines)
    {
        int voiceClipIndex = 0;
        foreach (var line in lines)
        {
            if (voiceClipIndex > voiceLines.Length - 1)
                break;
            textAndVoiceQueue.Enqueue((line, voiceLines[voiceClipIndex]));
            voiceClipIndex++;
        }

        if (!isDisplaying && isHint)
        {
            StartCoroutine(PlayQueue(upperTextObject));
            print("showing the message");
        }
        else if (!isDisplaying)
        {
            StartCoroutine(PlayQueue(bottomTextObject));
        } 
    }
    
    public void ShowTextSequence(IEnumerable<string> lines, bool isHint = false, float textDuration = 3f)
    {
        foreach (var line in lines)
        {
            textQueue.Enqueue((line, textDuration));
        }

        if (!isDisplaying && isHint)
        {
            StartCoroutine(DisplayQueue(upperTextObject));
            print("showing the message");
        }
        else if (!isDisplaying)
        {
            StartCoroutine(DisplayQueue(bottomTextObject));
        } 
    }

    public void StopSequence()
    {
        upperTextObject.text = "";
        bottomTextObject.text = "";
        StopAllCoroutines();
    }

    private IEnumerator DisplayQueue(TMP_Text textPositioned)
    {
        //print("showing the message - ienumerator");
        isDisplaying = true;
        while (textQueue.Count > 0)
        {
            //print("while loop");
            var (text, duration) = textQueue.Dequeue();
            textPositioned.text = text;
            textPositioned.gameObject.SetActive(true);
            yield return new WaitForSeconds(duration);
            //print("waiting done");
            textPositioned.gameObject.SetActive(false);
        }
        //print("loop done");
        isDisplaying = false;
        //print("isDisplaying = false");
    }
    
    private IEnumerator PlayQueue(TMP_Text textPositioned)
    {
        //print("showing the message - ienumerator");
        isDisplaying = true;
        while (textAndVoiceQueue.Count > 0)
        {
            //print("while loop");
            var (text, duration) = textAndVoiceQueue.Dequeue();
            textPositioned.text = text;
            textPositioned.gameObject.SetActive(true);
            voiceSource.PlayOneShot(duration);
            yield return new WaitForSeconds(duration.length);
            //print("waiting done");
            textPositioned.gameObject.SetActive(false);
        }
        //print("loop done");
        isDisplaying = false;
        //print("isDisplaying = false");
    }

    public void DisableIsDisplaying()
    {
        print("isDisplaying = false");
        isDisplaying = false;
    }
}
    
    
    

