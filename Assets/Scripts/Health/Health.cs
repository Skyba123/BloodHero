using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth;
    private Animator anim;
    private bool  dead;

    [SerializeField] AudioSource audioSource;
    [SerializeField] private AudioClip getHitSound;
    [SerializeField] private AudioClip deathSound;

    private BoxCollider2D boxCollider2D;

    public GameManager gameManager;

    [Header("Components")]
    [SerializeField]private Behaviour[] components;
    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();

        boxCollider2D = GetComponent<BoxCollider2D>();
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            //player hurt
            anim.SetTrigger("hurt");
            //iframes
            audioSource.clip = getHitSound;
            audioSource.Play();
        }
        else
        {
            //player dead
            if (!dead)
            {
                anim.SetTrigger("die");
                audioSource.Stop();
                audioSource.clip = deathSound;
                audioSource.Play();

                foreach (Behaviour component in components)
                {
                    component.enabled = false;
                }
                
                boxCollider2D.sharedMaterial = null;
                
                dead = true;

                gameManager.gameOver();
            }

        }
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }
     
    
}
