using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateSwitching : MonoBehaviour
{
    private int state;

    private void Start()
    {
        state = GameManager.Instance.playerDefaultState;
    }

    private void Update()
    {
        if(Input.GetKeyDown("f"))
        {
            Switch();
        }
    }

    private void Switch()
    {
        switch(state)
        {
            case 0:
                state = 1;
                Debug.Log("Defend");
                GameManager.Instance.isAttacking = false;
                GameManager.Instance.isDefending = true;
                break;
            case 1:
                state = 0;
                Debug.Log("Attack");
                GameManager.Instance.isDefending = false;
                GameManager.Instance.isAttacking = true;
                break;
        }
    }
}
