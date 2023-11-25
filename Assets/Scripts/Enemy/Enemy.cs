using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    [SerializeField] private int maxHealth;

    [SerializeField] private Animator animator;
    
    public int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }
    
    public void TakeDamage(int damage)
    {
        animator.SetTrigger("hurt");
        
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        animator.SetBool("isDead", true);

        GetComponent<Collider2D>().enabled = false;

        this.enabled = false;
    }
    
}
