using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SimpleMovement : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private SpriteRenderer renderer;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float accelaration = 2f;
    
    private Vector2 movement;

    public bool isRunning;
    
    void Update()
    {
        anim.SetFloat("MovementX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MovementY", Input.GetAxisRaw("Vertical"));
        
        renderer.flipX = Input.GetAxisRaw("Horizontal") < 0;
        
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime * accelaration);
            isRunning = true;
        }
        else
        {
            rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
            isRunning = false;
        }
        //executionerMovement.LateMove(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
}
