using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    [SerializeField] private int maxHealth;

    [SerializeField] private Animator animator;

    [SerializeField] private GameObject enemyPatrol;
    
    private int currentHealth;

    private Rigidbody2D rb2d;
    private void Start()
    {
        currentHealth = maxHealth;
        
        rb2d = GetComponent<Rigidbody2D>();
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
        rb2d.bodyType = RigidbodyType2D.Static;
        enemyPatrol.GetComponent<EnemyPatrol>().Death();
    }
    
    
    
}
