using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Animator animator;
    public float speed = 3.0f;
    public Transform target;
    public GameObject Player;
    [SerializeField]private float distanceBetween;
    public float jokeAttackRange = 15f;
    public float meleeAttackRange = 1.5f;

    private bool isMovementStopped = false;
    private float stopTimer = 1.5f;

    void Update()
    {
        distanceBetween = Vector3.Distance(transform.position, Player.transform.position);//finds distance between player and enemy
        if(!isMovementStopped)
        {
            RotateTowardsPlayer();
            if(distanceBetween <= jokeAttackRange && distanceBetween > meleeAttackRange)
            {
                JokeAttack();
            }
            else
            {
                //move towards player to get into joke range
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                animator.SetBool("isWalking", true);
                
                if (distanceBetween <= meleeAttackRange)
                {
                    StopMovement();//melee range stop moving
                    TickleAttack();
                }
            }
            //move towards player while attacking with jokes
            transform.position = Vector3.MoveTowards(this.transform.position,Player.transform.position,speed * Time.deltaTime);
        }
        else
        {
            stopTimer -= Time.deltaTime;

            if(stopTimer <= 0)
            {
                isMovementStopped = false;
                speed = 3.0f;
                stopTimer = 3.0f;
            }
        }
    }

    void RotateTowardsPlayer()
    {
    //lots of math to rotate the enemy towards player
    var offset = 0f;//MAYBE INCORRECT WHEN THE ENEMY MODEL GOES IN
    Vector3 direction = target.transform.position - transform.position;
    direction.y = 0; //Eliminates any Y-axis movement of enemy

    // Rotate towards the player
    transform.rotation = Quaternion.LookRotation(direction.normalized, Vector3.up) * Quaternion.Euler(Vector3.up * offset);

    }
    public void StopMovement()
    {
        speed = 0f;// stops the enemy being able to move
        isMovementStopped = true;
    }
    public void JokeAttack()
    {
        Debug.Log("Yo mama so fat....");
    }
    public void TickleAttack()
    {
        Debug.Log("Tickle Tickle Tickle");
    }
}
