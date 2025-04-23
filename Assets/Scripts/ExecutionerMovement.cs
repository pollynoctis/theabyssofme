using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ExecutionerMovement : MonoBehaviour
{
    [SerializeField] private Transform target;
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        agent.SetDestination(target.position);
    }

    //[SerializeField] private Animator anim;
    //[SerializeField] private SpriteRenderer renderer;
    //[SerializeField] private Rigidbody2D rb;


    //[SerializeField] private float speed = 100f;
    //private Vector2 movement;
    //[SerializeField] private float executionerDelay = 1f;

    /*public void LateMove(Vector3 position)
    {
        StartCoroutine(Move(executionerDelay, horizontal, vertical));
    }

    private IEnumerator Move(float delay, Vector3 position)
    {
        yield return new WaitForSeconds(delay);

        //anim.SetFloat("MovementX", horizontal);
        //anim.SetFloat("MovementY", vertical);

        movement.x = horizontal;
        movement.y = vertical;

        renderer.flipX = movement.x < 0;

        rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
    }*/
}
