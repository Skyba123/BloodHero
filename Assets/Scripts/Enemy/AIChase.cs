using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    public Transform player; 
    [SerializeField] private float moveSpeed ; 
    [SerializeField] private float attackRange ; 
    [SerializeField] private float stoppingDistance; 

    [Header("Jumping")] 
    
    [SerializeField] private float jumpForce;
    [SerializeField] private Transform leftJumpChecker;
    [SerializeField] private Transform rightJumpChecker;
    [SerializeField] private float groundCheckerRadius;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private float jumpRate = 2f;
    private float nextJumpTime = 0f;
    
    private Rigidbody2D body;
    
    private bool facingLeft = true;

    [Header("Animator")]
    [SerializeField] private Animator animator;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
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
        bool needToJumpLeft = Physics2D.OverlapCircle(leftJumpChecker.position, groundCheckerRadius, whatIsGround);
        bool needToJumpRight = Physics2D.OverlapCircle(rightJumpChecker.position, groundCheckerRadius, whatIsGround);

        if (Time.time >= nextJumpTime)
        {
            if (needToJumpLeft || needToJumpRight)
            {
                Jump();
                nextJumpTime = Time.time + 1f / jumpRate;
            }
        }
    }

    private void MoveTowardsPlayer()
    {
        
        Vector2 direction = player.position - transform.position;
        transform.Translate(direction.normalized * moveSpeed * Time.deltaTime);

       
        if (direction.x < 0 && !facingLeft || direction.x > 0 && facingLeft)
        {
            Flip();
        }
    }

    private void Flip()
    {
        facingLeft = !facingLeft;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    
    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpForce);
    }
}
