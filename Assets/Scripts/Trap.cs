using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" )
        {
            collision.GetComponent<Health>().TakeDamage(damage);

        } else if (collision.tag == "Enemy"){
            collision.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
