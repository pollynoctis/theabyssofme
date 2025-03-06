using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using TMPro;


public class AutomaticTextChange : MonoBehaviour
{
    public TextMeshProUGUI firstText;
    [SerializeField] [CanBeNull] private TextMeshProUGUI nextText;
    public float displayDuration = 3f;
    
    public virtual void Start()
    {
        //firstText.gameObject.SetActive(true);
        StartCoroutine(DeactivateTextAfterDelay());
    }

    public virtual IEnumerator DeactivateTextAfterDelay()
    {
        // Wait for the specified duration
        // Deactivate the text object
        yield return new WaitForSeconds(displayDuration);
        firstText.gameObject.SetActive(false);
        nextText.gameObject.SetActive(true);
        
        
    }
}