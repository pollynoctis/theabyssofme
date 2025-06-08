using UnityEngine;
using TMPro;

public class ClickGameManager : MonoBehaviour
{
    [System.Serializable]
    public class Step
    {
        public string sentence;          // The sentence to show
        public GameObject correctPoint;  // The finger the player must click
    }

    public Step[] steps;                // List of steps
    public TextMeshProUGUI sentenceText;  // The TextMeshProUGUI text on screen
    public GameObject blackScreen;      // The black screen to show when the player fails

    private int currentStep = 0;
    public TypewriterEffect typewriterEffect;
    public GameObject retryButton;



    void Start()
    {
        blackScreen.SetActive(false);
        ShowStep();
    }

    void ShowStep()
    {
        if (currentStep < steps.Length)
        {
            StopAllCoroutines();
            StartCoroutine(typewriterEffect.TypeText(sentenceText, steps[currentStep].sentence));
        }
        else
        {
            StopAllCoroutines();
            StartCoroutine(typewriterEffect.TypeText(sentenceText, "You did it"));
        }
    }

    public void PointClicked(GameObject clickedPoint)
    {
        if (clickedPoint == steps[currentStep].correctPoint)
        {
            currentStep++;
            ShowStep();
        }
        else
        {
            // STOP all typing and show "Wrong"
            StopAllCoroutines();  // <<< IMPORTANT: stop the typewriter effect
            blackScreen.SetActive(true);
            sentenceText.text = "Wrong.";
            retryButton.SetActive(true);  // <<< Show the Retry button
        }
    }


}
