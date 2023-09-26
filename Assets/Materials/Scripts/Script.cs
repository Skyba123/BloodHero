using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour
    
{
    public CharacterController2D controller;
    public float runSpeed = 5f; // скорость движения
    public float jumpForce = 10f; // сила прыжка

    public float horizontalMove = 0f;
    bool jump = false;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    public Animator animator;

    private void Awake()
    {
        
    }



    private void FixedUpdate()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump")) 
        {
            jump = true;
            animator.SetBool("Jumping", true);
        }
    }
     public void OnLanding()
    {
        animator.SetBool("Jumping", false);
    }

    private void Update()
    {

        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;


   
    }

    private void Start()
    {
        
        
    }
}
