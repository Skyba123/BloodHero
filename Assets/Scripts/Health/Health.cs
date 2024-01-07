using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool  dead;
    
    private Rigidbody2D rigidBody2D;

    [Header("Components")]
    [SerializeField]private Behaviour[] components;
    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            //player hurt
            anim.SetTrigger("hurt");
            //iframes
        }
        else
        {
            //player dead
            if (!dead)
            {
                anim.SetTrigger("die");


                foreach (Behaviour component in components)
                {
                    component.enabled = false;
                }
                
                rigidBody2D.bodyType = RigidbodyType2D.Static;

                dead = true;
            }

        }
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }
        //private void Update()
        //{
        //if (Input.GetKeyDown(KeyCode.E))
        //    TakeDamage(1);
        //}
    
}
