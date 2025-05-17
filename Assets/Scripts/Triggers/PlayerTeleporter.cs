using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerTeleporter : ParentTriggerObject
{
    [SerializeField] private Transform teleportDestination;
    [SerializeField] private GameObject executioner;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = teleportDestination.position;
            executioner.transform.position = teleportDestination.position;
        }
    }
}
