using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private int maxHealth;
    private int currentHealth;
    public EnemyHealthBar healthBar;
    
    [SerializeField] private Animator animator;

    [SerializeField] private EnemyPatrol enemyPatrol;

    [SerializeField] private AIChase aiChase;
    
    
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        
        aiChase = GetComponent<AIChase>();
    }

    public void TakeDamage(int damage)
    {
        animator.SetTrigger("hurt");

        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        
        if (currentHealth <= 0)
        {
            Die();
            healthBar.TurnOff();
        }
    }

    private void Die()
    {
        animator.SetBool("isDead", true);

        if (aiChase != null)
        {
            aiChase.enabled = false;
        }
        else if (enemyPatrol != null)
        {
            enemyPatrol.Death();
        }

        this.GameObject().layer = LayerMask.NameToLayer("DeadEnemy");
    }

}
