using System;
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

    [SerializeField] private GameObject playerFront, playerSide, playerSideFlipped,playerBack;

    private Vector2 movement;

    public bool isRunning;

    void Update()
    {
        /*anim.SetFloat("MovementX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MovementY", Input.GetAxisRaw("Vertical"));
        renderer.flipX = Input.GetAxisRaw("Horizontal") < 0;*/
        //executionerMovement.LateMove(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x < 0)
        {
            playerSideFlipped.SetActive(true);
            playerSide.SetActive(false); playerBack.SetActive(false); playerFront.SetActive(false);
        }
        if (movement.x > 0 )
        {
            playerSide.SetActive(true);
            playerSideFlipped.SetActive(false); playerBack.SetActive(false); playerFront.SetActive(false);
        }
        if (movement.y < 0)
        {
            playerFront.SetActive(true);
            playerSideFlipped.SetActive(false); playerSide.SetActive(false); playerBack.SetActive(false);
        } 
        if (movement.y > 0)
        {
            playerBack.SetActive(true);
            
            
            playerSideFlipped.SetActive(false); playerSide.SetActive(false); playerFront.SetActive(false);
        }
        
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