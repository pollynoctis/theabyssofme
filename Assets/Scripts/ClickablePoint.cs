using UnityEngine;

public class ClickablePoint : MonoBehaviour
{
    public ClickGameManager gameManager;

    void OnMouseDown()
    {
        // Play the AudioSource attached to this finger
        AudioSource audio = GetComponent<AudioSource>();
        if (audio != null)
        {
            audio.Play();
        }

        // Tell the GameManager which point was clicked
        gameManager.PointClicked(gameObject);
    }
}
