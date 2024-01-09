using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    public GameObject player;
    public float speed;
 

    private float distance;


    [Header("Animator")]
    [SerializeField] private Animator anim;

    void Start()
    {
        if (anim == null)
        {
            Debug.LogError("Animator not assigned!");
        }
    }

    
    void Update()
    {
            Chase();
    }

    void Chase()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();

        if (distance < 8)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

            float moveMagnitude = direction.magnitude;

            anim.SetBool("moving", moveMagnitude > 0);

            if (direction.x < 0)
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else if (direction.x > 0)
            {
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        }
        else
        {
            anim.SetBool("moving", false);
        }
    }

}
