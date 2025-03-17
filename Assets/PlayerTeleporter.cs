using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerTeleporter : MonoBehaviour
{
    [SerializeField] private Transform teleportDestination; 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = teleportDestination.position;
        }
    }
}
