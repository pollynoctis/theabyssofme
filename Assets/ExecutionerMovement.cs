using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecutionerMovement : MonoBehaviour
{
    //[SerializeField] private Animator anim;
    [SerializeField] private SpriteRenderer renderer;
    [SerializeField] private Rigidbody2D rb;
    
    
    [SerializeField] private float speed = 100f;
    private Vector2 movement;
    [SerializeField] private float executionerDelay = 1f;

    public void LateMove(float horizontal, float vertical)
    {
        StartCoroutine(Move(executionerDelay, horizontal, vertical));
    }
    
    private IEnumerator Move(float delay, float horizontal, float vertical)
    {
        yield return new WaitForSeconds(delay);
        
        //anim.SetFloat("MovementX", horizontal);
        //anim.SetFloat("MovementY", vertical);
        
        movement.x = horizontal;
        movement.y = vertical;
        
        renderer.flipX = movement.x < 0;
        
        rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
    }
    
    
}
