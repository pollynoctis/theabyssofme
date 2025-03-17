using System;
using UnityEngine;

public class LeucotomeInPuzzle : MonoBehaviour
{
    [SerializeField] private Transform hitPoint; // Точка удара на инструменте
    [SerializeField] private float hitRadius = 0.1f; // Радиус проверки попадания
    private bool isDragging = false;
    

    private void Update()
    {
        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
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
            Debug.Log("lobotomy point");
            GameObject.Find("LobotomyPuzzle").GetComponent<LobotomyPuzzleController>().CorrectHit();
            
            
            
        }
        else
        {
            Debug.Log("wrong spot");
            GameObject.Find("LobotomyPuzzle").GetComponent<LobotomyPuzzleController>().StartCoroutine("ScreenShake");
            
        }
    }
    
    private void OnDrawGizmos()
    {
        if (hitPoint != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(hitPoint.position, hitRadius);
        }
    }
    
    
}