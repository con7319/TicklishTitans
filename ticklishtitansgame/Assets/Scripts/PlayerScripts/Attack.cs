using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour

{   
    ArrayList jokesListArray = new ArrayList();
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
        string filePath = @"Assets\csv\jokeslist.csv";
        
        try
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                        jokesListArray.Add(line); // Adding each line to the ArrayList
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
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
        Debug.Log("choosing joke");
        
        int randomInt = UnityEngine.Random.Range(0, jokesListArray.Count);

        if (randomInt >= 0 && randomInt < jokesListArray.Count)
            {
            var line = jokesListArray[randomInt]; 
            
            Debug.Log("joke chosen:");
            Debug.Log(line);
                
            }
        
        //Add animation code
        //Make this do something
    }
    private IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
}