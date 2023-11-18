using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;
    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
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
                GetComponent<Hero>().enabled = false;
                dead = true;
                ShowDeathMenu();
            }
            anim.SetTrigger("daed");
            GetComponent<Hero>().enabled = false;


        }
    }
    public void ShowDeathMenu()
    {
        // Assuming you have a Canvas with a death menu panel
        // Make sure to set the "Menu_DeathAnimation" trigger in the Animator for the death menu panel
        // You can enable it by setting its gameObject.SetActive(true) or changing canvasGroup.alpha if you're using CanvasGroup for fading effects

        // Example assuming you have a reference to the Canvas:
        Canvas canvas = FindObjectOfType<Canvas>();
        if (canvas != null)
        {
            Animator deathMenuAnimator = canvas.GetComponentInChildren<Animator>();
            if (deathMenuAnimator != null)
            {
                deathMenuAnimator.SetTrigger("Menu_DeathAnimation");
            }
        }
    }

    public void AddHealth(float _value)
        {
            currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
                TakeDamage(1);
        }

    }


