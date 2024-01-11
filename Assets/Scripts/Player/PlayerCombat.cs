using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerCombat : MonoBehaviour
{

    [Header("Combat")]
    [SerializeField] private int attackDamage;
    [SerializeField] private float attackRadius;
    [SerializeField] private float attackRate = 2f;
    private float nextAttackTime = 0f;
    [SerializeField] Transform attackPoint;
    [SerializeField] LayerMask enemyLayers;
    private AudioSource audioSource;
    [SerializeField] private AudioClip attack_1;
    [SerializeField] private AudioClip attack_2;
    [SerializeField] private AudioClip attack_3;
    [SerializeField] private AudioClip attack_4;

    private AudioClip[] attackSound;
    
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();
        attackSound = new AudioClip[]
        {
            attack_1,
            attack_2,
            attack_3,
            attack_4
        };
    }
    
    private void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                PlayToAttack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }
    
    private void PlayToAttack()
    {
        animator.SetTrigger("attack");
        PlayAttackSound();
    }
    public void GiveDamage()
    {
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
    
    public void PlayAttackSound()
    {
        if (attackSound != null && attackSound.Length > 0)
        {
            int randomIndex = Random.Range(0, attackSound.Length);
            
            audioSource.clip = attackSound[randomIndex];
            audioSource.Play();
        }
    }
}
