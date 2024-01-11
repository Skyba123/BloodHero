using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [Header("Horizontal Movement")]
    [SerializeField] private float speed;
    //[SerializeField] private float airSpeedModificator;

    [Header("Jumping")]
    [SerializeField] private float jumpForce;
    [SerializeField] private Transform groundChecker;
    [SerializeField] private float groundCheckerRadius;
    [SerializeField] private LayerMask whatIsGround;

    [Header("Sounds")] 
    [SerializeField] private AudioSource jumpSound;
    
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;
    
    public void Awake()
    {
        body = GetComponent<Rigidbody2D>();  
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
        
        //Flip player when moving left-right
        if (horizontalInput >  0.01)
            transform.localScale = new Vector3(4,4,1);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-4,4,1);

        bool isGrounded = Physics2D.OverlapCircle(groundChecker.position, groundCheckerRadius, whatIsGround);

        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            Jump();
        }
        
        //Set animator
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", grounded);
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpForce);
        anim.SetTrigger("jump");
        jumpSound.Play();
        grounded = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
            grounded = true;
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(groundChecker.position, groundCheckerRadius);
    }
}
