using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class XRayPuzzleController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    
    [SerializeField] private GameObject doorToOpen; 
    [SerializeField] private GameObject TextToShow; 
    
    [SerializeField] private CinemachineVirtualCamera cinemachineCamera;
    [SerializeField] private GameObject scalpel;
    
    private CinemachineBasicMultiChannelPerlin noise;
    
    void Start()
    {
        noise = cinemachineCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        SimpleMovement component = player.GetComponent<SimpleMovement>();
        component.enabled = false;
        player.GetComponent<Rigidbody2D>().isKinematic = true;
    }
    
    public IEnumerator ScreenShake()
    {
        noise.m_AmplitudeGain = 2f; 
        noise.m_FrequencyGain = 3f;

        yield return new WaitForSeconds(0.3f); 

        noise.m_AmplitudeGain = 0f;
        noise.m_FrequencyGain = 0f;
    }
}
