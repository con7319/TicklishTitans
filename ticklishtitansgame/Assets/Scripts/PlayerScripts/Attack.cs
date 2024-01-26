using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private void Update()
    {
        if(GameManager.Instance.isAttacking && Input.GetMouseButtonDown(0))
        {
            Tickle();
        }

        if(GameManager.Instance.isAttacking && Input.GetMouseButtonDown(1))
        {
            Joke();
        }
    }

    private void Tickle()
    {
        Debug.Log("Tickle");

        //Add animation code
        //Make this do something
    }

    private void Joke()
    {
        Debug.Log("Insert joke here");

        //Add animation code
        //Make this do something
    }
}
