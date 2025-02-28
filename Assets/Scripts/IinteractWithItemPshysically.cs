using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] private KeyCode InteractKey = KeyCode.Space;
    [SerializeField] private float interactRadius = 2f;
    [SerializeField] private LayerMask layerMask;
    private InteractableScript currentInteractable;
    private float colliderDistance;
    private Collider2D closestCollider;
    void Start()
    {
        
    }

    void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, interactRadius, layerMask);
        
        if (colliders.Length > 0)
        {   // find closest interactable object in sphere
            foreach (Collider2D col in colliders)
            {
                if (colliderDistance == 0)
                {
                    colliderDistance = Vector2.Distance(transform.position, col.transform.position);
                    closestCollider = col;
                }
                else if (Vector2.Distance(transform.position, col.transform.position) < colliderDistance)
                {
                    colliderDistance = Vector2.Distance(transform.position, col.transform.position);
                    closestCollider = col;
                }
            }

            //focus on closest interactable object
            if (currentInteractable == null)
            {
                closestCollider.TryGetComponent(out currentInteractable);

                if (currentInteractable)
                    currentInteractable.OnFocus();
            }
            else if (closestCollider.gameObject.GetInstanceID() != currentInteractable.gameObject.GetInstanceID())
            {
                currentInteractable.OnLoseFocus();
                currentInteractable = null;
            }

            colliderDistance = 0f;
        }
        else
        {
            if (currentInteractable != null)
            {
                currentInteractable.OnLoseFocus();
                currentInteractable = null;
            }
        }

        //interact
        if (Input.GetKeyDown(InteractKey) && currentInteractable != null)
        {
            currentInteractable.OnInteract();
        }
    }
}
