using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletheatseek : MonoBehaviour
{
    public float speed = 5f;
    public float rotatingSpeed = 200f;
    private Rigidbody rb;
    private Transform target;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Find the closest enemy at the start
        FindClosestEnemy();
    }

    void FixedUpdate()
    {
        if (target == null)
        {
            // Optionally destroy the bullet if there's no target
            Destroy(gameObject);
            return;
        }

        Vector3 direction = (target.position - transform.position).normalized;
        Vector3 rotateAmount = Vector3.Cross(transform.forward, direction);
        rb.angularVelocity = rotateAmount * rotatingSpeed;
        rb.velocity = transform.forward * speed;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            Destroy(gameObject);
        }
    }

    void FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float closestDistance = Mathf.Infinity;
        GameObject closestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distance = (enemy.transform.position - transform.position).sqrMagnitude;
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }

        if (closestEnemy != null)
        {
            target = closestEnemy.transform;
        }
    }
}