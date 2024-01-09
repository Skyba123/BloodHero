using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    [SerializeField] private int maxHealth;

    [SerializeField] private Animator animator;
    
    [SerializeField] private GameObject enemyPatrol;

    [SerializeField] private AIChase aiChase;
    
    private int currentHealth;

    private Rigidbody2D rigidBody2D;
    
    private void Start()
    {
        currentHealth = maxHealth;

        aiChase = GetComponent<AIChase>();
        
        rigidBody2D = GetComponent<Rigidbody2D>();
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
        rigidBody2D.bodyType = RigidbodyType2D.Static;
        aiChase.enabled = false;
        
        if (enemyPatrol != null)
        {
            enemyPatrol.GetComponent<EnemyPatrol>().Death();
        }
    }
    
    
    
}
