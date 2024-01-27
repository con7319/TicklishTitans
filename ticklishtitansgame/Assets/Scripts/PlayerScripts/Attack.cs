using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private GameObject tickleArea = default;
    public TickleArea tickleAreaScript;
    private bool canAttack = true;
    private bool isAttacking = false;
    private float attackCooldown = 2.5f;


    private bool tickling = false;
    private int TickleDamage = 10;


    void Start()
    {
        tickleArea = transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        if (canAttack && Input.GetMouseButtonDown(0))
        {
            if (tickleAreaScript.inCollider && GameManager.Instance.isAttacking)
            {
                isAttacking = true;
                Tickle();
            }
        }

        if (tickling)
        {
            tickleArea.SetActive(tickling);
        }

        // Check if the attack input has been released
        if (isAttacking && !Input.GetMouseButton(0))
        {
            isAttacking = false;
        }
    }

    private void Tickle()
    {
        if (canAttack)
        {
            canAttack = false;
            TickleDamage = 10; // Set TickleDamage here if you want to reset it every time Tickle is called
            Debug.Log("Tickle");
            tickleAreaScript.HahaTime(TickleDamage);

            // Add animation code
            // Make this do something

            tickleArea.SetActive(true);

            tickling = true;

            StartCoroutine(AttackCooldown());
        }
    }

    private void Joke()
    {
        Debug.Log("Insert joke here");

        //Add animation code
        //Make this do something
    }
    private IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
}