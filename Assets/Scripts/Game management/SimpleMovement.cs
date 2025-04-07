using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SimpleMovement : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private SpriteRenderer renderer;
    [SerializeField] private Rigidbody2D rb;
    
    
    [SerializeField] private float speed = 100f;
    private Vector2 movement;
    
    void Update()
    {
        anim.SetFloat("MovementX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MovementY", Input.GetAxisRaw("Vertical"));
        
        renderer.flipX = Input.GetAxisRaw("Horizontal") < 0;
        
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
    }
}
