using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    public Transform player; 
    [SerializeField] private float moveSpeed ; 
    [SerializeField] private float attackRange ; 
    [SerializeField] private float   stoppingDistance; 

    private bool facingLeft = true;

    [Header("Animator")]
    [SerializeField] private Animator animator;

    private Rigidbody2D rb;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Chase();
    }
    private void Chase()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer < attackRange)
        {
            if (distanceToPlayer > stoppingDistance)
            {
               
                MoveTowardsPlayer();
               
                animator.SetBool("moving", true);
            }
            else
            {
             
                animator.SetBool("moving", false);
               
               
            }
        }
        else
        {

            animator.SetBool("moving", false);
        }
    }

    private void MoveTowardsPlayer()
    {
        
        Vector2 direction = player.position - transform.position;
        rb.velocity = new Vector2(direction.normalized.x * moveSpeed, rb.velocity.y);


        if (direction.x < 0 && !facingLeft || direction.x > 0 && facingLeft)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingLeft = !facingLeft;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
