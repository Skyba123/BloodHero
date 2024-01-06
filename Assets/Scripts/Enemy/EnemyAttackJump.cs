using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackJump : MonoBehaviour
{
    [Header("For Petrolling")]
    [SerializeField] float moveSpeed;
    private float moveDirection = 1;
    private bool facingRight = true;
    [SerializeField] Transform groundCheckPoint;
    [SerializeField] Transform wallCheckPoint;
    [SerializeField] float circleRadius;
    [SerializeField] LayerMask groundLayer;
    private bool checkingGround;
    private bool checkingWall;

    [Header("Other")]
    private Rigidbody2D enemyRB;


    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {
        checkingGround = Physics2D.OverlapCircle(groundCheckPoint.position,circleRadius,groundLayer);
        checkingWall = Physics2D.OverlapCircle(wallCheckPoint.position, circleRadius, groundLayer);
        Petrolling();
    }

    void Petrolling()
    {
        if (!checkingGround || checkingWall)
        {
            if (facingRight)
            {
                Flip();
            }
            else if (!facingRight)
            {
                Flip();
            }
            
        }  
        enemyRB.velocity = new Vector2(moveSpeed * moveDirection,enemyRB.velocity.y);
    }

    void Flip()
    {
        moveDirection *= -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(groundCheckPoint.position, circleRadius);
        Gizmos.DrawWireSphere(wallCheckPoint.position, circleRadius);
    }
}
