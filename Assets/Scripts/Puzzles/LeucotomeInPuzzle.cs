using System;
using UnityEngine;
using UnityEngine.Rendering;

public class LeucotomeInPuzzle : MonoBehaviour
{
    [SerializeField] private Transform hitPoint; // Точка удара на инструменте
    [SerializeField] private float hitRadius = 0.1f; // Радиус проверки попадания
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip incorrectHit;
    
    public bool isDragging = false;


    private void Start()
    {
        Collider2D collider = GetComponent<Collider2D>();
        if (collider == null)
        {
            print("no collider!");
        }

        if (hitPoint == null)
        { 
            print("no hit point");
        }
    }


    private void Update()
    {
        if (Camera.main ==null)
        {
            Debug.Log("no main camera found!");
        }
        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(Input.mousePosition);
            Debug.Log(mousePosition);
            mousePosition.z = 0f;
            transform.position = mousePosition;
        }
    }
    private void OnMouseDown() 
    {
        isDragging = true;
    }
    private void OnMouseUp()
    {
        isDragging = false;
        CheckHit();
    }
    private void CheckHit()
    {
        Collider2D targetCollider = Physics2D.OverlapCircle(hitPoint.position, hitRadius);

        if (targetCollider == null) 
        {
            Debug.LogError("no collider!");
        }
        if (targetCollider != null && targetCollider.CompareTag("CorrectHitArea"))
        {
            //Debug.Log("lobotomy point");
            GameObject.Find("LobotomyPuzzle").GetComponent<LobotomyPuzzleController>().CorrectHit();
        }
        else
        {
            source.PlayOneShot(incorrectHit);
            //Debug.Log("wrong spot");
            GameObject.Find("LobotomyPuzzle").GetComponent<LobotomyPuzzleController>().StartCoroutine("ScreenShake");
        }
    }
    
    private void OnDrawGizmos()
    {
        if (hitPoint != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(hitPoint.position, hitRadius);
        }
    }
}