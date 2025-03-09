using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerPosition : MonoBehaviour
{
    
    //delete this script, it's not needed
    void Start()
    {
        SaveSystem saveSystem = FindObjectOfType<SaveSystem>();
        if (saveSystem != null && saveSystem.checkpointPosition != Vector2.zero)
        {
            transform.position = saveSystem.checkpointPosition;
            Debug.Log($"Player moved to saved position: {transform.position}");
        }
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.velocity = Vector2.zero; 
        }
    }

}
