using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SimpleMovement : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private SpriteRenderer renderer;
    [SerializeField] private SpriteRenderer rendererLight;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float accelaration = 2f;

    private Vector2 movement;

    public bool isRunning;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        anim.SetFloat("MovementX", movement.x);
        anim.SetFloat("MovementY", movement.y);
        anim.SetBool("isMoving", movement.sqrMagnitude > 0.01f);

        renderer.flipX = movement.x < 0;
        rendererLight.flipX = movement.x < 0;
        
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
    }
}