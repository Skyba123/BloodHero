using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    [Header("Combat")]
    
    [SerializeField] private int attackDamage;
    
    [SerializeField] private float attackRadius;
    
    [SerializeField] Transform attackPoint;
    
    [SerializeField] LayerMask enemyLayers;
    
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) Attack();
    }
    
    public void Attack()
    {
        animator.SetTrigger("attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
}
