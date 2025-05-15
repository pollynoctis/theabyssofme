using UnityEngine;
using Cinemachine;
using System.Collections;

public class LobotomyPuzzleController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cinemachineCamera;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject keyToEnable;
    [SerializeField] private GameObject objectToEnable;
    
    private CinemachineBasicMultiChannelPerlin noise;


    [SerializeField] private AudioSource source;
    public AudioClip hitSound;


    [SerializeField] private InventoryManager inventManager;

    [SerializeField] private GameObject leuctome;
    
    
    private void Start()
    {
        keyToEnable.SetActive(false);
        SimpleMovement component = player.GetComponent<SimpleMovement>();
        component.enabled = false;
        noise = cinemachineCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        player.GetComponent<Rigidbody2D>().isKinematic = true;
    }
    public void CorrectHit()
    {
        AudioSource.PlayClipAtPoint(hitSound, Camera.main.transform.position);
        SimpleMovement component = player.GetComponent<SimpleMovement>();
        component.enabled = true;
        Vector2 keySpawn = new Vector2(player.transform.position.x - 3f, player.transform.position.y - 0.5f);
        keyToEnable.transform.position = keySpawn;
        keyToEnable.SetActive(true);
        
        objectToEnable.SetActive(true);
        gameObject.SetActive(false);
        
        
        player.GetComponent<Rigidbody2D>().isKinematic = false;
        
        inventManager.RemoveItem(leuctome);
        
        //pievienot skaņu un tumšo ekrānu
    }

    public IEnumerator ScreenShake()
    {
        //Debug.Log("shake");

        if (noise == null)
        {
            Debug.LogError("CinemachineBasicMultiChannelPerlin! not found");
            yield break;
        } //debugging for cinemachine

        noise.m_AmplitudeGain = 2f; 
        noise.m_FrequencyGain = 3f;

        yield return new WaitForSeconds(0.3f); 

        noise.m_AmplitudeGain = 0f;
        noise.m_FrequencyGain = 0f;
    }
}