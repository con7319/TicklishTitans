using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private GameObject TickleArea = default;
    public TickleArea tickleAreaScript;


    private bool tickling = false;
    private int TickleDamage = 10;

    private float itsTickleTime = 0.25f;
    private float timer = 0f;

    void Start()
    {
        TickleArea = transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        if (tickleAreaScript.inCollider == true && GameManager.Instance.isAttacking && Input.GetMouseButtonDown(0))
        {

            Tickle();
        }

        if (tickling)
        {
            timer += Time.deltaTime;

            if (timer > itsTickleTime)
            {
                timer = 0;
                tickling = false;
                TickleArea.SetActive(tickling);
            }
        }
    }

    private void Tickle()
    {
        TickleDamage = 10; // Set TickleDamage here if you want to reset it every time Tickle is called
        Debug.Log("Tickle");
        tickleAreaScript.HahaTime(TickleDamage);

        // Add animation code
        // Make this do something

        TickleArea.SetActive(true);

        tickling = true;
    }

    private void Joke()
    {
        Debug.Log("Insert joke here");

        //Add animation code
        //Make this do something
    }
}