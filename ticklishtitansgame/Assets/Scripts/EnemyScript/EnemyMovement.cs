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
    private GameObject eTicklePoint = default;
    public GameObject jokeProjectile;
    public Transform firePoint;
    public ETickleArea tickleAreaScript;
    public TickleArea playerTickleAreaScript;
    public Defend defentScript;
    public bool isTickleBlocking = false;
    public bool canTickleBlock = true;
    public bool isJokeBlocking = false;
    public bool canJokeBlock = true;
    public bool canAttack = true;
    private bool tickling = false;
    private int tickleDamage = 10;
    private bool isMovementStopped = false;
    private float stopTimer = 2f;
    private float shootTimer = 2f;

    void Update()
    {
        distanceBetween = Vector3.Distance(transform.position, Player.transform.position);//finds distance between player and enemy
        if(!isMovementStopped)
        {
            shootTimer -= Time.deltaTime;

            RotateTowardsPlayer();
            if(shootTimer <= 0 && distanceBetween <= jokeAttackRange && distanceBetween > meleeAttackRange)
            {
                int random1 = Random.Range(0, 4);

                switch(random1)
                {
                    case 0:
                        Debug.Log("A");
                        JokeAttack();
                        break;
                    case 1:
                        Debug.Log("B");
                        JokeBlock();
                        break;
                }

                shootTimer = 2f;
            }
            else
            {
                //move towards player to get into joke range
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                
                if (canAttack && distanceBetween <= meleeAttackRange)
                {
                    StopMovement();//melee range stop moving

                    int random2 = Random.Range(0, 4);

                    Debug.Log(random2);

                    switch(random2)
                    {
                        case 0:
                            Debug.Log("A");
                            TickleAttack();
                            break;
                        case 1:
                            Debug.Log("B");
                            TickleBlock();
                            break;
                    }
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
                canAttack = true;
                isMovementStopped = false;
                speed = 3.0f;
                stopTimer = 3.0f;
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            int jokeDamage = 15;
            playerTickleAreaScript.HahaTime(jokeDamage);
            
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
        // Debug.Log("Yo mama so fat....");

        GameObject jokeProjectilePrefab = Instantiate(jokeProjectile, firePoint.position, firePoint.rotation);
        Destroy(jokeProjectilePrefab, 1f);
        animator.SetBool("isJoking", true);
        StartCoroutine(AnimCooldown());

    }
    public void TickleAttack()
    {
        canAttack = false;

        tickleDamage = 10;

        if(!defentScript.isCrossingArms)
        {
            tickleAreaScript.HahaTime(tickleDamage);
            animator.SetBool("isTickling", true);
            StartCoroutine(AnimCooldown());
        }

        // Add animation code
        // Make this do something

        tickling = true;
        Debug.Log("Tickle Tickle Tickle");
    }

    private void TickleBlock()
    {
        isTickleBlocking = true;
        animator.SetBool("isTBlocking", true);
        StartCoroutine(TickleBlockLasts());
        StartCoroutine(TickleBlockCooldown());
    }

    private IEnumerator TickleBlockLasts()
    {
        yield return new WaitForSeconds(2f);
        animator.SetBool("isTBlocking", false);
        isTickleBlocking = false;
    }

    private IEnumerator TickleBlockCooldown()
    {
        yield return new WaitForSeconds(5f);

        canTickleBlock = true;
    }

    private void JokeBlock()
    {
        isJokeBlocking = true;
        animator.SetBool("isJBlocking", true);
        StartCoroutine(JokeBlockLasts());
        StartCoroutine(JokeBlockCooldown());
    }

    private IEnumerator JokeBlockLasts()
    {
        yield return new WaitForSeconds(2f);
        animator.SetBool("isJBlocking", false);
        isJokeBlocking = false;
    }

    private IEnumerator JokeBlockCooldown()
    {
        yield return new WaitForSeconds(5f);

        canJokeBlock = true;
    }
    private IEnumerator AnimCooldown()
    {
        yield return new WaitForSeconds(2f);
        animator.SetBool("isJoking", false);
        animator.SetBool("isTickling", false);
    }
}
