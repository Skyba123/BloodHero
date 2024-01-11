using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    public Transform player;
    [Header("Moving")]
    [SerializeField] private float moveSpeed ;
    [Header("Attack")]
    [SerializeField] private float attackRange ; 
    [SerializeField] private float stoppingDistance; 
    [Header("Jumping")] 
    [SerializeField] private float jumpForce;
    [SerializeField] private Transform leftGroundChecker;
    [SerializeField] private Transform rightGroundChecker;
    [SerializeField] private float groundCheckerRadius;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private float jumpRate = 2f;
    private float nextJumpTime = 0f;
    [Header("Animator")]
    [SerializeField] private Animator animator;

    private Rigidbody2D rb;
    
    private bool facingLeft = true;
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
        
        bool wannaJumpLeft = Physics2D.OverlapCircle(leftGroundChecker.position, groundCheckerRadius, whatIsGround);
        bool wannaJumpRight = Physics2D.OverlapCircle(rightGroundChecker.position, groundCheckerRadius, whatIsGround);
        if (Time.time >= nextJumpTime)
        {
            if (wannaJumpLeft || wannaJumpRight)
            {
                Jump();
                nextJumpTime = Time.time + 1f / jumpRate;
            }
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
    
    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        animator.SetBool("jumping", true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("jumping", false);
        }
    }
}
