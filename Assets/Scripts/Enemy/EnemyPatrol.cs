using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header ("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header ("Enemy")]
    [SerializeField] private Transform enemy;
    [SerializeField] private SpriteRenderer spriteRenderer;

    [Header("Movement parameters")]
    [SerializeField] private float speed = 4;


    private Vector3 initScale;
    private bool movingLeft;

    [Header("Animator")]
    [SerializeField]private Animator anim;

    [Header("Idle Behaviour")]
    [SerializeField]private float idleDuration;
    private float idleTimer;
    
    private void Awake()
    {
        initScale = enemy.localScale;
    }
    
    private void Update()
    {
        if (movingLeft)
        {
            if(enemy.position.x >= leftEdge.position.x)
            {
                MoveInDirection(-1);
            }
            else
            {
                DirectionChange();
            }
            
        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x)
            {
                MoveInDirection(1);
            }
            else
            {
                DirectionChange();
            }

        }
        
    }

    private void OnDisable()
    {
        anim.SetBool("moving", false);
    }

    private void DirectionChange()
    {
        anim.SetBool("moving", false);

        idleTimer += Time.deltaTime;

        if(idleTimer > idleDuration)
        movingLeft = !movingLeft;
    }
    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;
        anim.SetBool("moving", true);
        // Face direction
        //enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * initScale.x * _direction, 
        //    initScale.y, initScale.z);
       
            spriteRenderer.flipX = Mathf.Abs(initScale.x) * initScale.x * _direction > 0;
        
       
        //Move direction
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed,
            enemy.position.y, enemy.position.z);
    }

    public void Death()
    {
        speed = 0;
    }
    private void OnAnimatorMove()
    {
        
    }
}
