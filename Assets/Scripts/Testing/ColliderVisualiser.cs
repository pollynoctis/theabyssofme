using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderVisualiser : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        BoxCollider2D col = GetComponent<BoxCollider2D>();
        Gizmos.color = Color.magenta; 
        Vector2 position = (Vector2)transform.position + col.offset;
        Gizmos.DrawWireCube(position, col.size);
        
    }
}
