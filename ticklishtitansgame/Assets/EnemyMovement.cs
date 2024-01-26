using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float speed = 3.0f;
    public Transform target;
    public GameObject Player;
    [SerializeField]private float distance;
    public float distanceBetween = 5f;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        RotateTowardsPlayer();
        distance = Vector3.Distance(transform.position, Player.transform.position);//finds distance between player and enemy
                //move towards player if it is close enough
                transform.position = Vector3.MoveTowards(this.transform.position,Player.transform.position,speed * Time.deltaTime);
                //moves towards the player 
        if (distance <= 1.3f)
        {
            StopMovement();
        }

    }

    void RotateTowardsPlayer()
    {
    //lots of math to rotate the enemy towards player
    var offset = 270f;
    Vector3 direction = target.transform.position - transform.position;
    direction.y = 0; // Assuming your game is played on a flat surface (e.g., the XZ plane)

    // Rotate towards the player
    transform.rotation = Quaternion.LookRotation(direction.normalized, Vector3.up) * Quaternion.Euler(Vector3.up * offset);

    }
    public void StopMovement()
    {
        speed = 0f;// stops the enemy being able to move
    }
}
