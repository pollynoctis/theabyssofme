using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SimpleMovement : MonoBehaviour
{
    [SerializeField] private float speed = 100f;
    private Vector2 movement;
    [SerializeField] private Rigidbody2D rb;
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
    }
}
