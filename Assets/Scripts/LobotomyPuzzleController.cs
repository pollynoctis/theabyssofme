using UnityEngine;
using Cinemachine;
using System.Collections;

public class LobotomyPuzzleController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cinemachineCamera;
    private CinemachineBasicMultiChannelPerlin noise;

    public AudioClip hitSound;

    private void Start()
    {
        noise = cinemachineCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }
    public void CorrectHit()
    {
        AudioSource.PlayClipAtPoint(hitSound, Camera.main.transform.position);
        //pievienot skaņu un tumšo ekrānu
    }

    public IEnumerator ScreenShake()
    {
        Debug.Log("shake");

        /*if (noise == null)
        {
            Debug.LogError("CinemachineBasicMultiChannelPerlin! not found");
            yield break;
        }*/

        noise.m_AmplitudeGain = 2f; 
        noise.m_FrequencyGain = 3f;

        yield return new WaitForSeconds(0.3f); 

        noise.m_AmplitudeGain = 0f;
        noise.m_FrequencyGain = 0f;
        
    }
}